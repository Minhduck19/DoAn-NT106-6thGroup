using APP_DOAN.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class CreateCourse : Form
    {
        // Sự kiện trả dữ liệu lớp về MainForm
        public event Action<string, string, int>? OnCourseCreated;

        private readonly string _giangVienName;

        public CreateCourse(string giangVienName)
        {
            InitializeComponent();
            _giangVienName = giangVienName;
        }

        private async void btnLuu_Click_1(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã lớp và Tên lớp!");
                return;
            }

            if (!int.TryParse(txtSiSo.Text.Trim(), out int siSo))
            {
                MessageBox.Show("Sĩ số phải là một số nguyên!");
                return;
            }

            // 2. Kiểm tra xác thực giảng viên
            if (string.IsNullOrEmpty(FirebaseApi.CurrentUid))
            {
                MessageBox.Show("Lỗi xác thực: Vui lòng đăng nhập lại.");
                Debug.WriteLine("❌ FirebaseApi.CurrentUid is empty");
                return;
            }

            if (string.IsNullOrEmpty(FirebaseApi.IdToken))
            {
                MessageBox.Show("Lỗi: Token xác thực không hợp lệ.");
                Debug.WriteLine("❌ FirebaseApi.IdToken is empty");
                return;
            }

            try
            {
                btnLuu.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // 3. KIỂM TRA TRÙNG MÃ LỚP
                var existingCourse = await FirebaseApi.Get<Course>($"Courses/{maLop}");

                if (existingCourse != null)
                {
                    MessageBox.Show(
                        $"Mã lớp '{maLop}' đã tồn tại trong hệ thống. Vui lòng chọn mã khác!",
                        "Trùng mã lớp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    btnLuu.Enabled = true;
                    Cursor = Cursors.Default;
                    return;
                }

                // 4. Nếu không trùng, tiến hành tạo mới
                var newCourse = new Course
                {
                    MaLop = maLop,
                    TenLop = tenLop,
                    SiSo = siSo,
                    GiangVienUid = FirebaseApi.CurrentUid,
                    Instructor = _giangVienName
                };

                // Lưu lên Firebase
                bool success = await FirebaseApi.Put($"Courses/{newCourse.MaLop}", newCourse);

                if (success)
                {
                    OnCourseCreated?.Invoke(newCourse.MaLop, newCourse.TenLop, newCourse.SiSo);
                    MessageBox.Show("Tạo lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Có lỗi xảy ra khi lưu dữ liệu lên Firebase. Kiểm tra kết nối Internet và quyền Firebase.",
                        "Lỗi Firebase",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => Close();

        private void panelMain_Paint(object sender, PaintEventArgs e) { }
    }
}
