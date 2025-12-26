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
        public event EventHandler<string> DeleteConversation;
        public event EventHandler<string> MuteNotification;
        private string _fileUrl;
        private string _fileName;

        private Panel pnlOnlineStatus;
        private Label lblMessage;
        private LinkLabel lnkDownloadFile;
        private Label lblName; 

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

            lblMessage = new Label();
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(70, 35);
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = Color.Gray;
            lblMessage.Visible = false;
            this.Controls.Add(lblMessage);

            // Add and configure the lnkDownloadFile control
            lnkDownloadFile = new LinkLabel();
            lnkDownloadFile.AutoSize = true;
            lnkDownloadFile.Location = new Point(70, 55);
            lnkDownloadFile.Visible = false;
            lnkDownloadFile.LinkClicked += LnkDownloadFile_LinkClicked;
            this.Controls.Add(lnkDownloadFile);

            // Thêm và cấu hình lblName
            lblName = new Label();
            lblName.AutoSize = true;
            lblName.Location = new Point(70, 15);
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.ForeColor = Color.Black;
            this.Controls.Add(lblName);

            // Xử lý click cho tất cả control con
            this.Click += OnClick;
            lblHoTen.Click += OnClick;
            lblLastMessage.Click += OnClick;
            picAvatar.Click += OnClick;

            // Thêm tooltip cho button menu
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnMenu, "Nhấp để xem tùy chọn");
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
        private void LnkDownloadFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = _fileName;
                    saveFileDialog.Title = "Lưu file";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Download từ URL
                        using (var client = new System.Net.Http.HttpClient())
                        {
                            var fileBytes = client.GetByteArrayAsync(_fileUrl).Result;
                            System.IO.File.WriteAllBytes(saveFileDialog.FileName, fileBytes);
                            MessageBox.Show("Tải file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetFileData(string senderName, string fileName, string fileUrl, bool isCurrentUser)
        {
            lblName.Text = senderName;
            lblMessage.Text = $"📎 {fileName}";
            lblMessage.Visible = true;
            _fileUrl = fileUrl;
            _fileName = fileName;

            lnkDownloadFile.Text = $"📥 Tải: {fileName}";
            lnkDownloadFile.Visible = true;
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

        // Hiển thị menu khi click nút 3 chấm
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            
            // Thêm mục xóa cuộc trò chuyện
            var itemDelete = contextMenu.Items.Add("Xóa cuộc trò chuyện");
            itemDelete.Click += (s, args) => 
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa cuộc trò chuyện với {HoTen}?", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteConversation?.Invoke(this, UserId);
                }
            };

            // Thêm mục tắt thông báo
            var itemMute = contextMenu.Items.Add("Tắt thông báo");
            itemMute.Click += (s, args) => 
            {
                MuteNotification?.Invoke(this, UserId);
            };

            // Hiển thị menu tại vị trí cursor
            contextMenu.Show(Cursor.Position);
        }

        // Hiệu ứng hover cho button menu
        private void BtnMenu_MouseEnter(object sender, EventArgs e)
        {
            btnMenu.ForeColor = Color.FromArgb(33, 150, 243);
            btnMenu.FillColor = Color.FromArgb(240, 248, 255);
        }

        private void BtnMenu_MouseLeave(object sender, EventArgs e)
        {
            btnMenu.ForeColor = Color.Gray;
            btnMenu.FillColor = Color.Transparent;
        }
    }
}
