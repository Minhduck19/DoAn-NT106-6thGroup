using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class Student_Information
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel panelMainContent;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

        // Avatar Controls (Mới thêm)
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChangeAvatar;

        private Guna.UI2.WinForms.Guna2Panel grpPersonalInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStudentID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFullName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDOB;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtStudentID; // Đổi tên từ TeacherID

        private Guna.UI2.WinForms.Guna2Panel grpAcademicInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMajor;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtSex;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtClass;
        private Guna.UI2.WinForms.Guna2TextBox txtFaculty;
        private Guna.UI2.WinForms.Guna2TextBox txtBirthday;

        // Labels
        private Guna.UI2.WinForms.Guna2HtmlLabel labelSex;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelKhoa;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelLop;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new Guna2Panel();
            this.picAvatar = new Guna2CirclePictureBox(); // Avatar
            this.btnChangeAvatar = new Guna2Button();     // Nút đổi ảnh
            this.lblWelcome = new Guna2HtmlLabel();
            this.btnSave = new Guna2Button();
            this.btnLogout = new Guna2Button();

            this.panelTop = new Guna2Panel();
            this.lblTitle = new Guna2HtmlLabel();

            this.panelMainContent = new Guna2Panel();
            this.grpPersonalInfo = new Guna2Panel();
            this.txtStudentID = new Guna2TextBox();
            this.lblStudentID = new Guna2HtmlLabel();
            this.lblFullName = new Guna2HtmlLabel();
            this.txtFullName = new Guna2TextBox();

            this.grpAcademicInfo = new Guna2Panel();
            this.txtEmail = new Guna2TextBox();
            this.txtClass = new Guna2TextBox();
            this.txtFaculty = new Guna2TextBox();
            this.txtBirthday = new Guna2TextBox();
            this.txtSex = new Guna2TextBox();

            this.lblDOB = new Guna2HtmlLabel();
            this.labelSex = new Guna2HtmlLabel();
            this.labelKhoa = new Guna2HtmlLabel();
            this.labelLop = new Guna2HtmlLabel();
            this.labelEmail = new Guna2HtmlLabel();

            // Init Panels
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            this.grpPersonalInfo.SuspendLayout();
            this.grpAcademicInfo.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelLeft (Chứa Avatar và Nút bấm)
            // 
            this.panelLeft.BackColor = Color.White;
            this.panelLeft.Controls.Add(this.picAvatar);
            this.panelLeft.Controls.Add(this.btnChangeAvatar);
            this.panelLeft.Controls.Add(this.lblWelcome);
            this.panelLeft.Controls.Add(this.btnSave);
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Size = new Size(220, 608);
            this.panelLeft.ShadowDecoration.Enabled = true;

            // -- lblWelcome --
            this.lblWelcome.BackColor = Color.Transparent;
            this.lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblWelcome.Location = new Point(20, 20);
            this.lblWelcome.Text = "Chào, Sinh viên";

            // -- picAvatar (Hình tròn) --
            this.picAvatar.BackColor = Color.Transparent;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new Point(45, 70);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.ShadowDecoration.Enabled = true;
            this.picAvatar.Size = new Size(130, 130);
            this.picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabStop = false;

            // -- btnChangeAvatar --
            this.btnChangeAvatar.BorderRadius = 15;
            this.btnChangeAvatar.FillColor = Color.FromArgb(94, 148, 255);
            this.btnChangeAvatar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnChangeAvatar.ForeColor = Color.White;
            this.btnChangeAvatar.Location = new Point(55, 215);
            this.btnChangeAvatar.Name = "btnChangeAvatar";
            this.btnChangeAvatar.Size = new Size(110, 35);
            this.btnChangeAvatar.Text = "Đổi ảnh";
            this.btnChangeAvatar.Click += new System.EventHandler(this.btnChangeAvatar_Click);

            // -- btnSave --
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = Color.FromArgb(39, 174, 96); // Màu xanh lá
            this.btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(20, 480);
            this.btnSave.Size = new Size(180, 45);
            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // -- btnLogout --
            this.btnLogout.BorderRadius = 10;
            this.btnLogout.FillColor = Color.Gray;
            this.btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(20, 540);
            this.btnLogout.Size = new Size(180, 45);
            this.btnLogout.Text = "Thoát";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Size = new Size(719, 60);

            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(220, 12);
            this.lblTitle.Text = "THÔNG TIN SINH VIÊN";

            // 
            // panelMainContent
            // 
            this.panelMainContent.Controls.Add(this.grpPersonalInfo);
            this.panelMainContent.Controls.Add(this.grpAcademicInfo);
            this.panelMainContent.Dock = DockStyle.Fill;
            this.panelMainContent.Padding = new Padding(20);
            this.panelMainContent.Size = new Size(719, 548);

            // 
            // grpPersonalInfo (Thông tin cơ bản)
            // 
            this.grpPersonalInfo.BorderRadius = 15;
            this.grpPersonalInfo.FillColor = Color.White;
            this.grpPersonalInfo.Location = new Point(20, 20);
            this.grpPersonalInfo.Size = new Size(680, 120);
            this.grpPersonalInfo.ShadowDecoration.Enabled = true;
            this.grpPersonalInfo.Controls.Add(this.lblStudentID);
            this.grpPersonalInfo.Controls.Add(this.txtStudentID);
            this.grpPersonalInfo.Controls.Add(this.lblFullName);
            this.grpPersonalInfo.Controls.Add(this.txtFullName);

            // -- Mã sinh viên --
            this.lblStudentID.Text = "Mã số sinh viên:";
            this.lblStudentID.BackColor = Color.Transparent;
            this.lblStudentID.Font = new Font("Segoe UI", 10F);
            this.lblStudentID.Location = new Point(30, 20);

            this.txtStudentID.BorderRadius = 5;
            this.txtStudentID.Location = new Point(30, 45);
            this.txtStudentID.Size = new Size(250, 36);

            // -- Họ tên --
            this.lblFullName.Text = "Họ và tên:";
            this.lblFullName.BackColor = Color.Transparent;
            this.lblFullName.Font = new Font("Segoe UI", 10F);
            this.lblFullName.Location = new Point(350, 20);

            this.txtFullName.BorderRadius = 5;
            this.txtFullName.Location = new Point(350, 45);
            this.txtFullName.Size = new Size(280, 36);

            // 
            // grpAcademicInfo (Thông tin chi tiết)
            // 
            this.grpAcademicInfo.BorderRadius = 15;
            this.grpAcademicInfo.FillColor = Color.White;
            this.grpAcademicInfo.Location = new Point(20, 160);
            this.grpAcademicInfo.Size = new Size(680, 350);
            this.grpAcademicInfo.ShadowDecoration.Enabled = true;

            // Add Controls to grpAcademicInfo
            this.grpAcademicInfo.Controls.Add(this.lblDOB); this.grpAcademicInfo.Controls.Add(this.txtBirthday);
            this.grpAcademicInfo.Controls.Add(this.labelSex); this.grpAcademicInfo.Controls.Add(this.txtSex);
            this.grpAcademicInfo.Controls.Add(this.labelKhoa); this.grpAcademicInfo.Controls.Add(this.txtFaculty);
            this.grpAcademicInfo.Controls.Add(this.labelLop); this.grpAcademicInfo.Controls.Add(this.txtClass);
            this.grpAcademicInfo.Controls.Add(this.labelEmail); this.grpAcademicInfo.Controls.Add(this.txtEmail);

            // Positioning Helper
            int startY = 30; int gapY = 60; int labelX = 50; int textX = 200; int textW = 400;

            // 1. Ngày sinh
            SetupField(this.lblDOB, "Ngày sinh:", this.txtBirthday, labelX, textX, startY, textW);

            // 2. Giới tính
            SetupField(this.labelSex, "Giới tính:", this.txtSex, labelX, textX, startY + gapY, textW);

            // 3. Khoa
            SetupField(this.labelKhoa, "Khoa:", this.txtFaculty, labelX, textX, startY + gapY * 2, textW);

            // 4. Lớp sinh hoạt
            SetupField(this.labelLop, "Lớp sinh hoạt:", this.txtClass, labelX, textX, startY + gapY * 3, textW);

            // 5. Email
            SetupField(this.labelEmail, "Email:", this.txtEmail, labelX, textX, startY + gapY * 4, textW);
            this.txtEmail.Enabled = false;

            // Form Config
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(939, 608);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Name = "Student_Information";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Thông tin sinh viên";
            this.Load += new System.EventHandler(this.Student_Information_Load);

            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMainContent.ResumeLayout(false);
            this.grpPersonalInfo.ResumeLayout(false);
            this.grpPersonalInfo.PerformLayout();
            this.grpAcademicInfo.ResumeLayout(false);
            this.grpAcademicInfo.PerformLayout();
            this.ResumeLayout(false);
        }

        private void SetupField(Guna2HtmlLabel lbl, string text, Guna2TextBox txt, int lx, int tx, int y, int w)
        {
            lbl.Text = text;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Segoe UI", 10F);
            lbl.Location = new Point(lx, y + 5);

            txt.BorderRadius = 5;
            txt.Location = new Point(tx, y);
            txt.Size = new Size(w, 36);
        }
    }
}