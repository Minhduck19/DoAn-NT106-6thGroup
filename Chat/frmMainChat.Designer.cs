// Tên file: frmMainChat.Designer.cs
namespace APP_DOAN
{
    partial class frmMainChat
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelContacts = new Guna.UI2.WinForms.Guna2Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            flowUserListPanel = new FlowLayoutPanel();
            label1 = new Label();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            panelInfo = new Guna.UI2.WinForms.Guna2Panel();
            lblInfoRole = new Label();
            lblInfoEmail = new Label();
            lblInfoName = new Label();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            panelChatArea = new Guna.UI2.WinForms.Guna2Panel();
            flowChatPanel = new FlowLayoutPanel();
            panelInput = new Guna.UI2.WinForms.Guna2Panel();
            txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            btnSend = new Guna.UI2.WinForms.Guna2Button();
            panelContacts.SuspendLayout();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            panelChatArea.SuspendLayout();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // panelContacts
            // 
            panelContacts.BackColor = Color.White;
            panelContacts.Controls.Add(guna2TextBox1);
            panelContacts.Controls.Add(flowUserListPanel);
            panelContacts.Controls.Add(label1);
            panelContacts.CustomizableEdges = customizableEdges3;
            panelContacts.Dock = DockStyle.Left;
            panelContacts.FillColor = Color.FromArgb(249, 249, 249);
            panelContacts.Location = new Point(0, 0);
            panelContacts.Margin = new Padding(3, 4, 3, 4);
            panelContacts.Name = "panelContacts";
            panelContacts.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelContacts.Size = new Size(280, 750);
            panelContacts.TabIndex = 0;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(0, 62);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(274, 41);
            guna2TextBox1.TabIndex = 0;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            // 
            // flowUserListPanel
            // 
            flowUserListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowUserListPanel.AutoScroll = true;
            flowUserListPanel.BackColor = Color.Transparent;
            flowUserListPanel.FlowDirection = FlowDirection.TopDown;
            flowUserListPanel.Location = new Point(0, 99);
            flowUserListPanel.Margin = new Padding(3, 4, 3, 4);
            flowUserListPanel.Name = "flowUserListPanel";
            flowUserListPanel.Size = new Size(280, 651);
            flowUserListPanel.TabIndex = 1;
            flowUserListPanel.WrapContents = false;
            flowUserListPanel.Paint += flowUserListPanel_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(113, 28);
            label1.TabIndex = 0;
            label1.Text = "TIN NHẮN";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Left;
            guna2Separator1.FillColor = Color.FromArgb(220, 220, 220);
            guna2Separator1.Location = new Point(280, 0);
            guna2Separator1.Margin = new Padding(3, 4, 3, 4);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1, 750);
            guna2Separator1.TabIndex = 1;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.Controls.Add(lblInfoRole);
            panelInfo.Controls.Add(lblInfoEmail);
            panelInfo.Controls.Add(lblInfoName);
            panelInfo.Controls.Add(guna2CirclePictureBox1);
            panelInfo.CustomizableEdges = customizableEdges6;
            panelInfo.Dock = DockStyle.Right;
            panelInfo.FillColor = Color.FromArgb(249, 249, 249);
            panelInfo.Location = new Point(1528, 0);
            panelInfo.Margin = new Padding(3, 4, 3, 4);
            panelInfo.Name = "panelInfo";
            panelInfo.ShadowDecoration.CustomizableEdges = customizableEdges7;
            panelInfo.Size = new Size(250, 750);
            panelInfo.TabIndex = 2;
            // 
            // lblInfoRole
            // 
            lblInfoRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfoRole.BackColor = Color.Transparent;
            lblInfoRole.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoRole.ForeColor = Color.Gray;
            lblInfoRole.Location = new Point(6, 275);
            lblInfoRole.Name = "lblInfoRole";
            lblInfoRole.Size = new Size(232, 29);
            lblInfoRole.TabIndex = 3;
            lblInfoRole.Text = "(Vai trò)";
            lblInfoRole.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblInfoEmail
            // 
            lblInfoEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfoEmail.BackColor = Color.Transparent;
            lblInfoEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoEmail.ForeColor = Color.Gray;
            lblInfoEmail.Location = new Point(6, 246);
            lblInfoEmail.Name = "lblInfoEmail";
            lblInfoEmail.Size = new Size(232, 29);
            lblInfoEmail.TabIndex = 2;
            lblInfoEmail.Text = "(Email)";
            lblInfoEmail.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblInfoName
            // 
            lblInfoName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfoName.BackColor = Color.Transparent;
            lblInfoName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoName.Location = new Point(6, 200);
            lblInfoName.Name = "lblInfoName";
            lblInfoName.Size = new Size(232, 35);
            lblInfoName.TabIndex = 1;
            lblInfoName.Text = "(Chọn để chat)";
            lblInfoName.TextAlign = ContentAlignment.TopCenter;
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox1.Image = Properties.Resources.avatar_trang_1_cd729c335b;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(75, 62);
            guna2CirclePictureBox1.Margin = new Padding(3, 4, 3, 4);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(100, 125);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2Separator2
            // 
            guna2Separator2.Dock = DockStyle.Right;
            guna2Separator2.FillColor = Color.FromArgb(220, 220, 220);
            guna2Separator2.Location = new Point(1527, 0);
            guna2Separator2.Margin = new Padding(3, 4, 3, 4);
            guna2Separator2.Name = "guna2Separator2";
            guna2Separator2.Size = new Size(1, 750);
            guna2Separator2.TabIndex = 3;
            // 
            // panelChatArea
            // 
            panelChatArea.BackColor = Color.White;
            panelChatArea.Controls.Add(flowChatPanel);
            panelChatArea.Controls.Add(panelInput);
            panelChatArea.CustomizableEdges = customizableEdges14;
            panelChatArea.Dock = DockStyle.Fill;
            panelChatArea.Location = new Point(281, 0);
            panelChatArea.Margin = new Padding(3, 4, 3, 4);
            panelChatArea.Name = "panelChatArea";
            panelChatArea.ShadowDecoration.CustomizableEdges = customizableEdges15;
            panelChatArea.Size = new Size(1246, 750);
            panelChatArea.TabIndex = 4;
            // 
            // flowChatPanel
            // 
            flowChatPanel.AutoScroll = true;
            flowChatPanel.BackColor = Color.White;
            flowChatPanel.Dock = DockStyle.Fill;
            flowChatPanel.FlowDirection = FlowDirection.TopDown;
            flowChatPanel.Location = new Point(0, 0);
            flowChatPanel.Margin = new Padding(3, 4, 3, 4);
            flowChatPanel.Name = "flowChatPanel";
            flowChatPanel.Padding = new Padding(10, 12, 0, 12);
            flowChatPanel.Size = new Size(1246, 675);
            flowChatPanel.TabIndex = 1;
            flowChatPanel.WrapContents = false;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(txtMessage);
            panelInput.Controls.Add(btnSend);
            panelInput.CustomizableEdges = customizableEdges12;
            panelInput.Dock = DockStyle.Bottom;
            panelInput.Enabled = false;
            panelInput.FillColor = Color.FromArgb(249, 249, 249);
            panelInput.Location = new Point(0, 675);
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(10);
            panelInput.ShadowDecoration.CustomizableEdges = customizableEdges13;
            panelInput.ShadowDecoration.Depth = 5;
            panelInput.ShadowDecoration.Enabled = true;
            panelInput.ShadowDecoration.Shadow = new Padding(0, -5, 0, 0);
            panelInput.Size = new Size(1246, 75);
            panelInput.TabIndex = 0;
            // 
            // txtMessage
            // 
            txtMessage.BorderRadius = 8;
            txtMessage.BorderThickness = 0;
            txtMessage.Cursor = Cursors.IBeam;
            txtMessage.CustomizableEdges = customizableEdges8;
            txtMessage.DefaultText = "";
            txtMessage.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMessage.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMessage.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMessage.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMessage.Font = new Font("Segoe UI", 9F);
            txtMessage.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMessage.Location = new Point(10, 10);
            txtMessage.Margin = new Padding(3, 5, 3, 5);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Nhập tin nhắn...";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.CustomizableEdges = customizableEdges9;
            txtMessage.Size = new Size(1126, 55);
            txtMessage.TabIndex = 0;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // btnSend
            // 
            btnSend.Animated = true;
            btnSend.BorderRadius = 8;
            btnSend.CustomizableEdges = customizableEdges10;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.Dock = DockStyle.Right;
            btnSend.FillColor = Color.Transparent;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Image = Properties.Resources.maybay;
            btnSend.ImageSize = new Size(25, 25);
            btnSend.Location = new Point(1136, 10);
            btnSend.Margin = new Padding(3, 4, 3, 4);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges11;
            btnSend.Size = new Size(100, 55);
            btnSend.TabIndex = 1;
            // 
            // frmMainChat
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1778, 750);
            Controls.Add(panelChatArea);
            Controls.Add(guna2Separator2);
            Controls.Add(panelInfo);
            Controls.Add(guna2Separator1);
            Controls.Add(panelContacts);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMainChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMainChat_FormClosing;
            Load += frmMainChat_Load;
            panelContacts.ResumeLayout(false);
            panelContacts.PerformLayout();
            panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            panelChatArea.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelContacts;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel panelInfo;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Panel panelChatArea;
        private System.Windows.Forms.FlowLayoutPanel flowUserListPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfoRole;
        private System.Windows.Forms.Label lblInfoEmail;
        private System.Windows.Forms.Label lblInfoName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowChatPanel;
        private Guna.UI2.WinForms.Guna2Panel panelInput;
        private Guna.UI2.WinForms.Guna2TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}