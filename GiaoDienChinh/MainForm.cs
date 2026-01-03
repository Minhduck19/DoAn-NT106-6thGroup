using APP_DOAN.GiaoDienChinh;
using APP_DOAN.Môn_học;
using APP_DOAN.Services; // Namespace chứa FirebaseService
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class MainForm : Form
    {
        private IDisposable _courseListener;
        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _loggedInEmail;
        private readonly string _idToken;
        private FirebaseClient _firebaseClient;

        private bool isLoggingOut = false;
        private List<Course> _allCourses = new();

        public MainForm(string uid, string hoTen, string email, string token)
        {
            InitializeComponent();

            _currentUserUid = uid;
            _currentUserName = hoTen;
            _loggedInEmail = email;
            _idToken = token;

            // Dùng Singleton FirebaseService nếu đã có, hoặc tạo mới nếu chưa
            // Ưu tiên dùng Singleton để đồng bộ
            try
            {
                _firebaseClient = FirebaseService.Instance._client;
            }
            catch
            {
                // Fallback nếu chưa initialize (ít khi xảy ra nếu login đúng)
                _firebaseClient = new FirebaseClient(
                    "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Đảm bảo Service đã chạy
            try { FirebaseService.Initialize(_idToken); } catch { }

            lblWelcome.Text = $"Chào mừng,\n{_currentUserName} (Sinh viên)";

            await LoadClassDataFromFirebase();
            ListenCourseChanges();
        }

        // --- XỬ LÝ FIREBASE ---
        private async Task LoadClassDataFromFirebase()
        {
            try
            {
                // 1. Hiển thị trạng thái "Đang tải..." để người dùng không thấy trống trơn
                if (_allCourses.Count == 0) // Chỉ hiện khi chưa có dữ liệu
                {
                    flpCourses.Controls.Clear();
                    Label lblLoading = new Label()
                    {
                        Text = "Đang tải dữ liệu...",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Location = new Point(20, 20)
                    };
                    flpCourses.Controls.Add(lblLoading);
                }

                // 2. Tạo các Task để lấy dữ liệu song song (Chạy cùng lúc)
                var taskAllCourses = _firebaseClient
                    .Child("Courses")
                    .OnceAsync<Course>();

                var taskStudentMap = _firebaseClient
                    .Child("CourseStudents")
                    .OnceAsync<Dictionary<string, StudentInfo>>(); // Lưu ý: Dùng StudentInfo như đã sửa

                // 3. Chờ cả 2 nhiệm vụ hoàn thành cùng lúc (Tốc độ nhanh gấp đôi)
                await Task.WhenAll(taskAllCourses, taskStudentMap);

                // 4. Lấy kết quả từ các Task đã hoàn thành
                var firebaseCourses = taskAllCourses.Result;
                var courseStudentsSnapshot = taskStudentMap.Result;

                // 5. Xử lý logic ghép nối dữ liệu (Phần này giữ nguyên logic của bạn)
                var joinedCourseIds = new HashSet<string>();

                if (courseStudentsSnapshot != null)
                {
                    joinedCourseIds = new HashSet<string>(
                        courseStudentsSnapshot
                            .Where(cs => cs.Object != null &&
                                         cs.Object.ContainsKey(_currentUserUid))
                            .Select(cs => cs.Key)
                    );
                }

                _allCourses.Clear();

                foreach (var c in firebaseCourses)
                {
                    if (c.Object == null) continue;

                    bool isJoined = joinedCourseIds.Contains(c.Key);

                    _allCourses.Add(new Course(
                        c.Key,
                        c.Object.TenLop ?? "Chưa đặt tên",
                        c.Object.Instructor ?? "N/A",
                        isJoined
                    ));
                }

                // 6. Vẽ lại giao diện ngay lập tức
                PopulateAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải lớp:\n" + ex.Message,
                    "Firebase Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ListenCourseChanges()
        {
            _courseListener = _firebaseClient
                .Child("CourseStudents")
                .AsObservable<object>()
                .Subscribe(_ =>
                {
                    if (!IsHandleCreated) return;
                    BeginInvoke(new Action(async () =>
                    {
                        await LoadClassDataFromFirebase();
                    }));
                });
        }

        // --- HÀM QUAN TRỌNG: VẼ GIAO DIỆN CARD (THAY THẾ LISTVIEW) ---
        private void PopulateAllCourses(List<Course> listToDisplay = null)
        {
            // Nếu không truyền list cụ thể thì lấy tất cả các lớp đã join
            var sourceList = listToDisplay ?? _allCourses;

            // Lọc ra các lớp đã tham gia (IsJoined = true)
            var joinedCourses = sourceList.Where(c => c.IsJoined).ToList();

            // Xóa sạch các card cũ
            flpCourses.Controls.Clear();

            if (joinedCourses.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Chưa tham gia khóa học nào.";
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.ForeColor = Color.DimGray;
                lblEmpty.AutoSize = true;
                lblEmpty.Margin = new Padding(20);
                flpCourses.Controls.Add(lblEmpty);
                return;
            }

            // Vòng lặp tạo từng thẻ
            foreach (var c in joinedCourses)
            {
                // 1. Tạo Panel chính (Cái thẻ)
                Panel pnlCard = new Panel();
                pnlCard.Size = new Size(flpCourses.Width - 40, 110); // Trừ hao thanh cuộn
                pnlCard.BackColor = Color.White; // Màu nền trắng
                pnlCard.Margin = new Padding(10, 5, 10, 15); // Khoảng cách giữa các thẻ
                pnlCard.Cursor = Cursors.Hand;
                pnlCard.Tag = c.Id; // Lưu ID để click

                // Sự kiện click vào panel
                pnlCard.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);

                // 2. Tạo Tên môn học (Màu xanh dương)
                Label lblName = new Label();
                lblName.Text = c.TenLop ?? "Chưa đặt tên";
                lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(51, 153, 255); // Xanh dương sáng
                lblName.Location = new Point(20, 15);
                lblName.AutoSize = true;
                lblName.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop); // Click chữ cũng mở
                pnlCard.Controls.Add(lblName);

                // 3. Tạo Tên giảng viên (Màu xám nhạt)
                Label lblGV = new Label();
                lblGV.Text = $"GV: {c.Instructor ?? "N/A"}";
                lblGV.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                lblGV.ForeColor = Color.LightGray;
                lblGV.Location = new Point(20, 50);
                lblGV.AutoSize = true;
                lblGV.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);
                pnlCard.Controls.Add(lblGV);

                // 4. Trạng thái (Góc phải)
                Label lblStatus = new Label();
                lblStatus.Text = "✅ Đã tham gia";
                lblStatus.ForeColor = Color.LightGreen;
                lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                lblStatus.AutoSize = true;
                lblStatus.Location = new Point(pnlCard.Width - 120, 15);
                lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                pnlCard.Controls.Add(lblStatus);

                // Thêm thẻ vào FlowLayoutPanel
                flpCourses.Controls.Add(pnlCard);
            }
        }

        // Hàm mở Form chi tiết khi click vào thẻ
        private void OpenCourseDetail(string courseId, string courseName)
        {
            CourseDetailForm frm = new CourseDetailForm(courseId, courseName, _currentUserUid, _firebaseClient);
            frm.ShowDialog();

        }

        // --- TÌM KIẾM ---
        private void Find_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtNameClass_TextChanged(object sender, EventArgs e)
        {
            // Có thể tìm kiếm ngay khi gõ (Realtime search)
            // PerformSearch(); 
        }

        private void PerformSearch()
        {
            string keyword = txtNameClass.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                PopulateAllCourses(); // Hiện lại tất cả
                return;
            }

            // Lọc danh sách trong bộ nhớ (không gọi lại Firebase cho nhanh)
            var filteredList = _allCourses
                .Where(c => (c.TenLop != null && c.TenLop.ToLower().Contains(keyword)))
                .ToList();

            PopulateAllCourses(filteredList);
        }


        // --- CÁC CHỨC NĂNG MENU KHÁC (GIỮ NGUYÊN) ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.isLoggingOut = true;
                this.Close();
                // Nhớ mở lại Form Login ở Program.cs hoặc gọi ở đây
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _courseListener?.Dispose();

            if (!isLoggingOut)
            {
                var result = MessageBox.Show("Thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        // Các event click menu
        private void lblWelcome_Click(object sender, EventArgs e) => cmsUserOptions.Show(lblWelcome, new Point(0, lblWelcome.Height));
        private void cmsUserOptions_Opening_1(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Information frm = new Student_Information(_currentUserUid, _idToken, _loggedInEmail);
            frm.ShowDialog();
            this.Show();
        }
        private void scheduleToolStripMenuItem_Click_1(object sender, EventArgs e) => MessageBox.Show("Chức năng Lịch học đang phát triển.");
        private void gradesToolStripMenuItem_Click_1(object sender, EventArgs e) => MessageBox.Show("Chức năng Điểm đang phát triển.");

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword frm = new ChangePassword(_loggedInEmail, _idToken);
            frm.ShowDialog();
            this.Show();
        }

        private void đăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonHocDaDangKy frm = new MonHocDaDangKy(_currentUserUid, _idToken);
            frm.ShowDialog();
            this.Show();
            _ = LoadClassDataFromFirebase(); // Load lại data khi quay về
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMainChat chat = new frmMainChat(_currentUserUid, _currentUserName, _idToken);
            chat.Show();
        }

        private void grpJoinedCourses_Click_1(object sender, EventArgs e) { }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) { }

        private void flpCourses_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class StudentInfo
    {
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string MSSV { get; set; }
    }
}