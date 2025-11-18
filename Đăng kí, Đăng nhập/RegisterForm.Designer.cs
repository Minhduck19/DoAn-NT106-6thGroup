using Guna.UI2.WinForms;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace APP_DOAN// <-- Nhớ đổi lại tên project của bạn
{
    partial class RegisterForm
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

        private Guna2HtmlLabel lblTitle; // Tiêu đề lớn
        private Guna2HtmlLabel lblEmail;
        private Guna2TextBox txtNewEmail;
        private Guna2HtmlLabel lblPassword;
        private Guna2TextBox txtNewPassword;
        private Guna2Button btnRegister;
        private Guna2GroupBox gbRole; // Thay GroupBox thường
        private Guna2RadioButton rbGiangVien; // Thay RadioButton thường
        private Guna2RadioButton rbSinhVien; // Thay RadioButton thường
        private Guna2Panel pnlRegisterCard; // Card chứa form
        private Guna2HtmlLabel linkLogin; // Link chuyển sang đăng nhập

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            pnlRegisterCard = new Guna2Panel();
            linkLogin = new Guna2HtmlLabel();
            gbRole = new Guna2GroupBox();
            rbGiangVien = new Guna2RadioButton();
            rbSinhVien = new Guna2RadioButton();
            btnRegister = new Guna2Button();
            txtNewPassword = new Guna2TextBox();
            txtNewEmail = new Guna2TextBox();
            lblTitle = new Guna2HtmlLabel();
            pnlRegisterCard.SuspendLayout();
            gbRole.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRegisterCard
            // 
            pnlRegisterCard.Anchor = AnchorStyles.None;
            pnlRegisterCard.BackColor = Color.Transparent;
            pnlRegisterCard.BorderColor = Color.DodgerBlue;
            pnlRegisterCard.BorderRadius = 25;
            pnlRegisterCard.Controls.Add(linkLogin);
            pnlRegisterCard.Controls.Add(gbRole);
            pnlRegisterCard.Controls.Add(btnRegister);
            pnlRegisterCard.Controls.Add(txtNewPassword);
            pnlRegisterCard.Controls.Add(txtNewEmail);
            pnlRegisterCard.Controls.Add(lblTitle);
            pnlRegisterCard.CustomizableEdges = customizableEdges9;
            pnlRegisterCard.FillColor = Color.White;
            pnlRegisterCard.ForeColor = SystemColors.MenuHighlight;
            pnlRegisterCard.Location = new Point(455, 100);
            pnlRegisterCard.Name = "pnlRegisterCard";
            pnlRegisterCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlRegisterCard.Size = new Size(522, 550);
            pnlRegisterCard.TabIndex = 0;
            // 
            // linkLogin
            // 
            linkLogin.BackColor = Color.Transparent;
            linkLogin.Cursor = Cursors.Hand;
            linkLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            linkLogin.ForeColor = Color.FromArgb(52, 152, 219);
            linkLogin.Location = new Point(122, 488);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(263, 25);
            linkLogin.TabIndex = 5;
            linkLogin.Text = "<a href='#'>Đã có tài khoản? Đăng nhập ngay</a>";
            linkLogin.Click += linkLogin_Click;
            // 
            // gbRole
            // 
            gbRole.BorderRadius = 12;
            gbRole.Controls.Add(rbGiangVien);
            gbRole.Controls.Add(rbSinhVien);
            gbRole.CustomizableEdges = customizableEdges1;
            gbRole.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            gbRole.ForeColor = Color.FromArgb(52, 152, 219);
            gbRole.Location = new Point(92, 290);
            gbRole.Name = "gbRole";
            gbRole.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gbRole.Size = new Size(340, 80);
            gbRole.TabIndex = 3;
            gbRole.Text = "Vai trò";
            // 
            // rbGiangVien
            // 
            rbGiangVien.AutoSize = true;
            rbGiangVien.CheckedState.BorderColor = Color.FromArgb(52, 152, 219);
            rbGiangVien.CheckedState.BorderThickness = 0;
            rbGiangVien.CheckedState.FillColor = Color.FromArgb(52, 152, 219);
            rbGiangVien.CheckedState.InnerColor = Color.White;
            rbGiangVien.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbGiangVien.ForeColor = Color.Black;
            rbGiangVien.Location = new Point(135, 45);
            rbGiangVien.Name = "rbGiangVien";
            rbGiangVien.Size = new Size(100, 24);
            rbGiangVien.TabIndex = 1;
            rbGiangVien.Text = "Giảng viên";
            rbGiangVien.UncheckedState.BorderColor = Color.Silver;
            rbGiangVien.UncheckedState.BorderThickness = 2;
            rbGiangVien.UncheckedState.FillColor = Color.Transparent;
            rbGiangVien.UncheckedState.InnerColor = Color.Transparent;
            // 
            // rbSinhVien
            // 
            rbSinhVien.AutoSize = true;
            rbSinhVien.CheckedState.BorderColor = Color.FromArgb(52, 152, 219);
            rbSinhVien.CheckedState.BorderThickness = 0;
            rbSinhVien.CheckedState.FillColor = Color.FromArgb(52, 152, 219);
            rbSinhVien.CheckedState.InnerColor = Color.White;
            rbSinhVien.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbSinhVien.ForeColor = Color.Black;
            rbSinhVien.Location = new Point(20, 45);
            rbSinhVien.Name = "rbSinhVien";
            rbSinhVien.Size = new Size(89, 24);
            rbSinhVien.TabIndex = 0;
            rbSinhVien.Text = "Sinh viên";
            rbSinhVien.UncheckedState.BorderColor = Color.Silver;
            rbSinhVien.UncheckedState.BorderThickness = 2;
            rbSinhVien.UncheckedState.FillColor = Color.Transparent;
            rbSinhVien.UncheckedState.InnerColor = Color.Transparent;
            // 
            // btnRegister
            // 
            btnRegister.BorderRadius = 15;
            btnRegister.CustomizableEdges = customizableEdges3;
            btnRegister.FillColor = Color.FromArgb(46, 204, 113);
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(139, 413);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRegister.Size = new Size(236, 45);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Đăng Ký";
            btnRegister.Click += btnRegister_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BorderRadius = 12;
            txtNewPassword.CustomizableEdges = customizableEdges5;
            txtNewPassword.DefaultText = "";
            txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNewPassword.Location = new Point(92, 208);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.PlaceholderText = "Mật khẩu";
            txtNewPassword.SelectedText = "";
            txtNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNewPassword.Size = new Size(340, 45);
            txtNewPassword.TabIndex = 2;
            // 
            // txtNewEmail
            // 
            txtNewEmail.BorderRadius = 12;
            txtNewEmail.CustomizableEdges = customizableEdges7;
            txtNewEmail.DefaultText = "";
            txtNewEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNewEmail.Location = new Point(92, 124);
            txtNewEmail.Margin = new Padding(3, 4, 3, 4);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.PlaceholderText = "Email";
            txtNewEmail.SelectedText = "";
            txtNewEmail.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtNewEmail.Size = new Size(340, 45);
            txtNewEmail.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(176, 38);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1430, 756);
            Controls.Add(pnlRegisterCard);
            ForeColor = SystemColors.MenuHighlight;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Ký Tài Khoản Mới";
            WindowState = FormWindowState.Maximized;
            Load += RegisterForm_Load;
            pnlRegisterCard.ResumeLayout(false);
            pnlRegisterCard.PerformLayout();
            gbRole.ResumeLayout(false);
            gbRole.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

    }
}