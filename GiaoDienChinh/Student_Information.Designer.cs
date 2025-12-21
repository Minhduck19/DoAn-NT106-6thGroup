using Guna.UI2.WinForms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class Student_Information
    {
        private System.ComponentModel.IContainer components = null;

        // KHAI BÁO CONTROLS VỚI GUNA UI
        private Guna2Panel panelLeft;
        private Guna2Panel panelTop;
        private Guna2Panel panelMainContent;

        private Guna2HtmlLabel lblWelcome;
        private Guna2Button btnLogout;
        private Guna2HtmlLabel lblTitle;

        // Thay GroupBox bằng Guna2Panel để tạo hiệu ứng Card
        private Guna2Panel grpPersonalInfo;
        private Guna2HtmlLabel lblStudentID;
        private Guna2HtmlLabel lblFullName;
        private Guna2HtmlLabel lblDOB;
        private Guna2TextBox txtFullName;
        private Guna2TextBox txtHDT;

        private Guna2Panel grpAcademicInfo;
        private Guna2HtmlLabel lblClass;
        private Guna2HtmlLabel lblMajor;
        private Guna2HtmlLabel lblEmail;
        private Guna2TextBox txtSex;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLeft = new Guna2Panel();
            btnSave = new Guna2Button();
            lblWelcome = new Guna2HtmlLabel();
            btnLogout = new Guna2Button();
            panelTop = new Guna2Panel();
            lblTitle = new Guna2HtmlLabel();
            panelMainContent = new Guna2Panel();
            grpPersonalInfo = new Guna2Panel();
            txtStudentID = new Guna2TextBox();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            lblStudentID = new Guna2HtmlLabel();
            lblFullName = new Guna2HtmlLabel();
            txtFullName = new Guna2TextBox();
            lblDOB = new Guna2HtmlLabel();
            txtHDT = new Guna2TextBox();
            grpAcademicInfo = new Guna2Panel();
            guna2HtmlLabel8 = new Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna2HtmlLabel();
            txtEmail = new Guna2TextBox();
            txtClass = new Guna2TextBox();
            txtFaculty = new Guna2TextBox();
            txtBirthday = new Guna2TextBox();
            lblClass = new Guna2HtmlLabel();
            lblMajor = new Guna2HtmlLabel();
            txtSex = new Guna2TextBox();
            lblEmail = new Guna2HtmlLabel();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            grpPersonalInfo.SuspendLayout();
            grpAcademicInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(btnSave);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(btnLogout);
            panelLeft.CustomizableEdges = customizableEdges5;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelLeft.Size = new Size(200, 500);
            panelLeft.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 10;
            btnSave.CustomizableEdges = customizableEdges1;
            btnSave.FillColor = Color.FromArgb(231, 76, 60);
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(10, 393);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(180, 40);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Black;
            lblWelcome.Location = new Point(12, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(117, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào, [User]";
            // 
            // btnLogout
            // 
            btnLogout.BorderRadius = 10;
            btnLogout.CustomizableEdges = customizableEdges3;
            btnLogout.FillColor = Color.FromArgb(231, 76, 60);
            btnLogout.Font = new Font("Segoe UI", 9F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(10, 450);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLogout.Size = new Size(180, 40);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Thoát";
            btnLogout.Click += btnLogout_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.ControlLightLight;
            panelTop.Controls.Add(lblTitle);
            panelTop.CustomizableEdges = customizableEdges7;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(200, 0);
            panelTop.Name = "panelTop";
            panelTop.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelTop.Size = new Size(600, 60);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(150, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN SINH VIÊN";
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(grpPersonalInfo);
            panelMainContent.Controls.Add(grpAcademicInfo);
            panelMainContent.CustomizableEdges = customizableEdges29;
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(200, 60);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(20);
            panelMainContent.ShadowDecoration.CustomizableEdges = customizableEdges30;
            panelMainContent.Size = new Size(600, 440);
            panelMainContent.TabIndex = 0;
            // 
            // grpPersonalInfo
            // 
            grpPersonalInfo.BackColor = Color.Transparent;
            grpPersonalInfo.BorderRadius = 10;
            grpPersonalInfo.Controls.Add(txtStudentID);
            grpPersonalInfo.Controls.Add(guna2HtmlLabel3);
            grpPersonalInfo.Controls.Add(guna2HtmlLabel2);
            grpPersonalInfo.Controls.Add(guna2HtmlLabel1);
            grpPersonalInfo.Controls.Add(lblStudentID);
            grpPersonalInfo.Controls.Add(lblFullName);
            grpPersonalInfo.Controls.Add(txtFullName);
            grpPersonalInfo.Controls.Add(lblDOB);
            grpPersonalInfo.Controls.Add(txtHDT);
            grpPersonalInfo.CustomizableEdges = customizableEdges15;
            grpPersonalInfo.FillColor = Color.White;
            grpPersonalInfo.Location = new Point(20, 20);
            grpPersonalInfo.Name = "grpPersonalInfo";
            grpPersonalInfo.ShadowDecoration.CustomizableEdges = customizableEdges16;
            grpPersonalInfo.ShadowDecoration.Enabled = true;
            grpPersonalInfo.Size = new Size(560, 160);
            grpPersonalInfo.TabIndex = 0;
            // 
            // txtStudentID
            // 
            txtStudentID.CustomizableEdges = customizableEdges9;
            txtStudentID.DefaultText = "";
            txtStudentID.Font = new Font("Segoe UI", 9F);
            txtStudentID.Location = new Point(253, 4);
            txtStudentID.Margin = new Padding(3, 4, 3, 4);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.PlaceholderText = "";
            txtStudentID.SelectedText = "";
            txtStudentID.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtStudentID.Size = new Size(239, 33);
            txtStudentID.TabIndex = 9;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel3.AutoSize = false;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Location = new Point(289, 41);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(151, 28);
            guna2HtmlLabel3.TabIndex = 8;
            guna2HtmlLabel3.Text = "Hệ đào tạo:";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(18, 39);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(151, 30);
            guna2HtmlLabel2.TabIndex = 7;
            guna2HtmlLabel2.Text = "Họ và tên:";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(96, 3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(151, 30);
            guna2HtmlLabel1.TabIndex = 6;
            guna2HtmlLabel1.Text = "Mã số sinh viên:";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblStudentID
            // 
            lblStudentID.BackColor = Color.Transparent;
            lblStudentID.Location = new Point(0, 0);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(3, 2);
            lblStudentID.TabIndex = 0;
            lblStudentID.Text = null;
            // 
            // lblFullName
            // 
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Location = new Point(0, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(3, 2);
            lblFullName.TabIndex = 2;
            lblFullName.Text = null;
            // 
            // txtFullName
            // 
            txtFullName.CustomizableEdges = customizableEdges11;
            txtFullName.DefaultText = "";
            txtFullName.Font = new Font("Segoe UI", 9F);
            txtFullName.Location = new Point(18, 69);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "";
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtFullName.Size = new Size(229, 48);
            txtFullName.TabIndex = 3;
            // 
            // lblDOB
            // 
            lblDOB.BackColor = Color.Transparent;
            lblDOB.Location = new Point(0, 0);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(3, 2);
            lblDOB.TabIndex = 4;
            lblDOB.Text = null;
            // 
            // txtHDT
            // 
            txtHDT.CustomizableEdges = customizableEdges13;
            txtHDT.DefaultText = "";
            txtHDT.Font = new Font("Segoe UI", 9F);
            txtHDT.Location = new Point(289, 69);
            txtHDT.Margin = new Padding(3, 4, 3, 4);
            txtHDT.Name = "txtHDT";
            txtHDT.PlaceholderText = "";
            txtHDT.SelectedText = "";
            txtHDT.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtHDT.Size = new Size(244, 48);
            txtHDT.TabIndex = 5;
            // 
            // grpAcademicInfo
            // 
            grpAcademicInfo.BackColor = Color.Transparent;
            grpAcademicInfo.BorderRadius = 10;
            grpAcademicInfo.Controls.Add(guna2HtmlLabel8);
            grpAcademicInfo.Controls.Add(guna2HtmlLabel7);
            grpAcademicInfo.Controls.Add(guna2HtmlLabel6);
            grpAcademicInfo.Controls.Add(guna2HtmlLabel5);
            grpAcademicInfo.Controls.Add(guna2HtmlLabel4);
            grpAcademicInfo.Controls.Add(txtEmail);
            grpAcademicInfo.Controls.Add(txtClass);
            grpAcademicInfo.Controls.Add(txtFaculty);
            grpAcademicInfo.Controls.Add(txtBirthday);
            grpAcademicInfo.Controls.Add(lblClass);
            grpAcademicInfo.Controls.Add(lblMajor);
            grpAcademicInfo.Controls.Add(txtSex);
            grpAcademicInfo.Controls.Add(lblEmail);
            grpAcademicInfo.CustomizableEdges = customizableEdges27;
            grpAcademicInfo.FillColor = Color.White;
            grpAcademicInfo.Location = new Point(20, 195);
            grpAcademicInfo.Name = "grpAcademicInfo";
            grpAcademicInfo.ShadowDecoration.CustomizableEdges = customizableEdges28;
            grpAcademicInfo.ShadowDecoration.Enabled = true;
            grpAcademicInfo.Size = new Size(560, 230);
            grpAcademicInfo.TabIndex = 1;
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel8.AutoSize = false;
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Location = new Point(18, 182);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(151, 30);
            guna2HtmlLabel8.TabIndex = 13;
            guna2HtmlLabel8.Text = "Email:";
            guna2HtmlLabel8.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel7.AutoSize = false;
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Location = new Point(18, 100);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(151, 30);
            guna2HtmlLabel7.TabIndex = 12;
            guna2HtmlLabel7.Text = "Khoa:";
            guna2HtmlLabel7.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel6.AutoSize = false;
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Location = new Point(18, 138);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(151, 30);
            guna2HtmlLabel6.TabIndex = 11;
            guna2HtmlLabel6.Text = "Lớp sinh hoạt:";
            guna2HtmlLabel6.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel5.AutoSize = false;
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Location = new Point(18, 59);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(151, 30);
            guna2HtmlLabel5.TabIndex = 10;
            guna2HtmlLabel5.Text = "Năm sinh:";
            guna2HtmlLabel5.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel4.AutoSize = false;
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Location = new Point(18, 18);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(151, 30);
            guna2HtmlLabel4.TabIndex = 9;
            guna2HtmlLabel4.Text = "Giới tính:";
            guna2HtmlLabel4.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // txtEmail
            // 
            txtEmail.CustomizableEdges = customizableEdges17;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(175, 179);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtEmail.Size = new Size(358, 33);
            txtEmail.TabIndex = 8;
            // 
            // txtClass
            // 
            txtClass.CustomizableEdges = customizableEdges19;
            txtClass.DefaultText = "";
            txtClass.Font = new Font("Segoe UI", 9F);
            txtClass.Location = new Point(175, 138);
            txtClass.Margin = new Padding(3, 4, 3, 4);
            txtClass.Name = "txtClass";
            txtClass.PlaceholderText = "";
            txtClass.SelectedText = "";
            txtClass.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtClass.Size = new Size(358, 33);
            txtClass.TabIndex = 7;
            // 
            // txtFaculty
            // 
            txtFaculty.CustomizableEdges = customizableEdges21;
            txtFaculty.DefaultText = "";
            txtFaculty.Font = new Font("Segoe UI", 9F);
            txtFaculty.Location = new Point(175, 97);
            txtFaculty.Margin = new Padding(3, 4, 3, 4);
            txtFaculty.Name = "txtFaculty";
            txtFaculty.PlaceholderText = "";
            txtFaculty.SelectedText = "";
            txtFaculty.ShadowDecoration.CustomizableEdges = customizableEdges22;
            txtFaculty.Size = new Size(358, 33);
            txtFaculty.TabIndex = 6;
            // 
            // txtBirthday
            // 
            txtBirthday.AcceptsTab = true;
            txtBirthday.CustomizableEdges = customizableEdges23;
            txtBirthday.DefaultText = "";
            txtBirthday.Font = new Font("Segoe UI", 9F);
            txtBirthday.Location = new Point(175, 56);
            txtBirthday.Margin = new Padding(3, 4, 3, 4);
            txtBirthday.Name = "txtBirthday";
            txtBirthday.PlaceholderText = "";
            txtBirthday.SelectedText = "";
            txtBirthday.ShadowDecoration.CustomizableEdges = customizableEdges24;
            txtBirthday.Size = new Size(358, 33);
            txtBirthday.TabIndex = 5;
            // 
            // lblClass
            // 
            lblClass.BackColor = Color.Transparent;
            lblClass.Location = new Point(0, 0);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(3, 2);
            lblClass.TabIndex = 0;
            lblClass.Text = null;
            // 
            // lblMajor
            // 
            lblMajor.BackColor = Color.Transparent;
            lblMajor.Location = new Point(0, 0);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(3, 2);
            lblMajor.TabIndex = 2;
            lblMajor.Text = null;
            // 
            // txtSex
            // 
            txtSex.CustomizableEdges = customizableEdges25;
            txtSex.DefaultText = "";
            txtSex.Font = new Font("Segoe UI", 9F);
            txtSex.Location = new Point(175, 15);
            txtSex.Margin = new Padding(3, 4, 3, 4);
            txtSex.Name = "txtSex";
            txtSex.PlaceholderText = "";
            txtSex.SelectedText = "";
            txtSex.ShadowDecoration.CustomizableEdges = customizableEdges26;
            txtSex.Size = new Size(358, 33);
            txtSex.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Location = new Point(0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(3, 2);
            lblEmail.TabIndex = 4;
            lblEmail.Text = null;
            // 
            // Student_Information
            // 
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 500);
            Controls.Add(panelMainContent);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Name = "Student_Information";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin sinh viên";
            Load += Teacher_Information_Load;
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

            // ... (Phần ResumeLayout giữ nguyên) ...
        }

        #endregion

        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2HtmlLabel guna2HtmlLabel8;
        private Guna2HtmlLabel guna2HtmlLabel7;
        private Guna2HtmlLabel guna2HtmlLabel6;
        private Guna2HtmlLabel guna2HtmlLabel5;
        private Guna2HtmlLabel guna2HtmlLabel4;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtClass;
        private Guna2TextBox txtFaculty;
        private Guna2TextBox txtBirthday;
        private Guna2Button btnSave;
        private Guna2TextBox txtStudentID;
    }
}
