using System.Drawing;
using System.Windows.Forms;

    namespace APP_DOAN
{
    partial class ChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnChange;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnChange = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(548, 183);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(552, 207);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 27);
            txtEmail.TabIndex = 1;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.BackColor = Color.Transparent;
            lblCurrentPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentPassword.ForeColor = Color.White;
            lblCurrentPassword.Location = new Point(548, 245);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(99, 20);
            lblCurrentPassword.TabIndex = 2;
            lblCurrentPassword.Text = "Mật khẩu cũ:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(552, 269);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(360, 27);
            txtCurrentPassword.TabIndex = 3;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.BackColor = Color.Transparent;
            lblNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.Location = new Point(548, 307);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(110, 20);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "Mật khẩu mới:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(552, 331);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(360, 27);
            txtNewPassword.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Location = new Point(548, 369);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(147, 20);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(552, 393);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(360, 27);
            txtConfirmPassword.TabIndex = 7;
            // 
            // btnChange
            // 
            btnChange.BackgroundImage = (Image)resources.GetObject("btnChange.BackgroundImage");
            btnChange.BackgroundImageLayout = ImageLayout.Stretch;
            btnChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChange.ForeColor = Color.White;
            btnChange.Location = new Point(726, 435);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(90, 34);
            btnChange.TabIndex = 8;
            btnChange.Text = "Đổi";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackgroundImage = (Image)resources.GetObject("btnCancel.BackgroundImage");
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(820, 435);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 34);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1426, 760);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblCurrentPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnChange);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            Load += ChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}