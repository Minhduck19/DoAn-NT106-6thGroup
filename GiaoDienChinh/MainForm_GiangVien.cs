using APP_DOAN.GiaoDienChinh;
using APP_DOAN.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class MainForm_GiangVien : Form
    {
        private string loggedInEmail;
        private string idToken;
        private bool isLoggingOut = false;
        private string currentUid;
        private string currentDisplayName;
        private TextBox txtFind;

        public MainForm_GiangVien(string uid, string displayName, string token)
        {
            InitializeComponent();
            this.idToken = token;
            this.currentUid = uid;
            this.currentDisplayName = displayName;

            // Đăng ký sự kiện Resize để cột tự giãn khi phóng to Form
            lvMyCourses.Resize += lvMyCourses_Resize;

            // Khởi tạo TextBox tìm kiếm (giữ nguyên logic của bạn)
            this.txtFind = new TextBox
            {
                Name = "txtFind",
                Width = 200,
                Location = new System.Drawing.Point(20, 60)
            };
            this.Controls.Add(txtFind);
        }

        private void MainForm_GiangVien_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào mừng,\nGV. {currentDisplayName}";

            // 1. Thiết lập cấu trúc cột trước
            SetupListViewColumns();

            // 2. Load dữ liệu sau
            LoadMyCoursesData();
        }

        private void SetupListViewColumns()
        {
            lvMyCourses.Columns.Clear();
            lvMyCourses.View = View.Details;
            lvMyCourses.FullRowSelect = true;
            lvMyCourses.GridLines = true;

            // Tính toán độ rộng thực tế (trừ đi 25 cho thanh cuộn dọc)
            int totalWidth = lvMyCourses.ClientSize.Width - 25;
            if (totalWidth <= 0) totalWidth = 600; // Giá trị dự phòng

            // Cấu hình cột theo tỷ lệ % cố định
            lvMyCourses.Columns.Add("Mã Lớp", (int)(totalWidth * 0.20), HorizontalAlignment.Left);
            lvMyCourses.Columns.Add("Tên Lớp Học", (int)(totalWidth * 0.65), HorizontalAlignment.Left);
            lvMyCourses.Columns.Add("Sĩ số", (int)(totalWidth * 0.15), HorizontalAlignment.Center);
        }

        // Sự kiện giúp cột luôn đẹp khi thay đổi kích thước Form
        private void lvMyCourses_Resize(object sender, EventArgs e)
        {
            if (lvMyCourses.Columns.Count >= 3)
            {
                int totalWidth = lvMyCourses.ClientSize.Width - 25;
                lvMyCourses.Columns[0].Width = (int)(totalWidth * 0.20);
                lvMyCourses.Columns[1].Width = (int)(totalWidth * 0.65);
                lvMyCourses.Columns[2].Width = (int)(totalWidth * 0.15);
            }
        }

        private async void LoadMyCoursesData()
        {
            if (string.IsNullOrEmpty(currentUid)) return;

            lvMyCourses.Items.Clear();
            try
            {
                var data = await FirebaseApi.Get<Dictionary<string, CourseInfo>>("Courses");

                if (data != null)
                {
                    foreach (var entry in data)
                    {
                        var course = entry.Value;
                        // Chỉ hiện lớp của Giảng viên hiện tại
                        if (course != null && course.GiangVienUid == currentUid)
                        {
                            string maLop = !string.IsNullOrEmpty(course.MaLop) ? course.MaLop : entry.Key;
                            AddCourseToListView(maLop, course.TenLop, course.SiSo);
                        }
                    }
                }

                // LƯU Ý: Tuyệt đối KHÔNG gọi AutoResizeColumns ở đây nữa 
                // vì nó sẽ phá vỡ tỷ lệ % chúng ta vừa chia bên trên.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message);
            }
        }

        private void AddCourseToListView(string maLop, string tenLop, int siSo)
        {
            var item = new ListViewItem(maLop);
            item.SubItems.Add(tenLop);
            item.SubItems.Add(siSo.ToString());
            item.Tag = maLop;
            lvMyCourses.Items.Add(item);
        }

        // --- CÁC HÀM SỰ KIỆN KHÁC (GIỮ NGUYÊN) ---

        

        private async void btnCreateCourse_Click_1(object sender, EventArgs e)
        {
            FirebaseApi.IdToken = this.idToken;
            CreateCourse createCourse = new CreateCourse();
            createCourse.OnCourseCreated += (maLop, tenLop, siSo) =>
            {
                AddCourseToListView(maLop, tenLop, siSo);
            };
            createCourse.ShowDialog();
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void lvMyCourses_DoubleClick_1(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0) return;

            string courseId = lvMyCourses.SelectedItems[0].Tag.ToString();
            string courseName = lvMyCourses.SelectedItems[0].SubItems[1].Text;

            var form = new CourseDetailForm(courseId, courseName, idToken, currentUid);
            form.ShowDialog();
            LoadMyCoursesData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                isLoggingOut = true;
                this.Close();
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher_Information profileForm = new Teacher_Information(currentUid, idToken, loggedInEmail);

            profileForm.FormClosed += (s, args) =>
            {
                this.Show();
                lblWelcome.Text = $"Chào mừng,\nGV. {currentDisplayName}";
            };

            profileForm.ShowDialog();
        }

        private async void BtnDeleteCourse_Click_1(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = lvMyCourses.SelectedItems[0];
            string courseId = selectedItem.Tag.ToString();
            string courseName = selectedItem.SubItems[1].Text;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn XÓA LỚP:\n\n{courseName}\n\n" +
                "⚠ Hành động này sẽ xóa:\n" +
                "- Lớp học\n" +
                "- Danh sách sinh viên\n" +
                "- Yêu cầu tham gia\n" +
                "- Bài tập liên quan\n\n" +
                "Không thể khôi phục!",
                "Xác nhận xóa lớp",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                // 1️⃣ Xóa lớp
                await FirebaseApi.Delete($"Courses/{courseId}");

                // 2️⃣ Xóa sinh viên trong lớp
                await FirebaseApi.Delete($"CourseStudents/{courseId}");

                // 3️⃣ Xóa yêu cầu tham gia
                await FirebaseApi.Delete($"JoinRequests/{courseId}");

                // 4️⃣ (Nếu có) Xóa assignment
                await FirebaseApi.Delete($"Assignments/{courseId}");

                // 5️⃣ Cập nhật UI
                lvMyCourses.Items.Remove(selectedItem);

                MessageBox.Show("Đã xóa lớp học thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa lớp:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

    }
}