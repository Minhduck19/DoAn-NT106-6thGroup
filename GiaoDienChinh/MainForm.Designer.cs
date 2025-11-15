namespace APP_DOAN
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpJoinedCourses;
        private System.Windows.Forms.ListView lvJoinedCourses;

        private System.Windows.Forms.GroupBox grpAvailableCourses;
        private System.Windows.Forms.DataGridView dgvAvailableCourses;

        private System.Windows.Forms.ContextMenuStrip cmsUserOptions;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;

        private System.Windows.Forms.DataGridViewTextBoxColumn colCourseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstructor;
        private System.Windows.Forms.DataGridViewButtonColumn colJoin;

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelLeft = new Panel();
            btnLogout = new Button();
            lblWelcome = new Label();
            panelTop = new Panel();
            lblTitle = new Label();
            panelMainContent = new Panel();
            grpAvailableCourses = new GroupBox();
            dgvAvailableCourses = new DataGridView();
            colCourseId = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colInstructor = new DataGridViewTextBoxColumn();
            colJoin = new DataGridViewButtonColumn();
            grpJoinedCourses = new GroupBox();
            lvJoinedCourses = new ListView();
            cmsUserOptions = new ContextMenuStrip(components);
            profileToolStripMenuItem = new ToolStripMenuItem();
            messagesToolStripMenuItem = new ToolStripMenuItem();
            scheduleToolStripMenuItem = new ToolStripMenuItem();
            gradesToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            grpAvailableCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).BeginInit();
            grpJoinedCourses.SuspendLayout();
            cmsUserOptions.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = SystemColors.ControlDark;
            panelLeft.BackgroundImage = (Image)resources.GetObject("panelLeft.BackgroundImage");
            panelLeft.BackgroundImageLayout = ImageLayout.Stretch;
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 747);
            panelLeft.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackgroundImage = (Image)resources.GetObject("btnLogout.BackgroundImage");
            btnLogout.BackgroundImageLayout = ImageLayout.Center;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(0, 707);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 40);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Cursor = Cursors.Hand;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(12, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(176, 26);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Chào, [User]";
            lblWelcome.Click += lblWelcome_Click_1;
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.ControlLightLight;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(200, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1227, 60);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(150, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(264, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh sách Lớp học";
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(grpAvailableCourses);
            panelMainContent.Controls.Add(grpJoinedCourses);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(200, 60);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(10);
            panelMainContent.Size = new Size(1227, 687);
            panelMainContent.TabIndex = 0;
            // 
            // grpAvailableCourses
            // 
            grpAvailableCourses.Controls.Add(dgvAvailableCourses);
            grpAvailableCourses.Dock = DockStyle.Fill;
            grpAvailableCourses.Location = new Point(610, 10);
            grpAvailableCourses.Name = "grpAvailableCourses";
            grpAvailableCourses.Padding = new Padding(10);
            grpAvailableCourses.Size = new Size(607, 667);
            grpAvailableCourses.TabIndex = 1;
            grpAvailableCourses.TabStop = false;
            grpAvailableCourses.Text = "Khóa học khả dụng (chưa tham gia)";
            // 
            // dgvAvailableCourses
            // 
            dgvAvailableCourses.AllowUserToAddRows = false;
            dgvAvailableCourses.AllowUserToDeleteRows = false;
            dgvAvailableCourses.AllowUserToResizeRows = false;
            dgvAvailableCourses.BackgroundColor = SystemColors.Window;
            dgvAvailableCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailableCourses.Columns.AddRange(new DataGridViewColumn[] { colCourseId, colCourseName, colInstructor, colJoin });
            dgvAvailableCourses.Dock = DockStyle.Fill;
            dgvAvailableCourses.Location = new Point(10, 30);
            dgvAvailableCourses.MultiSelect = false;
            dgvAvailableCourses.Name = "dgvAvailableCourses";
            dgvAvailableCourses.RowHeadersVisible = false;
            dgvAvailableCourses.RowHeadersWidth = 51;
            dgvAvailableCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableCourses.Size = new Size(587, 627);
            dgvAvailableCourses.TabIndex = 0;
            dgvAvailableCourses.CellContentClick += dgvAvailableCourses_CellContentClick;
            // 
            // colCourseId
            // 
            colCourseId.HeaderText = "Id";
            colCourseId.MinimumWidth = 6;
            colCourseId.Name = "colCourseId";
            colCourseId.Visible = false;
            colCourseId.Width = 50;
            // 
            // colCourseName
            // 
            colCourseName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCourseName.HeaderText = "Tên môn";
            colCourseName.MinimumWidth = 6;
            colCourseName.Name = "colCourseName";
            // 
            // colInstructor
            // 
            colInstructor.HeaderText = "Giảng viên";
            colInstructor.MinimumWidth = 6;
            colInstructor.Name = "colInstructor";
            colInstructor.Width = 200;
            // 
            // colJoin
            // 
            colJoin.HeaderText = "";
            colJoin.MinimumWidth = 6;
            colJoin.Name = "colJoin";
            colJoin.Text = "Tham gia";
            colJoin.UseColumnTextForButtonValue = true;
            colJoin.Width = 90;
            // 
            // grpJoinedCourses
            // 
            grpJoinedCourses.Controls.Add(lvJoinedCourses);
            grpJoinedCourses.Dock = DockStyle.Left;
            grpJoinedCourses.Location = new Point(10, 10);
            grpJoinedCourses.Name = "grpJoinedCourses";
            grpJoinedCourses.Padding = new Padding(10);
            grpJoinedCourses.Size = new Size(600, 667);
            grpJoinedCourses.TabIndex = 0;
            grpJoinedCourses.TabStop = false;
            grpJoinedCourses.Text = "Các khóa học đã tham gia";
            // 
            // lvJoinedCourses
            // 
            lvJoinedCourses.Dock = DockStyle.Fill;
            lvJoinedCourses.FullRowSelect = true;
            lvJoinedCourses.GridLines = true;
            lvJoinedCourses.Location = new Point(10, 30);
            lvJoinedCourses.MultiSelect = false;
            lvJoinedCourses.Name = "lvJoinedCourses";
            lvJoinedCourses.Size = new Size(580, 627);
            lvJoinedCourses.TabIndex = 0;
            lvJoinedCourses.UseCompatibleStateImageBehavior = false;
            lvJoinedCourses.View = View.Details;
            lvJoinedCourses.SelectedIndexChanged += lvJoinedCourses_SelectedIndexChanged_2;
            // 
            // cmsUserOptions
            // 
            cmsUserOptions.ImageScalingSize = new Size(20, 20);
            cmsUserOptions.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, messagesToolStripMenuItem, scheduleToolStripMenuItem, gradesToolStripMenuItem, changePasswordToolStripMenuItem });
            cmsUserOptions.Name = "cmsUserOptions";
            cmsUserOptions.Size = new Size(211, 152);
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(210, 24);
            profileToolStripMenuItem.Text = "Hồ sơ";
            profileToolStripMenuItem.Click += profileToolStripMenuItem_Click_1;
            // 
            // messagesToolStripMenuItem
            // 
            messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            messagesToolStripMenuItem.Size = new Size(210, 24);
            messagesToolStripMenuItem.Text = "Tin nhắn";
            messagesToolStripMenuItem.Click += messagesToolStripMenuItem_Click_1;
            // 
            // scheduleToolStripMenuItem
            // 
            scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            scheduleToolStripMenuItem.Size = new Size(210, 24);
            scheduleToolStripMenuItem.Text = "Lịch học";
            scheduleToolStripMenuItem.Click += scheduleToolStripMenuItem_Click_1;
            // 
            // gradesToolStripMenuItem
            // 
            gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            gradesToolStripMenuItem.Size = new Size(210, 24);
            gradesToolStripMenuItem.Text = "Điểm";
            gradesToolStripMenuItem.Click += gradesToolStripMenuItem_Click_1;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(210, 24);
            changePasswordToolStripMenuItem.Text = "Đổi mật khẩu";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1427, 747);
            Controls.Add(panelMainContent);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Name = "MainForm";
            Text = "Trang chủ";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            panelLeft.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMainContent.ResumeLayout(false);
            grpAvailableCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).EndInit();
            grpJoinedCourses.ResumeLayout(false);
            cmsUserOptions.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
    }
}