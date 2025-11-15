using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class MainForm : Form
    {

        private string loggedInEmail;
        private string idToken;

        // Lưu vai trò: "Student" hoặc "Lecturer"
        private string userRole = "Student";

        // Cờ để-xử-lý-đăng-xuất
        private bool isLoggingOut = false;

        // Danh sách môn học trong bộ nhớ (mẫu)
        private List<Course> _allCourses = new();

        // Nút quản lý khóa học cho giảng viên (tạo động)
        private Button btnManageCourses;

        // Constructor nhận thông tin từ LoginForm (có thể gọi không tham số hoặc có email/token)
        public MainForm(string email = "", string token = null, string role = "Student")
        {
            InitializeComponent();

            // Lưu thông tin đăng nhập
            this.loggedInEmail = email ?? string.Empty;
            this.idToken = token;
            this.userRole = string.IsNullOrWhiteSpace(role) ? "Student" : role;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng (tách tên từ email hoặc hiển thị "Khách")
            string username = "Khách";
            if (!string.IsNullOrWhiteSpace(loggedInEmail) && loggedInEmail.Contains('@'))
            {
                username = loggedInEmail.Split('@')[0];
            }

            lblWelcome.Text = $"Chào mừng,\n{username} ({(userRole == "Lecturer" ? "Giảng viên" : "Sinh viên")})";

            // Nếu là giảng viên, thêm nút "Quản lý khóa học"
            if (userRole == "Lecturer")
            {
                AddManageCoursesButton();
            }

            // Ẩn/hiện cột tham gia dựa trên vai trò (nếu có cột)
            try
            {
                if (dgvAvailableCourses.Columns.Contains("colJoin"))
                {
                    dgvAvailableCourses.Columns["colJoin"].Visible = (userRole == "Student");
                }
            }
            catch { /* ignore if designer names differ */ }

            // --- 2. Cài đặt Cột cho ListView ---
            SetupJoinedListViewColumns();

            // --- 3. Tải dữ liệu lớp học (Giả lập) ---
            LoadClassData();
        }

        private void AddManageCoursesButton()
        {
            try
            {
                btnManageCourses = new Button
                {
                    Text = "Quản lý khóa học",
                    AutoSize = true
                };

                // Nếu có btnLogout trên form, đặt nút quản lý bên trái nó
                if (this.Controls.ContainsKey("btnLogout"))
                {
                    var ctrlLogout = this.Controls["btnLogout"];
                    // Tạm đặt ở bên trái của btnLogout
                    btnManageCourses.Location = new Point(Math.Max(8, ctrlLogout.Left - 120), ctrlLogout.Top);
                }
                else
                {
                    // fallback: góc trên phải
                    btnManageCourses.Location = new Point(this.ClientSize.Width - 130, 10);
                    btnManageCourses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                }

                btnManageCourses.Click += BtnManageCourses_Click;
                this.Controls.Add(btnManageCourses);
            }
            catch
            {
                // ignore layout errors
            }
        }

        private void BtnManageCourses_Click(object sender, EventArgs e)
        {
            // Mô phỏng chức năng quản lý lớp cho giảng viên
            MessageBox.Show("Chức năng Quản lý khóa học cho Giảng viên (mẫu).", "Quản lý khóa học", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetupJoinedListViewColumns()
        {
            lvJoinedCourses.Columns.Clear();
            lvJoinedCourses.Columns.Add("Tên môn", 380);
            lvJoinedCourses.Columns.Add("Giảng viên", 200);
        }

        private void LoadClassData()
        {
            // Dữ liệu mẫu — thay thế bằng API/Firebase sau
            _allCourses = new List<Course>
      {
        new Course("CS101", "Nhập môn Lập trình", "Nguyễn Văn A", true),
        new Course("DB202", "Cơ sở dữ liệu", "Trần Thị B", true),
        new Course("NET301", "Lập trình .NET", "Lê Văn C", true),
        new Course("AI401", "Trí tuệ nhân tạo", "Phạm Thị D", false),
        new Course("SEC101", "An toàn thông tin", "Hoàng Vũ", false),
        new Course("ML205", "Học máy cơ bản", "Nguyễn Minh", false)
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
                item.Tag = c.Id; // lưu id để sử dụng sau
                lvJoinedCourses.Items.Add(item);
            }
        }

        private void PopulateAvailableCourses()
        {
            dgvAvailableCourses.Rows.Clear();

            var available = _allCourses.Where(c => !c.IsJoined).ToList();
            foreach (var c in available)
            {
                // Thêm hàng: ẩn Id, Tên, Giảng viên — cột cuối là cột nút được cấu hình trong designer
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
            // Kiểm tra vai trò: chỉ cho phép Sinh viên tham gia
            if (userRole != "Student")
            {
                MessageBox.Show("Chỉ sinh viên mới có thể tham gia khóa học.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var course = _allCourses.FirstOrDefault(c => c.Id == courseId);
            if (course == null) return;

            // Gọi đến backend / Firebase để thực sự tham gia khóa học.
            // Mẫu xác nhận tham gia khóa học.
            var confirm = MessageBox.Show($"Bạn có muốn tham gia \"{course.Name}\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            course.IsJoined = true;

            PopulateJoinedCourses();
            PopulateAvailableCourses();

            MessageBox.Show($"Bạn đã tham gia khóa học: {course.Name}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Show user options menu (Hồ sơ, Tin nhắn, Lịch học, Điểm)
        private void lblWelcome_Click_1(object sender, EventArgs e)
        {
            // Show the context menu below the label
            cmsUserOptions.Show(lblWelcome, new Point(0, lblWelcome.Height));
        }

        // --- GIỮ NGUYÊN HÀM NÀY ---
        // Hàm này vẫn hiển thị MessageBox thông tin hồ sơ
        private void profileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Open profile screen or show simple info
            MessageBox.Show($"Hồ sơ: {loggedInEmail}\nVai trò: {(userRole == "Lecturer" ? "Giảng viên" : "Sinh viên")}", "Hồ sơ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void messagesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Tin nhắn (chức năng mẫu).", "Tin nhắn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void scheduleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Lịch học (chức năng mẫu).", "Lịch học", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gradesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Điểm (chức năng mẫu).", "Điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- HÀM MỚI (Tạo bằng cách nhấp đúp vào mục menu "Đổi mật khẩu") ---
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở Form đổi mật khẩu

            ChangePassword changePassForm = new ChangePassword(this.loggedInEmail, this.idToken);

            // Tạm ẩn form chính
            this.Hide();

            // Hiển thị form đổi mật khẩu. Dùng ShowDialog() để nó chặn form chính
            changePassForm.ShowDialog();

            // Sau khi form đổi mật khẩu (ShowDialog) bị đóng, hiển thị lại form chính
            this.Show();
        }

        // --- THAY ĐỔI: Sửa hàm btnLogout_Click ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận Đăng xuất",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isLoggingOut = true; // Đánh dấu là đang chủ động đăng xuất

                // 1. Tạo một instance của GiaoDienGoc (Form gốc)
                // (Đảm bảo bạn đã có Form tên GiaoDienGoc trong dự án)
                GiaoDienGoc formGoc = new GiaoDienGoc();

                // 2. Hiển thị form GiaoDienGoc
                formGoc.Show();

                // 3. Đóng Form chính (MainForm)
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xử lý khi người dùng nhấn nút X (đóng cửa sổ)
            if (!isLoggingOut)
            {
                // Nếu không phải là chủ động đăng xuất (mà là nhấn nút X)
                // thì hỏi để-thoát-cả-ứng-dụng
                var result = MessageBox.Show("Bạn có muốn thoát hoàn toàn ứng dụng?", "Xác nhận Thoát",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy việc đóng Form
                }
            }
        }

        // Hàm này có code logic, chúng ta giữ lại
        private void lvJoinedCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: show more details or allow leaving the course
            if (lvJoinedCourses.SelectedItems.Count == 0) return;
            var id = lvJoinedCourses.SelectedItems[0].Tag?.ToString();
            var course = _allCourses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                MessageBox.Show($"{course.Name}\nGiảng viên: {course.Instructor}", "Chi tiết khóa học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lvJoinedCourses_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

       
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
