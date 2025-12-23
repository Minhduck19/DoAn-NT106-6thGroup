using APP_DOAN;   // Thêm namespace chứa class User
using APP_DOAN.Services; // Thêm namespace chứa FirebaseApi
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Student_Information : Form
    {
        private string _uid;
        private string _idToken;
        private string _email;

        public Student_Information(string uid, string idToken, string email)
        {
            InitializeComponent();
            _uid = uid;
            _idToken = idToken;
            _email = email;

            // Cấu hình Token cho lớp static FirebaseApi ngay khi mở Form
            FirebaseApi.IdToken = _idToken;
        }



        private async Task LoadDataAsync()
        {
            try
            {
                // SỬ DỤNG THƯ VIỆN CỦA BẠN: Lấy dữ liệu từ path "Users/UID"
                var user = await FirebaseApi.Get<User>($"Users/{_uid}");
                if (user == null)
                {
                    MessageBox.Show("Dữ liệu trả về bị null! Hãy kiểm tra Path hoặc Token.");
                }
                else if (user != null)
                {

                    txtFullName.Text = user.HoTen;
                    txtTeacherID.Text = user.MaGiangVien;
                    txtBirthday.Text = user.NgaySinh;
                    txtSex.Text = user.Sex;
                    txtFaculty.Text = user.Khoa;
                    txtClass.Text = user.ChucVu;
                    txtEmail.Text = user.Email;
                    txtEmail.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Hồ sơ giảng viên chưa được cập nhật.");
                    txtEmail.Text = _email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                // Lấy data cũ để giữ các trường không hiển thị trên giao diện (như IsOnline)
                var oldData = await FirebaseApi.Get<User>($"Users/{_uid}");

                var updatedUser = new User
                {
                    Email = _email,
                    Role = "GiangVien",
                    HoTen = txtFullName.Text.Trim(),
                    Sex = txtSex.Text.Trim(),
                    MaGiangVien = txtTeacherID.Text.Trim(),
                    NgaySinh = txtBirthday.Text.Trim(),
                    Khoa = txtFaculty.Text.Trim(),
                    ChucVu = txtClass.Text.Trim(),
                    IsOnline = oldData?.IsOnline ?? false,
                    CreatedDate = oldData?.CreatedDate ?? DateTime.UtcNow.ToString("o")
                };

                // SỬ DỤNG THƯ VIỆN CỦA BẠN: Ghi đè dữ liệu
                bool success = await FirebaseApi.Put($"Users/{_uid}", updatedUser);

                if (success)
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu trữ: " + ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private async void Student_Information_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}