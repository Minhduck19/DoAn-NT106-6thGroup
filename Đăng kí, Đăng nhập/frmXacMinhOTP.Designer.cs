
namespace APP_DOAN
{
    partial class frmXacMinhOTP
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            panelMain = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnXacMinh = new Guna.UI2.WinForms.Guna2Button();
            txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            panelMain.SuspendLayout();
            SuspendLayout();
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
            panelMain.Controls.Add(btnCancel);
            panelMain.Controls.Add(btnXacMinh);
            panelMain.Controls.Add(txtOTP);
            panelMain.Controls.Add(label1);
            panelMain.FillColor = Color.White;
            panelMain.Location = new Point(697, 188);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Radius = 15;
            panelMain.ShadowColor = Color.Black;
            panelMain.ShadowDepth = 150;
            panelMain.ShadowShift = 10;
            panelMain.Size = new Size(383, 375);
            panelMain.TabIndex = 0;
            // 
            // btnXacMinh
            // 
            btnXacMinh.Animated = true;
            btnXacMinh.BorderRadius = 10;
            btnXacMinh.CustomizableEdges = customizableEdges1;
            btnXacMinh.DisabledState.BorderColor = Color.DarkGray;
            btnXacMinh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXacMinh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXacMinh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXacMinh.FillColor = Color.FromArgb(0, 118, 221);
            btnXacMinh.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXacMinh.ForeColor = Color.White;
            btnXacMinh.Location = new Point(64, 218);
            btnXacMinh.Margin = new Padding(3, 4, 3, 4);
            btnXacMinh.Name = "btnXacMinh";
            btnXacMinh.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnXacMinh.Size = new Size(260, 56);
            btnXacMinh.TabIndex = 2;
            btnXacMinh.Text = "Xác minh";
            btnXacMinh.Click += btnXacMinh_Click;
            // 
            // txtOTP
            // 
            txtOTP.Animated = true;
            txtOTP.BorderRadius = 8;
            txtOTP.Cursor = Cursors.IBeam;
            txtOTP.CustomizableEdges = customizableEdges7;
            txtOTP.DefaultText = "";
            txtOTP.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtOTP.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtOTP.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtOTP.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtOTP.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOTP.Font = new Font("Segoe UI", 10.2F);
            txtOTP.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOTP.Location = new Point(64, 134);
            txtOTP.Margin = new Padding(3, 6, 3, 6);
            txtOTP.MaxLength = 6;
            txtOTP.Name = "txtOTP";
            txtOTP.PlaceholderText = "Nhập mã OTP 6 số";
            txtOTP.SelectedText = "";
            txtOTP.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtOTP.Size = new Size(260, 50);
            txtOTP.TabIndex = 1;
            txtOTP.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 118, 221);
            label1.Location = new Point(64, 56);
            label1.Name = "label1";
            label1.Size = new Size(260, 45);
            label1.TabIndex = 0;
            label1.Text = "XÁC MINH OTP";
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges3;
            guna2ControlBox1.FillColor = Color.FromArgb(0, 118, 221);
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1729, 2);
            guna2ControlBox1.Margin = new Padding(3, 4, 3, 4);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ControlBox1.Size = new Size(45, 36);
            guna2ControlBox1.TabIndex = 1;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 15;
            btnCancel.CustomizableEdges = customizableEdges5;
            btnCancel.FillColor = Color.FromArgb(231, 76, 60);
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(64, 291);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCancel.Size = new Size(260, 46);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // frmXacMinhOTP
            // 
            AcceptButton = btnXacMinh;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.d552cbffdb75d65d2130679ea07d6ac2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1776, 750);
            Controls.Add(guna2ControlBox1);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmXacMinhOTP";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xác Minh OTP";
            WindowState = FormWindowState.Maximized;
            Load += frmXacMinhOTP_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelMain;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2Button btnXacMinh;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}