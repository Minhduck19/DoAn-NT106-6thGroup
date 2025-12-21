using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth.Requests;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN
{
    public partial class LoginForm : Form
    {
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        public LoginForm()
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(webApiKey) || webApiKey.Contains("YOUR_KEY"))
            {
                MessageBox.Show("Lỗi: webApiKey chưa được cấu hình.", "Lỗi Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
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
                // 1. Đăng nhập (Auth)
                var loginResult = await SignInWithEmailPasswordAsync(email, password);
                if (!loginResult.Success)
                {
                    HandleFirebaseError(loginResult.ErrorMessage);
                    return;
                }
                string idToken = loginResult.IdToken;
                string uid = loginResult.LocalId;

                User userProfile = await GetUserProfileAsync(uid, idToken);
                if (userProfile == null)
                {
                    MessageBox.Show("Đăng nhập thành công nhưng không tìm thấy hồ sơ (Database).", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string hoTen = userProfile.HoTen;
                string userRole = userProfile.Role;


                this.Hide();
                if (userRole == "GiangVien")
                {

                    using (MainForm_GiangVien mainFormGV = new MainForm_GiangVien(uid, hoTen, idToken))
                    {
                        mainFormGV.ShowDialog();
                    }
                }
                else if (userRole == "SinhVien")
                {

                    using (MainForm mainFormSV = new MainForm(uid, hoTen, email, idToken))
                    {
                        mainFormSV.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Vai trò không xác định.", "Lỗi Vai Trò", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                    return;
                }

                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleUiEnabled(true);
                Cursor = Cursors.Default;
            }
        }


        private async Task<User> GetUserProfileAsync(string uid, string idToken)
        {
            try
            {

                var authClient = new FirebaseClient(
                    firebaseDatabaseUrl,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(idToken)
                    });


                var user = await authClient
                    .Child("Users")
                    .Child(uid)
                    .OnceSingleAsync<User>();

                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi lấy profile: {ex.Message}");
                return null;
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
            this.Close();
        }

        private void linkRegister_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
            this.Show();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ForgotPasswordForm forgotpw = new ForgotPasswordForm())
            {
                forgotpw.ShowDialog();
            }
            this.Show();

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlLoginCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}