namespace APP_DOAN
{
    partial class ForgotPasswordForm
    {
        // (Xóa các khai báo cũ: private Label lblPrompt; private TextBox txtEmail; ...)

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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            panelMain = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblPrompt = new Label();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnSend = new Guna.UI2.WinForms.Guna2Button();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblTitle = new Label();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            guna2ShadowForm1.BorderRadius = 20;
            guna2ShadowForm1.ShadowColor = Color.DimGray;
            guna2ShadowForm1.TargetForm = this;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.None;
            panelMain.BackColor = Color.Transparent;
            panelMain.Controls.Add(lblPrompt);
            panelMain.Controls.Add(btnCancel);
            panelMain.Controls.Add(btnSend);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblTitle);
            panelMain.FillColor = Color.White;
            panelMain.Location = new Point(234, 158);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Radius = 15;
            panelMain.ShadowColor = Color.Black;
            panelMain.ShadowDepth = 150;
            panelMain.ShadowShift = 10;
            panelMain.Size = new Size(400, 438);
            panelMain.TabIndex = 0;
            // 
            // lblPrompt
            // 
            lblPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrompt.ForeColor = Color.Gray;
            lblPrompt.Location = new Point(40, 125);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(320, 60);
            lblPrompt.TabIndex = 6;
            lblPrompt.Text = "Nhập email của bạn và chúng tôi sẽ gửi cho bạn một link để đặt lại mật khẩu.";
            lblPrompt.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            btnCancel.Animated = true;
            btnCancel.BorderRadius = 10;
            btnCancel.CustomizableEdges = customizableEdges13;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(70, 350);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnCancel.Size = new Size(260, 56);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSend
            // 
            btnSend.Animated = true;
            btnSend.BorderRadius = 10;
            btnSend.CustomizableEdges = customizableEdges9;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.FillColor = Color.FromArgb(0, 118, 221);
            btnSend.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(70, 275);
            btnSend.Margin = new Padding(3, 4, 3, 4);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSend.Size = new Size(260, 56);
            btnSend.TabIndex = 2;
            btnSend.Text = "Gửi";
            btnSend.Click += btnSend_Click;
            // 
            // txtEmail
            // 
            txtEmail.Animated = true;
            txtEmail.BorderRadius = 8;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.CustomizableEdges = customizableEdges15;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(70, 200);
            txtEmail.Margin = new Padding(3, 5, 3, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email của bạn";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtEmail.Size = new Size(260, 50);
            txtEmail.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(0, 118, 221);
            lblTitle.Location = new Point(50, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(298, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUÊN MẬT KHẨU";
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges11;
            guna2ControlBox1.FillColor = Color.FromArgb(0, 118, 221);
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(823, 2);
            guna2ControlBox1.Margin = new Padding(3, 4, 3, 4);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2ControlBox1.Size = new Size(45, 36);
            guna2ControlBox1.TabIndex = 1;
            // 
            // ForgotPasswordForm
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 118, 221);
            BackgroundImage = Properties.Resources.d552cbffdb75d65d2130679ea07d6ac2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(870, 750);
            Controls.Add(guna2ControlBox1);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quên mật khẩu";
            WindowState = FormWindowState.Maximized;
            Load += ForgotPasswordForm_Load;
            Resize += ForgotPasswordForm_Resize;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblPrompt;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

    }
}