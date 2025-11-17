using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using APP_DOAN.GiaoDienChinh;

namespace APP_DOAN
{
    public partial class MainForm : Form
    {
        private readonly string _currentUserUid; 
        private readonly string _currentUserName; 
        private readonly string _loggedInEmail; 
        private readonly string _idToken;       

        private bool isLoggingOut = false;
        private List<Course> _allCourses = new();
        public MainForm(string uid, string hoTen, string email, string token)
        {
            InitializeComponent();

            _currentUserUid = uid;
            _currentUserName = hoTen;
            _loggedInEmail = email;
            _idToken = token;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào mừng,\n{_currentUserName} (Sinh viên)";


            try
            {
                if (dgvAvailableCourses.Columns.Contains("colJoin"))
                {
                    dgvAvailableCourses.Columns["colJoin"].Visible = true;
                }
            }
            catch { /* ignore */ }

            SetupJoinedListViewColumns();
            LoadClassData();
        }


        private void SetupJoinedListViewColumns()
        {
            lvJoinedCourses.Columns.Clear();
            lvJoinedCourses.Columns.Add("Tên môn", 380);
            lvJoinedCourses.Columns.Add("Giảng viên", 200);
        }

        private void LoadClassData()
        {
            _allCourses = new List<Course>
            {
                new Course("CS101", "Nhập môn Lập trình", "Nguyễn Văn A", true),
                new Course("DB202", "Cơ sở dữ liệu", "Trần Thị B", true),
            };
            PopulateJoinedCourses();
            PopulateAvailableCourses();
        }

        private void PopulateJoinedCourses()
        {
            lvJoinedCourses.Items.Clear();
            var joined = _allCourses.Where(c => c.IsJoined);
            foreach (var c in joined)
            {
                var item = new ListViewItem(c.Name);
                item.SubItems.Add(c.Instructor);
                item.Tag = c.Id;
                lvJoinedCourses.Items.Add(item);
            }
        }

        private void PopulateAvailableCourses()
        {
            dgvAvailableCourses.Rows.Clear();
            var available = _allCourses.Where(c => !c.IsJoined).ToList();
            foreach (var c in available)
            {
                dgvAvailableCourses.Rows.Add(c.Id, c.Name, c.Instructor);
            }
        }

        private void dgvAvailableCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            var column = grid.Columns[e.ColumnIndex];
            if (column.Name == "colJoin")
            {
                var idObj = grid.Rows[e.RowIndex].Cells["colCourseId"].Value;
                if (idObj == null) return;
                string courseId = idObj.ToString();
                JoinCourse(courseId);
            }
        }

        private void JoinCourse(string courseId)
        {

            var course = _allCourses.FirstOrDefault(c => c.Id == courseId);
            if (course == null) return;

            var confirm = MessageBox.Show($"Bạn có muốn tham gia \"{course.Name}\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            course.IsJoined = true;
            PopulateJoinedCourses();
            PopulateAvailableCourses();
            MessageBox.Show($"Bạn đã tham gia khóa học: {course.Name}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblWelcome_Click_1(object sender, EventArgs e)
        {
            cmsUserOptions.Show(lblWelcome, new Point(0, lblWelcome.Height));
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
                        Student_Information profileForm = new Student_Information(this._loggedInEmail, "Student");
            profileForm.ShowDialog();
            this.Show();
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainChat chatLobby = new frmMainChat(
        _currentUserUid,
        _currentUserName,
        this._idToken // (Lấy 'idToken' mà LoginForm đã truyền cho bạn)
    );
            chatLobby.Show();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lịch học (chức năng mẫu).", "Lịch học", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
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
            var id = lvJoinedCourses.SelectedItems[0].Tag.ToString();
            var course = _allCourses.FirstOrDefault(c => c.Id == id);
            if (course == null) return;
            ChiTietLopHoc form = new ChiTietLopHoc(course);
            form.ShowDialog();
        }

        private void cmsUserOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void grpJoinedCourses_Click(object sender, EventArgs e) { }
        private void panelLeft_Paint(object sender, PaintEventArgs e) { }
    }

    public class Course
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public bool IsJoined { get; set; }

        public Course(string id, string name, string instructor, bool joined)
        {
            Id = id;
            Name = name;
            Instructor = instructor;
            IsJoined = joined;
        }
    }
}