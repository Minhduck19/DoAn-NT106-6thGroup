using APP_DOAN.GiaoDienChinh;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

            //Tạo FireBase client với token xác thực
            _firebaseClient = new FirebaseClient(
                "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(token)
                }
            );
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            FirebaseService.Initialize(_idToken);
            lblWelcome.Text = $"Chào mừng,\n{_currentUserName} (Sinh viên)";
            SetupJoinedListViewColumns();

            await LoadClassDataFromFirebase();
            ListenCourseChanges(); // 🔥 BẮT BUỘC
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



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _courseListener?.Dispose();
            base.OnFormClosing(e);
        }


        private void LoadMockClassData()
        {
            _allCourses.Clear(); // Đảm bảo danh sách trống trước khi thêm

            // Dữ liệu lớp học cố định (MOCK DATA)
            var testCourses = new List<Course>
    {
        // Lớp 1: Đã tham gia (IsJoined = true)
        new Course("MOCK001", "Lập Trình Web Nâng Cao (TEST)", "TS. Nguyễn Văn Test", true)
        {
            // Quan trọng: Thêm UID hiện tại vào danh sách Students để giả lập đã tham gia
            Students = new List<string> { _currentUserUid }
        },
        // Lớp 2: Đã tham gia (IsJoined = true)
        new Course("MOCK002", "Phân Tích Thiết Kế Hệ Thống", "GS. Lê Thị Giả Lập", true)
        {
            Students = new List<string> { _currentUserUid }
        },
        // Lớp 3: CHƯA tham gia (IsJoined = false)
        new Course("MOCK003", "Kinh Tế Vi Mô", "ThS. Phạm Mock Data", false)
    };

            _allCourses.AddRange(testCourses);

            // Điền dữ liệu các lớp ĐÃ tham gia vào ListView
            Test();
        }

        private void Test()
        {
            if (lvJoinedCourses == null) return;

            lvJoinedCourses.Items.Clear();

            // Lọc ra các lớp có IsJoined = true
            var joined = _allCourses.Where(c => c.IsJoined).ToList();

            if (joined.Count == 0)
            {
                var item = new ListViewItem("Không có lớp nào."); // Thay đổi nội dung hiển thị
                item.SubItems.Add("-");
                lvJoinedCourses.Items.Add(item);
                return;
            }

            foreach (var c in joined)
            {
                var item = new ListViewItem(c.Name);
                item.SubItems.Add(c.Instructor);
                item.Tag = c.Id;
                lvJoinedCourses.Items.Add(item);
            }
        }

        private void SetupJoinedListViewColumns()
        {
            lvJoinedCourses.Columns.Clear();
            lvJoinedCourses.Columns.Add("Tên môn học", 400);
            lvJoinedCourses.Columns.Add("Giảng viên", 300);
            lvJoinedCourses.Columns.Add("Trạng thái", 250);
        }

        // Tải dữ liệu lớp học từ Firebase
        private async Task LoadClassDataFromFirebase()
        {
            try
            {
                var firebaseCourses = await _firebaseClient
                    .Child("Courses")
                    .OnceAsync<Course>();

                var courseStudents = await _firebaseClient
                    .Child("CourseStudents")
                    .OnceAsync<Dictionary<string, bool>>();

                _allCourses.Clear();

                foreach (var c in firebaseCourses)
                {
                    bool isJoined = courseStudents.Any(cs =>
                        cs.Key == c.Key && cs.Object.ContainsKey(_currentUserUid));

                    _allCourses.Add(new Course(
                        c.Key,
                        c.Object.TenLop,
                        c.Object.Instructor,
                        isJoined
                    ));
                }

                PopulateAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lớp: " + ex.Message);
            }
        }


        private void PopulateAllCourses()
        {
            if (lvJoinedCourses == null) return;
            lvJoinedCourses.Items.Clear();

            var joinedCourses = _allCourses.Where(c => c.IsJoined).ToList();

            if (joinedCourses.Count == 0)
            {
                var empty = new ListViewItem("Chưa đăng ký môn nào");
                empty.SubItems.Add("-");
                empty.SubItems.Add("-");
                lvJoinedCourses.Items.Add(empty);
                return;
            }

            foreach (var c in joinedCourses)
            {
                var item = new ListViewItem(c.TenLop ?? "Không có tên");
                item.SubItems.Add(c.Instructor ?? "Chưa rõ");
                item.SubItems.Add("✅ Đã đăng ký");
                item.ForeColor = Color.Green;
                item.Tag = c.Id;

                lvJoinedCourses.Items.Add(item);
            }
        }



        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Information frmInfo = new Student_Information(_currentUserUid, _idToken, _loggedInEmail);
            frmInfo.ShowDialog();
            this.Show();
        }

        private void scheduleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Lịch học (chức năng mẫu).", "Lịch học", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gradesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Điểm (chức năng mẫu).", "Điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassForm = new ChangePassword(this._loggedInEmail, this._idToken);
            this.Hide();
            changePassForm.ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.isLoggingOut = true;
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                var result = MessageBox.Show("Bạn có muốn thoát hoàn toàn ứng dụng?", "Xác nhận Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }



        private void lvJoinedCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvJoinedCourses.SelectedItems.Count == 0) return;

            var item = lvJoinedCourses.SelectedItems[0];
            if (item.Tag == null) return;

            string courseId = item.Tag.ToString();
            string tenLop = item.Text;

            Assignment frmAssignment = new Assignment(courseId);
            frmAssignment.Show();

            Submit_Agsignment frmSubmit = new Submit_Agsignment(
                tenLop,
                _firebaseClient,
                courseId,
                _currentUserUid
            );

            frmSubmit.OnSubmitSuccess += frmAssignment.Frm_OnSubmitSuccess;
            frmSubmit.ShowDialog();
        }


        private void cmsUserOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void grpJoinedCourses_Click(object sender, EventArgs e) { }
        private void panelLeft_Paint(object sender, PaintEventArgs e) { }


        private void đăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonHocDaDangKy frm = new MonHocDaDangKy(_currentUserUid, _idToken);
            frm.ShowDialog();
            this.Show();
            _ = LoadClassDataFromFirebase();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            cmsUserOptions.Show(lblWelcome, new Point(0, lblWelcome.Height));
        }

        private void cmsUserOptions_Opening_1(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void grpJoinedCourses_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            frmMainChat chatLobby = new frmMainChat(
         _currentUserUid,
         _currentUserName,
         this._idToken
        );

            chatLobby.Show();
        }

        private void lvJoinedCourses_ItemActivate(object sender, MouseEventArgs e)
        {
            if (lvJoinedCourses.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = lvJoinedCourses.SelectedItems[0];

            string courseId = selectedItem.Tag.ToString();   // ✅ ID LỚP
            string tenLop = selectedItem.Text;               // tên lớp

            Submit_Agsignment submitForm = new Submit_Agsignment(
                tenLop,
                _firebaseClient,      // ✅ FirebaseClient có token
                courseId,             // ✅ courseId THẬT
                _currentUserUid       // ✅ UID sinh viên
            );

            submitForm.ShowDialog();
        }


        private void Find_Click(object sender, EventArgs e)
        {
            string searchText = txtNameClass.Text.ToLower().Trim();
            lvJoinedCourses.Items.Clear();

            var filtered = _allCourses
                .Where(c => c.Name?.ToLower().Contains(searchText) == true)
                .ToList();

            foreach (var c in filtered)
            {
                var item = new ListViewItem(c.Name);
                item.SubItems.Add(c.Instructor);
                item.SubItems.Add(c.IsJoined ? "✅ Đã tham gia" : "❌ Chưa tham gia");
                item.Tag = c.Id;
                lvJoinedCourses.Items.Add(item);
            }
        }

        private void txtNameClass_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Course
    {
        public string Id { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; } // Đổi từ Name thành TenLop cho khớp Firebase
        public string Instructor { get; set; }
        public bool IsJoined { get; set; }
        public List<string> Students { get; set; } = new List<string>();

        // Thuộc tính phụ để không phải sửa code ở các hàm khác đang gọi .Name
        public string Name => TenLop;

        public int SiSo { get; internal set; }

        public Course() { } // Cần thiết để Firebase đổ dữ liệu vào

        public Course(string id, string tenLop, string instructor, bool joined)
        {
            Id = id;
            TenLop = tenLop;
            Instructor = instructor;
            IsJoined = joined;
        }
    }
}

