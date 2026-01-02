using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_DOAN.Services;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class FixCourse : Form
    {

        // Delegate để cập nhật ListView khi sửa xong
        public Action<string, string, int> OnCourseUpdated;
        private string tenLop;
        private int siSo;

        public FixCourse(string maLop)
        {
            InitializeComponent();
            txtMaLop.Text = maLop;
            txtTenLop.Text = tenLop;
            txtSiSo.Text = siSo.ToString();

            // Gán sự kiện
            btnCapNhat.Click += btnCapNhat_Click;
            btnDong.Click += (s, e) => this.Close();
        }

        public FixCourse(string maLop, string tenLop, int siSo) : this(maLop)
        {
            this.tenLop = tenLop;
            this.siSo = siSo;
        }

        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string newName = txtTenLop.Text.Trim();
            string newSiSoStr = txtSiSo.Text.Trim();

            if (string.IsNullOrEmpty(newName) || !int.TryParse(newSiSoStr, out int newSiSo))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ.");
                return;
            }

            try
            {
                // 1. Tạo object dữ liệu mới để cập nhật
                var updatedCourse = new Course
                {
                    MaLop = maLop,
                    TenLop = newName,
                    SiSo = newSiSo,
                    GiangVienUid = FirebaseApi.CurrentUid // Giữ nguyên định danh chủ sở hữu
                };

                // 2. Gửi lên Firebase (Sử dụng MaLop làm Key để ghi đè)
                bool success = await FirebaseApi.Put($"Courses/{maLop}", updatedCourse);

                if (success)
                {
                    // 3. Cập nhật giao diện thông qua delegate
                    OnCourseUpdated?.Invoke(maLop, newName, newSiSo);
                    MessageBox.Show("Cập nhật lên hệ thống thành công!", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối Firebase khi cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
