using Guna.UI2.WinForms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace APP_DOAN
{
    partial class LoginForm
    {
        // Thay đổi khai báo controls sang Guna UI
        private Guna2HtmlLabel label1;
        private Guna2HtmlLabel label2;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPassword;
        private Guna2Button btnLogin;
        private Guna2Button btnCancel;
        private Guna2HtmlLabel linkRegister; // Dùng HtmlLabel giả làm Link
        private Container components;
        private Guna2Panel pnlLoginCard; // Card đăng nhập
        private Guna2HtmlLabel lblMainTitle; // Tiêu đề lớn

        public LinearGradientMode GradientMode { get; private set; }
        public Color FillColor { get; private set; }
        public Color GradientColor { get; private set; }

        // ... (Khai báo components giữ nguyên) ...

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LoginForm));
            pnlLoginCard = new Guna2Panel();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            lblMainTitle = new Guna2HtmlLabel();
            txtPassword = new Guna2TextBox();
            txtEmail = new Guna2TextBox();
            btnLogin = new Guna2Button();
            btnCancel = new Guna2Button();
            linkRegister = new Guna2HtmlLabel();
            label1 = new Guna2HtmlLabel();
            label2 = new Guna2HtmlLabel();
            pnlLoginCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.Anchor = AnchorStyles.None;
            pnlLoginCard.BackColor = Color.Transparent;
            pnlLoginCard.BorderColor = Color.White;
            pnlLoginCard.BorderRadius = 25;
            pnlLoginCard.Controls.Add(guna2HtmlLabel1);
            pnlLoginCard.Controls.Add(lblMainTitle);
            pnlLoginCard.Controls.Add(txtPassword);
            pnlLoginCard.Controls.Add(txtEmail);
            pnlLoginCard.Controls.Add(btnLogin);
            pnlLoginCard.Controls.Add(btnCancel);
            pnlLoginCard.Controls.Add(linkRegister);
            pnlLoginCard.CustomizableEdges = customizableEdges9;
            pnlLoginCard.FillColor = Color.AliceBlue;
            pnlLoginCard.ForeColor = Color.Snow;
            pnlLoginCard.Location = new Point(517, 151);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlLoginCard.ShadowDecoration.Enabled = true;
            pnlLoginCard.Size = new Size(384, 431);
            pnlLoginCard.TabIndex = 0;
            pnlLoginCard.Paint += pnlLoginCard_Paint;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Cursor = Cursors.Hand;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(52, 152, 219);
            guna2HtmlLabel1.Location = new Point(60, 391);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(130, 25);
            guna2HtmlLabel1.TabIndex = 6;
            guna2HtmlLabel1.Text = "<a href='#'>Quên mật khẩu? </a>";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // lblMainTitle
            // 
            lblMainTitle.BackColor = Color.Transparent;
            lblMainTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblMainTitle.Location = new Point(71, 27);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(248, 56);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "ĐĂNG NHẬP";
            // 
            // txtPassword
            // 
            txtPassword.BorderRadius = 12;
            txtPassword.CustomizableEdges = customizableEdges1;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(71, 159);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPassword.Size = new Size(250, 40);
            txtPassword.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 12;
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(71, 100);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(250, 40);
            txtEmail.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 15;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.FillColor = Color.DeepSkyBlue;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(71, 234);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(250, 45);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 15;
            btnCancel.CustomizableEdges = customizableEdges7;
            btnCancel.FillColor = Color.DeepSkyBlue;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(71, 296);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancel.Size = new Size(250, 44);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click_1;
            // 
            // linkRegister
            // 
            linkRegister.BackColor = Color.Transparent;
            linkRegister.Cursor = Cursors.Hand;
            linkRegister.Font = new Font("Segoe UI", 10F);
            linkRegister.ForeColor = Color.FromArgb(52, 152, 219);
            linkRegister.Location = new Point(60, 360);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(259, 25);
            linkRegister.TabIndex = 5;
            linkRegister.Text = "<a href='#'>Chưa có tài khoản? Đăng ký ngay</a>";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(3, 2);
            label1.TabIndex = 0;
            label1.Text = null;
            label1.Visible = false;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(3, 2);
            label2.TabIndex = 0;
            label2.Text = null;
            label2.Visible = false;
            // 
            // LoginForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1343, 717);
            Controls.Add(pnlLoginCard);
            Cursor = Cursors.Arrow;
            ForeColor = SystemColors.ActiveCaption;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "LoginForm";
            WindowState = FormWindowState.Maximized;
            Load += LoginForm_Load_1;
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2HtmlLabel guna2HtmlLabel1;
    }
}