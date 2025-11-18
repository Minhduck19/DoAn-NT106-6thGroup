using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }



        private void CenterPanel()
        {
            // Code căn giữa
            panelMain.Location = new Point(
                (this.ClientSize.Width - panelMain.Width) / 2,
                (this.ClientSize.Height - panelMain.Height) / 2
            );
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
            txtEmail.Focus();
        }

        private void ForgotPasswordForm_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        // --- CÁC HÀM XỬ LÝ NÚT BẤM ---

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email của bạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            ToggleUi(false);

            try
            {
                // Gọi hàm gửi link reset của Firebase
                bool success = await SendPasswordResetEmailAsync(email);

                if (success)
                {
                    MessageBox.Show("Một link đặt lại mật khẩu đã được gửi đến email của bạn. Vui lòng kiểm tra hộp thư (kể cả Spam).",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thành công
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }

        private void ToggleUi(bool enabled)
        {
            txtEmail.Enabled = enabled;
            btnSend.Enabled = enabled;
            btnCancel.Enabled = enabled;
        }



        private async Task<bool> SendPasswordResetEmailAsync(string email)
        {
            using var httpClient = new HttpClient();
            var payload = new { requestType = "PASSWORD_RESET", email = email };
            var json = JsonSerializer.Serialize(payload);

            var response = await httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={webApiKey}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Phân tích lỗi từ Firebase
                string errorBody = await response.Content.ReadAsStringAsync();
                string errorMessage = "Một lỗi không xác định đã xảy ra.";
                try
                {
                    using var doc = JsonDocument.Parse(errorBody);
                    if (doc.RootElement.TryGetProperty("error", out var err) && err.TryGetProperty("message", out var msg))
                    {
                        if (msg.GetString() == "EMAIL_NOT_FOUND")
                            errorMessage = "Email này không tồn tại trong hệ thống.";
                        else
                            errorMessage = msg.GetString();
                    }
                }
                catch { }

                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}