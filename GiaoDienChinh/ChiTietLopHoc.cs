using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static APP_DOAN.GiaoDienChinh.CourseDetailForm;

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
                // 1. Lấy thông tin cá nhân của sinh viên (Dùng class User bạn đã định nghĩa)
                var studentProfile = await _firebaseClient
                    .Child("Users")
                    .Child(_userUid)
                    .OnceSingleAsync<User>(); // Sử dụng class User của bạn ở đây

                // Lấy HoTen từ profile
                string studentName = studentProfile?.HoTen ?? "Học viên ẩn danh";

                // 2. Tạo yêu cầu mới với biến HoTen
                var newRequest = new JoinRequest
                {
                    HoTen = studentName, // Đưa giá trị vào HoTen
                    Status = "pending"
                };

                // 3. Đẩy lên Firebase
                await _firebaseClient
                    .Child("JoinRequests")
                    .Child(_course.Id)
                    .Child(_userUid)
                    .PutAsync(newRequest);

                MessageBox.Show("Đã gửi yêu cầu thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi yêu cầu: {ex.Message}", "Lỗi hệ thống");
                btnAgree.Enabled = true;
                btnAgree.Text = "Đồng ý";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public class JoinRequest
        {
            public string HoTen { get; set; } // Đổi từ StudentName thành HoTen
            public string Status { get; set; }
        }
    }
}