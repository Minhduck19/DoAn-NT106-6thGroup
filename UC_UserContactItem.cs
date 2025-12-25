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

            // Indicator trạng thái online (Giữ nguyên logic vẽ của bạn)
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
            pnlOnlineStatus.BringToFront();

            // Click cho tất cả control con
            this.Click += OnClick;
            lblHoTen.Click += OnClick;
            lblLastMessage.Click += OnClick;
            picAvatar.Click += OnClick;
        }

        public void SetData(string uid, string hoTen, string email, string role, string lastMessage, string timestamp, int unreadCount = 0)
        {
            this.UserId = uid;
            this.HoTen = hoTen;
            this.Email = email;
            this.Role = role;

            lblHoTen.Text = hoTen;
            lblLastMessage.Text = lastMessage;
            lblTimestamp.Text = timestamp;

            btnNotification.Text = unreadCount.ToString();
            btnNotification.Visible = (unreadCount > 0);
        }

        // Cập nhật: Thêm Invoke để an toàn khi chạy đa luồng
        public void SetOnlineStatus(bool isOnline)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetOnlineStatus(isOnline)));
                return;
            }
            pnlOnlineStatus.BackColor = isOnline ? Color.LimeGreen : Color.Gray;
            if (isOnline) this.BackColor = Color.LightGreen; // Nếu online thì cả dòng hóa xanh để test
            else this.BackColor = Color.Transparent;
        }

        private void OnClick(object sender, EventArgs e)
        {
            UserClicked?.Invoke(this, e);
        }

        public void SetSelected(bool isSelected)
        {
            this.BackColor = isSelected ? Color.FromArgb(230, 240, 255) : Color.Transparent;
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

        private void UC_UserContactItem_Load(object sender, EventArgs e) { }

        private void lblLastMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnNotification_Click(object sender, EventArgs e)
        {

        }

        private void lblTimestamp_Click(object sender, EventArgs e)
        {

        }
        private string FormatLastOnline(long lastOnline)
        {
            var last = DateTimeOffset.FromUnixTimeMilliseconds(lastOnline).LocalDateTime;
            var diff = DateTime.Now - last;

            if (diff.TotalSeconds < 60)
                return "Vừa truy cập";
            if (diff.TotalMinutes < 60)
                return $"Hoạt động {Math.Floor(diff.TotalMinutes)} phút trước";
            if (diff.TotalHours < 24)
                return $"Hoạt động {Math.Floor(diff.TotalHours)} giờ trước";

            return $"Online {last:dd/MM/yyyy HH:mm}";
        }
        public void SetLastOnline(bool isOnline, long lastOnline)
        {
            if (isOnline)
            {
                lblTimestamp.Text = "Đang online";
                lblTimestamp.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblTimestamp.Text = FormatLastOnline(lastOnline);
                lblTimestamp.ForeColor = Color.Gray;
            }
        }

    }
}