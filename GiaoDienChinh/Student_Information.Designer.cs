namespace APP_DOAN.GiaoDienChinh
{
    partial class Student_Information
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMainContent;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpPersonalInfo;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtDOB;

        private System.Windows.Forms.GroupBox grpAcademicInfo;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.TextBox txtEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelLeft = new Panel();
            lblWelcome = new Label();
            btnLogout = new Button();
            panelTop = new Panel();
            lblTitle = new Label();
            panelMainContent = new Panel();
            grpPersonalInfo = new GroupBox();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblDOB = new Label();
            txtDOB = new TextBox();
            grpAcademicInfo = new GroupBox();
            lblClass = new Label();
            txtClass = new TextBox();
            lblMajor = new Label();
            txtMajor = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            grpPersonalInfo.SuspendLayout();
            grpAcademicInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = SystemColors.ControlDark;
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 500);
            panelLeft.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.Location = new Point(12, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(176, 26);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào, [User]";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(0, 460);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 40);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Đăng xuất";
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.ControlLightLight;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(200, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(600, 60);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(150, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(260, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thông tin sinh viên";
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(grpPersonalInfo);
            panelMainContent.Controls.Add(grpAcademicInfo);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(200, 60);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(10);
            panelMainContent.Size = new Size(600, 440);
            panelMainContent.TabIndex = 0;
            // 
            // grpPersonalInfo
            // 
            grpPersonalInfo.Controls.Add(lblStudentID);
            grpPersonalInfo.Controls.Add(txtStudentID);
            grpPersonalInfo.Controls.Add(lblFullName);
            grpPersonalInfo.Controls.Add(txtFullName);
            grpPersonalInfo.Controls.Add(lblDOB);
            grpPersonalInfo.Controls.Add(txtDOB);
            grpPersonalInfo.Location = new Point(20, 20);
            grpPersonalInfo.Name = "grpPersonalInfo";
            grpPersonalInfo.Size = new Size(567, 154);
            grpPersonalInfo.TabIndex = 0;
            grpPersonalInfo.TabStop = false;
            grpPersonalInfo.Text = "Thông tin cá nhân";
            // 
            // lblStudentID
            // 
            lblStudentID.Location = new Point(74, 30);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(100, 23);
            lblStudentID.TabIndex = 0;
            lblStudentID.Text = "Mã sinh viên:";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(274, 27);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.ReadOnly = true;
            txtStudentID.Size = new Size(259, 27);
            txtStudentID.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.Location = new Point(74, 61);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 23);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ tên:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(274, 60);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(259, 27);
            txtFullName.TabIndex = 3;
            // 
            // lblDOB
            // 
            lblDOB.Location = new Point(74, 93);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(100, 23);
            lblDOB.TabIndex = 4;
            lblDOB.Text = "Ngày sinh:";
            // 
            // txtDOB
            // 
            txtDOB.Location = new Point(274, 93);
            txtDOB.Name = "txtDOB";
            txtDOB.ReadOnly = true;
            txtDOB.Size = new Size(259, 27);
            txtDOB.TabIndex = 5;
            // 
            // grpAcademicInfo
            // 
            grpAcademicInfo.Controls.Add(lblClass);
            grpAcademicInfo.Controls.Add(txtClass);
            grpAcademicInfo.Controls.Add(lblMajor);
            grpAcademicInfo.Controls.Add(txtMajor);
            grpAcademicInfo.Controls.Add(lblEmail);
            grpAcademicInfo.Controls.Add(txtEmail);
            grpAcademicInfo.Location = new Point(20, 180);
            grpAcademicInfo.Name = "grpAcademicInfo";
            grpAcademicInfo.Size = new Size(567, 185);
            grpAcademicInfo.TabIndex = 1;
            grpAcademicInfo.TabStop = false;
            grpAcademicInfo.Text = "Thông tin học tập";
            grpAcademicInfo.Enter += grpAcademicInfo_Enter;
            // 
            // lblClass
            // 
            lblClass.Location = new Point(74, 30);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(100, 23);
            lblClass.TabIndex = 0;
            lblClass.Text = "Lớp:";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(274, 26);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new Size(259, 27);
            txtClass.TabIndex = 1;
            // 
            // lblMajor
            // 
            lblMajor.Location = new Point(74, 63);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(100, 23);
            lblMajor.TabIndex = 2;
            lblMajor.Text = "Ngành:";
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(274, 60);
            txtMajor.Name = "txtMajor";
            txtMajor.ReadOnly = true;
            txtMajor.Size = new Size(259, 27);
            txtMajor.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(74, 99);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            lblEmail.Click += lblEmail_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(274, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(259, 27);
            txtEmail.TabIndex = 5;
            // 
            // Student_Information
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(panelMainContent);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Name = "Student_Information";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin sinh viên";
            panelLeft.ResumeLayout(false);
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
