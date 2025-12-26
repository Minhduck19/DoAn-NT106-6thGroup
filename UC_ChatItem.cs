using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace APP_DOAN
{
    public partial class UC_ChatItem : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string MessageId { get; set; } // Fixed property name

        public event EventHandler<string> RequestUnsend;
        private bool _isMe;
        private int _maxImageSize = 300;
        public UC_ChatItem()
        {
            InitializeComponent();
            ContextMenuStrip menu = new ContextMenuStrip();
            var itemXoa = menu.Items.Add("Thu hồi tin nhắn");
            itemXoa.Click += (s, e) => RequestUnsend?.Invoke(this, this.MessageId); // Fixed property name

            this.ContextMenuStrip = menu;
            picImage.LoadCompleted += PicImage_LoadCompleted;
        }

        public void SetMessage(string text, bool isMe, string status, string type = "text")
        {
            // Cấu hình
            int doCongGoc = 20; // Độ bo tròn
            int padding = 12;   // Khoảng cách từ viền bong bóng vào chữ
            int rightPadding = 10; // Padding phải

            _isMe = isMe;

            // Reset Control
            if (lblMessage.Parent != panelBubble)
            {
                panelBubble.Controls.Add(lblMessage);
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Dock = DockStyle.None;
            }

            if (type == "image")
            {
                // --- XỬ LÝ ẢNH ---
                panelBubble.Visible = false;
                lblMessage.Visible = false;
                picImage.Visible = true;

                if (picImage.Parent != this) picImage.Parent = this;
                picImage.BringToFront();

                // Đặt tạm kích thước placeholder
                picImage.Size = new Size(200, 150);
                
                // Vị trí placeholder - GIỮ NGUYÊN (sẽ thay đổi sau khi load)
                picImage.Location = new Point(10, 5);
                
                picImage.Image = null;
                picImage.BackColor = Color.LightGray;

                // BẮT ĐẦU TẢI ẢNH
                try { picImage.LoadAsync(text); } catch { }
            }
            else
            {
                // --- XỬ LÝ TEXT ---
                picImage.Visible = false;
                panelBubble.Visible = true;
                lblMessage.Visible = true;

                // 1. Setup nội dung
                lblMessage.Text = text;
                lblMessage.MaximumSize = new Size((int)(this.Width * 0.65), 0);
                lblMessage.AutoSize = true;

                // 2. Tính kích thước bong bóng bao quanh chữ
                panelBubble.Width = lblMessage.Width + (padding * 2);
                panelBubble.Height = lblMessage.Height + (padding * 2);

                // 3. Đặt Text nằm giữa bong bóng
                lblMessage.Location = new Point(padding, padding);

                // 4. Màu sắc & Vị trí
                if (isMe)
                {
                    // MÌNH GỬI: Nền Xanh - Chữ Trắng
                    panelBubble.FillColor = Color.FromArgb(0, 118, 212);
                    lblMessage.ForeColor = Color.White;
                    panelBubble.Location = new Point(this.Width - panelBubble.Width - rightPadding, 5);
                }
                else
                {
                    // NGƯỜI KHÁC: Nền Xám - Chữ Đen
                    panelBubble.FillColor = Color.FromArgb(229, 229, 234);
                    lblMessage.ForeColor = Color.Black;
                    panelBubble.Location = new Point(rightPadding, 5);
                }

                // 5. Bo góc bong bóng
                LamTronGoc(panelBubble, doCongGoc);
            }

            // --- TÍNH CHIỀU CAO CONTROL ---
            Control doiTuongCuoi = (type == "image") ? (Control)picImage : panelBubble;

            // Status (Đã xem/Đã gửi)
            if (isMe && lblStatus != null)
            {
                lblStatus.Visible = true;
                lblStatus.Text = (status == "read") ? "Đã xem" : "Đã gửi";
                lblStatus.ForeColor = Color.Gray;
                lblStatus.Location = new Point(this.Width - lblStatus.Width - 15, doiTuongCuoi.Bottom + 3);
                this.Height = lblStatus.Bottom + 10;
            }
            else
            {
                if (lblStatus != null) lblStatus.Visible = false;
                this.Height = doiTuongCuoi.Bottom + 10;
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Hàm cắt góc cho mọi Control (Panel, PictureBox, Button...)
        private void LamTronGoc(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();

            // Tạo 4 góc bo tròn
            path.AddArc(0, 0, radius, radius, 180, 90);                         // Góc trên-trái
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);    // Góc trên-phải
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90); // Góc dưới-phải
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);    // Góc dưới-trái

            path.CloseFigure();

            // Áp dụng vùng cắt (Region) vào control
            control.Region = new Region(path);
        }
        private void PicImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (picImage.Image == null) return;

            // 1. Lấy kích thước thật của ảnh gốc
            int imgW = picImage.Image.Width;
            int imgH = picImage.Image.Height;

            // 2. Tính toán kích thước hiển thị mới (Giữ nguyên tỷ lệ)
            int newWidth, newHeight;

            if (imgW > imgH) // Ảnh ngang (Landscape)
            {
                newWidth = _maxImageSize;
                newHeight = (int)((double)imgH / imgW * _maxImageSize);
            }
            else // Ảnh dọc (Portrait) hoặc Vuông
            {
                newHeight = _maxImageSize;
                newWidth = (int)((double)imgW / imgH * _maxImageSize);
            }

            // 3. ĐẢM BẢO ẢNH KHÔNG VƯỢT QUÁ CHIỀU RỘNG CONTROL
            int rightPadding = 10;
            // Để dư 10px ở lề trái AND 10px ở lề phải
            int maxAllowedWidth = this.Width - (rightPadding * 2);
    
            if (newWidth > maxAllowedWidth)
            {
                float scale = (float)maxAllowedWidth / newWidth;
                newWidth = maxAllowedWidth;
                newHeight = (int)(newHeight * scale);
            }

            // 4. Áp dụng kích thước mới cho PictureBox
            picImage.Size = new Size(newWidth, newHeight);

            // 5. Căn chỉnh vị trí - BỎ Math.Max() để ảnh ở đúng vị trí phải
            if (_isMe)
            {
                // MÌNH GỬI: Ảnh căn phải (Right edge = this.Width - 10)
                // Left edge = this.Width - picImage.Width - 10
                int xPos = this.Width - picImage.Width - rightPadding;
                picImage.Location = new Point(xPos, 5);
            }
            else
            {
                // NGƯỜI KHÁC: Ảnh căn trái (Left edge = 10)
                picImage.Location = new Point(rightPadding, 5);
            }

            // 6. Bo góc lại
            LamTronGoc(picImage, 20);

            // 7. Cập nhật chiều cao UserControl
            int statusOffset = (lblStatus != null && lblStatus.Visible) ? lblStatus.Height + 5 : 0;

            // Đặt lại vị trí status nếu có
            if (lblStatus != null && lblStatus.Visible)
            {
                lblStatus.Location = new Point(this.Width - lblStatus.Width - 10, picImage.Bottom + 2);
            }

            this.Height = picImage.Bottom + statusOffset + 10;
        }
        private void UC_ChatItem_Resize(object sender, EventArgs e)
        {
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void panelBubble_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}