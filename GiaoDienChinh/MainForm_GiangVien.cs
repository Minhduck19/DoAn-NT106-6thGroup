using APP_DOAN.GiaoDienChinh;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace APP_DOAN
{
    public partial class MainForm_GiangVien : Form
    {
        // Biến lưu thông tin đăng nhập
        private string loggedInEmail;
        private string idToken;
        private bool isLoggingOut = false;
        private string currentUid;
        private string currentDisplayName;


        // (Trong tương lai, bạn sẽ dùng 'idToken' hoặc 'loggedInEmail'
        //  để-truy-vấn-Firebase-lấy-các-lớp-của-giảng-viên-này)

        public MainForm_GiangVien(string uid, string displayName, string token)
        {
            InitializeComponent();
            this.idToken = token;
            this.currentUid = uid;                    // UID thật
            this.currentDisplayName = displayName;    // Họ tên giảng viên
        }

        private void MainForm_GiangVien_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin Giảng viên
            string username = currentDisplayName;
            lblWelcome.Text = $"Chào mừng,\nGV. {username}";

            // Cài đặt cột cho ListView
            SetupListViewColumns();

            // Tải dữ liệu các lớp của Giảng viên (Dữ liệu giả lập)
            LoadMyCoursesData();
        }

        private void SetupListViewColumns()
        {
            lvMyCourses.Columns.Clear();
            lvMyCourses.Columns.Add("Mã Lớp", 100);
            lvMyCourses.Columns.Add("Tên Lớp Học", 350);
            lvMyCourses.Columns.Add("Sĩ số", 100);
            // (Bạn có thể thêm các cột khác như "Học kỳ", "Trạng thái")
        }

        private void LoadMyCoursesData()
        {
            // Dữ liệu giả lập - Trong tương lai, bạn sẽ:
            // 1. Dùng idToken/email để-lấy-UID-của-GV
            // 2. Truy vấn Firebase: `firebaseClient.Child("Courses").OrderBy("InstructorUID").EqualTo(uid)...`

            lvMyCourses.Items.Clear();

            // Giả sử giảng viên này dạy 2 lớp
            var item1 = new ListViewItem("DB202");
            item1.SubItems.Add("Cơ sở dữ liệu");
            item1.SubItems.Add("40"); // Sĩ số
            item1.Tag = "DB202"; // Lưu ID để-sử-dụng
            lvMyCourses.Items.Add(item1);

            var item2 = new ListViewItem("NET301");
            item2.SubItems.Add("Lập trình .NET");
            item2.SubItems.Add("35");
            item2.Tag = "NET301";
            lvMyCourses.Items.Add(item2);
        }

        // --- XỬ LÝ CÁC NÚT HÀNH ĐỘNG ---
        private void AddCourseToListView(string maLop, string tenLop, int siSo)
        {
            var item = new ListViewItem(maLop);
            item.SubItems.Add(tenLop);
            item.SubItems.Add(siSo.ToString());
            item.Tag = maLop;

            lvMyCourses.Items.Add(item);
        }


        private void btnCreateCourse_Click_1(object sender, EventArgs e)
        {
            CreateCourse createCourse = new CreateCourse();
            createCourse.OnCourseCreated += (maLop, tenLop, siSo) =>
            {
                AddCourseToListView(maLop, tenLop, siSo);
            };

            createCourse.ShowDialog();


            var firebaseClient = new FirebaseClient(
                "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(idToken) // DÙNG TOKEN THẬT TỪ LOGIN
                });

            var createForm = new CreateCourseForm(firebaseClient, currentUid, currentDisplayName);

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Tạo lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load lại danh sách lớp nếu cần
                // LoadMyCoursesData();
            }
        }

        private void btnEditCourse_Click_1(object sender, EventArgs e, FixCourse fixCourse)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Chưa chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvMyCourses.SelectedItems[0];
            string maLop = item.Text;
            string tenLop = item.SubItems[1].Text;
            int siSo = int.Parse(item.SubItems[2].Text);

            FixCourse editForm = new FixCourse(maLop, tenLop, siSo);
            editForm.OnCourseUpdated = (updatedMaLop, updatedTenLop, updatedSiSo) =>
            {
                item.SubItems[1].Text = updatedTenLop;
                item.SubItems[2].Text = updatedSiSo.ToString();
            };
            fixCourse.ShowDialog();
        }

        private void btnDeleteCourse_Click_1(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa.", "Chưa chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string courseId = lvMyCourses.SelectedItems[0].Tag.ToString();
            string courseName = lvMyCourses.SelectedItems[0].SubItems[1].Text; // Lấy tên lớp

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp '{courseName}' (ID: {courseId}) không? Hành động này không thể hoàn tác.",
                                        "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // (Trong tương lai, bạn sẽ gọi API Firebase để-xóa-lớp-học)
                MessageBox.Show($"Đã xóa lớp (ID: {courseId}).", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách sau khi xóa
                LoadMyCoursesData();
            }
        }


        // --- LOGIC ĐĂNG XUẤT VÀ ĐÓNG FORM ---
        // (Giữ nguyên logic giống MainForm của Sinh viên)

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận Đăng xuất",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isLoggingOut = true; // Đánh dấu là đang chủ động đăng xuất
                this.Close(); // Đóng Form chính để-quay-về GiaoDienGoc
            }
        }

        private void MainForm_GiangVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xử lý khi người dùng nhấn nút X (đóng cửa sổ)
            if (!isLoggingOut)
            {
                var result = MessageBox.Show("Bạn có muốn thoát hoàn toàn ứng dụng?", "Xác nhận Thoát",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy việc đóng Form
                }
            }
            // Nếu isLoggingOut là true, Form sẽ tự động đóng
            // và quay về GiaoDienGoc (sau đó GiaoDienGoc.Close() sẽ-kết-thúc-ứng-dụng)
        }

        private void lvMyCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher_Information profileForm = new Teacher_Information(loggedInEmail, idToken);
            profileForm.ShowDialog();
            this.Show();
        }

        private void btnFindCourse_Click(object sender, EventArgs e)
        {
            string searchText = txtFind.Text.Trim().ToLower();

            // Nếu TextBox trống, tải lại toàn bộ danh sách lớp học
            if (string.IsNullOrEmpty(searchText))
            {
                LoadMyCoursesData();
                return;
            }

            foreach (ListViewItem item in lvMyCourses.Items)
            {

                string courseCode = item.Text.ToLower(); // Lấy Mã Lớp
                string courseName = item.SubItems[1].Text.ToLower(); // Lấy Tên Lớp

                if (courseCode.Contains(searchText) || courseName.Contains(searchText))
                {
                    // Nếu khớp, TÔ SÁNG và đảm bảo mục đó hiển thị
                    item.Selected = true;
                    item.BackColor = System.Drawing.Color.LightYellow;
                    item.EnsureVisible();
                }
                else
                {
                    // Nếu không khớp, bỏ chọn và đặt lại màu nền mặc định
                    item.Selected = false;
                    item.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Chưa chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvMyCourses.SelectedItems[0];
            string maLop = item.Text;
            string tenLop = item.SubItems[1].Text;
            int siSo = int.Parse(item.SubItems[2].Text);

            FixCourse editForm = new FixCourse(maLop, tenLop, siSo);
            editForm.OnCourseUpdated = (updatedMaLop, updatedTenLop, updatedSiSo) =>
            {
                item.SubItems[1].Text = updatedTenLop;
                item.SubItems[2].Text = updatedSiSo.ToString();
            };
            editForm.ShowDialog();
        private void lvMyCourses_DoubleClick_1(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
                return;

            string courseId = lvMyCourses.SelectedItems[0].Tag.ToString();
            string courseName = lvMyCourses.SelectedItems[0].SubItems[1].Text;

            var form = new CourseDetailForm(courseId, courseName, idToken, loggedInEmail);
            form.ShowDialog();

            // Reload lại danh sách lớp
            LoadMyCoursesData();
        }
    }
}