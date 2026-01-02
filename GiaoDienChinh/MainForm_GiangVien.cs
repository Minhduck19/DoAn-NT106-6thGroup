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
        private string idToken;
        private string currentUid;
        private string currentDisplayName;

        private FirebaseClient _client;
        private List<Course> _allMyCourses = new List<Course>();

        public MainForm_GiangVien(string uid, string displayName, string token)
        {
            InitializeComponent(); // Kết nối với file Designer
            this.idToken = token;
            this.currentUid = uid;
            this.currentDisplayName = displayName;

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
            lblWelcome.Text = $"Xin chào, Giảng viên {currentDisplayName}!";
            LoadMyCoursesData();
        }

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
                MessageBox.Show("Lỗi: " + ex.Message);
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

            foreach (var course in courses)
            {
                // Gọi hàm vẽ thẻ Guna Card
                RenderGunaCard(course);
            }
        }

        // --- HÀM VẼ THẺ GUNA (CARD) ---
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

            // Sự kiện click panel
            pnl.Click += (s, e) => OpenDetail(c);

            // 1. Tên Lớp
            Label lblName = new Label();
            lblName.Text = c.TenLop;
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(40, 40, 40);
            lblName.Location = new Point(20, 15);
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Click += (s, e) => OpenDetail(c);
            pnl.Controls.Add(lblName);

            // 2. Thông tin phụ
            Label lblInfo = new Label();
            lblInfo.Text = $"Mã lớp: {c.MaLop}   •   Sĩ số: {c.SiSoHienTai}/{c.SiSo}";
            lblInfo.Font = new Font("Segoe UI", 10);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(23, 50);
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Click += (s, e) => OpenDetail(c);
            pnl.Controls.Add(lblInfo);

            // 3. Nút Sửa (Vàng nhạt)
            Guna2Button btnEdit = new Guna2Button();
            btnEdit.Text = "Sửa";
            btnEdit.BorderRadius = 8;
            btnEdit.FillColor = Color.FromArgb(255, 248, 230);
            btnEdit.ForeColor = Color.Orange;
            btnEdit.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnEdit.Size = new Size(70, 30);
            btnEdit.Location = new Point(pnl.Width - 170, 40);
            btnEdit.Click += (s, e) => EditCourseAction(c);
            pnl.Controls.Add(btnEdit);

            // 4. Nút Xóa (Đỏ nhạt)
            Guna2Button btnDelete = new Guna2Button();
            btnDelete.Text = "Xóa";
            btnDelete.BorderRadius = 8;
            btnDelete.FillColor = Color.FromArgb(255, 235, 235);
            btnDelete.ForeColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnDelete.Size = new Size(70, 30);
            btnDelete.Location = new Point(pnl.Width - 90, 40);
            btnDelete.Click += (s, e) => DeleteCourseAction(c);
            pnl.Controls.Add(btnDelete);

            flpMyCourses.Controls.Add(pnl);
        }

        // --- CÁC HÀM SỰ KIỆN ---

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            FirebaseApi.CurrentUid = this.currentUid;
            FirebaseApi.IdToken = this.idToken;
            CreateCourse createCourse = new CreateCourse();
            createCourse.OnCourseCreated += (ma, ten, si) => { LoadMyCoursesData(); };
            createCourse.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtFind.Text;
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

        private void OpenDetail(Course c)
        {
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

        private void DeleteCourseAction(Course c)
        {
            if (MessageBox.Show($"Xóa lớp '{c.TenLop}'?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteCourseProcess(c);
            }
        }

        private async void DeleteCourseProcess(Course c)
        {
            try
            {
                await FirebaseApi.Delete($"Courses/{c.Id}");
                await FirebaseApi.Delete($"CourseStudents/{c.Id}");
                await FirebaseApi.Delete($"Assignments/{c.Id}");
                await FirebaseApi.Delete($"JoinRequests/{c.Id}");
                MessageBox.Show("Đã xóa thành công.");
                LoadMyCoursesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }
    }
}