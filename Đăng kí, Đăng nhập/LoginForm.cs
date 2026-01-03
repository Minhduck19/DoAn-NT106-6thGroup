using APP_DOAN.Services;
using Firebase.Auth.Requests;
using Firebase.Database;
using Firebase.Database.Query;
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
                var loginResult = await SignInWithEmailPasswordAsync(email, password);
                if (!loginResult.Success)
                {
                    HandleFirebaseError(loginResult.ErrorMessage);
                    return;
                }

                FirebaseApi.IdToken = loginResult.IdToken;
                FirebaseApi.CurrentUid = loginResult.LocalId;

                FirebaseService.Initialize(loginResult.IdToken);

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
                    using (MainForm_GiangVien mainFormGV = new MainForm_GiangVien(uid, hoTen, idToken, email))
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
            catch (HttpRequestException ex)
            {
                return (false, null, null, $"Lỗi kết nối: {ex.Message}");
            }

            if (!response.IsSuccessStatusCode)
            {
                return (false, null, null, "Email hoặc mật khẩu không chính xác.");
            }

            try
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<JsonElement>(jsonResult, options);

                if (result.TryGetProperty("idToken", out var idToken) &&
                    result.TryGetProperty("localId", out var localId))
                {
                    return (true, idToken.GetString(), localId.GetString(), null);
                }

                return (false, null, null, "Phản hồi không hợp lệ từ Firebase.");
            }
            catch (JsonException ex)
            {
                return (false, null, null, $"Lỗi phân tích JSON: {ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void HandleFirebaseError(string errorMessage)
        {
            MessageBox.Show($"Lỗi đăng nhập: {errorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToggleUiEnabled(bool enabled)
        {
            btnLogin.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtPassword.Enabled = enabled;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }
    }
}