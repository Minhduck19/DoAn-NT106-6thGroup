using System;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class UC_UserContactItem : UserControl
    {
        // Biến để lưu thông tin của người này
        public string UserId { get; private set; }
        public string HoTen { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }

        // Sự kiện (event) để thông báo cho Form Cha là "Tôi bị click!"
        public event EventHandler UserClicked;

        public UC_UserContactItem()
        {
            InitializeComponent();

            // Gắn sự kiện click cho tất cả control con
            // Để bấm vào đâu nó cũng kích hoạt sự kiện
            this.Click += OnClick;
            lblHoTen.Click += OnClick;
            lblLastMessage.Click += OnClick;
            picAvatar.Click += OnClick;
        }

        // Hàm "bơm" dữ liệu vào
        public void SetData(string uid, string hoTen, string email, string role, string lastMessage, string timestamp, int unreadCount = 0)
        {
            // Lưu lại TẤT CẢ thông tin
            this.UserId = uid;
            this.HoTen = hoTen;
            this.Email = email;
            this.Role = role;

            // Hiển thị lên giao diện
            lblHoTen.Text = hoTen;
            lblLastMessage.Text = lastMessage; // (Hiển thị tin nhắn cuối)
            lblTimestamp.Text = timestamp;

            btnNotification.Text = unreadCount.ToString();
            btnNotification.Visible = (unreadCount > 0);
        }

        // Khi UserControl được click
        private void OnClick(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện UserClicked
            UserClicked?.Invoke(this, e);
        }

        public void Select()
        {
            // Đổi màu nền thành màu "đã chọn" (ví dụ: xanh nhạt)
            this.BackColor = Color.FromArgb(230, 240, 255);
        }

        // Hàm MỚI: Dùng để "bỏ chọn" (Hàm gây lỗi)
        public void Deselect()
        {
            // Trả về màu nền mặc định
            this.BackColor = Color.Transparent; // (Hoặc Color.White)
        }

        // SỬA 2 HÀM NÀY (để nó không "đè" màu khi đang chọn)
        private void UC_UserContactItem_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor != Color.FromArgb(230, 240, 255)) // Nếu chưa select
            {
                this.BackColor = Color.FromArgb(245, 245, 245); // Màu hover
            }
        }

        private void UC_UserContactItem_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor != Color.FromArgb(230, 240, 255)) // Nếu chưa select
            {
                this.BackColor = Color.Transparent; // Trả về mặc định
            }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {

        }

        private void lblLastMessage_Click(object sender, EventArgs e)
        {

        }

        private void UC_UserContactItem_Load(object sender, EventArgs e)
        {

        }
    }
}