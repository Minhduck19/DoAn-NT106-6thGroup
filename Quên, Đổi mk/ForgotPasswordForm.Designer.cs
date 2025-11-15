using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN
{
    partial class ForgotPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPrompt;
        private TextBox txtEmail;
        private Button btnSend;
        private Button btnCancel;

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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm));
            lblPrompt = new Label();
            txtEmail = new TextBox();
            btnSend = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.BackColor = Color.Transparent;
            lblPrompt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrompt.ForeColor = Color.White;
            lblPrompt.Location = new Point(529, 287);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(354, 38);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Nhập email để nhận link đặt lại mật khẩu:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(529, 337);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(454, 36);
            txtEmail.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackgroundImage = (Image)resources.GetObject("btnSend.BackgroundImage");
            btnSend.BackgroundImageLayout = ImageLayout.Stretch;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(615, 379);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(107, 40);
            btnSend.TabIndex = 2;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += BtnSend_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackgroundImage = (Image)resources.GetObject("btnCancel.BackgroundImage");
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(807, 379);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1431, 752);
            Controls.Add(lblPrompt);
            Controls.Add(txtEmail);
            Controls.Add(btnSend);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quên mật khẩu";
            Load += ForgotPasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}