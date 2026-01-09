using APP_DOAN.Services;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic; // Cần cho Dictionary

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Student_Information : Form
    {
        private string _uid;
        private string _idToken;
        private string _email;
        private string _currentAvatarUrl = "https://i.imgur.com/7vN3FAa.png"; // Avatar mặc định

        public Student_Information(string uid, string idToken, string email)
        {
            InitializeComponent();
            _uid = uid;
            _idToken = idToken;
            _email = email;

            // Cấu hình Token
            FirebaseApi.IdToken = _idToken;
        }

        private async void Student_Information_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var rawData = await FirebaseApi.Get<Dictionary<string, object>>($"Users/{_uid}");

                if (rawData == null || rawData.Count == 0)
                {
                    MessageBox.Show("Chưa có thông tin sinh viên. Vui lòng cập nhật.");
                    txtEmail.Text = _email;
                    picAvatar.LoadAsync(_currentAvatarUrl);
                }
                else
                {
                    // Map dữ liệu vào các ô (Sử dụng hàm GetValue an toàn)
                    txtFullName.Text = GetValue(rawData, "HoTen");
                    txtStudentID.Text = GetValue(rawData, "MSSV"); // Đổi từ MaGiangVien -> MaSinhVien

                    // Nếu MaSinhVien trống, thử tìm MaGiangVien (trường hợp dùng chung User model)
                    if (string.IsNullOrEmpty(txtStudentID.Text))
                        txtStudentID.Text = GetValue(rawData, "MaGiangVien");

                    txtBirthday.Text = GetValue(rawData, "NgaySinh");
                    txtSex.Text = GetValue(rawData, "Sex");
                    txtFaculty.Text = GetValue(rawData, "Khoa");
                    txtClass.Text = GetValue(rawData, "Lop"); 

                    string fbEmail = GetValue(rawData, "Email");
                    txtEmail.Text = string.IsNullOrEmpty(fbEmail) ? _email : fbEmail;
                    txtEmail.Enabled = false;

                    // Avatar
                    string avatar = GetValue(rawData, "AvatarUrl");
                    if (!string.IsNullOrEmpty(avatar))
                    {
                        _currentAvatarUrl = avatar;
                    }
                    picAvatar.LoadAsync(_currentAvatarUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message);
            }
        }

        // Hàm hỗ trợ lấy dữ liệu an toàn từ Dictionary
        private string GetValue(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key)) return data[key]?.ToString() ?? "";
            // Thử tìm key chữ thường nếu không thấy
            string lowerKey = char.ToLower(key[0]) + key.Substring(1);
            if (data.ContainsKey(lowerKey)) return data[lowerKey]?.ToString() ?? "";
            return "";
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    // 1. Hiển thị xem trước
                    picAvatar.Image = Image.FromFile(ofd.FileName);

                    // 2. Upload lên Cloudinary (Sử dụng Helper có sẵn của bạn)
                    string cloudUrl = CloudinaryHelper.UploadImage(ofd.FileName);

                    if (!string.IsNullOrEmpty(cloudUrl))
                    {
                        _currentAvatarUrl = cloudUrl;
                        MessageBox.Show("Tải ảnh lên thành công! Hãy bấm 'Lưu' để cập nhật.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Upload ảnh thất bại.");
                        picAvatar.LoadAsync(_currentAvatarUrl); // Revert
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var oldData = await FirebaseApi.Get<User>($"Users/{_uid}");

                // Tạo object User để lưu (Map các trường SV)
                var updatedUser = new User
                {
                    Email = _email,
                    Role = "SinhVien", // Cố định Role là SinhVien
                    HoTen = txtFullName.Text.Trim(),
                    Sex = txtSex.Text.Trim(),
                    // Lưu vào trường MaSinhVien (hoặc MaGiangVien nếu dùng chung model)
                    MSSV = txtStudentID.Text.Trim(),
                    NgaySinh = txtBirthday.Text.Trim(),
                    Khoa = txtFaculty.Text.Trim(),
                    Lop = txtClass.Text.Trim(), // Lưu Lớp vào trường ChucVu hoặc Lop

                    AvatarUrl = _currentAvatarUrl, // Lưu Link Avatar

                    IsOnline = oldData?.IsOnline ?? false,
                    CreatedDate = oldData?.CreatedDate ?? DateTime.UtcNow.ToString("o")
                };
                
                bool success = await FirebaseApi.Put($"Users/{_uid}", updatedUser);

                if (success)
                {
                    await LoadDataAsync();
                    MessageBox.Show("Cập nhật hồ sơ sinh viên thành công!");
                }
                else
                    MessageBox.Show("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu trữ: " + ex.Message);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}