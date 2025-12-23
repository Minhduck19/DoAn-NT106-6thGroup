using System;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class UC_UserContactItem : UserControl
    {
        public string UserId { get; private set; }
        public string HoTen { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }

        public event EventHandler UserClicked;

        private Panel pnlOnlineStatus;

        public UC_UserContactItem()
        {
            InitializeComponent();

            // Indicator trạng thái online
            pnlOnlineStatus = new Panel();
            pnlOnlineStatus.Size = new Size(12, 12);
            pnlOnlineStatus.BackColor = Color.Gray; // offline mặc định
            pnlOnlineStatus.Location = new Point(5, 5);
            pnlOnlineStatus.BorderStyle = BorderStyle.None;
            pnlOnlineStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlOnlineStatus.Region = new Region(new System.Drawing.Drawing2D.GraphicsPath(
                new PointF[] { new PointF(0, 6), new PointF(6, 0), new PointF(12, 6), new PointF(6, 12) },
                new byte[] {
                    (byte)System.Drawing.Drawing2D.PathPointType.Start,
                    (byte)System.Drawing.Drawing2D.PathPointType.Line,
                    (byte)System.Drawing.Drawing2D.PathPointType.Line,
                    (byte)System.Drawing.Drawing2D.PathPointType.Line
                }));
            this.Controls.Add(pnlOnlineStatus);

            // Click cho tất cả control con
            this.Click += OnClick;
            lblHoTen.Click += OnClick;
            lblLastMessage.Click += OnClick;
            picAvatar.Click += OnClick;
        }

        // Đảm bảo tên biến trong ngoặc (uid, hoTen, email...) phải Y CHANG bên kia gọi
        public void SetData(string uid, string hoTen, string email, string role, string lastMessage, string timestamp, int unreadCount)
        {
            // Gán dữ liệu vào biến nội bộ (để dùng cho Search)
            this.UserId = uid;     // Nếu bên kia gọi uid, bên này phải đón bằng uid
            this.HoTen = hoTen;
            this.Email = email;
            this.Role = role;

            // Gán lên giao diện
            lblHoTen.Text = hoTen;
            lblLastMessage.Text = lastMessage;

            // Xử lý timestamp (nếu rỗng thì ẩn)
            lblTimestamp.Text = timestamp;

            // Xử lý số tin nhắn chưa đọc
            if (unreadCount > 0)
            {
                btnNotification.Text = unreadCount.ToString();
                btnNotification.Visible = true;
            }
            else
            {
                btnNotification.Visible = false;
            }
        }

        public void SetOnlineStatus(bool isOnline)
        {
            pnlOnlineStatus.BackColor = isOnline ? Color.LimeGreen : Color.Gray;
        }

        private void OnClick(object sender, EventArgs e)
        {
            UserClicked?.Invoke(this, e);
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected)
            {
                this.BackColor = Color.FromArgb(230, 240, 255); 
            }
            else
            {
                this.BackColor = Color.Transparent;
            }
        }

        

        public void Deselect()
        {
            this.BackColor = Color.Transparent;
        }

        private void UC_UserContactItem_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor != Color.FromArgb(230, 240, 255))
                this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void UC_UserContactItem_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor != Color.FromArgb(230, 240, 255))
                this.BackColor = Color.Transparent;
        }
    }
}
