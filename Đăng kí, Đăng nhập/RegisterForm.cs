using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APP_DOAN
{
    public partial class RegisterForm : Form
    {
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/"; 

        
        private readonly EmailService _emailService;

        public RegisterForm()
        {
            InitializeComponent();
            _emailService = new EmailService(); 

            if (string.IsNullOrWhiteSpace(webApiKey) || webApiKey == "YOUR_FIREBASE_WEB_API_KEY")
            {
                MessageBox.Show("Bạn chưa thiết lập Firebase Web API Key!", "Lỗi Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
                return;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtNewEmail.Text.Trim();
            string password = txtNewPassword.Text.Trim();
            string role = "";
            if (rbSinhVien.Checked) role = "SinhVien";
            else if (rbGiangVien.Checked) role = "GiangVien";

            if (!IsValidEmail(email) || password.Length < 6 || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ, mật khẩu (ít nhất 6 ký tự) và chọn vai trò.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleUiEnabled(false);
            Cursor = Cursors.WaitCursor;

            string idToken = null;

            try
            {
                // BƯỚC 1: TẠO TÀI KHOẢN TRÊN FIREBASE AUTH
                var registerResult = await RegisterWithEmailPasswordAsync(email, password);

                if (!registerResult.Success)
                {
                    string thongBaoLoi = registerResult.ErrorMessage switch
                    {
                        "EMAIL_EXISTS" => "Email này đã tồn tại.",
                        "WEAK_PASSWORD" => "Mật khẩu quá yếu (ít nhất 6 ký tự).",
                        _ => $"Lỗi đăng ký: {registerResult.ErrorMessage}"
                    };
                    MessageBox.Show(thongBaoLoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                idToken = registerResult.IdToken; // Lấy token
                string localId = registerResult.LocalId; // Lấy UID

                // BƯỚC 2: TẠO VÀ GỬI OTP (LUỒNG MỚI)
                string otpCode = new Random().Next(100000, 999999).ToString();

                MessageBox.Show("Đang gửi mã OTP đến email của bạn...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bool emailSent = await _emailService.SendVerificationCodeAsync(email, otpCode);

                if (!emailSent)
                {
                    MessageBox.Show("Không thể gửi mã xác minh. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Vì không gửi được mail, chúng ta nên xóa tài khoản vừa tạo
                    await DeleteUserAsync(idToken);
                    return;
                }

                // BƯỚC 3: MỞ FORM OTP ĐỂ XÁC MINH
                // Tạo đối tượng để lưu vào DB (nếu xác minh thành công)
                var userToSave = new { Email = email, Role = role, CreatedDate = DateTime.UtcNow };

                using (var otpForm = new frmXacMinhOTP(otpCode, idToken, localId,email, role, firebaseDatabaseUrl))
                {
                    var dialogResult = otpForm.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        
                        MessageBox.Show("Đăng ký và xác minh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // Người dùng đã đóng form OTP (hoặc xác minh thất bại)
                        MessageBox.Show("Quá trình đăng ký đã bị hủy.", "Đã hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // BƯỚC 4: XÓA TÀI KHOẢN KHỎI AUTH VÌ KHÔNG XÁC MINH
                        await DeleteUserAsync(idToken);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Nếu có lỗi và đã tạo user, hãy xóa đi
                if (idToken != null)
                {
                    await DeleteUserAsync(idToken);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                ToggleUiEnabled(true);
            }
        }

        // *** HÀM MỚI ***
        // Hàm này dùng để xóa user khỏi Firebase Auth nếu họ hủy OTP
        private async Task DeleteUserAsync(string idToken)
        {
            try
            {
                using var httpClient = new HttpClient();
                var payload = new { idToken = idToken };
                var json = JsonSerializer.Serialize(payload);
                await httpClient.PostAsync(
                    $"https://identitytoolkit.googleapis.com/v1/accounts:delete?key={webApiKey}",
                    new StringContent(json, Encoding.UTF8, "application/json")
                );
            }
            catch (Exception ex)
            {
                // Ghi log lỗi xóa user (không cần báo cho người dùng)
                Debug.WriteLine($"Lỗi khi dọn dẹp user: {ex.Message}");
            }
        }

        // --- CÁC HÀM CŨ GIỮ NGUYÊN ---

        // (Hàm này giữ nguyên)
        private async Task<(bool Success, string IdToken, string LocalId, string ErrorMessage)> RegisterWithEmailPasswordAsync(string email, string password)
        {
            // ... (Giữ nguyên code của bạn)
            using var httpClient = new HttpClient();
            var payload = new { email = email, password = password, returnSecureToken = true };
            var json = JsonSerializer.Serialize(payload);
            HttpResponseMessage response;
            try
            {
                response = await httpClient.PostAsync(
                    $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={webApiKey}",
                    new StringContent(json, Encoding.UTF8, "application/json")
                );
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"HTTP error calling signUp: {httpEx}");
                return (false, null, null, "Lỗi kết nối đến Firebase.");
            }
            string body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    using var doc = JsonDocument.Parse(body);
                    if (doc.RootElement.TryGetProperty("error", out var err) && err.TryGetProperty("message", out var msg))
                    {
                        return (false, null, null, msg.GetString());

                    }
                }
                catch (JsonException) { /* ignore parsing errors */ }
                return (false, null, null, "Đăng ký không thành công.");
            }
            try
            {
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;
                var idToken = root.GetProperty("idToken").GetString();
                var localId = root.GetProperty("localId").GetString();
                return (true, idToken, localId, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error parsing signUp response: {ex}");
                return (false, null, null, "Không thể xử lý phản hồi từ Firebase.");
            }
        }

        // (Hàm này KHÔNG CẦN DÙNG NỮA, nhưng có thể giữ lại)
        private async Task SendVerificationEmailAsync(string idToken)
        {
            // ... (Code cũ của bạn, chúng ta không gọi hàm này nữa)
        }

        // (Hàm này giữ nguyên)
        private static bool IsValidEmail(string email)
        {
            try { _ = new MailAddress(email); return true; } catch { return false; }
        }

        // (Hàm này giữ nguyên)
        private void ToggleUiEnabled(bool enabled)
        {
            txtNewEmail.Enabled = enabled;
            txtNewPassword.Enabled = enabled;
            btnRegister.Enabled = enabled;
            rbSinhVien.Enabled = enabled;
            rbGiangVien.Enabled = enabled;
            gbRole.Enabled = enabled;
        }

        // (Hàm này giữ nguyên)
        private void RegisterForm_Load(object sender, EventArgs e) { }
        private void txtNewPassword_TextChanged(object sender, EventArgs e) { }

        // (Hàm này giữ nguyên)
        private void linkLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}