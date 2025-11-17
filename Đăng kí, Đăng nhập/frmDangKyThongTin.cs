// Tên file: frmDangKyThongTin.cs
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

// Đảm bảo namespace này khớp với project của bạn
namespace APP_DOAN
{
    public partial class frmDangKyThongTin : Form
    {
        // Biến lưu trữ thông tin xác thực và thông tin cơ bản
        private readonly string _idToken;
        private readonly string _localId;
        private readonly string _email;
        private readonly string _role;
        private readonly string _firebaseDatabaseUrl;

        public frmDangKyThongTin(string idToken, string localId, string email, string role, string dbUrl)
        {
            InitializeComponent();
            _idToken = idToken;
            _localId = localId;
            _email = email;
            _role = role;
            _firebaseDatabaseUrl = dbUrl;
        }

        private void frmDangKyThongTin_Load(object sender, EventArgs e)
        {
            

            // Focus vào ô Họ Tên
            txtHoTen.Focus();
        }

        private async void btnHoanTat_Click(object sender, EventArgs e)
        {
            // 1. Thu thập dữ liệu
            string hoTen = txtHoTen.Text.Trim();
            string mssv = txtMSSV.Text.Trim();
            string lop = txtLop.Text.Trim();
            string ngaySinh = dtpNgaySinh.Text; // Lấy dạng chuỗi (vd: "17/11/2025")
            string nganhHoc = cboNganhHoc.Text;

            // 2. Kiểm tra dữ liệu (Validation)
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(lop))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên, MSSV, và Lớp.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleUi(false);
            Cursor = Cursors.WaitCursor;

            try
            {
                // 3. Tạo đối tượng hoàn chỉnh để lưu
                var fullUserProfile = new
                {
                    Email = _email,
                    Role = _role,
                    HoTen = hoTen,
                    MSSV = mssv,
                    Lop = lop,
                    NgaySinh = ngaySinh,
                    NganhHoc = nganhHoc,
                    CreatedDate = DateTime.UtcNow // Ngày tạo tài khoản
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
                    .Child(_localId) // Dùng UID làm key
                    .PutAsync(fullUserProfile);

                MessageBox.Show("Hoàn tất đăng ký thông tin!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi Firebase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleUi(true);
                Cursor = Cursors.Default;
            }
        }

        private void ToggleUi(bool enabled)
        {
            txtHoTen.Enabled = enabled;
            txtMSSV.Enabled = enabled;
            txtLop.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            cboNganhHoc.Enabled = enabled;
            btnHoanTat.Enabled = enabled;
        }

        // Xử lý nếu người dùng bấm 'X' (Hủy)
        private void frmDangKyThongTin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                // Nếu không phải là bấm "Hoàn tất" (ví dụ: bấm 'X')
                var result = MessageBox.Show("Bạn có chắc muốn hủy? \nQuá trình đăng ký sẽ bị hủy bỏ.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Ngăn không cho form đóng
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel; // Báo hủy
                }
            }
        }

        private void cboNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}