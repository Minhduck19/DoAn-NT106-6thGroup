using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace APP_DOAN
{
    public partial class UC_ChatItem : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string MessageId { get; set; }
        
        public bool IsMe { get; private set; }

        public event EventHandler<string> RequestUnsend;
        private bool _isMe;
        private int _maxImageSize = 300;

        private PictureBox picImage = new PictureBox();
        private UC_FileMessage _fileMessage = null;
        private string _avatarUrl = "";

        public UC_ChatItem()
        {
            InitializeComponent();
            ContextMenuStrip menu = new ContextMenuStrip();
            var itemXoa = menu.Items.Add("Thu hồi tin nhắn");
            itemXoa.Click += (s, e) => RequestUnsend?.Invoke(this, this.MessageId);

            this.ContextMenuStrip = menu;
            
            // Cấu hình PictureBox cho ảnh
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.BackColor = Color.LightGray;
            picImage.Visible = false;
            this.Controls.Add(picImage);
            
            picImage.LoadCompleted += PicImage_LoadCompleted;
            picImage.Click += PicImage_Click;
        }

        // Mở form xem ảnh khi click vào ảnh
        private void PicImage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentImageUrl) && picImage.Image != null)
            {
                ImageViewerForm viewer = new ImageViewerForm(_currentImageUrl);
                viewer.ShowDialog();
            }
        }

        private string _currentImageUrl = "";

        public void SetMessage(string text, bool isMe, string status, string type)
        {
            SetMessage(text, isMe, status, type, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), null);
        }

        public void SetMessage(string text, bool isMe, string status, string type, long timestamp, long? previousTimestamp, string fileUrl = null, string fileName = null, string avatarUrl = "")
        {
            _avatarUrl = avatarUrl;
            _isMe = isMe;
            this.IsMe = isMe;  // Thêm dòng này
            
            // Cấu hình
            int doCongGoc = 20;
            int padding = 12;
            int rightPadding = 10;

            _isMe = isMe;

            // Reset Control
            if (lblMessage.Parent != panelBubble)
            {
                panelBubble.Controls.Add(lblMessage);
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Dock = DockStyle.None;
            }

            // Hiển thị nhãn thời gian khi cách nhau >= 10 phút
            Label lblTimeSeperator = null;
            bool showTimeSeparator = false;

            if (previousTimestamp.HasValue)
            {
                long timeDifferenceMs = timestamp - previousTimestamp.Value;
                long timeDifferenceMinutes = timeDifferenceMs / (1000 * 60);

                // Nếu cách nhau >= 10 phút, hiển thị thời gian
                if (timeDifferenceMinutes >= 10)
                {
                    showTimeSeparator = true;
                    lblTimeSeperator = new Label();
                    lblTimeSeperator.Name = "lblTimeSeparator";
                    lblTimeSeperator.AutoSize = true;
                    lblTimeSeperator.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
                    lblTimeSeperator.ForeColor = Color.Gray;
                    lblTimeSeperator.TextAlign = ContentAlignment.MiddleCenter;

                    // Định dạng thời gian: HH:mm
                    string timeString = ConvertTimestampToTime(timestamp);
                    lblTimeSeperator.Text = timeString;

                    this.Controls.Add(lblTimeSeperator);
                    lblTimeSeperator.Location = new Point((this.Width - lblTimeSeperator.Width) / 2, 5);
                }
            }

            if (type == "image")
            {
                // --- XỬ LÝ ẢNH ---
                panelBubble.Visible = false;
                lblMessage.Visible = false;
                picImage.Visible = true;
                picImage.BringToFront();

                // Sử dụng fileUrl nếu có, nếu không thì dùng text
                string imageUrlToLoad = !string.IsNullOrEmpty(fileUrl) ? fileUrl : text;
                _currentImageUrl = imageUrlToLoad;

                // Tải lại ảnh từ URL
                picImage.Image = null;
                picImage.SizeMode = PictureBoxSizeMode.Zoom;
                picImage.Size = new Size(200, 150);
                
                if (isMe)
                {
                    picImage.Location = new Point(this.Width - 300 - rightPadding, showTimeSeparator ? 35 : 5);
                }
                else
                {
                    picImage.Location = new Point(rightPadding, showTimeSeparator ? 35 : 5);
                }

                picImage.BackColor = Color.LightGray;
                picImage.ErrorImage = null;
                picImage.WaitOnLoad = false;

                // *** Load ảnh với error handling ***
                try 
                { 
                    if (!string.IsNullOrEmpty(imageUrlToLoad))
                    {
                        System.Diagnostics.Debug.WriteLine($"Loading image: {imageUrlToLoad}");
                        picImage.LoadAsync(imageUrlToLoad);
                    }
                    else
                    {
                        picImage.Image = new Bitmap(picImage.Width, picImage.Height);
                        picImage.BackColor = Color.DarkGray;
                        System.Diagnostics.Debug.WriteLine("Image URL is empty");
                    }
                } 
                catch (Exception ex) 
                { 
                    System.Diagnostics.Debug.WriteLine($"Error loading image: {ex.Message}");
                    picImage.BackColor = Color.Red;
                }
            }
            else if (type == "file")
            {
                // --- XỬ LÝ FILE ---
                picImage.Visible = false;
                panelBubble.Visible = false;
                lblMessage.Visible = false;

                // Tạo UC_FileMessage nếu chưa có
                if (_fileMessage == null)
                {
                    _fileMessage = new UC_FileMessage();
                    this.Controls.Add(_fileMessage);
                }

                _fileMessage.Visible = true;
                _fileMessage.SetFileData(fileUrl, fileName);

                if (isMe)
                {
                    _fileMessage.Location = new Point(this.Width - _fileMessage.Width - rightPadding, showTimeSeparator ? 35 : 5);
                }
                else
                {
                    _fileMessage.Location = new Point(rightPadding, showTimeSeparator ? 35 : 5);
                }

                _fileMessage.BringToFront();
            }
            else
            {
                // --- XỬ LÝ TEXT ---
                picImage.Visible = false;
                panelBubble.Visible = true;
                lblMessage.Visible = true;

                if (_fileMessage != null)
                    _fileMessage.Visible = false;

                lblMessage.UseCompatibleTextRendering = false;
                lblMessage.AutoEllipsis = false;

                // Font fallback: Segoe UI trước, nếu không được sẽ thử Segoe UI Emoji
                try
                {
                    lblMessage.Font = new Font("Segoe UI Emoji", 10, FontStyle.Regular);
                   
                }
                catch
                {
                    lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }

                lblMessage.Text = text;

                lblMessage.MaximumSize = new Size((int)(this.Width * 0.65), 0);
                lblMessage.AutoSize = true;

                panelBubble.Width = lblMessage.Width + (padding * 2);
                panelBubble.Height = lblMessage.Height + (padding * 2);

                lblMessage.Location = new Point(padding, padding);

                if (isMe)
                {
                    panelBubble.FillColor = Color.FromArgb(0, 118, 212);
                    lblMessage.ForeColor = Color.White;
                    panelBubble.Location = new Point(this.Width - panelBubble.Width - rightPadding, showTimeSeparator ? 35 : 5);
                }
                else
                {
                    panelBubble.FillColor = Color.FromArgb(229, 229, 234);
                    lblMessage.ForeColor = Color.Black;
                    panelBubble.Location = new Point(rightPadding, showTimeSeparator ? 35 : 5);
                }

                LamTronGoc(panelBubble, doCongGoc);
            }

            // --- TÍnh chiều cao control ---
            Control doiTuongCuoi;
            if (type == "image")
                doiTuongCuoi = picImage;
            else if (type == "file")
                doiTuongCuoi = _fileMessage;
            else
                doiTuongCuoi = panelBubble;

            int timeSeparatorHeight = showTimeSeparator ? 30 : 0;

            // Status và Avatar - quản lý bởi frmMainChat
            // Mặc định ẩn status, để frmMainChat quyết định hiển thị
            if (lblStatus != null) 
                lblStatus.Visible = false;

            picAvatarStatus.Visible = false;
            
            // Tính chiều cao: thêm khoảng cách cho avatar/status nếu cần
            int extraHeight = 0;
            if (!_isMe) // Có thể hiển thị avatar cho tin nhắn của người khác
            {
                extraHeight = 35; // Khoảng cách cho avatar
            }
            else // Có thể hiển thị status cho tin nhắn của mình
            {
                extraHeight = 25; // Khoảng cách cho status
            }
            
            this.Height = doiTuongCuoi.Bottom + 10 + timeSeparatorHeight + extraHeight;
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

        private void LamTronGoc(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void PicImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (picImage.Image == null) return;

            int imgW = picImage.Image.Width;
            int imgH = picImage.Image.Height;

            int newWidth, newHeight;

            if (imgW > imgH)
            {
                newWidth = _maxImageSize;
                newHeight = (int)((double)imgH / imgW * _maxImageSize);
            }
            else
            {
                newHeight = _maxImageSize;
                newWidth = (int)((double)imgW / imgH * _maxImageSize);
            }

            int rightPadding = 10;
            int maxAllowedWidth = this.Width - rightPadding;

            if (newWidth > maxAllowedWidth)
            {
                float scale = (float)maxAllowedWidth / newWidth;
                newWidth = maxAllowedWidth;
                newHeight = (int)(newHeight * scale);
            }

            picImage.Size = new Size(newWidth, newHeight);

            if (_isMe)
            {
                int xPos = this.Width - picImage.Width - rightPadding;
                picImage.Location = new Point(xPos, 5);
            }
            else
            {
                picImage.Location = new Point(rightPadding, 5);
            }

            LamTronGoc(picImage, 20);

            int statusOffset = (lblStatus != null && lblStatus.Visible) ? lblStatus.Height + 5 : 0;

            if (lblStatus != null && lblStatus.Visible)
            {
                lblStatus.Location = new Point(this.Width - lblStatus.Width - 10, picImage.Bottom + 2);
            }

            this.Height = picImage.Bottom + statusOffset + 10;
        }

        private string ConvertTimestampToTime(long timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(timestamp);
            dateTime = dateTime.ToLocalTime();
            return dateTime.ToString("HH:mm");
        }

        private void UC_ChatItem_Resize(object sender, EventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
        private void panelBubble_Paint(object sender, PaintEventArgs e) { }
        private void guna2PictureBox1_Click(object sender, EventArgs e) { }

        private void UC_ChatItem_Load(object sender, EventArgs e)
        {

        }

        public void ShowStatus()
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "[Đã gửi]";
                lblStatus.ForeColor = Color.Gray;
                lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblStatus.AutoSize = true;
                lblStatus.Visible = true;

                // Đặt status dưới tin nhắn của mình
                if (_isMe)
                {
                    // Tính vị trí dưới panelBubble
                    lblStatus.Location = new Point(
                        panelBubble.Right - lblStatus.Width,
                        panelBubble.Bottom + 5
                    );
                }
                
                this.Invalidate();
            }
        }

        /// <summary>
        /// Hiển thị avatar dưới tin nhắn của người khác
        /// </summary>
        public void ShowAvatarBelow()
        {
            if (picAvatarStatus != null && !string.IsNullOrEmpty(_avatarUrl))
            {
                picAvatarStatus.Visible = true;
                picAvatarStatus.ImageLocation = _avatarUrl;

                // Đặt avatar dưới bubble, căn phải nếu là tin nhắn của mình, căn trái nếu là người khác
                if (_isMe)
                {
                    // Avatar ở phía dưới bên phải cho tin nhắn của mình
                    picAvatarStatus.Location = new Point(
                        panelBubble.Right - picAvatarStatus.Width,
                        panelBubble.Bottom + 5
                    );
                }
                else
                {
                    // Avatar ở phía dưới bên trái cho tin nhắn của người khác
                    picAvatarStatus.Location = new Point(
                        10,
                        panelBubble.Bottom + 5
                    );
                }
            }
        }
        public void HideStatus()
        {
            if (lblStatus != null)
            {
                lblStatus.Visible = false;
            }
        }

        /// <summary>
        /// Ẩn avatar
        /// </summary>
        public void HideAvatar()
        {
            if (picAvatarStatus != null)
            {
                picAvatarStatus.Visible = false;
            }
        }
    }
}