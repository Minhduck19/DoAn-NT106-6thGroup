using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class ChangePassword : Form
    {
        // Lấy API Key từ LoginForm hoặc RegisterForm
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";

        private readonly string _loggedInEmail;
        private readonly string _originalIdToken; // Token GỐC lúc đăng nhập

        // Constructor nhận thông tin từ MainForm
        public ChangePassword(string email, string idToken)
        {
            InitializeComponent();
            _loggedInEmail = email;
            _originalIdToken = idToken;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            CenterPanel();
            txtEmail.Text = _loggedInEmail; // Hiển thị email
            txtEmail.ReadOnly = true; // Không cho sửa
            txtCurrentPassword.Focus();
        }

        // --- CÁC HÀM XỬ LÝ GIAO DIỆN (ĐỂ CĂN GIỮA) ---

        private void CenterPanel()
        {
            panelMain.Location = new Point(
                (this.ClientSize.Width - panelMain.Width) / 2,
                (this.ClientSize.Height - panelMain.Height) / 2
            );
        }

        private void ChangePassword_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        // --- CÁC HÀM XỬ LÝ NÚT BẤM ---

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            string currentPass = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(currentPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            ToggleUi(false);

            try
            {
                // 2. Xác thực lại mật khẩu cũ
                //    (Đây là bước quan trọng, ta "mượn" logic của LoginForm)
                var reAuthResult = await SignInWithEmailPasswordAsync(_loggedInEmail, currentPass);
                if (!reAuthResult.Success)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác.", "Lỗi Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Nếu mật khẩu cũ đúng, dùng "vé" MỚI NHẤT để đổi
                string freshIdToken = reAuthResult.IdToken;
                bool changeSuccess = await UpdatePasswordAsync(freshIdToken, newPass);

                if (changeSuccess)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                ToggleUi(true);
            }
        }

        private void ToggleUi(bool enabled)
        {
            txtCurrentPassword.Enabled = enabled;
            txtNewPassword.Enabled = enabled;
            txtConfirmPassword.Enabled = enabled;
            btnChange.Enabled = enabled;
            btnCancel.Enabled = enabled;
        }

        // --- CÁC HÀM LOGIC GỌI FIREBASE (QUAN TRỌNG) ---

        // Hàm "mượn" từ LoginForm để xác thực mật khẩu cũ
        private async Task<(bool Success, string IdToken)> SignInWithEmailPasswordAsync(string email, string password)
        {
            using var httpClient = new HttpClient();
            var payload = new { email = email, password = password, returnSecureToken = true };
            var json = JsonSerializer.Serialize(payload);

            var response = await httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={webApiKey}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            if (!response.IsSuccessStatusCode) return (false, null);

            string body = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(body);
            var idToken = doc.RootElement.GetProperty("idToken").GetString();
            return (true, idToken);
        }

        // Hàm gọi API đổi mật khẩu
        private async Task<bool> UpdatePasswordAsync(string idToken, string newPassword)
        {
            using var httpClient = new HttpClient();
            var payload = new { idToken = idToken, password = newPassword, returnSecureToken = false };
            var json = JsonSerializer.Serialize(payload);

            var response = await httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:update?key={webApiKey}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Không thể cập nhật mật khẩu. Vui lòng đăng xuất và thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}