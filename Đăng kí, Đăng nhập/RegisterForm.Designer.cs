using Guna.UI2.WinForms;

namespace APP_DOAN
{
    partial class RegisterForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlRegisterCard = new Guna2Panel();
            lblTitle = new Guna2HtmlLabel();
            txtNewEmail = new Guna2TextBox();
            txtNewPassword = new Guna2TextBox();
            gbRole = new Guna2GroupBox();
            rbGiangVien = new Guna2RadioButton();
            rbSinhVien = new Guna2RadioButton();
            btnRegister = new Guna2Button();
            btnBack = new Guna2Button();
            pnlRegisterCard.SuspendLayout();
            gbRole.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRegisterCard
            // 
            pnlRegisterCard.Anchor = AnchorStyles.None;
            pnlRegisterCard.BackColor = Color.Transparent;
            pnlRegisterCard.BorderRadius = 25;
            pnlRegisterCard.Controls.Add(lblTitle);
            pnlRegisterCard.Controls.Add(txtNewEmail);
            pnlRegisterCard.Controls.Add(txtNewPassword);
            pnlRegisterCard.Controls.Add(gbRole);
            pnlRegisterCard.Controls.Add(btnRegister);
            pnlRegisterCard.Controls.Add(btnBack);
            pnlRegisterCard.CustomizableEdges = customizableEdges11;
            pnlRegisterCard.FillColor = Color.White;
            pnlRegisterCard.Location = new Point(538, 110);
            pnlRegisterCard.Name = "pnlRegisterCard";
            pnlRegisterCard.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlRegisterCard.ShadowDecoration.Enabled = true;
            pnlRegisterCard.Size = new Size(400, 550);
            pnlRegisterCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(85, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(253, 52);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ MỚI";
            // 
            // txtNewEmail
            // 
            txtNewEmail.BorderRadius = 12;
            txtNewEmail.CustomizableEdges = customizableEdges1;
            txtNewEmail.DefaultText = "";
            txtNewEmail.Font = new Font("Segoe UI", 10F);
            txtNewEmail.Location = new Point(50, 130);
            txtNewEmail.Margin = new Padding(3, 4, 3, 4);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.PlaceholderText = "Nhập Email đăng ký";
            txtNewEmail.SelectedText = "";
            txtNewEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtNewEmail.Size = new Size(300, 45);
            txtNewEmail.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BorderRadius = 12;
            txtNewPassword.CustomizableEdges = customizableEdges3;
            txtNewPassword.DefaultText = "";
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.Location = new Point(50, 200);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.PlaceholderText = "Nhập Mật khẩu";
            txtNewPassword.SelectedText = "";
            txtNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtNewPassword.Size = new Size(300, 45);
            txtNewPassword.TabIndex = 2;
            // 
            // gbRole
            // 
            gbRole.BorderRadius = 10;
            gbRole.Controls.Add(rbGiangVien);
            gbRole.Controls.Add(rbSinhVien);
            gbRole.CustomizableEdges = customizableEdges5;
            gbRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbRole.ForeColor = Color.FromArgb(125, 137, 149);
            gbRole.Location = new Point(50, 270);
            gbRole.Name = "gbRole";
            gbRole.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gbRole.Size = new Size(300, 100);
            gbRole.TabIndex = 3;
            gbRole.Text = "Chọn Vai Trò";
            // 
            // rbGiangVien
            // 
            rbGiangVien.AutoSize = true;
            rbGiangVien.CheckedState.BorderColor = Color.FromArgb(52, 152, 219);
            rbGiangVien.CheckedState.BorderThickness = 0;
            rbGiangVien.CheckedState.FillColor = Color.FromArgb(52, 152, 219);
            rbGiangVien.Location = new Point(160, 55);
            rbGiangVien.Name = "rbGiangVien";
            rbGiangVien.Size = new Size(104, 24);
            rbGiangVien.TabIndex = 1;
            rbGiangVien.Text = "Giảng viên";
            rbGiangVien.UncheckedState.BorderThickness = 0;
            // 
            // rbSinhVien
            // 
            rbSinhVien.AutoSize = true;
            rbSinhVien.CheckedState.BorderColor = Color.FromArgb(52, 152, 219);
            rbSinhVien.CheckedState.BorderThickness = 0;
            rbSinhVien.CheckedState.FillColor = Color.FromArgb(52, 152, 219);
            rbSinhVien.Location = new Point(30, 55);
            rbSinhVien.Name = "rbSinhVien";
            rbSinhVien.Size = new Size(93, 24);
            rbSinhVien.TabIndex = 0;
            rbSinhVien.Text = "Sinh viên";
            rbSinhVien.UncheckedState.BorderThickness = 0;
            // 
            // btnRegister
            // 
            btnRegister.BorderRadius = 15;
            btnRegister.CustomizableEdges = customizableEdges7;
            btnRegister.FillColor = Color.FromArgb(52, 152, 219);
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 400);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRegister.Size = new Size(300, 45);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "ĐĂNG KÝ";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBack
            // 
            btnBack.BorderRadius = 15;
            btnBack.CustomizableEdges = customizableEdges9;
            btnBack.FillColor = Color.FromArgb(189, 195, 199);
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(50, 460);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnBack.Size = new Size(300, 45);
            btnBack.TabIndex = 5;
            btnBack.Text = "QUAY LẠI";
            btnBack.Click += btnBack_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.d552cbffdb75d65d2130679ea07d6ac2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1430, 756);
            Controls.Add(pnlRegisterCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            pnlRegisterCard.ResumeLayout(false);
            pnlRegisterCard.PerformLayout();
            gbRole.ResumeLayout(false);
            gbRole.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlRegisterCard;
        private Guna2HtmlLabel lblTitle;
        private Guna2TextBox txtNewEmail;
        private Guna2TextBox txtNewPassword;
        private Guna2GroupBox gbRole;
        private Guna2RadioButton rbSinhVien;
        private Guna2RadioButton rbGiangVien;
        private Guna2Button btnRegister;
        private Guna2Button btnBack;
    }
}