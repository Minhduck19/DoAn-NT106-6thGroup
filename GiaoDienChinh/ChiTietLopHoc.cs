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
            if (_course.IsJoined)
            {
                btnAgree.Text = "Đã tham gia";
                btnAgree.Enabled = false;
                btnAgree.BackColor = Color.LightGreen;
                return;
            }
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
                MessageBox.Show("Lỗi: Mã lớp không hợp lệ!");
                return;
            }

            try
            {
                btnAgree.Enabled = false;
                btnAgree.Text = "Đang gửi yêu cầu...";

                // Kiểm tra đã gửi yêu cầu chưa
                var existed = await _firebaseClient
                    .Child("JoinRequests")
                    .Child(_course.Id)
                    .Child(_userUid)
                    .OnceSingleAsync<JoinRequest>();

                if (existed != null)
                {
                    MessageBox.Show("Bạn đã gửi yêu cầu trước đó!");
                    return;
                }

                // Tạo yêu cầu tham gia lớp
                var request = new JoinRequest
                {
                    StudentUid = _userUid,
                    StudentName = "Sinh viên", // hoặc lấy từ Users
                    Status = "pending",
                    RequestTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                };

                await _firebaseClient
                    .Child("JoinRequests")
                    .Child(_course.Id)
                    .Child(_userUid)
                    .PutAsync(request);

                MessageBox.Show(
                    "Đã gửi yêu cầu tham gia lớp!\nVui lòng chờ giảng viên duyệt.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi yêu cầu: " + ex.Message);
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
            public string StudentUid { get; set; }
            public string StudentName { get; set; }
            public string Status { get; set; }   // pending | approved | denied
            public string RequestTime { get; set; }
        }

    }
}