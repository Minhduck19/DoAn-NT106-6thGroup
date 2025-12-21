// --- THÊM CÁC 'USING' MỚI ---
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace APP_DOAN
{
    public partial class RegisterForm : Form
    {
        private readonly string webApiKey = "AIzaSyA7fh7FLwmHFHrwchTX1gcATk1ulr45QLs";
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/"; // URL thật của bạn



        public RegisterForm()
        {
            InitializeComponent();


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

            // (Kiểm tra dữ liệu đầu vào...)
            if (!IsValidEmail(email) || password.Length < 6 || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ, mật khẩu (ít nhất 6 ký tự) và chọn vai trò.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleUiEnabled(false);
            Cursor = Cursors.WaitCursor;

            try
            {

                var registerResult = await RegisterWithEmailPasswordAsync(email, password);

                if (!registerResult.Success)
                {

                    string thongBaoLoi = registerResult.ErrorMessage switch
                    {
                        "EMAIL_EXISTS" => "Email này đã tồn tại. Vui lòng sử dụng một email khác.",
                        "WEAK_PASSWORD" => "Mật khẩu quá yếu. Vui lòng chọn mật khẩu mạnh hơn (ít nhất 6 ký tự).",
                        _ => $"Lỗi đăng ký: {registerResult.ErrorMessage}"
                    };
                    MessageBox.Show(thongBaoLoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- BƯỚC 3B: LƯU VAI TRÒ VÀO REALTIME DATABASE ---
                string idToken = registerResult.IdToken;
                string localId = registerResult.LocalId; // Đây là UID (CMND)

                var userToSave = new { Email = email, Role = role, CreatedDate = DateTime.UtcNow };

                // *** PHẦN SỬA LỖI QUAN TRỌNG NHẤT ***
                // Tạo một client MỚI, có "CMND" (idToken)
                var authClient = new FirebaseClient(
                    firebaseDatabaseUrl,
                    new FirebaseOptions
                    {
                        // "Factory" này sẽ "gắn" idToken vào yêu cầu
                        AuthTokenAsyncFactory = () => Task.FromResult(idToken)
                    });

                // Dùng client ĐÃ XÁC THỰC (authClient) để-ghi-dữ-liệu
                await authClient
                    .Child("Users")
                    .Child(localId)
                    .PutAsync(userToSave);

                // --- BƯỚC 4: HOÀN TẤT ---
                await SendVerificationEmailAsync(idToken);
                MessageBox.Show("Đăng ký thành công! Vui lòng nhập thông tin chi tiết.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form thông tin chi tiết dựa trên vai trò
                this.Hide();
                if (role == "SinhVien")
                {
                    using (frmDangKyThongTin formThongTinSV = new frmDangKyThongTin(idToken, localId, email, role, firebaseDatabaseUrl))
                    {
                        formThongTinSV.ShowDialog();
                    }
                }
                else if (role == "GiangVien")
                {
                    // Sửa dòng này: thêm 'email' vào constructor
                    using (frmDangKyThongTinGV formThongTinGV = new frmDangKyThongTinGV(localId, idToken))
                    {
                        formThongTinGV.ShowDialog();
                    }
                }

                this.Close(); // Đóng form đăng ký sau khi form thông tin đã đóng

            }
            catch (Exception ex)
            {
                // Nếu bạn vẫn thấy "Permission Denied", nó sẽ bị bắt ở đây
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ToggleUiEnabled(true);
            }
        }

        // *** HÀM NÀY GIỮ NGUYÊN (VÌ NÓ TRẢ VỀ 'LocalId' LÀ ĐÚNG) ***
        private async Task<(bool Success, string IdToken, string LocalId, string ErrorMessage)> RegisterWithEmailPasswordAsync(string email, string password)
        {
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


        private async Task SendVerificationEmailAsync(string idToken)
        {
            using var httpClient = new HttpClient();
            var content = new { requestType = "VERIFY_EMAIL", idToken = idToken };
            var json = JsonSerializer.Serialize(content);
            var response = await httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={webApiKey}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Không thể gửi email xác minh.");

            }
        }


        private static bool IsValidEmail(string email)
        {
            try { _ = new MailAddress(email); return true; } catch { return false; }
        }


        private void ToggleUiEnabled(bool enabled)
        {
            txtNewEmail.Enabled = enabled;
            txtNewPassword.Enabled = enabled;
            btnRegister.Enabled = enabled;
            rbSinhVien.Enabled = enabled;
            rbGiangVien.Enabled = enabled;
            gbRole.Enabled = enabled;
        }

        private void RegisterForm_Load(object sender, EventArgs e) { }
        private void txtNewPassword_TextChanged(object sender, EventArgs e) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}