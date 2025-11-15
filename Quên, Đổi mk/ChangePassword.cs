using System;
using System.Diagnostics;
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
        // --- THÊM BIẾN NÀY ĐỂ LƯU EMAIL ---
        private string _loggedInEmail;

        // Replace with your Firebase Web API key
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";

        // Hàm khởi tạo mặc định (Visual Studio tự tạo)
        public ChangePassword()
        {
            InitializeComponent();
        }

        // --- BƯỚC 2: THÊM HÀM KHỞI TẠO MỚI NÀY ---
        // Đây là hàm mà MainForm đang gọi
        public ChangePassword(string email, string token)
        {
            InitializeComponent(); // Phải gọi hàm này

            _loggedInEmail = email;
            // (Bạn không cần dùng 'token' truyền từ MainForm,
            // vì code của bạn đã tự lấy idToken mới khi xác thực. Rất tốt!)

            // Cải tiến: Tự động điền email vào textbox và khóa lại
            if (!string.IsNullOrEmpty(_loggedInEmail))
            {
                txtEmail.Text = _loggedInEmail;
                txtEmail.ReadOnly = true; // Ngăn người dùng sửa
            }
        }

        private async void btnChange_Click_1(object? sender, EventArgs e)
        {
            string email = txtEmail.Text?.Trim() ?? string.Empty;
            string currentPassword = txtCurrentPassword.Text ?? string.Empty;
            string newPassword = txtNewPassword.Text ?? string.Empty;
            string confirm = txtConfirmPassword.Text ?? string.Empty;

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirm)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnChange.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                // Re-authenticate (sign in) to obtain idToken
                var signInResult = await SignInWithEmailPasswordAsync(email, currentPassword);
                if (!signInResult.Success)
                {
                    MessageBox.Show($"Không thể xác thực: {signInResult.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string idToken = signInResult.IdToken;

                var updateOk = await UpdatePasswordAsync(idToken, newPassword);
                if (updateOk)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể đổi mật khẩu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnChange.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click_1(object? sender, EventArgs e)
        {
            Close();
        }

        private static bool IsValidEmail(string email)
        {
            try { _ = new MailAddress(email); return true; }
            catch { return false; }
        }

        private async Task<(bool Success, string? IdToken, string? ErrorMessage)> SignInWithEmailPasswordAsync(string email, string password)
        {
            using var http = new HttpClient();
            var payload = new { email = email, password = password, returnSecureToken = true };
            var json = JsonSerializer.Serialize(payload);
            HttpResponseMessage response;

            try
            {
                response = await http.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={webApiKey}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
            catch (HttpRequestException hx)
            {
                Debug.WriteLine(hx);
                return (false, null, "Lỗi kết nối đến máy chủ xác thực.");
            }

            string body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var errMsg = ParseFirebaseError(body);
                return (false, null, errMsg ?? "Xác thực không thành công.");
            }

            try
            {
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;
                if (root.TryGetProperty("idToken", out var t))
                {
                    return (true, t.GetString(), null);
                }

                return (false, null, "Phản hồi đăng nhập không hợp lệ.");
            }
            catch (JsonException jx)
            {
                Debug.WriteLine(jx);
                return (false, null, "Không thể xử lý phản hồi từ xác thực.");
            }
        }

        private async Task<bool> UpdatePasswordAsync(string idToken, string newPassword)
        {
            using var http = new HttpClient();
            var payload = new { idToken = idToken, password = newPassword, returnSecureToken = true };
            var json = JsonSerializer.Serialize(payload);

            HttpResponseMessage response;
            try
            {
                response = await http.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:update?key={webApiKey}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
            catch (HttpRequestException hx)
            {
                Debug.WriteLine(hx);
                return false;
            }

            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return true;

            var errMsg = ParseFirebaseError(body);
            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageBox.Show(errMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Debug.WriteLine($"UpdatePassword error: {body}");
            }

            return false;
        }

        private static string? ParseFirebaseError(string body)
        {
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("error", out var err))
                {
                    if (err.TryGetProperty("message", out var msg))
                        return msg.GetString();
                    // some responses contain error->errors array
                    if (err.TryGetProperty("errors", out var errors) && errors.ValueKind == JsonValueKind.Array && errors.GetArrayLength() > 0)
                    {
                        var first = errors[0];
                        if (first.TryGetProperty("message", out var m2))
                            return m2.GetString();
                    }
                }
            }
            catch (JsonException) { /* ignore */ }

            return null;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        
    }
}
