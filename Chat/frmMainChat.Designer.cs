namespace APP_DOAN
{
    partial class frmMainChat
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            flowUserListPanel = new FlowLayoutPanel();
            panelSearch = new Panel();
            guna2TextBox1 = new TextBox();
            panelTabs = new Panel();
            btnTabClass = new Button();
            btnTabPersonal = new Button();
            panelChatArea = new Panel();
            flowChatPanel = new FlowLayoutPanel();
            panelInput = new Panel();
            btnSend = new Button();
            btnUpload = new Button();
            btnEmoji = new Button();
            txtMessage = new TextBox();
            panelHeader = new Panel();
            lblInfoRole = new Label();
            lblInfoEmail = new Label();
            lblInfoName = new Label();
            guna2CirclePictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelSearch.SuspendLayout();
            panelTabs.SuspendLayout();
            panelChatArea.SuspendLayout();
            panelInput.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(flowUserListPanel);
            splitContainer1.Panel1.Controls.Add(panelSearch);
            splitContainer1.Panel1.Controls.Add(panelTabs);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(240, 242, 245);
            splitContainer1.Panel2.Controls.Add(panelChatArea);
            splitContainer1.Panel2.Controls.Add(panelHeader);
            splitContainer1.Size = new Size(1100, 650);
            splitContainer1.SplitterDistance = 320;
            splitContainer1.TabIndex = 0;
            // 
            // flowUserListPanel
            // 
            flowUserListPanel.AutoScroll = true;
            flowUserListPanel.BackColor = Color.White;
            flowUserListPanel.Dock = DockStyle.Fill;
            flowUserListPanel.Location = new Point(0, 105);
            flowUserListPanel.Name = "flowUserListPanel";
            flowUserListPanel.Size = new Size(320, 545);
            flowUserListPanel.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(guna2TextBox1);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 50);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(15, 10, 15, 10);
            panelSearch.Size = new Size(320, 55);
            panelSearch.TabIndex = 1;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.FromArgb(240, 242, 245);
            guna2TextBox1.BorderStyle = BorderStyle.None;
            guna2TextBox1.Dock = DockStyle.Fill;
            guna2TextBox1.Font = new Font("Segoe UI", 10F);
            guna2TextBox1.Location = new Point(15, 10);
            guna2TextBox1.Multiline = true;
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "   Tìm kiếm người dùng/lớp...";
            guna2TextBox1.Size = new Size(290, 35);
            guna2TextBox1.TabIndex = 0;
            // 
            // panelTabs
            // 
            panelTabs.BackColor = Color.White;
            panelTabs.Controls.Add(btnTabClass);
            panelTabs.Controls.Add(btnTabPersonal);
            panelTabs.Dock = DockStyle.Top;
            panelTabs.Location = new Point(0, 0);
            panelTabs.Name = "panelTabs";
            panelTabs.Padding = new Padding(5);
            panelTabs.Size = new Size(320, 50);
            panelTabs.TabIndex = 2;
            // 
            // btnTabClass
            // 
            btnTabClass.BackColor = Color.WhiteSmoke;
            btnTabClass.Cursor = Cursors.Hand;
            btnTabClass.Dock = DockStyle.Right;
            btnTabClass.FlatAppearance.BorderSize = 0;
            btnTabClass.FlatStyle = FlatStyle.Flat;
            btnTabClass.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnTabClass.ForeColor = Color.FromArgb(64, 64, 64);
            btnTabClass.Location = new Point(163, 5);
            btnTabClass.Name = "btnTabClass";
            btnTabClass.Size = new Size(152, 40);
            btnTabClass.TabIndex = 1;
            btnTabClass.Text = "Lớp học";
            btnTabClass.UseVisualStyleBackColor = false;
            // 
            // btnTabPersonal
            // 
            btnTabPersonal.BackColor = Color.FromArgb(0, 118, 212);
            btnTabPersonal.Cursor = Cursors.Hand;
            btnTabPersonal.Dock = DockStyle.Left;
            btnTabPersonal.FlatAppearance.BorderSize = 0;
            btnTabPersonal.FlatStyle = FlatStyle.Flat;
            btnTabPersonal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnTabPersonal.ForeColor = Color.White;
            btnTabPersonal.Location = new Point(5, 5);
            btnTabPersonal.Name = "btnTabPersonal";
            btnTabPersonal.Size = new Size(152, 40);
            btnTabPersonal.TabIndex = 0;
            btnTabPersonal.Text = "Cá nhân";
            btnTabPersonal.UseVisualStyleBackColor = false;
            // 
            // panelChatArea
            // 
            panelChatArea.Controls.Add(flowChatPanel);
            panelChatArea.Controls.Add(panelInput);
            panelChatArea.Dock = DockStyle.Fill;
            panelChatArea.Location = new Point(0, 70);
            panelChatArea.Name = "panelChatArea";
            panelChatArea.Size = new Size(776, 580);
            panelChatArea.TabIndex = 1;
            // 
            // flowChatPanel
            // 
            flowChatPanel.AutoScroll = true;
            flowChatPanel.BackColor = Color.FromArgb(240, 242, 245);
            flowChatPanel.Dock = DockStyle.Fill;
            flowChatPanel.FlowDirection = FlowDirection.TopDown;
            flowChatPanel.Location = new Point(0, 0);
            flowChatPanel.Name = "flowChatPanel";
            flowChatPanel.Padding = new Padding(10, 0, 0, 20);
            flowChatPanel.Size = new Size(776, 520);
            flowChatPanel.TabIndex = 0;
            flowChatPanel.WrapContents = false;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(btnSend);
            panelInput.Controls.Add(btnUpload);
            panelInput.Controls.Add(btnEmoji);
            panelInput.Controls.Add(txtMessage);
            panelInput.Dock = DockStyle.Bottom;
            panelInput.Enabled = false;
            panelInput.Location = new Point(0, 520);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(776, 60);
            panelInput.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Right;
            btnSend.BackColor = Color.White;
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.FromArgb(0, 118, 212);
            btnSend.Location = new Point(690, 12);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 36);
            btnSend.TabIndex = 1;
            btnSend.Text = "GỬI";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // btnUpload
            // 
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI Emoji", 14F);
            btnUpload.ForeColor = Color.FromArgb(0, 118, 212);
            btnUpload.Location = new Point(10, 10);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(40, 40);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "📎";
            btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnEmoji
            // 
            btnEmoji.Anchor = AnchorStyles.Right;
            btnEmoji.Cursor = Cursors.Hand;
            btnEmoji.FlatAppearance.BorderSize = 0;
            btnEmoji.FlatStyle = FlatStyle.Flat;
            btnEmoji.Font = new Font("Segoe UI Emoji", 14F);
            btnEmoji.ForeColor = Color.FromArgb(0, 118, 212);
            btnEmoji.Location = new Point(645, 10);
            btnEmoji.Name = "btnEmoji";
            btnEmoji.Size = new Size(40, 40);
            btnEmoji.TabIndex = 3;
            btnEmoji.Text = "😊";
            btnEmoji.UseVisualStyleBackColor = true;
            btnEmoji.Click += btnEmoji_Click;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.BackColor = Color.FromArgb(240, 242, 245);
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.Font = new Font("Segoe UI", 11F);
            txtMessage.Location = new Point(60, 15);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Nhập tin nhắn...";
            txtMessage.Size = new Size(580, 30);
            txtMessage.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblInfoRole);
            panelHeader.Controls.Add(lblInfoEmail);
            panelHeader.Controls.Add(lblInfoName);
            panelHeader.Controls.Add(guna2CirclePictureBox1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(776, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblInfoRole
            // 
            lblInfoRole.Anchor = AnchorStyles.Right;
            lblInfoRole.AutoSize = true;
            lblInfoRole.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblInfoRole.ForeColor = Color.FromArgb(0, 118, 212);
            lblInfoRole.Location = new Point(586, 30);
            lblInfoRole.Name = "lblInfoRole";
            lblInfoRole.Size = new Size(54, 20);
            lblInfoRole.TabIndex = 3;
            lblInfoRole.Text = "Vai trò";
            lblInfoRole.Click += lblInfoRole_Click;
            // 
            // lblInfoEmail
            // 
            lblInfoEmail.AutoSize = true;
            lblInfoEmail.Font = new Font("Segoe UI", 9F);
            lblInfoEmail.ForeColor = Color.Gray;
            lblInfoEmail.Location = new Point(82, 40);
            lblInfoEmail.Name = "lblInfoEmail";
            lblInfoEmail.Size = new Size(149, 20);
            lblInfoEmail.TabIndex = 2;
            lblInfoEmail.Text = "email@example.com";
            // 
            // lblInfoName
            // 
            lblInfoName.AutoSize = true;
            lblInfoName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblInfoName.ForeColor = Color.FromArgb(28, 30, 33);
            lblInfoName.Location = new Point(80, 12);
            lblInfoName.Name = "lblInfoName";
            lblInfoName.Size = new Size(193, 30);
            lblInfoName.TabIndex = 1;
            lblInfoName.Text = "(Tên người dùng)";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Location = new Point(20, 10);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.Size = new Size(50, 50);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // frmMainChat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 650);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMainChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng Dụng Chat";
            Load += frmMainChat_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelTabs.ResumeLayout(false);
            panelChatArea.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowUserListPanel;
        private System.Windows.Forms.Panel panelTabs;
        private System.Windows.Forms.Button btnTabClass;
        private System.Windows.Forms.Button btnTabPersonal;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox guna2TextBox1;

        private System.Windows.Forms.Panel panelChatArea;
        private System.Windows.Forms.FlowLayoutPanel flowChatPanel;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnEmoji;
        private System.Windows.Forms.TextBox txtMessage;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblInfoRole;
        private System.Windows.Forms.Label lblInfoEmail;
        private System.Windows.Forms.Label lblInfoName;
        private System.Windows.Forms.PictureBox guna2CirclePictureBox1;
    }
}