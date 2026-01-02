namespace APP_DOAN 
{
    partial class UC_ChatItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblMessage = new Label();
            picAvatarStatus = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            panelBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarStatus).BeginInit();
            SuspendLayout();
            // 
            // panelBubble
            // 
            panelBubble.BorderRadius = 15;
            panelBubble.Controls.Add(lblMessage);
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            panelBubble.CustomizableEdges = customizableEdges1;
            panelBubble.FillColor = Color.FromArgb(33, 150, 243);
            panelBubble.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBubble.Location = new Point(3, 4);
            panelBubble.Margin = new Padding(3, 4, 3, 4);
            panelBubble.Name = "panelBubble";
            panelBubble.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelBubble.Size = new Size(315, 91);
            panelBubble.TabIndex = 0;
            panelBubble.Paint += panelBubble_Paint;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(252, 59);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(80, 22);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "[Đã gửi]";
            lblStatus.Click += lblStatus_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(10, 10);
            lblMessage.Margin = new Padding(3, 4, 3, 4);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(161, 30);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Nội dung tin nhắn";
            lblMessage.UseCompatibleTextRendering = true;
            // 
            // picAvatarStatus
            // 
            picAvatarStatus.BackColor = Color.Transparent;
            picAvatarStatus.FillColor = Color.WhiteSmoke;
            picAvatarStatus.ImageRotate = 0F;
            picAvatarStatus.Location = new Point(320, 70);
            picAvatarStatus.Name = "picAvatarStatus";
            picAvatarStatus.ShadowDecoration.CustomizableEdges = customizableEdges3;
            picAvatarStatus.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatarStatus.Size = new Size(24, 24);
            picAvatarStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatarStatus.TabIndex = 2;
            picAvatarStatus.TabStop = false;
            picAvatarStatus.Visible = false;
            // 
            // UC_ChatItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(picAvatarStatus);
            Controls.Add(lblStatus);
            Controls.Add(panelBubble);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_ChatItem";
            Size = new Size(339, 99);
            Load += UC_ChatItem_Load;
            panelBubble.ResumeLayout(false);
            panelBubble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarStatus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelBubble;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Label lblMessage;
        internal Guna.UI2.WinForms.Guna2CirclePictureBox picAvatarStatus;
    }
}