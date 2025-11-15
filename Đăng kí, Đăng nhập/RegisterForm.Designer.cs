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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            lblEmail = new Label();
            txtNewEmail = new TextBox();
            lblPassword = new Label();
            txtNewPassword = new TextBox();
            btnRegister = new Button();
            gbRole = new GroupBox();
            rbGiangVien = new RadioButton();
            rbSinhVien = new RadioButton();
            gbRole.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(501, 288);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 28);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtNewEmail
            // 
            txtNewEmail.Location = new Point(608, 292);
            txtNewEmail.Margin = new Padding(4, 5, 4, 5);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.Size = new Size(309, 27);
            txtNewEmail.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(490, 357);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(98, 28);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(608, 358);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(309, 27);
            txtNewPassword.TabIndex = 2;
            // 
            // btnRegister
            // 
            btnRegister.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnRegister.BackgroundImage");
            btnRegister.BackgroundImageLayout = ImageLayout.Center;
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(608, 474);
            btnRegister.Margin = new Padding(4, 5, 4, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(180, 54);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Đăng Ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // gbRole
            // 
            gbRole.BackColor = Color.Transparent;
            gbRole.Controls.Add(rbGiangVien);
            gbRole.Controls.Add(rbSinhVien);
            gbRole.ForeColor = Color.White;
            gbRole.Location = new Point(608, 399);
            gbRole.Name = "gbRole";
            gbRole.Size = new Size(309, 60);
            gbRole.TabIndex = 3;
            gbRole.TabStop = false;
            gbRole.Text = "Vai trò";
            // 
            // rbGiangVien
            // 
            rbGiangVien.AutoSize = true;
            rbGiangVien.Location = new Point(177, 25);
            rbGiangVien.Name = "rbGiangVien";
            rbGiangVien.Size = new Size(100, 24);
            rbGiangVien.TabIndex = 1;
            rbGiangVien.TabStop = true;
            rbGiangVien.Text = "Giảng viên";
            rbGiangVien.UseVisualStyleBackColor = true;
            // 
            // rbSinhVien
            // 
            rbSinhVien.AutoSize = true;
            rbSinhVien.Location = new Point(55, 25);
            rbSinhVien.Name = "rbSinhVien";
            rbSinhVien.Size = new Size(89, 24);
            rbSinhVien.TabIndex = 0;
            rbSinhVien.TabStop = true;
            rbSinhVien.Text = "Sinh viên";
            rbSinhVien.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1430, 756);
            Controls.Add(gbRole);
            Controls.Add(btnRegister);
            Controls.Add(txtNewPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtNewEmail);
            Controls.Add(lblEmail);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Ký Tài Khoản Mới";
            Load += RegisterForm_Load;
            gbRole.ResumeLayout(false);
            gbRole.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        // Các control được khai báo ở đây để file .cs kia có thể thấy
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnRegister;

        // --- THÊM KHAI BÁO MỚI ---
        private System.Windows.Forms.GroupBox gbRole;
        private System.Windows.Forms.RadioButton rbSinhVien;
        private System.Windows.Forms.RadioButton rbGiangVien;
    }
}