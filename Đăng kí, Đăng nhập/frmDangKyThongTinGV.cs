using APP_DOAN.GiaoDienChinh;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APP_DOAN
{
    public partial class frmDangKyThongTinGV : Form
    {
        private readonly string _idToken;
        private readonly string _localId;
        private readonly string _email;
        private readonly string _role;
        private readonly string _firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        public GiangVienData NewGiangVienInfo { get; private set; }

        // Constructor cập nhật - thêm email và role
        public frmDangKyThongTinGV(string localId, string idToken, string email, string role)
        {
            InitializeComponent();
            _idToken = idToken;
            _localId = localId;
            _email = email;
            _role = role;
        }

        private void frmDangKyThongTinGV_Load(object sender, EventArgs e)
        {
            txtHoTen.Focus();
        }

        private async void btnHoanTat_Click(object sender, EventArgs e)
        {
            // 1. Thu thập dữ liệu
            string hoTen = txtHoTen.Text.Trim();
            string maGV = txtMaGiangVien.Text.Trim();
            string ngaySinh = dtpNgaySinh.Text;
            string khoa = cboKhoa.Text;
            string chucVu = cboChucVu.Text;
            string bang = txtBang.Text.Trim();

            // 2. Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(maGV) || string.IsNullOrEmpty(khoa))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên, Mã giảng viên, và Khoa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleUi(false);
            Cursor = Cursors.WaitCursor;

            try
            {
                // 3. Tạo đối tượng Giảng viên hoàn chỉnh để lưu
                var giangVienProfile = new
                {
                    Email = _email,
                    Role = _role,
                    HoTen = hoTen,
                    MaGiangVien = maGV,
                    NgaySinh = ngaySinh,
                    Khoa = khoa,
                    ChucVu = chucVu,
                    Bang = bang,
                    CreatedDate = DateTime.UtcNow
                };

                // 4. Kết nối Firebase với quyền xác thực (idToken)
                var authClient = new FirebaseClient(
                    _firebaseDatabaseUrl,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
                    });

                // 5. Lưu vào Realtime Database dùng UID (localId)
                await authClient
                    .Child("Users")
                    .Child(_localId)
                    .PutAsync(giangVienProfile);

                NewGiangVienInfo = new GiangVienData
                {
                    HoTen = hoTen,
                    MaGiangVien = maGV,
                    NgaySinh = ngaySinh,
                    Khoa = khoa,
                    MonHoc = chucVu,
                    Bang = bang,
                    Email = _email
                };

                MessageBox.Show("Hoàn tất đăng ký thông tin giảng viên!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi Firebase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleUi(true);
                Cursor = Cursors.Default;
            }
        }

        private void ToggleUi(bool enabled)
        {
            txtHoTen.Enabled = enabled;
            txtMaGiangVien.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            cboKhoa.Enabled = enabled;
            cboChucVu.Enabled = enabled;
            txtBang.Enabled = enabled;
            btnHoanTat.Enabled = enabled;
        }

        private void frmDangKyThongTinGV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show("Bạn có chắc muốn hủy? \nQuá trình đăng ký sẽ bị hủy bỏ.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}