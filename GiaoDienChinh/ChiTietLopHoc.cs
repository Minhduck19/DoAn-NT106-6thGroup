using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class ChiTietLopHoc : Form
    {
        private readonly Course _course;
        private readonly string _userUid;
        private readonly FirebaseClient _firebaseClient;

        // Constructor nhận thông tin lớp và UID người dùng
        public ChiTietLopHoc(Course course, string userUid, string token)
        {
            InitializeComponent();
            _course = course;
            _userUid = userUid;

            _firebaseClient = new FirebaseClient(
                "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
            );

            // Gán sự kiện Load để hiển thị thông tin khi mở Form
            this.Load += ChiTietLopHoc_Load;
        }

        private void ChiTietLopHoc_Load(object sender, EventArgs e)
        {
            HienThiThongTinLop();
        }

        private void HienThiThongTinLop()
        {
            int hienTai = _course.Students?.Count ?? 0;
            int toiDa = _course.SiSo;

            if (toiDa <= 0) toiDa = 50;

            if (hienTai >= toiDa)
            {
                btnAgree.Text = "Lớp đã đầy";
                btnAgree.Enabled = false;
                btnAgree.BackColor = Color.Gray;
            }
            else
            {
                btnAgree.Enabled = true;
                btnAgree.Text = "Đồng ý";
                btnAgree.BackColor = Color.AliceBlue; // Màu nút bình thường của bạn
            }
        }

        private async void btnAgree_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_course.Id))
            {
                MessageBox.Show("Lỗi: Mã định danh lớp học không hợp lệ!");
                return;
            }
            try
            {
                
                btnAgree.Enabled = false; // Chặn bấm liên tiếp
                btnAgree.Text = "Đang xử lý...";

                // 1. Tải dữ liệu mới nhất của lớp này từ Firebase để kiểm tra sĩ số thực tế
                var latestCourse = await _firebaseClient
                    .Child("Courses")
                    .Child(_course.Id) // Id là key của lớp trên Firebase
                    .OnceSingleAsync<CourseInfo>();

                if (latestCourse == null)
                {
                    MessageBox.Show("Không tìm thấy dữ benevolence lớp học!", "Lỗi");
                    return;
                }

                // 2. Kiểm tra danh sách Students (tránh lỗi null)
                if (latestCourse.Students == null)
                    latestCourse.Students = new List<string>();

                // 3. KIỂM TRA ĐẦY LỚP (Logic chính)
                if (latestCourse.Students.Count >= latestCourse.SiSo)
                {
                    MessageBox.Show($"Rất tiếc! Lớp học vừa mới đầy ({latestCourse.Students.Count}/{latestCourse.SiSo}), bạn không thể đăng ký.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HienThiThongTinLop(); // Cập nhật lại giao diện
                    return;
                }

                // 4. Kiểm tra xem mình đã có trong lớp chưa (phòng hờ)
                if (latestCourse.Students.Contains(_userUid))
                {
                    MessageBox.Show("Bạn đã tham gia lớp này rồi.", "Thông báo");
                    return;
                }

                // 5. Nếu còn chỗ -> Thêm UID vào danh sách và cập nhật
                latestCourse.Students.Add(_userUid);
                latestCourse.SiSoHienTai = latestCourse.Students.Count; // Đồng bộ sĩ số hiện tại

                await _firebaseClient
                    .Child("Courses")
                    .Child(_course.Id)
                    .PutAsync(latestCourse);

                MessageBox.Show("Đăng ký tham gia lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị StackTrace để biết chính xác dòng nào bị lỗi
                MessageBox.Show($"Lỗi chi tiết: {ex.Message}\n\nTại: {ex.StackTrace}", "Lỗi hệ thống");
                btnAgree.Enabled = true;
                btnAgree.Text = "Đồng ý";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}