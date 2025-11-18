namespace APP_DOAN
{
    partial class LoginForm
    {
        // ... (các biến private cho điều khiển) ...
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel linkRegister;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
<<<<<<< HEAD
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            linkRegister = new LinkLabel();
=======
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
>>>>>>> origin/develop
            SuspendLayout();
            // 
            // label1
            // 
<<<<<<< HEAD
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(502, 304);
            label1.Name = "label1";
            label1.Size = new Size(63, 28);
            label1.TabIndex = 6;
            label1.Text = "Email:";
            // 
            // label2
=======
            pnlLoginCard.Anchor = AnchorStyles.None;
            pnlLoginCard.BackColor = Color.Transparent;
            pnlLoginCard.BorderColor = Color.FromArgb(224, 247, 250);
            pnlLoginCard.BorderRadius = 25;
            pnlLoginCard.Controls.Add(guna2HtmlLabel1);
            pnlLoginCard.Controls.Add(lblMainTitle);
            pnlLoginCard.Controls.Add(txtPassword);
            pnlLoginCard.Controls.Add(txtEmail);
            pnlLoginCard.Controls.Add(btnLogin);
            pnlLoginCard.Controls.Add(btnCancel);
            pnlLoginCard.Controls.Add(linkRegister);
            pnlLoginCard.CustomizableEdges = customizableEdges9;
            pnlLoginCard.FillColor = Color.White;
            pnlLoginCard.Location = new Point(703, 159);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlLoginCard.ShadowDecoration.Enabled = true;
            pnlLoginCard.Size = new Size(354, 431);
            pnlLoginCard.TabIndex = 0;
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
            guna2HtmlLabel1.Text = "<a href='#'>Quên mật khẩu?</a>";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // lblMainTitle
>>>>>>> origin/develop
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(502, 348);
            label2.Name = "label2";
            label2.Size = new Size(98, 28);
            label2.TabIndex = 5;
            label2.Text = "Mật khẩu:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(571, 308);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(275, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(606, 348);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(240, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackgroundImage = (Image)resources.GetObject("btnLogin.BackgroundImage");
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.ForeColor = SystemColors.ActiveCaptionText;
            btnLogin.Location = new Point(556, 401);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(128, 37);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackgroundImage = (Image)resources.GetObject("btnCancel.BackgroundImage");
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.Location = new Point(705, 401);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(141, 37);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click_1;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.BackColor = Color.Transparent;
            linkRegister.ForeColor = Color.White;
            linkRegister.LinkColor = Color.White;
            linkRegister.Location = new Point(628, 459);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(229, 20);
            linkRegister.TabIndex = 0;
            linkRegister.TabStop = true;
            linkRegister.Text = "Chưa có tài khoản? Đăng ký ngay";
            linkRegister.LinkClicked += linkRegister_LinkClicked_1;
            // 
            // LoginForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1419, 756);
            Controls.Add(linkRegister);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Đăng nhập";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna2HtmlLabel guna2HtmlLabel1;
    }
}