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

            // Hiển thị trạng thái online/offline dưới dạng hình thoi
            pnlOnlineStatus = new Panel();
            pnlOnlineStatus.Size = new Size(12, 12);
            pnlOnlineStatus.BackColor = Color.Gray;
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

            // Xử lý click cho tất cả control con
            this.Click += OnClick;
            lblHoTen.Click += OnClick;
            lblLastMessage.Click += OnClick;
            picAvatar.Click += OnClick;
        }

        // Gán dữ liệu contact vào control
        public void SetData(string uid, string hoTen, string email, string role, string lastMessage, string timestamp, int unreadCount)
        {
            this.UserId = uid;
            this.HoTen = hoTen;
            this.Email = email;
            this.Role = role;

            lblHoTen.Text = hoTen;
            lblLastMessage.Text = lastMessage;
            lblTimestamp.Text = timestamp;

            // Hiển thị số tin nhắn chưa đọc
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

        // Cập nhật trạng thái online/offline
        public void SetOnlineStatus(bool isOnline)
        {
            pnlOnlineStatus.BackColor = isOnline ? Color.LimeGreen : Color.Gray;
        }

        private void OnClick(object sender, EventArgs e)
        {
            UserClicked?.Invoke(this, e);
        }

        // Đánh dấu contact được chọn
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

        // Hiệu ứng hover
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
