namespace APP_DOAN
{
    partial class GiaoDienGoc
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaoDienGoc));
            lblTitle = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            lnkForgotPassword = new LinkLabel();
            lblSubtitle = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(519, 242);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(459, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hệ Thống Quản Lý Lớp Học";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 122, 204);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(588, 379);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 62);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.White;
            btnRegister.BackgroundImage = (Image)resources.GetObject("btnRegister.BackgroundImage");
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnRegister.FlatAppearance.BorderSize = 2;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.FromArgb(50, 50, 50);
            btnRegister.Location = new Point(588, 454);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(300, 62);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Đăng Ký Tài Khoản";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.ActiveLinkColor = Color.White;
            lnkForgotPassword.BackColor = Color.Transparent;
            lnkForgotPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkForgotPassword.LinkColor = Color.White;
            lnkForgotPassword.Location = new Point(663, 538);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(300, 29);
            lnkForgotPassword.TabIndex = 3;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Quên mật khẩu?";
            lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.Transparent;
            lblSubtitle.Location = new Point(416, 302);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(656, 57);
            lblSubtitle.TabIndex = 4;
            lblSubtitle.Text = "Vui lòng đăng nhập hoặc đăng ký để tiếp tục";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GiaoDienGoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1435, 758);
            Controls.Add(lblSubtitle);
            Controls.Add(lnkForgotPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "GiaoDienGoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chào mừng";
            Load += GiaoDienGoc_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.Label lblSubtitle;
    }
}