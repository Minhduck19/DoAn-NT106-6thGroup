using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace APP_DOAN
{
    public partial class frmXacMinhOTP : Form
    {

        private readonly string _expectedCode;
        private readonly string _idToken;
        private readonly string _localId;
        private readonly object _userToSave;
        private readonly string _firebaseDatabaseUrl;
        private readonly string _email;
        private readonly string _role;

        /// <summary>
        /// Constructor để nhận dữ liệu từ Form Đăng Ký
        /// </summary>
        public frmXacMinhOTP(string expectedCode, string idToken, string localId, string email, string role, string dbUrl)
        {
            InitializeComponent();

            // Gán các giá trị nhận được
            _expectedCode = expectedCode;
            _idToken = idToken;
            _localId = localId;
            _firebaseDatabaseUrl = dbUrl;

            // *** GÁN 2 GIÁ TRỊ MỚI ĐỂ SỬA LỖI ***
            _email = email;
            _role = role;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút "Xác Minh"
        /// </summary>

        private void btnXacMinh_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() != _expectedCode)
            {
                MessageBox.Show("Mã OTP không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            this.Hide();

            // Biến để lưu kết quả
            DialogResult infoResult = DialogResult.Cancel;

            // *** ĐIỀU HƯỚNG THEO VAI TRÒ (ROLE) ***
            if (_role == "SinhVien")
            {
                // Mở form Sinh Viên
                using (var infoForm = new frmDangKyThongTin(_idToken, _localId, _email, _role, _firebaseDatabaseUrl))
                {
                    infoResult = infoForm.ShowDialog();
                }
            }
            else if (_role == "GiangVien")
            {
                // Mở form Giảng Viên - thêm email và role
                using (var infoFormGV = new frmDangKyThongTinGV(_localId, _idToken, _email, _role))
                {
                    infoResult = infoFormGV.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Vai trò không xác định.");
            }

            // Gửi kết quả (OK hoặc Cancel) về cho RegisterForm
            this.DialogResult = infoResult;
            this.Close();
        }

        private void frmXacMinhOTP_Load(object sender, EventArgs e)
        {

            txtOTP.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}