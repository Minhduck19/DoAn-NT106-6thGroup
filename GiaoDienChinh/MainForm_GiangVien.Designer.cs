namespace APP_DOAN
{
    partial class MainForm_GiangVien
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
        // Khai báo Controls sử dụng Guna.UI2
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel panelMainContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

        // Giữ lại ListView và FlowLayoutPanel
        private System.Windows.Forms.ListView lvMyCourses;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private Guna.UI2.WinForms.Guna2Button btnCreateCourse;
        private Guna.UI2.WinForms.Guna2Button btnEditCourse;
        private Guna.UI2.WinForms.Guna2Button btnDeleteCourse;

        // Khai báo ColumnHeader cho ListView
        private System.Windows.Forms.ColumnHeader colCourseID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStudentCount;
        private System.Windows.Forms.ColumnHeader colStatus;

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            lblWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelTop = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelMainContent = new Guna.UI2.WinForms.Guna2Panel();
            lvMyCourses = new ListView();
            colCourseID = new ColumnHeader();
            colName = new ColumnHeader();
            colStudentCount = new ColumnHeader();
            colStatus = new ColumnHeader();
            flpActions = new FlowLayoutPanel();
            btnCreateCourse = new Guna.UI2.WinForms.Guna2Button();
            btnEditCourse = new Guna.UI2.WinForms.Guna2Button();
            btnDeleteCourse = new Guna.UI2.WinForms.Guna2Button();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.DodgerBlue;
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.CustomizableEdges = customizableEdges3;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.ForeColor = Color.Cyan;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelLeft.ShadowDecoration.Depth = 15;
            panelLeft.ShadowDecoration.Enabled = true;
            panelLeft.Size = new Size(240, 691);
            panelLeft.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BorderRadius = 15;
            btnLogout.CustomizableEdges = customizableEdges1;
            btnLogout.FillColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(20, 620);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogout.Size = new Size(200, 50);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click_1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = false;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(236, 240, 241);
            lblWelcome.Location = new Point(20, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(217, 111);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Chào mừng,\n[Giảng viên]";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.CustomizableEdges = customizableEdges5;
            panelTop.Dock = DockStyle.Top;
            panelTop.ForeColor = SystemColors.ActiveCaptionText;
            panelTop.Location = new Point(240, 0);
            panelTop.Name = "panelTop";
            panelTop.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelTop.Size = new Size(742, 70);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(254, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Lớp học";
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.White;
            panelMainContent.Controls.Add(lvMyCourses);
            panelMainContent.Controls.Add(flpActions);
            panelMainContent.CustomizableEdges = customizableEdges13;
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(240, 70);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(15);
            panelMainContent.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelMainContent.Size = new Size(742, 621);
            panelMainContent.TabIndex = 2;
            // 
            // lvMyCourses
            // 
            lvMyCourses.Columns.AddRange(new ColumnHeader[] { colCourseID, colName, colStudentCount, colStatus });
            lvMyCourses.Dock = DockStyle.Fill;
            lvMyCourses.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvMyCourses.FullRowSelect = true;
            lvMyCourses.Location = new Point(15, 77);
            lvMyCourses.Name = "lvMyCourses";
            lvMyCourses.Size = new Size(712, 529);
            lvMyCourses.TabIndex = 1;
            lvMyCourses.UseCompatibleStateImageBehavior = false;
            lvMyCourses.View = View.Details;
            lvMyCourses.SelectedIndexChanged += lvMyCourses_SelectedIndexChanged;
            lvMyCourses.DoubleClick += lvMyCourses_DoubleClick_1;
            // 
            // colCourseID
            // 
            colCourseID.Text = "Mã Lớp";
            colCourseID.Width = 100;
            // 
            // colName
            // 
            colName.Text = "Tên Môn học";
            colName.Width = 300;
            // 
            // colStudentCount
            // 
            colStudentCount.Text = "Số Sinh viên";
            colStudentCount.Width = 120;
            // 
            // colStatus
            // 
            colStatus.Text = "Trạng thái";
            colStatus.Width = 150;
            // 
            // flpActions
            // 
            flpActions.Controls.Add(btnCreateCourse);
            flpActions.Controls.Add(btnEditCourse);
            flpActions.Controls.Add(btnDeleteCourse);
            flpActions.Dock = DockStyle.Top;
            flpActions.Location = new Point(15, 15);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(712, 62);
            flpActions.TabIndex = 0;
            // 
            // btnCreateCourse
            // 
            btnCreateCourse.BorderRadius = 10;
            btnCreateCourse.CustomizableEdges = customizableEdges7;
            btnCreateCourse.FillColor = Color.FromArgb(46, 204, 113);
            btnCreateCourse.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateCourse.ForeColor = Color.White;
            btnCreateCourse.Location = new Point(3, 3);
            btnCreateCourse.Name = "btnCreateCourse";
            btnCreateCourse.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCreateCourse.Size = new Size(150, 50);
            btnCreateCourse.TabIndex = 0;
            btnCreateCourse.Text = "➕ Tạo Lớp Mới";
            btnCreateCourse.Click += btnCreateCourse_Click_1;
            // 
            // btnEditCourse
            // 
            btnEditCourse.BorderRadius = 10;
            btnEditCourse.CustomizableEdges = customizableEdges9;
            btnEditCourse.FillColor = Color.FromArgb(241, 196, 15);
            btnEditCourse.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditCourse.ForeColor = Color.FromArgb(44, 62, 80);
            btnEditCourse.Location = new Point(159, 3);
            btnEditCourse.Name = "btnEditCourse";
            btnEditCourse.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnEditCourse.Size = new Size(150, 50);
            btnEditCourse.TabIndex = 1;
            btnEditCourse.Text = "✏️ Sửa Lớp";
            btnEditCourse.Click += btnEditCourse_Click_1;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.BorderRadius = 10;
            btnDeleteCourse.CustomizableEdges = customizableEdges11;
            btnDeleteCourse.FillColor = Color.FromArgb(231, 76, 60);
            btnDeleteCourse.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteCourse.ForeColor = Color.White;
            btnDeleteCourse.Location = new Point(315, 3);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDeleteCourse.Size = new Size(150, 50);
            btnDeleteCourse.TabIndex = 2;
            btnDeleteCourse.Text = "🗑️ Xóa Lớp";
            btnDeleteCourse.Click += btnDeleteCourse_Click_1;
            // 
            // MainForm_GiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 691);
            Controls.Add(panelMainContent);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 738);
            Name = "MainForm_GiangVien";
            Text = "Trang chủ Giảng viên";
            Load += MainForm_GiangVien_Load;
            panelLeft.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMainContent.ResumeLayout(false);
            flpActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
    #endregion
}