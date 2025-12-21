using Guna.UI2.WinForms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class Student_Information
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel panelLeft;
        private Guna2Panel panelTop;
        private Guna2Panel panelMainContent;
        private Guna2HtmlLabel lblWelcome;
        private Guna2Button btnLogout;
        private Guna2HtmlLabel lblTitle;
        private Guna2Panel grpPersonalInfo;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2TextBox txtStudentID;
        private Guna2TextBox txtFullName;
        private Guna2TextBox txtHDT;
        private Guna2Panel grpAcademicInfo;
        private Guna2HtmlLabel guna2HtmlLabel4;
        private Guna2HtmlLabel guna2HtmlLabel5;
        private Guna2HtmlLabel guna2HtmlLabel6;
        private Guna2HtmlLabel guna2HtmlLabel7;
        private Guna2HtmlLabel guna2HtmlLabel8;
        private Guna2TextBox txtSex;
        private Guna2TextBox txtBirthday;
        private Guna2TextBox txtFaculty;
        private Guna2TextBox txtClass;
        private Guna2TextBox txtEmail;
        private Guna2Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            panelLeft = new Guna2Panel();
            panelTop = new Guna2Panel();
            panelMainContent = new Guna2Panel();
            lblWelcome = new Guna2HtmlLabel();
            btnLogout = new Guna2Button();
            btnSave = new Guna2Button();
            lblTitle = new Guna2HtmlLabel();
            grpPersonalInfo = new Guna2Panel();
            grpAcademicInfo = new Guna2Panel();

            // Khởi tạo các Label và TextBox chi tiết
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            txtStudentID = new Guna2TextBox();
            txtFullName = new Guna2TextBox();
            txtHDT = new Guna2TextBox();

            guna2HtmlLabel4 = new Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna2HtmlLabel();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            guna2HtmlLabel8 = new Guna2HtmlLabel();
            txtSex = new Guna2TextBox();
            txtBirthday = new Guna2TextBox();
            txtFaculty = new Guna2TextBox();
            txtClass = new Guna2TextBox();
            txtEmail = new Guna2TextBox();

            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            grpPersonalInfo.SuspendLayout();
            grpAcademicInfo.SuspendLayout();
            SuspendLayout();

            // --- panelLeft ---
            panelLeft.BackColor = Color.FromArgb(242, 245, 250);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(btnSave);
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(180, 520);
            panelLeft.TabIndex = 0;

            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWelcome.Location = new Point(15, 30);
            lblWelcome.Size = new Size(110, 22);
            lblWelcome.Text = "CHÀO SINH VIÊN";

            btnSave.BorderRadius = 8;
            btnSave.FillColor = Color.FromArgb(46, 204, 113);
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(10, 400);
            btnSave.Size = new Size(160, 45);
            btnSave.Text = "LƯU THÔNG TIN";
            btnSave.Click += btnSave_Click;

            btnLogout.BorderRadius = 8;
            btnLogout.FillColor = Color.FromArgb(231, 76, 60);
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(10, 455);
            btnLogout.Size = new Size(160, 45);
            btnLogout.Text = "THOÁT";
            btnLogout.Click += btnLogout_Click;

            // --- panelTop ---
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(180, 0);
            panelTop.Size = new Size(620, 70);

            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(140, 15);
            lblTitle.Text = "HỒ SƠ SINH VIÊN";

            // --- panelMainContent ---
            panelMainContent.BackColor = Color.FromArgb(242, 245, 250);
            panelMainContent.Controls.Add(grpPersonalInfo);
            panelMainContent.Controls.Add(grpAcademicInfo);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(180, 70);
            panelMainContent.Size = new Size(620, 450);

            // --- grpPersonalInfo (Card 1) ---
            grpPersonalInfo.BorderRadius = 15;
            grpPersonalInfo.FillColor = Color.White;
            grpPersonalInfo.Location = new Point(20, 15);
            grpPersonalInfo.Size = new Size(570, 175);
            grpPersonalInfo.ShadowDecoration.Enabled = true;
            grpPersonalInfo.ShadowDecoration.Color = Color.Gainsboro;

            // Labels 1
            guna2HtmlLabel1.Text = "Mã số sinh viên:";
            guna2HtmlLabel1.Location = new Point(25, 25);
            guna2HtmlLabel2.Text = "Họ và tên:";
            guna2HtmlLabel2.Location = new Point(25, 75);
            guna2HtmlLabel3.Text = "Hệ đào tạo:";
            guna2HtmlLabel3.Location = new Point(25, 125);

            // TextBoxes 1
            txtStudentID.Location = new Point(180, 20);
            txtStudentID.Size = new Size(350, 36);
            txtStudentID.BorderRadius = 5;
            txtStudentID.ReadOnly = true;

            txtFullName.Location = new Point(180, 70);
            txtFullName.Size = new Size(350, 36);
            txtFullName.BorderRadius = 5;

            txtHDT.Location = new Point(180, 120);
            txtHDT.Size = new Size(350, 36);
            txtHDT.BorderRadius = 5;

            grpPersonalInfo.Controls.AddRange(new Control[] { guna2HtmlLabel1, guna2HtmlLabel2, guna2HtmlLabel3, txtStudentID, txtFullName, txtHDT });

            // --- grpAcademicInfo (Card 2) ---
            grpAcademicInfo.BorderRadius = 15;
            grpAcademicInfo.FillColor = Color.White;
            grpAcademicInfo.Location = new Point(20, 205);
            grpAcademicInfo.Size = new Size(570, 225);
            grpAcademicInfo.ShadowDecoration.Enabled = true;
            grpAcademicInfo.ShadowDecoration.Color = Color.Gainsboro;

            // Labels 2
            guna2HtmlLabel4.Text = "Giới tính:";
            guna2HtmlLabel4.Location = new Point(25, 20);
            guna2HtmlLabel5.Text = "Ngày sinh:";
            guna2HtmlLabel5.Location = new Point(25, 60);
            guna2HtmlLabel7.Text = "Khoa:";
            guna2HtmlLabel7.Location = new Point(25, 100);
            guna2HtmlLabel6.Text = "Lớp sinh hoạt:";
            guna2HtmlLabel6.Location = new Point(25, 140);
            guna2HtmlLabel8.Text = "Email liên hệ:";
            guna2HtmlLabel8.Location = new Point(25, 180);

            // TextBoxes 2
            txtSex.Location = new Point(180, 15);
            txtSex.Size = new Size(350, 32);
            txtSex.BorderRadius = 5;

            txtBirthday.Location = new Point(180, 55);
            txtBirthday.Size = new Size(350, 32);
            txtBirthday.BorderRadius = 5;

            txtFaculty.Location = new Point(180, 95);
            txtFaculty.Size = new Size(350, 32);
            txtFaculty.BorderRadius = 5;

            txtClass.Location = new Point(180, 135);
            txtClass.Size = new Size(350, 32);
            txtClass.BorderRadius = 5;

            txtEmail.Location = new Point(180, 175);
            txtEmail.Size = new Size(350, 32);
            txtEmail.BorderRadius = 5;

            grpAcademicInfo.Controls.AddRange(new Control[] { guna2HtmlLabel4, guna2HtmlLabel5, guna2HtmlLabel6, guna2HtmlLabel7, guna2HtmlLabel8, txtSex, txtBirthday, txtFaculty, txtClass, txtEmail });

            // --- Form Settings ---
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(panelMainContent);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Student_Information";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết sinh viên";

            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMainContent.ResumeLayout(false);
            grpPersonalInfo.ResumeLayout(false);
            grpPersonalInfo.PerformLayout();
            grpAcademicInfo.ResumeLayout(false);
            grpAcademicInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}