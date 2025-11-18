using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using APP_DOAN.GiaoDienChinh;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN
{
    public partial class MainForm : Form
    {
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
            lblWelcome.Text = $"Chào mừng,\n{_currentUserName} (Sinh viên)";
            SetupJoinedListViewColumns();
            await LoadClassDataFromFirebase();
        }


        private void SetupJoinedListViewColumns()
        {
            lvJoinedCourses.Columns.Clear();
            lvJoinedCourses.Columns.Add("Tên môn", 380);
            lvJoinedCourses.Columns.Add("Giảng viên", 200);
        }

        // Tải dữ liệu lớp học từ Firebase
        private async Task LoadClassDataFromFirebase()
        {
            try
            {
                var firebaseCourses = await _firebaseClient
                    .Child("Courses")
                    .OnceAsync<Course>();

                _allCourses.Clear();

                foreach (var c in firebaseCourses)
                {
                    bool isJoined = false;

                    // 🔍 Kiểm tra user có tham gia lớp hay chưa
                    if (c.Object != null && c.Object.Students != null)
                    {
                        if (c.Object.Students.Contains(_currentUserUid))
                            isJoined = true;
                    }

                    _allCourses.Add(new Course(
                        c.Key,
                        c.Object.Name,
                        c.Object.Instructor,
                        isJoined
                    ));
                }

                PopulateJoinedCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ Firebase!\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void PopulateJoinedCourses()
        {
            lvJoinedCourses.Items.Clear();

            var joined = _allCourses.Where(c => c.IsJoined).ToList();

            if (joined.Count == 0)
            {
                var item = new ListViewItem(" ");
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




        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Information profileForm = new Student_Information(this._loggedInEmail, "Student");
            profileForm.ShowDialog();
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
            if (lvJoinedCourses.SelectedItems[0].Text == " ") return;
            var id = lvJoinedCourses.SelectedItems[0].Tag.ToString();
            var course = _allCourses.FirstOrDefault(c => c.Id == id);
            if (course == null) return;
            ChiTietLopHoc form = new ChiTietLopHoc(course);
            form.ShowDialog();
        }

        private void cmsUserOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void grpJoinedCourses_Click(object sender, EventArgs e) { }
        private void panelLeft_Paint(object sender, PaintEventArgs e) { }


        private void đăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKyMonHoc frm = new DangKyMonHoc(_currentUserUid, _idToken);
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
    }

    public class Course
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public bool IsJoined { get; set; }
        public List<string> Students { get; set; } = new List<string>();

        public Course() { }

        public Course(string id, string name, string instructor, bool joined)
        {
            Id = id;
            Name = name;
            Instructor = instructor;
            IsJoined = joined;
        }
    }
}