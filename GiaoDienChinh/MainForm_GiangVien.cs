using APP_DOAN.GiaoDienChinh;
using APP_DOAN.Services;
using Firebase.Database;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class MainForm_GiangVien : Form
    {
        // Biến lưu thông tin User
        private string loggedInEmail;
        private string idToken;
        private string currentUid;
        private string currentDisplayName;

        private FirebaseClient _client;
        private List<Course> _allMyCourses = new List<Course>();

        public MainForm_GiangVien(string uid, string displayName, string token, string email)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.idToken = token;
            this.currentUid = uid;
            this.currentDisplayName = displayName;
            this.loggedInEmail = email;

            // --- KẾT NỐI FIREBASE ---
            try
            {
                _client = FirebaseService.Instance._client;
            }
            catch
            {
                _client = new FirebaseClient(
                    "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );
            }
        }

        private void MainForm_GiangVien_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {currentDisplayName}!";

            // Đăng ký sự kiện tìm kiếm cho TextBox (txtSearch) trong Designer
            txtSearch.TextChanged += (s, ev) => PerformSearch(txtSearch.Text);

            LoadMyCoursesData();
        }

        // --- CÁC SỰ KIỆN NÚT BẤM (Đã kết nối với Designer) ---

        // 1. Mở Hồ sơ (Nút btnProfile)
        private void OpenProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher_Information profileForm = new Teacher_Information(currentUid, idToken, loggedInEmail);
            profileForm.ShowDialog();
            this.Show();
        }

        // 2. Đăng xuất (Nút btnLogout)
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // 3. Tạo lớp (Nút btnCreate)
        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            // Cập nhật Token mới nhất cho API trước khi mở form
            FirebaseApi.CurrentUid = this.currentUid;
            FirebaseApi.IdToken = this.idToken;

            CreateCourse createCourse = new CreateCourse();
            // Khi tạo xong thì tải lại danh sách
            createCourse.OnCourseCreated += (ma, ten, si) => { LoadMyCoursesData(); };
            createCourse.ShowDialog();
        }

        // 4. Mở Chat (Nút btnChat - Gradient)
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form chat đã mở chưa
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmMainChat)
                {
                    f.BringToFront();
                    return;
                }
            }

            // Mở form chat mới
            frmMainChat chat = new frmMainChat(currentUid, currentDisplayName, idToken);
            chat.Show();
        }

        // --- XỬ LÝ DỮ LIỆU & VẼ THẺ (LOGIC GIỮ NGUYÊN) ---

        private async void LoadMyCoursesData()
        {
            // Hiệu ứng loading
            flpMyCourses.Controls.Clear();
            Guna2Button btnLoad = new Guna2Button
            {
                Text = "Đang tải dữ liệu...",
                FillColor = Color.Transparent,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 12),
                DisabledState = { FillColor = Color.Transparent },
                AutoSize = true
            };
            flpMyCourses.Controls.Add(btnLoad);

            try
            {
                var data = await FirebaseApi.Get<Dictionary<string, Course>>("Courses");

                // Xóa loading để chuẩn bị hiển thị data
                flpMyCourses.Controls.Clear();
                _allMyCourses.Clear();

                if (data != null)
                {
                    foreach (var entry in data)
                    {
                        var course = entry.Value;
                        // Chỉ lấy lớp của giảng viên hiện tại
                        if (course != null && course.GiangVienUid == currentUid)
                        {
                            if (string.IsNullOrEmpty(course.Id)) course.Id = entry.Key;
                            if (string.IsNullOrEmpty(course.MaLop)) course.MaLop = entry.Key;
                            _allMyCourses.Add(course);
                        }
                    }
                }
                RenderList(_allMyCourses);
            }
            catch (Exception ex)
            {
                flpMyCourses.Controls.Clear();
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void RenderList(List<Course> courses)
        {
            flpMyCourses.Controls.Clear();
            if (courses.Count == 0)
            {
                Label lbl = new Label { Text = "Chưa có lớp học nào.", AutoSize = true, ForeColor = Color.Gray, Margin = new Padding(20) };
                flpMyCourses.Controls.Add(lbl);
                return;
            }
            foreach (var course in courses) RenderGunaCard(course);
        }

        private void RenderGunaCard(Course c)
        {
            Guna2Panel pnl = new Guna2Panel();
            pnl.Size = new Size(flpMyCourses.Width - 50, 110);
            pnl.BorderRadius = 15;
            pnl.FillColor = Color.White;
            pnl.Margin = new Padding(0, 0, 0, 15);
            pnl.Cursor = Cursors.Hand;

            // Bóng đổ
            pnl.ShadowDecoration.Enabled = true;
            pnl.ShadowDecoration.BorderRadius = 15;
            pnl.ShadowDecoration.Depth = 5;
            pnl.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);

            // Sự kiện Click vào thẻ -> Mở chi tiết
            pnl.Click += (s, e) => OpenDetail(c);

            // 1. Tên lớp
            Label lblName = new Label();
            lblName.Text = c.TenLop;
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(40, 40, 40);
            lblName.Location = new Point(20, 15);
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Click += (s, e) => OpenDetail(c); // Click label cũng mở
            pnl.Controls.Add(lblName);

            // 2. Thông tin phụ
            Label lblInfo = new Label();
            lblInfo.Text = $"Mã lớp: {c.MaLop}    •    Sĩ số: {c.SiSoHienTai}/{c.SiSo}";
            lblInfo.Font = new Font("Segoe UI", 10);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(23, 50);
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Click += (s, e) => OpenDetail(c);
            pnl.Controls.Add(lblInfo);

            // 3. Nút Sửa
            Guna2Button btnEdit = new Guna2Button();
            btnEdit.Text = "Sửa";
            btnEdit.BorderRadius = 8;
            btnEdit.FillColor = Color.FromArgb(255, 248, 230); // Vàng nhạt
            btnEdit.ForeColor = Color.Orange;
            btnEdit.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnEdit.Size = new Size(70, 30);
            btnEdit.Location = new Point(pnl.Width - 170, 40);
            btnEdit.Click += (s, e) => EditCourseAction(c);
            pnl.Controls.Add(btnEdit);

            // 4. Nút Xóa
            Guna2Button btnDelete = new Guna2Button();
            btnDelete.Text = "Xóa";
            btnDelete.BorderRadius = 8;
            btnDelete.FillColor = Color.FromArgb(255, 235, 235); // Đỏ nhạt
            btnDelete.ForeColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnDelete.Size = new Size(70, 30);
            btnDelete.Location = new Point(pnl.Width - 90, 40);
            btnDelete.Click += (s, e) => DeleteCourseAction(c);
            pnl.Controls.Add(btnDelete);

            flpMyCourses.Controls.Add(pnl);
        }

        private void OpenDetail(Course c)
        {
            // Mở form chi tiết quản lý khóa học
            FormQuanLyKhoaHoc detailForm = new FormQuanLyKhoaHoc(c.Id, c.TenLop, idToken);
            detailForm.ShowDialog();
            LoadMyCoursesData();
        }

        private void EditCourseAction(Course c)
        {
            FixCourse editForm = new FixCourse(c.MaLop, c.TenLop, c.SiSo);
            editForm.OnCourseUpdated = async (maMoi, tenMoi, siSoMoi) =>
            {
                c.MaLop = maMoi;
                c.TenLop = tenMoi;
                c.SiSo = siSoMoi;
                // Cập nhật lên Firebase
                await FirebaseApi.Patch($"Courses/{c.Id}", c);
                LoadMyCoursesData();
            };
            editForm.ShowDialog();
        }

        private async void DeleteCourseAction(Course c)
        {
            if (MessageBox.Show($"Xóa lớp '{c.TenLop}'? Dữ liệu sẽ mất vĩnh viễn.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Xóa tất cả dữ liệu liên quan
                    await FirebaseApi.Delete($"Courses/{c.Id}");
                    await FirebaseApi.Delete($"CourseStudents/{c.Id}");
                    await FirebaseApi.Delete($"Assignments/{c.Id}");
                    await FirebaseApi.Delete($"JoinRequests/{c.Id}");

                    MessageBox.Show("Đã xóa lớp học thành công!");
                    LoadMyCoursesData();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private void PerformSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                RenderList(_allMyCourses);
                return;
            }
            var filtered = _allMyCourses.FindAll(c =>
                (c.TenLop != null && c.TenLop.ToLower().Contains(keyword.ToLower())) ||
                (c.MaLop != null && c.MaLop.ToLower().Contains(keyword.ToLower())));
            RenderList(filtered);
        }

        private void flpMyCourses_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}