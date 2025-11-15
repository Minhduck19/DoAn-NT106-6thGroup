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
    public partial class ForgotPasswordForm : Form
    {
        // Replace with your Firebase Web API key
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text?.Trim() ?? string.Empty;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSend.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                bool ok = await SendPasswordResetAsync(email);
                if (ok)
                {
                    MessageBox.Show("Đã gửi email đặt lại mật khẩu. Vui lòng kiểm tra hộp thư.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể gửi email đặt lại mật khẩu. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task<bool> SendPasswordResetAsync(string email)
        {
            using var http = new HttpClient();
            var payload = new { requestType = "PASSWORD_RESET", email = email };
            var json = JsonSerializer.Serialize(payload);

            HttpResponseMessage response;
            try
            {
                response = await http.PostAsync(
                    $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={webApiKey}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"HTTP error sending password reset: {httpEx}");
                return false;
            }

            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return true;

            Debug.WriteLine($"Password reset error response: {body}");
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("error", out var err) &&
                    err.TryGetProperty("message", out var msg))
                {
                    MessageBox.Show(msg.GetString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (JsonException) { /* ignore parse errors */ }

            return false;
        }

        private static bool IsValidEmail(string email)
        {
            try { _ = new MailAddress(email); return true; }
            catch { return false; }
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
