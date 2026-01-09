namespace APP_DOAN
{
    partial class MainForm_GiangVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            borderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            lblWelcome = new Label();
            flpMyCourses = new FlowLayoutPanel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            btnCreate = new Guna.UI2.WinForms.Guna2Button();
            btnChat = new Guna.UI2.WinForms.Guna2GradientButton();
            btnProfile = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // borderlessForm
            // 
            borderlessForm.BorderRadius = 20;
            borderlessForm.ContainerControl = this;
            borderlessForm.DockIndicatorTransparencyValue = 0.6D;
            borderlessForm.ShadowColor = Color.DimGray;
            borderlessForm.TransparentWhileDrag = true;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(40, 40, 40);
            lblWelcome.Location = new Point(30, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(149, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Xin chào!";
            // 
            // flpMyCourses
            // 
            flpMyCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpMyCourses.AutoScroll = true;
            flpMyCourses.Location = new Point(34, 150);
            flpMyCourses.Name = "flpMyCourses";
            flpMyCourses.Size = new Size(1300, 850);
            flpMyCourses.TabIndex = 2;
            flpMyCourses.Paint += flpMyCourses_Paint;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 10;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges15;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(34, 85);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm lớp học...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtSearch.Size = new Size(300, 40);
            txtSearch.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.CustomizableEdges = customizableEdges13;
            btnExit.FillColor = Color.Transparent;
            btnExit.IconColor = Color.Gray;
            btnExit.Location = new Point(1310, 10);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnExit.Size = new Size(45, 30);
            btnExit.TabIndex = 10;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            btnMinimize.CustomizableEdges = customizableEdges11;
            btnMinimize.FillColor = Color.Transparent;
            btnMinimize.IconColor = Color.Gray;
            btnMinimize.Location = new Point(1260, 10);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnMinimize.Size = new Size(45, 30);
            btnMinimize.TabIndex = 11;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.BorderRadius = 10;
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.CustomizableEdges = customizableEdges3;
            btnCreate.FillColor = Color.FromArgb(0, 118, 212);
            btnCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(565, 85);
            btnCreate.Name = "btnCreate";
            btnCreate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCreate.Size = new Size(150, 40);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "+ Tạo lớp mới";
            btnCreate.Click += btnCreateCourse_Click;
            // 
            // btnChat
            // 
            btnChat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChat.BorderRadius = 10;
            btnChat.Cursor = Cursors.Hand;
            btnChat.CustomizableEdges = customizableEdges5;
            btnChat.FillColor = Color.FromArgb(118, 96, 240);
            btnChat.FillColor2 = Color.FromArgb(49, 209, 245);
            btnChat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChat.ForeColor = Color.White;
            btnChat.Location = new Point(1153, 85);
            btnChat.Name = "btnChat";
            btnChat.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnChat.Size = new Size(130, 40);
            btnChat.TabIndex = 1;
            btnChat.Text = "💬 Tin nhắn";
            btnChat.Click += guna2Button1_Click;
            // 
            // btnProfile
            // 
            btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProfile.BorderRadius = 10;
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.CustomizableEdges = customizableEdges7;
            btnProfile.FillColor = Color.FromArgb(64, 64, 64);
            btnProfile.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(421, 85);
            btnProfile.Name = "btnProfile";
            btnProfile.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnProfile.Size = new Size(120, 40);
            btnProfile.TabIndex = 2;
            btnProfile.Text = "Hồ sơ";
            btnProfile.Click += OpenProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BorderColor = Color.IndianRed;
            btnLogout.BorderRadius = 10;
            btnLogout.BorderThickness = 1;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.CustomizableEdges = customizableEdges9;
            btnLogout.FillColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogout.ForeColor = Color.IndianRed;
            btnLogout.Location = new Point(895, 85);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLogout.Size = new Size(119, 40);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Button1.BorderColor = Color.IndianRed;
            guna2Button1.BorderRadius = 10;
            guna2Button1.BorderThickness = 1;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.FillColor = Color.White;
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.IndianRed;
            guna2Button1.Location = new Point(733, 85);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(146, 40);
            guna2Button1.TabIndex = 12;
            guna2Button1.Text = "Đổi mật khẩu";
            guna2Button1.Click += guna2Button1_Click_1;
            // 
            // MainForm_GiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1371, 1067);
            Controls.Add(guna2Button1);
            Controls.Add(btnCreate);
            Controls.Add(btnChat);
            Controls.Add(btnProfile);
            Controls.Add(btnLogout);
            Controls.Add(btnMinimize);
            Controls.Add(btnExit);
            Controls.Add(txtSearch);
            Controls.Add(flpMyCourses);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm_GiangVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm_GiangVien";
            Load += MainForm_GiangVien_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel flpMyCourses;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;

        // Các nút Toolbar (Đã được chuẩn hóa tên biến)
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private Guna.UI2.WinForms.Guna2GradientButton btnChat;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}