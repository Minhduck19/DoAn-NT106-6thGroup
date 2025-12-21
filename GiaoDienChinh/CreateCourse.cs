using APP_DOAN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class CreateCourse : Form
    {

        // Sự kiện trả dữ liệu lớp về MainForm
        public event Action<string, string, int> OnCourseCreated;
        public CreateCourse()
        {
            InitializeComponent();
        }


        private async void btnLuu_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu cơ bản
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
                return;
            }

            try
            {
                btnLuu.Enabled = false; // Vô hiệu hóa nút để tránh bấm nhiều lần

                // 3. KIỂM TRA TRÙNG MÃ LỚP
                // Chúng ta thử Get dữ liệu tại đường dẫn Courses/{maLop}
                var existingCourse = await FirebaseApi.Get<CourseInfo>($"Courses/{maLop}");

                if (existingCourse != null)
                {
                    MessageBox.Show($"Mã lớp '{maLop}' đã tồn tại trong hệ thống. Vui lòng chọn mã khác!",
                                    "Trùng mã lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnLuu.Enabled = true;
                    return;
                }

                // 4. Nếu không trùng, tiến hành tạo mới
                var newCourse = new CourseInfo
                {
                    MaLop = maLop,
                    TenLop = tenLop,
                    SiSo = siSo,
                    GiangVienUid = FirebaseApi.CurrentUid,
                    // Khởi tạo danh sách học sinh trống để tránh lỗi null sau này
                    Students = new List<string>()
                };

                bool success = await FirebaseApi.Put($"Courses/{newCourse.MaLop}", newCourse);

                if (success)
                {
                    OnCourseCreated?.Invoke(newCourse.MaLop, newCourse.TenLop, newCourse.SiSo);
                    MessageBox.Show("Tạo lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi tạo xong
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu lên Firebase.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}");
            }
            finally
            {
                btnLuu.Enabled = true;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
