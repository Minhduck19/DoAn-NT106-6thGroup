using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN
{
    public partial class LoginForm : Form
    {
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/"; // URL thật của bạn

        // Không cần các thuộc tính public IdToken, UserEmail, UserRole nữa
        // vì form này sẽ tự xử lý điều hướng.

        public LoginForm()
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(webApiKey) || webApiKey.Contains("YOUR_KEY"))
            {
                MessageBox.Show("Lỗi: webApiKey chưa được cấu hình trong LoginForm.cs.", "Lỗi Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
                return;
            }
        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!IsValidEmail(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleUiEnabled(false);
            Cursor = Cursors.WaitCursor;

            try
            {
                // 1. Đăng nhập để lấy Token và UID
                var loginResult = await SignInWithEmailPasswordAsync(email, password);

                if (!loginResult.Success)
                {
                    HandleFirebaseError(loginResult.ErrorMessage);
                    return; // Dừng lại, finally sẽ kích hoạt UI
                }

                string idToken = loginResult.IdToken;
                string uid = loginResult.LocalId;

                // 2. Dùng Token để xác thực và lấy Role từ Realtime Database
                var authClient = new FirebaseClient(
                    firebaseDatabaseUrl,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(idToken)
                    });

                var userRole = await authClient
                    .Child("Users")
                    .Child(uid)
                    .Child("Role")
                    .OnceSingleAsync<string>();

                if (userRole == null)
                {
                    MessageBox.Show("Đăng nhập thành công nhưng không thể tìm thấy vai trò (Role) trong cơ sở dữ liệu.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại, finally sẽ kích hoạt UI
                }

                // 3. Logic điều hướng (ĐÃ CHUYỂN TỪ GIAODIENGOC VÀO ĐÂY)

                // Ẩn form đăng nhập
                this.Hide();

                if (userRole == "GiangVien")
                {
                    using (MainForm_GiangVien mainFormGV = new MainForm_GiangVien(email, idToken))
                    {
                        mainFormGV.ShowDialog();
                    }
                }
                else if (userRole == "SinhVien")
                {
                    using (MainForm mainFormSV = new MainForm(email, idToken))
                    {
                        mainFormSV.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Vai trò không xác định. Vui lòng liên hệ quản trị viên.", "Lỗi Vai Trò", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Hiển thị lại form đăng nhập nếu vai trò lỗi
                    this.Show();
                    return; // Không đóng ứng dụng
                }

                // Sau khi MainForm (GV hoặc SV) bị đóng, ShowDialog() kết thúc
                // Ta tiến hành đóng Form đăng nhập (cũng là form chính) để kết thúc ứng dụng.
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định khi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleUiEnabled(true);
                Cursor = Cursors.Default;
            }
        }

        private async Task<(bool Success, string IdToken, string LocalId, string ErrorMessage)> SignInWithEmailPasswordAsync(string email, string password)
        {
            string signInUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={webApiKey}";
            using var httpClient = new HttpClient();
            var payload = new { email = email, password = password, returnSecureToken = true };
            var json = JsonSerializer.Serialize(payload);
            HttpResponseMessage response;
            try
            {
                response = await httpClient.PostAsync(signInUrl, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"HTTP error calling signIn: {httpEx}");
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
                catch (JsonException) { }
                return (false, null, null, "Đăng nhập không thành công.");
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
                Debug.WriteLine($"Error parsing signIn response: {ex}");
                return (false, null, null, "Không thể xử lý phản hồi từ Firebase.");
            }
        }

        private void HandleFirebaseError(string errorMessage)
        {
            string thongBaoLoi;
            switch (errorMessage)
            {
                case "INVALID_LOGIN_CREDENTIALS":
                    thongBaoLoi = "Sai Email hoặc Mật khẩu. Vui lòng thử lại.";
                    break;
                case "INVALID_PASSWORD": thongBaoLoi = "Sai mật khẩu. Vui lòng thử lại."; break;
                case "EMAIL_NOT_FOUND": thongBaoLoi = "Email này chưa được đăng ký."; break;
                case "USER_DISABLED": thongBaoLoi = "Tài khoản này đã bị vô hiệu hóa."; break;
                default: thongBaoLoi = $"Lỗi đăng nhập: {errorMessage}"; break;
            }
            MessageBox.Show(thongBaoLoi, "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static bool IsValidEmail(string email)
        {
            try { _ = new MailAddress(email); return true; } catch { return false; }
        }

        private void ToggleUiEnabled(bool enabled)
        {
            txtEmail.Enabled = enabled;
            txtPassword.Enabled = enabled;
            btnLogin.Enabled = enabled;
            btnCancel.Enabled = enabled;
            linkRegister.Enabled = enabled;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            // Vì đây là form chính, nhấn Cancel (hoặc nút X) sẽ đóng ứng dụng
            this.Close();
        }

        private void linkRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Logic này giữ nguyên, dùng để mở form đăng ký
            this.Hide();
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }

        private void linkRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}