using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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

        private bool _hasLoadedInitialMessagesForCurrentChat = false;

        public UC_ChatItem()
        {
            InitializeComponent();

            ContextMenuStrip menu = new ContextMenuStrip();
            var itemXoa = menu.Items.Add("Thu hồi tin nhắn");
            itemXoa.Click += (s, e) => RequestUnsend?.Invoke(this, this.MessageId);
            this.ContextMenuStrip = menu;

            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.BackColor = Color.LightGray;
            picImage.Visible = false;
            picImage.Cursor = Cursors.Hand;
            picImage.Enabled = true;
            this.Controls.Add(picImage);

            picImage.LoadCompleted += PicImage_LoadCompleted;
            picImage.Click -= PicImage_Click;
            picImage.Click += PicImage_Click;
        }

        private void PicImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentImageUrl))
                return;

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(_currentImageUrl)
                {
                    UseShellExecute = true
                });
            }
            catch
            {
            }
        }

        private string _currentImageUrl = "";

        public void SetMessage(string text, bool isMe, string status, string type, long timestamp, long? previousTimestamp, string fileUrl = null, string fileName = null, string avatarUrl = "")
        {
            _avatarUrl = avatarUrl;
            _isMe = isMe;
            this.IsMe = isMe;

            int doCongGoc = 20;
            int padding = 12;
            int rightPadding = 10;

            if (lblMessage.Parent != panelBubble)
            {
                panelBubble.Controls.Add(lblMessage);
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Dock = DockStyle.None;
            }

            Label lblTimeSeperator = null;
            bool showTimeSeparator = false;

            if (previousTimestamp.HasValue)
            {
                long timeDifferenceMs = timestamp - previousTimestamp.Value;
                long timeDifferenceMinutes = timeDifferenceMs / (1000 * 60);

                if (timeDifferenceMinutes >= 10)
                {
                    showTimeSeparator = true;
                    lblTimeSeperator = new Label();
                    lblTimeSeperator.Name = "lblTimeSeparator";
                    lblTimeSeperator.AutoSize = true;
                    lblTimeSeperator.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    lblTimeSeperator.ForeColor = Color.Gray;
                    lblTimeSeperator.TextAlign = ContentAlignment.MiddleCenter;
                    lblTimeSeperator.Text = ConvertTimestampToTime(timestamp);
                    this.Controls.Add(lblTimeSeperator);
                    lblTimeSeperator.Location = new Point((this.Width - lblTimeSeperator.Width) / 2, 5);
                    lblTimeSeperator.Anchor = AnchorStyles.Top;
                }
            }

            // --- XỬ LÝ LOẠI TIN NHẮN ---
            if (type == "image")
            {
                panelBubble.Visible = false;
                lblMessage.Visible = false;
                picImage.Visible = true;
                picImage.BringToFront();

                string imageUrlToLoad = !string.IsNullOrEmpty(fileUrl) ? fileUrl : text;
                _currentImageUrl = imageUrlToLoad;

                picImage.Image = null;
                picImage.SizeMode = PictureBoxSizeMode.Zoom;
                picImage.Size = new Size(200, 150);

                if (isMe)
                {
                    picImage.Location = new Point(this.Width - 300 - rightPadding, showTimeSeparator ? 35 : 5);
                    picImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                }
                else
                {
                    picImage.Location = new Point(rightPadding, showTimeSeparator ? 35 : 5);
                    picImage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }

                picImage.BackColor = Color.LightGray;
                picImage.WaitOnLoad = false;
                try { if (!string.IsNullOrEmpty(imageUrlToLoad)) picImage.LoadAsync(imageUrlToLoad); } catch { picImage.BackColor = Color.Red; }
            }
            else if (type == "file")
            {
                picImage.Visible = false;
                panelBubble.Visible = false;
                lblMessage.Visible = false;

                if (_fileMessage == null) { _fileMessage = new UC_FileMessage(); this.Controls.Add(_fileMessage); }
                _fileMessage.Visible = true;
                _fileMessage.SetFileData(fileUrl, fileName);

                if (isMe)
                {
                    _fileMessage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    _fileMessage.Top = showTimeSeparator ? 35 : 5;
                    _fileMessage.Left = this.ClientSize.Width - _fileMessage.Width - rightPadding;
                }
                else
                {
                    _fileMessage.Location = new Point(rightPadding, showTimeSeparator ? 35 : 5);
                    _fileMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }
                _fileMessage.BringToFront();
            }
            else
            {
                picImage.Visible = false;
                panelBubble.Visible = true;
                lblMessage.Visible = true;
                if (_fileMessage != null) _fileMessage.Visible = false;

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
                    panelBubble.Location = new Point(0, showTimeSeparator ? 35 : 5);
                    panelBubble.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    panelBubble.Left = 0;
                    panelBubble.Top = showTimeSeparator ? 35 : 5;
                    panelBubble.Width = lblMessage.Width + (padding * 2);
                    panelBubble.Left = this.ClientSize.Width - panelBubble.Width - rightPadding;
                }
                else
                {
                    panelBubble.FillColor = Color.FromArgb(229, 229, 234);
                    lblMessage.ForeColor = Color.Black;
                    panelBubble.Location = new Point(rightPadding, showTimeSeparator ? 35 : 5);
                    panelBubble.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }
                LamTronGoc(panelBubble, doCongGoc);
            }
            Control doiTuongCuoi;
            if (type == "image") doiTuongCuoi = picImage;
            else if (type == "file") doiTuongCuoi = _fileMessage;
            else doiTuongCuoi = panelBubble;

            int timeSeparatorHeight = showTimeSeparator ? 30 : 0;
            int extraHeight = 25;

            this.Height = doiTuongCuoi.Bottom + 10 + timeSeparatorHeight + extraHeight;
        }

        public void SetStatusMode(string status, string partnerAvatarUrl)
        {
            if (lblStatus != null) lblStatus.Visible = false;
            if (picAvatarStatus != null) picAvatarStatus.Visible = false;

            Control targetBubble = panelBubble.Visible ? panelBubble : (picImage.Visible ? picImage : (Control)_fileMessage);
            if (targetBubble == null) return;

            int rightMarginX = this.Width - (picAvatarStatus != null ? picAvatarStatus.Width : 20) - 10;
            int bottomY = targetBubble.Bottom + 5;

            if (status == "seen")
            {
                if (picAvatarStatus != null)
                {
                    picAvatarStatus.Visible = true;
                    picAvatarStatus.Location = new Point(rightMarginX, bottomY);
                    picAvatarStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                    try
                    {
                        if (!string.IsNullOrEmpty(partnerAvatarUrl))
                            picAvatarStatus.LoadAsync(partnerAvatarUrl);
                        else
                            picAvatarStatus.Image = Properties.Resources.avatar_trang_1_cd729c335b1;
                    }
                    catch { picAvatarStatus.Image = Properties.Resources.avatar_trang_1_cd729c335b1; }
                }
            }
            else
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "Đã gửi";
                    lblStatus.ForeColor = Color.Gray;
                    lblStatus.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                    lblStatus.AutoSize = true;
                    lblStatus.Visible = true;
                    lblStatus.Location = new Point(this.Width - lblStatus.Width - 10, bottomY);
                    lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                }
            }
        }

        public void HideStatusAndSeen()
        {
            if (lblStatus != null) lblStatus.Visible = false;
            if (picAvatarStatus != null) picAvatarStatus.Visible = false;
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

            if (imgW > imgH) { newWidth = _maxImageSize; newHeight = (int)((double)imgH / imgW * _maxImageSize); }
            else { newHeight = _maxImageSize; newWidth = (int)((double)imgW / imgH * _maxImageSize); }

            int rightPadding = 10;
            int maxAllowedWidth = this.Width - rightPadding;
            if (newWidth > maxAllowedWidth) { float scale = (float)maxAllowedWidth / newWidth; newWidth = maxAllowedWidth; newHeight = (int)(newHeight * scale); }

            picImage.Size = new Size(newWidth, newHeight);
            bool showTimeSeparator = (this.Controls.ContainsKey("lblTimeSeparator"));
            int yPos = showTimeSeparator ? 35 : 5;

            if (_isMe)
            {
                picImage.Location = new Point(this.Width - picImage.Width - rightPadding, yPos);
                picImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                picImage.Top = showTimeSeparator ? 35 : 5;
                picImage.Left = this.ClientSize.Width - picImage.Width - rightPadding;
            }
            else
            {
                picImage.Location = new Point(rightPadding, yPos);
                picImage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }

            LamTronGoc(picImage, 20);
            this.Height = picImage.Bottom + 30;
        }

        private string ConvertTimestampToTime(long timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(timestamp);
            return dateTime.ToLocalTime().ToString("HH:mm");
        }

        public void ShowStatus() { }
        public void HideStatus() { if (lblStatus != null) lblStatus.Visible = false; }

        public void ShowAvatarBelow()
        {
            return;
        }

        public void HideAvatar() { if (picAvatarStatus != null) picAvatarStatus.Visible = false; }
    }
}