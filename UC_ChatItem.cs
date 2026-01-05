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

        public void SetMessage(
                string text,
                bool isMe,
                string status,
                string type,
                long timestamp,
                long? previousTimestamp,
                string fileUrl = null,
                string fileName = null,
                string avatarUrl = "",
                string senderName = "")
{
    this.SuspendLayout();

    _avatarUrl = avatarUrl;
    _isMe = isMe;
    this.IsMe = isMe;

    int radius = 20;
    int padding = 12;
    int rightPadding = 10;
    int currentY = 5;

    // Reset anchor tránh lỗi layout
    panelBubble.Anchor = AnchorStyles.None;
    picImage.Anchor = AnchorStyles.None;
    if (_fileMessage != null) _fileMessage.Anchor = AnchorStyles.None;

    // ================= TIME SEPARATOR =================
    if (previousTimestamp.HasValue)
    {
        long diffMinutes = (timestamp - previousTimestamp.Value) / (1000 * 60);
        if (diffMinutes >= 10)
        {
            Label lblTime = new Label();
            lblTime.Name = "lblTimeSeparator";
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 8);
            lblTime.ForeColor = Color.Gray;
            lblTime.Text = ConvertTimestampToTime(timestamp);

            this.Controls.Add(lblTime);
            lblTime.Location = new Point(
                (this.Width - lblTime.PreferredWidth) / 2,
                currentY
            );

            currentY = lblTime.Bottom + 5;
        }
    }

    // ================= SENDER NAME =================
    if (!isMe && !string.IsNullOrEmpty(senderName))
    {
        lblSenderName.Text = senderName;
        lblSenderName.Visible = true;
        lblSenderName.AutoSize = true;
        lblSenderName.ForeColor = Color.Gray;
        lblSenderName.Location = new Point(rightPadding, currentY);

        currentY = lblSenderName.Bottom + 2;
    }
    else
    {
        lblSenderName.Visible = false;
    }

    Control mainControl = null;

    // ================= IMAGE =================
    if (type == "image")
    {
        panelBubble.Visible = false;
        lblMessage.Visible = false;
        if (_fileMessage != null) _fileMessage.Visible = false;

        picImage.Visible = true;
        picImage.Tag = currentY;
        picImage.Image = null;

        _currentImageUrl = !string.IsNullOrEmpty(fileUrl) ? fileUrl : text;

        picImage.Location = isMe
            ? new Point(this.Width - 120, currentY)
            : new Point(rightPadding, currentY);

        picImage.Anchor = isMe
            ? AnchorStyles.Top | AnchorStyles.Right
            : AnchorStyles.Top | AnchorStyles.Left;

        try
        {
            if (!string.IsNullOrEmpty(_currentImageUrl))
                picImage.LoadAsync(_currentImageUrl);
        }
        catch { }

        mainControl = picImage;
    }

    // ================= FILE =================
    else if (type == "file")
    {
        picImage.Visible = false;
        panelBubble.Visible = false;
        lblMessage.Visible = false;

        if (_fileMessage == null)
        {
            _fileMessage = new UC_FileMessage();
            this.Controls.Add(_fileMessage);
        }

        _fileMessage.Visible = true;
        _fileMessage.SetFileData(fileUrl, fileName);

        _fileMessage.Location = isMe
            ? new Point(this.Width - _fileMessage.Width - rightPadding, currentY)
            : new Point(rightPadding, currentY);

        _fileMessage.Anchor = isMe
            ? AnchorStyles.Top | AnchorStyles.Right
            : AnchorStyles.Top | AnchorStyles.Left;

        mainControl = _fileMessage;
    }

    // ================= TEXT =================
    else
    {
        picImage.Visible = false;
        if (_fileMessage != null) _fileMessage.Visible = false;

        panelBubble.Visible = true;
        lblMessage.Visible = true;

        lblMessage.Text = text;
        lblMessage.MaximumSize = new Size((int)(this.Width * 0.65), 0); // FIX QUAN TRỌNG
        lblMessage.AutoSize = true;
        lblMessage.PerformLayout();

        panelBubble.Width = lblMessage.Width + padding * 2;
        panelBubble.Height = lblMessage.Height + padding * 2;
        lblMessage.Location = new Point(padding, padding);

        panelBubble.Location = isMe
            ? new Point(this.Width - panelBubble.Width - rightPadding, currentY)
            : new Point(rightPadding, currentY);

        panelBubble.Anchor = isMe
            ? AnchorStyles.Top | AnchorStyles.Right
            : AnchorStyles.Top | AnchorStyles.Left;

        panelBubble.FillColor = isMe
            ? Color.FromArgb(0, 118, 212)
            : Color.FromArgb(229, 229, 234);

        lblMessage.ForeColor = isMe ? Color.White : Color.Black;

        LamTronGoc(panelBubble, radius);

        mainControl = panelBubble;
    }

    // ================= SET HEIGHT UC (KHÔNG set cho IMAGE) =================
    if (mainControl != null && type != "image")
    {
        this.Height = mainControl.Bottom + 10;
    }

    this.ResumeLayout(true);
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

        public void ShowSenderName(string senderName)
        {
            if (lblSenderName != null)
            {
                lblSenderName.Text = senderName;
                lblSenderName.Visible = true;
            }
        }

        private void UC_ChatItem_Load(object sender, EventArgs e)
        {

        }

        private void panelBubble_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}