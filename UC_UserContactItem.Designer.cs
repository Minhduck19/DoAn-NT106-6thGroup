namespace APP_DOAN
{
    partial class UC_UserContactItem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lblHoTen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblLastMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTimestamp = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNotification = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // picAvatar
            // 
            picAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            picAvatar.Image = Properties.Resources.avatar_trang_1_cd729c335b;
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(15, 15);
            picAvatar.Margin = new Padding(3, 4, 3, 4);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(54, 52);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblHoTen
            // 
            lblHoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHoTen.BackColor = Color.Transparent;
            lblHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoTen.Location = new Point(75, 15);
            lblHoTen.Margin = new Padding(3, 4, 3, 4);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(119, 22);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Tên Người Dùng";
            // 
            // lblLastMessage
            // 
            lblLastMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLastMessage.BackColor = Color.Transparent;
            lblLastMessage.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastMessage.ForeColor = Color.Gray;
            lblLastMessage.Location = new Point(75, 48);
            lblLastMessage.Margin = new Padding(3, 4, 3, 4);
            lblLastMessage.Name = "lblLastMessage";
            lblLastMessage.Size = new Size(121, 19);
            lblLastMessage.TabIndex = 2;
            lblLastMessage.Text = "Tin nhắn cuối cùng...";
            // 
            // lblTimestamp
            // 
            lblTimestamp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimestamp.BackColor = Color.Transparent;
            lblTimestamp.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimestamp.ForeColor = Color.DimGray;
            lblTimestamp.Location = new Point(529, 20);
            lblTimestamp.Margin = new Padding(3, 4, 3, 4);
            lblTimestamp.Name = "lblTimestamp";
            lblTimestamp.Size = new Size(29, 17);
            lblTimestamp.TabIndex = 3;
            lblTimestamp.Text = "3 giờ";
            lblTimestamp.TextAlignment = ContentAlignment.TopRight;
            // 
            // btnNotification
            // 
            btnNotification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNotification.DisabledState.BorderColor = Color.DarkGray;
            btnNotification.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNotification.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNotification.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNotification.FillColor = Color.DodgerBlue;
            btnNotification.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnNotification.ForeColor = Color.White;
            btnNotification.Location = new Point(535, 46);
            btnNotification.Margin = new Padding(3, 4, 3, 4);
            btnNotification.Name = "btnNotification";
            btnNotification.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnNotification.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnNotification.Size = new Size(23, 21);
            btnNotification.TabIndex = 4;
            btnNotification.Text = "3";
            btnNotification.Visible = false;
            btnNotification.Click += btnNotification_Click;
            // 
            // UC_UserContactItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnNotification);
            Controls.Add(lblTimestamp);
            Controls.Add(lblLastMessage);
            Controls.Add(lblHoTen);
            Controls.Add(picAvatar);
            Cursor = Cursors.Hand;
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_UserContactItem";
            Size = new Size(600, 88);
            Load += UC_UserContactItem_Load;
            MouseEnter += UC_UserContactItem_MouseEnter;
            MouseLeave += UC_UserContactItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHoTen;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLastMessage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimestamp;
        private Guna.UI2.WinForms.Guna2CircleButton btnNotification;
    }
}