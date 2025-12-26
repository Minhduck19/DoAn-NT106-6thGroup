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

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLeft = new Panel();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            lblWelcome = new Label();
            panelTop = new Panel();
            lblTitle = new Label();
            panelMainContent = new Panel();
            lvMyCourses = new ListView();
            colCourseID = new ColumnHeader();
            colName = new ColumnHeader();
            colStudentCount = new ColumnHeader();
            colStatus = new ColumnHeader();
            flpActions = new FlowLayoutPanel();
            btnCreateCourse = new Button();
            btnEditCourse = new Button();
            btnDeleteCourse = new Button();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(52, 152, 219);
            panelLeft.BackgroundImageLayout = ImageLayout.Stretch;
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 691);
            panelLeft.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BorderRadius = 15;
            btnLogout.CustomizableEdges = customizableEdges1;
            btnLogout.FillColor = Color.FromArgb(255, 255, 255);
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(0, 631);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogout.Size = new Size(200, 45);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(12, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(176, 111);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Chào mừng,\n[Giảng viên]";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(200, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(782, 75);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(45, 45, 48);
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản Lý Lớp Học";
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = SystemColors.Control;
            panelMainContent.Controls.Add(lvMyCourses);
            panelMainContent.Controls.Add(flpActions);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(200, 75);
            panelMainContent.Margin = new Padding(3, 4, 3, 4);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(10, 12, 10, 12);
            panelMainContent.Size = new Size(782, 616);
            panelMainContent.TabIndex = 2;
            // 
            // lvMyCourses
            // 
            lvMyCourses.Columns.AddRange(new ColumnHeader[] { colCourseID, colName, colStudentCount, colStatus });
            lvMyCourses.Dock = DockStyle.Fill;
            lvMyCourses.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvMyCourses.FullRowSelect = true;
            lvMyCourses.GridLines = true;
            lvMyCourses.Location = new Point(10, 74);
            lvMyCourses.Margin = new Padding(3, 4, 3, 4);
            lvMyCourses.Name = "lvMyCourses";
            lvMyCourses.Size = new Size(762, 530);
            lvMyCourses.TabIndex = 1;
            lvMyCourses.UseCompatibleStateImageBehavior = false;
            lvMyCourses.View = View.Details;
            lvMyCourses.DoubleClick += lvMyCourses_DoubleClick_1;
            // 
            // colCourseID
            // 
            colCourseID.Text = "Mã Lớp";
            colCourseID.Width = 100;
            // 
            // colName
            // 
            colName.Text = "Tên Lớp";
            colName.Width = 200;
            // 
            // colStudentCount
            // 
            colStudentCount.Text = "Số Sinh Viên";
            colStudentCount.Width = 120;
            // 
            // colStatus
            // 
            colStatus.Text = "Trạng Thái";
            colStatus.Width = 120;
            // 
            // flpActions
            // 
            flpActions.Controls.Add(btnCreateCourse);
            flpActions.Controls.Add(btnEditCourse);
            flpActions.Controls.Add(btnDeleteCourse);
            flpActions.Dock = DockStyle.Top;
            flpActions.Location = new Point(10, 12);
            flpActions.Margin = new Padding(3, 4, 3, 4);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(762, 62);
            flpActions.TabIndex = 0;
            // 
            // btnCreateCourse
            // 
            btnCreateCourse.BackColor = Color.FromArgb(40, 167, 69);
            btnCreateCourse.FlatAppearance.BorderSize = 0;
            btnCreateCourse.FlatStyle = FlatStyle.Flat;
            btnCreateCourse.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateCourse.ForeColor = Color.White;
            btnCreateCourse.Location = new Point(3, 4);
            btnCreateCourse.Margin = new Padding(3, 4, 3, 4);
            btnCreateCourse.Name = "btnCreateCourse";
            btnCreateCourse.Size = new Size(120, 50);
            btnCreateCourse.TabIndex = 0;
            btnCreateCourse.Text = "Tạo Lớp Mới";
            btnCreateCourse.UseVisualStyleBackColor = false;
            btnCreateCourse.Click += btnCreateCourse_Click_1;
            // 
            // btnEditCourse
            // 
            btnEditCourse.BackColor = Color.FromArgb(255, 193, 7);
            btnEditCourse.FlatAppearance.BorderSize = 0;
            btnEditCourse.FlatStyle = FlatStyle.Flat;
            btnEditCourse.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditCourse.ForeColor = Color.Black;
            btnEditCourse.Location = new Point(129, 4);
            btnEditCourse.Margin = new Padding(3, 4, 3, 4);
            btnEditCourse.Name = "btnEditCourse";
            btnEditCourse.Size = new Size(120, 50);
            btnEditCourse.TabIndex = 1;
            btnEditCourse.Text = "Sửa Lớp";
            btnEditCourse.UseVisualStyleBackColor = false;
            btnEditCourse.Click += btnEditCourse_Click;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteCourse.FlatAppearance.BorderSize = 0;
            btnDeleteCourse.FlatStyle = FlatStyle.Flat;
            btnDeleteCourse.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteCourse.ForeColor = Color.White;
            btnDeleteCourse.Location = new Point(255, 4);
            btnDeleteCourse.Margin = new Padding(3, 4, 3, 4);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.Size = new Size(120, 50);
            btnDeleteCourse.TabIndex = 2;
            btnDeleteCourse.Text = "Xóa Lớp";
            btnDeleteCourse.UseVisualStyleBackColor = false;
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
            MinimumSize = new Size(800, 738);
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

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvMyCourses;
        private System.Windows.Forms.ColumnHeader colCourseID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStudentCount;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnCreateCourse;
        private System.Windows.Forms.Button btnEditCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
    }
}