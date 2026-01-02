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

        // KHAI BÁO CÁC CONTROL GUNA (Tạo bằng code)
        private Guna2TextBox txtFind;
        private Guna2Button btnCreateNew;
        private Guna2Button btnLogOut;
        private Guna2Button btnProfile; // Nút Hồ Sơ

        public MainForm_GiangVien(string uid, string displayName, string token, string email )
        {
            InitializeComponent();
            this.idToken = token;
            this.currentUid = uid;
            this.currentDisplayName = displayName;
            this.loggedInEmail = email; 

            // --- SETUP GIAO DIỆN ---
            SetupCustomUI();

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
            LoadMyCoursesData();
        }

        // 🔥 HÀM TẠO GIAO DIỆN ĐẸP
        private void SetupCustomUI()
        {
            // 1. Thanh tìm kiếm
            txtFind = new Guna2TextBox();
            txtFind.PlaceholderText = "Tìm kiếm lớp học...";
            txtFind.BorderRadius = 18;
            txtFind.Size = new Size(350, 40);
            txtFind.Location = new Point(30, 80);
            txtFind.Font = new Font("Segoe UI", 10);
            txtFind.TextChanged += (s, e) => PerformSearch(txtFind.Text);
            this.Controls.Add(txtFind);

            // 2. Nút Tạo Lớp Mới (Gradient Xanh)
            btnCreateNew = new Guna2Button();
            btnCreateNew.Text = "+ Tạo Lớp Mới";
            btnCreateNew.BorderRadius = 10;
            btnCreateNew.FillColor = Color.FromArgb(0, 118, 212);
            btnCreateNew.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCreateNew.ForeColor = Color.White;
            btnCreateNew.Size = new Size(160, 40);
            btnCreateNew.Location = new Point(400, 80);
            btnCreateNew.Cursor = Cursors.Hand;
            btnCreateNew.Click += btnCreateCourse_Click;
            this.Controls.Add(btnCreateNew);

            // 3. Nút Đăng Xuất (Góc phải - Viền đỏ)
            btnLogOut = new Guna2Button();
            btnLogOut.Text = "Đăng xuất";
            btnLogOut.BorderRadius = 10;
            btnLogOut.FillColor = Color.White;
            btnLogOut.BorderColor = Color.IndianRed;
            btnLogOut.BorderThickness = 1;
            btnLogOut.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnLogOut.ForeColor = Color.IndianRed;
            btnLogOut.Size = new Size(100, 40);
            btnLogOut.Location = new Point(this.Width - 140, 30);
            btnLogOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogOut.Click += btnLogout_Click;
            this.Controls.Add(btnLogOut);

            // 4. Nút Hồ Sơ Cá Nhân (Màu Tím - Bên cạnh Đăng xuất)
            btnProfile = new Guna2Button();
            btnProfile.Text = "Hồ sơ cá nhân";
            btnProfile.BorderRadius = 10;
            btnProfile.FillColor = Color.FromArgb(100, 88, 255);
            btnProfile.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Size = new Size(130, 40);
            btnProfile.Location = new Point(this.Width - 280, 30);
            btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProfile.Click += OpenProfile_Click;
            this.Controls.Add(btnProfile);
        }

        // --- CÁC SỰ KIỆN NÚT BẤM ---

        private void OpenProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Truyền đủ thông tin sang form Hồ sơ
            Teacher_Information profileForm = new Teacher_Information(currentUid, idToken, loggedInEmail);
            profileForm.ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            FirebaseApi.CurrentUid = this.currentUid;
            FirebaseApi.IdToken = this.idToken;
            CreateCourse createCourse = new CreateCourse();
            createCourse.OnCourseCreated += (ma, ten, si) => { LoadMyCoursesData(); };
            createCourse.ShowDialog();
        }

        // --- XỬ LÝ DỮ LIỆU & VẼ THẺ ---

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
                DisabledState = { FillColor = Color.Transparent }
            };
            flpMyCourses.Controls.Add(btnLoad);

            try
            {
                var data = await FirebaseApi.Get<Dictionary<string, Course>>("Courses");
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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void RenderList(List<Course> courses)
        {
            flpMyCourses.Controls.Clear();
            if (courses.Count == 0)
            {
                Label lbl = new Label { Text = "Chưa có lớp học nào.", AutoSize = true, ForeColor = Color.Gray, Margin = new Padding(10) };
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

            // Click vào thẻ mở chi tiết
            pnl.Click += (s, e) => OpenDetail(c);

            // Tên lớp
            Label lblName = new Label();
            lblName.Text = c.TenLop;
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(40, 40, 40);
            lblName.Location = new Point(20, 15);
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Click += (s, e) => OpenDetail(c);
            pnl.Controls.Add(lblName);

            // Thông tin phụ
            Label lblInfo = new Label();
            lblInfo.Text = $"Mã lớp: {c.MaLop}   •   Sĩ số: {c.SiSoHienTai}/{c.SiSo}";
            lblInfo.Font = new Font("Segoe UI", 10);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(23, 50);
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Click += (s, e) => OpenDetail(c);
            pnl.Controls.Add(lblInfo);

            // Nút Sửa
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

            // Nút Xóa
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
                    await FirebaseApi.Delete($"Courses/{c.Id}");
                    await FirebaseApi.Delete($"CourseStudents/{c.Id}");
                    await FirebaseApi.Delete($"Assignments/{c.Id}");
                    await FirebaseApi.Delete($"JoinRequests/{c.Id}");
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
                c.TenLop.ToLower().Contains(keyword.ToLower()) ||
                c.MaLop.ToLower().Contains(keyword.ToLower()));
            RenderList(filtered);
        }
    }
}