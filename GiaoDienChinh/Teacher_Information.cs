using APP_DOAN.Services;
using System;
using System.Collections.Generic; // Cần thư viện này để dùng Dictionary
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Teacher_Information : Form
    {
        private string _uid;
        private string _idToken;
        private string _email;
        private string _currentAvatarUrl = "https://i.imgur.com/7vN3FAa.png"; // Link mặc định

        public Teacher_Information(string uid, string idToken, string email)
        {
            InitializeComponent();
            _uid = uid;
            _idToken = idToken;
            _email = email;

            // Cấu hình Token
            FirebaseApi.IdToken = _idToken;
        }

        private async void Teacher_Information_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_uid))
            {
                MessageBox.Show("Lỗi: UID người dùng bị rỗng!", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await LoadDataAsync();
        }

        // 🔥 HÀM TẢI DỮ LIỆU "BẤT TỬ" (Chấp hết các loại lỗi tên biến)
        private async Task LoadDataAsync()
        {
            try
            {
                // 1. Lấy dữ liệu dưới dạng Dictionary (Cặp Khóa - Giá trị) thay vì Class cứng
                var rawData = await FirebaseApi.Get<Dictionary<string, object>>($"Users/{_uid}");

                if (rawData == null || rawData.Count == 0)
                {
                    // Nếu không có dữ liệu, điền email và load ảnh mặc định
                    txtEmail.Text = _email;
                    picAvatar.LoadAsync(_currentAvatarUrl);
                    return;
                }

                // 2. Tự động dò tìm tên trường (Không quan tâm Hoa/Thường)
                txtFullName.Text = GetValue(rawData, "HoTen");
                txtTeacherID.Text = GetValue(rawData, "MaGiangVien");
                txtBirthday.Text = GetValue(rawData, "NgaySinh");
                txtSex.Text = GetValue(rawData, "Sex");
                txtFaculty.Text = GetValue(rawData, "Khoa");
                txtClass.Text = GetValue(rawData, "ChucVu"); // Chức vụ
                txtBang.Text = GetValue(rawData, "Bang");

                // Email: Nếu trên Firebase có thì lấy, không thì lấy từ lúc đăng nhập
                string fireBaseEmail = GetValue(rawData, "Email");
                txtEmail.Text = string.IsNullOrEmpty(fireBaseEmail) ? _email : fireBaseEmail;

                // 3. Xử lý Avatar
                string avatarLink = GetValue(rawData, "AvatarUrl");
                if (!string.IsNullOrEmpty(avatarLink))
                {
                    _currentAvatarUrl = avatarLink;
                }
                picAvatar.LoadAsync(_currentAvatarUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm phụ trợ: Giúp lấy dữ liệu an toàn dù key viết Hoa hay thường
        private string GetValue(Dictionary<string, object> data, string key)
        {
            // Tìm chính xác ("HoTen")
            if (data.ContainsKey(key)) return data[key]?.ToString() ?? "";

            // Tìm chữ thường ("hoTen")
            string lowerKey = char.ToLower(key[0]) + key.Substring(1);
            if (data.ContainsKey(lowerKey)) return data[lowerKey]?.ToString() ?? "";

            // Tìm chữ thường hết ("hoten")
            if (data.ContainsKey(key.ToLower())) return data[key.ToLower()]?.ToString() ?? "";

            return ""; // Không tìm thấy
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                btnChangeAvatar.Text = "Đang tải...";
                btnChangeAvatar.Enabled = false;

                try
                {
                    // Hiển thị xem trước
                    picAvatar.Image = Image.FromFile(ofd.FileName);

                    // Upload lên Cloudinary
                    string cloudUrl = CloudinaryHelper.UploadImage(ofd.FileName);

                    if (!string.IsNullOrEmpty(cloudUrl))
                    {
                        _currentAvatarUrl = cloudUrl;
                        MessageBox.Show("Upload ảnh thành công! Bấm 'Lưu' để hoàn tất.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Upload thất bại. Vui lòng thử lại.");
                        picAvatar.LoadAsync(_currentAvatarUrl); // Quay về ảnh cũ
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi upload: " + ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    btnChangeAvatar.Text = "Đổi ảnh";
                    btnChangeAvatar.Enabled = true;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                // Lấy data cũ để giữ lại các trường hệ thống (IsOnline, CreatedDate)
                var oldData = await FirebaseApi.Get<User>($"Users/{_uid}");

                var updatedUser = new User
                {
                    Email = txtEmail.Text, // Lấy từ text box (hoặc biến _email)
                    Role = "GiangVien",
                    HoTen = txtFullName.Text.Trim(),
                    Sex = txtSex.Text.Trim(),
                    MaGiangVien = txtTeacherID.Text.Trim(),
                    NgaySinh = txtBirthday.Text.Trim(),
                    Khoa = txtFaculty.Text.Trim(),
                    ChucVu = txtClass.Text.Trim(),
                    Bang = txtBang.Text.Trim(),
                    AvatarUrl = _currentAvatarUrl,

                    // Giữ nguyên trạng thái cũ
                    IsOnline = oldData?.IsOnline ?? false,
                    CreatedDate = oldData?.CreatedDate ?? DateTime.UtcNow.ToString("o")
                };

                bool success = await FirebaseApi.Put($"Users/{_uid}", updatedUser);

                if (success) MessageBox.Show("Lưu hồ sơ thành công!");
                else MessageBox.Show("Lưu thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
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
    }
}