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
using System.Diagnostics;

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
                btnLuu.Enabled = false; // Vô hiệu hóa nút để tránh bấm nhiều lần
                Cursor = Cursors.WaitCursor;

                Debug.WriteLine($"📝 Đang tạo lớp: {maLop}");
                Debug.WriteLine($"   UID: {FirebaseApi.CurrentUid}");
                Debug.WriteLine($"   Token: {(FirebaseApi.IdToken.Length > 10 ? FirebaseApi.IdToken.Substring(0, 10) + "..." : "invalid")}");

                // 3. KIỂM TRA TRÙNG MÃ LỚP
                var existingCourse = await FirebaseApi.Get<Course>($"Courses/{maLop}");

                if (existingCourse != null)
                {
                    MessageBox.Show($"Mã lớp '{maLop}' đã tồn tại trong hệ thống. Vui lòng chọn mã khác!",
                                    "Trùng mã lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Debug.WriteLine($"⚠️ Mã lớp {maLop} đã tồn tại");
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
                    GiangVienUid = FirebaseApi.CurrentUid
                };

                Debug.WriteLine("🔄 Đang lưu dữ liệu lên Firebase...");

                // Lưu lên Firebase
                bool success = await FirebaseApi.Put($"Courses/{newCourse.MaLop}", newCourse);

                if (success)
                {
                    Debug.WriteLine($"✅ Lớp {maLop} tạo thành công!");
                    OnCourseCreated?.Invoke(newCourse.MaLop, newCourse.TenLop, newCourse.SiSo);
                    MessageBox.Show("Tạo lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi tạo xong
                }
                else
                {
                    Debug.WriteLine($"❌ Lỗi lưu dữ liệu lên Firebase");
                    MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu lên Firebase. Kiểm tra kết nối Internet và quyền Firebase.",
                                    "Lỗi Firebase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Exception: {ex.Message}");
                Debug.WriteLine($"   Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
