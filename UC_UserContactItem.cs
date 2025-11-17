using System;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class UC_UserContactItem : UserControl
    {
        // Biến để lưu thông tin của người này
        public string UserId { get; private set; }
        public string HoTen { get; private set; }

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
        public void SetData(string uid, string hoTen, string lastMessage, string timestamp, int unreadCount = 0)
        {
            this.UserId = uid;
            this.HoTen = hoTen;

            lblHoTen.Text = hoTen;
            lblLastMessage.Text = lastMessage;
            lblTimestamp.Text = timestamp;

            // Ẩn/hiện thông báo tin nhắn mới
            btnNotification.Text = unreadCount.ToString();
            btnNotification.Visible = (unreadCount > 0);
        }

        // Khi UserControl được click
        private void OnClick(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện UserClicked
            UserClicked?.Invoke(this, e);
        }

        // (Tùy chọn) Thêm hiệu ứng hover
        private void UC_UserContactItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void UC_UserContactItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {

        }
    }
}