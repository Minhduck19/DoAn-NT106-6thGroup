using Guna.UI2.WinForms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace APP_DOAN
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo lại controls theo Guna UI
        private Guna2Panel panelLeft;
        private Guna2Panel panelTop;
        private Guna2Panel panelMainContent;
        private Guna2HtmlLabel lblWelcome;
        private Guna2Button btnLogout;
        private Guna2HtmlLabel lblTitle;

        private Guna2GroupBox grpJoinedCourses;
        private Guna2GroupBox grpAvailableCourses;

        private ListView lvJoinedCourses;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLeft = new Guna2Panel();
            btnLogout = new Guna2Button();
            lblWelcome = new Guna2HtmlLabel();
            panelTop = new Guna2Panel();
            lblTitle = new Guna2HtmlLabel();
            panelMainContent = new Guna2Panel();
            grpAvailableCourses = new Guna2GroupBox();
            dgvAvailableCourses = new Guna2DataGridView();
            colCourseId = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colInstructor = new DataGridViewTextBoxColumn();
            colJoin = new DataGridViewButtonColumn();
            grpJoinedCourses = new Guna2GroupBox();
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
            SuspendLayout();

            // 
            // cmsUserOptions
            // 
            this.cmsUserOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUserOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.messagesToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.gradesToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.cmsUserOptions.Name = "cmsUserOptions";
            this.cmsUserOptions.Size = new System.Drawing.Size(168, 124);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "Hồ sơ";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.profileToolStripMenuItem.Text = "Hồ sơ";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click_1);
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Name = "Tin nhắn";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.messagesToolStripMenuItem.Text = "Tin nhắn";
            this.messagesToolStripMenuItem.Click += new System.EventHandler(this.messagesToolStripMenuItem_Click_1);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Name = "Lịch học";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.scheduleToolStripMenuItem.Text = "Lịch học";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click_1);
            // 
            // gradesToolStripMenuItem
            // 
            this.gradesToolStripMenuItem.Name = "Kết quả học tập";
            this.gradesToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.gradesToolStripMenuItem.Text = "Điểm";
            this.gradesToolStripMenuItem.Click += new System.EventHandler(this.gradesToolStripMenuItem_Click_1);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "Đổi mật khẩu";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.changePasswordToolStripMenuItem.Text = "Đổi mật khẩu";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);

            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(52, 152, 219);
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.CustomizableEdges = customizableEdges3;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelLeft.ShadowDecoration.Depth = 10;
            panelLeft.ShadowDecoration.Enabled = true;
            panelLeft.Size = new Size(240, 747);
            panelLeft.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BorderRadius = 15;
            btnLogout.CustomizableEdges = customizableEdges1;
            btnLogout.FillColor = Color.FromArgb(255, 255, 255);
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(20, 680);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogout.Size = new Size(200, 45);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Cursor = Cursors.Hand;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(236, 240, 241);
            lblWelcome.Location = new Point(20, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(133, 33);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Chào, [User]";
            lblWelcome.Click += lblWelcome_Click_1;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.CustomizableEdges = customizableEdges5;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(240, 0);
            panelTop.Name = "panelTop";
            panelTop.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelTop.Size = new Size(1187, 70);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(293, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dashboard | Lớp học";
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(236, 240, 241);
            panelMainContent.Controls.Add(grpAvailableCourses);
            panelMainContent.Controls.Add(grpJoinedCourses);
            panelMainContent.CustomizableEdges = customizableEdges11;
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(240, 70);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(15);
            panelMainContent.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelMainContent.Size = new Size(1187, 677);
            panelMainContent.TabIndex = 0;
            // 
            // grpAvailableCourses
            // 
            grpAvailableCourses.BackColor = Color.Transparent;
            grpAvailableCourses.BorderRadius = 15;
            grpAvailableCourses.Controls.Add(dgvAvailableCourses);
            grpAvailableCourses.CustomBorderColor = Color.FromArgb(46, 204, 113);
            grpAvailableCourses.CustomizableEdges = customizableEdges7;
            grpAvailableCourses.Dock = DockStyle.Fill;
            grpAvailableCourses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpAvailableCourses.ForeColor = Color.FromArgb(52, 73, 94);
            grpAvailableCourses.Location = new Point(615, 15);
            grpAvailableCourses.Name = "grpAvailableCourses";
            grpAvailableCourses.Padding = new Padding(10);
            grpAvailableCourses.ShadowDecoration.CustomizableEdges = customizableEdges8;
            grpAvailableCourses.ShadowDecoration.Enabled = true;
            grpAvailableCourses.Size = new Size(557, 647);
            grpAvailableCourses.TabIndex = 1;
            grpAvailableCourses.Text = "Lớp học khả dụng";
            // 
            // dgvAvailableCourses
            // 
            dgvAvailableCourses.AllowUserToAddRows = false;
            dgvAvailableCourses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvAvailableCourses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAvailableCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAvailableCourses.ColumnHeadersHeight = 40;
            dgvAvailableCourses.Columns.AddRange(new DataGridViewColumn[] { colCourseId, colCourseName, colInstructor, colJoin });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAvailableCourses.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAvailableCourses.Dock = DockStyle.Fill;
            dgvAvailableCourses.GridColor = Color.FromArgb(236, 240, 241);
            dgvAvailableCourses.Location = new Point(10, 50);
            dgvAvailableCourses.MultiSelect = false;
            dgvAvailableCourses.Name = "dgvAvailableCourses";
            dgvAvailableCourses.RowHeadersVisible = false;
            dgvAvailableCourses.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dgvAvailableCourses.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAvailableCourses.RowTemplate.Height = 35;
            dgvAvailableCourses.Size = new Size(537, 587);
            dgvAvailableCourses.TabIndex = 0;
            dgvAvailableCourses.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvAvailableCourses.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvAvailableCourses.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvAvailableCourses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvAvailableCourses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvAvailableCourses.ThemeStyle.BackColor = Color.White;
            dgvAvailableCourses.ThemeStyle.GridColor = Color.FromArgb(236, 240, 241);
            dgvAvailableCourses.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvAvailableCourses.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAvailableCourses.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvAvailableCourses.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvAvailableCourses.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAvailableCourses.ThemeStyle.HeaderStyle.Height = 40;
            dgvAvailableCourses.ThemeStyle.ReadOnly = false;
            dgvAvailableCourses.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvAvailableCourses.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAvailableCourses.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvAvailableCourses.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvAvailableCourses.ThemeStyle.RowsStyle.Height = 35;
            dgvAvailableCourses.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvAvailableCourses.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvAvailableCourses.CellContentClick += dgvAvailableCourses_CellContentClick;
            // 
            // colCourseId
            // 
            colCourseId.HeaderText = "Mã Khóa học";
            colCourseId.MinimumWidth = 6;
            colCourseId.Name = "colCourseId";
            colCourseId.Visible = false;
            // 
            // colCourseName
            // 
            colCourseName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCourseName.HeaderText = "Tên Môn học";
            colCourseName.MinimumWidth = 6;
            colCourseName.Name = "colCourseName";
            // 
            // colInstructor
            // 
            colInstructor.HeaderText = "Giảng viên";
            colInstructor.MinimumWidth = 6;
            colInstructor.Name = "colInstructor";
            // 
            // colJoin
            // 
            colJoin.HeaderText = "Thao tác";
            colJoin.MinimumWidth = 6;
            colJoin.Name = "colJoin";
            colJoin.Text = "Tham gia";
            colJoin.UseColumnTextForButtonValue = true;
            // 
            // grpJoinedCourses
            // 
            grpJoinedCourses.BackColor = Color.Transparent;
            grpJoinedCourses.BorderRadius = 15;
            grpJoinedCourses.Controls.Add(lvJoinedCourses);
            grpJoinedCourses.CustomBorderColor = Color.FromArgb(52, 152, 219);
            grpJoinedCourses.CustomizableEdges = customizableEdges9;
            grpJoinedCourses.Dock = DockStyle.Left;
            grpJoinedCourses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpJoinedCourses.ForeColor = Color.FromArgb(52, 73, 94);
            grpJoinedCourses.Location = new Point(15, 15);
            grpJoinedCourses.Name = "grpJoinedCourses";
            grpJoinedCourses.Padding = new Padding(10);
            grpJoinedCourses.ShadowDecoration.CustomizableEdges = customizableEdges10;
            grpJoinedCourses.ShadowDecoration.Enabled = true;
            grpJoinedCourses.Size = new Size(600, 647);
            grpJoinedCourses.TabIndex = 0;
            grpJoinedCourses.Text = "Các khóa học đã tham gia";
            // 
            // lvJoinedCourses
            // 
            lvJoinedCourses.Dock = DockStyle.Fill;
            lvJoinedCourses.FullRowSelect = true;
            lvJoinedCourses.GridLines = true;
            lvJoinedCourses.Location = new Point(10, 50);
            lvJoinedCourses.MultiSelect = false;
            lvJoinedCourses.Name = "lvJoinedCourses";
            lvJoinedCourses.Size = new Size(580, 587);
            lvJoinedCourses.TabIndex = 0;
            lvJoinedCourses.UseCompatibleStateImageBehavior = false;
            lvJoinedCourses.View = View.Details;
            lvJoinedCourses.SelectedIndexChanged += lvJoinedCourses_SelectedIndexChanged;
            // 
            // cmsUserOptions
            // 
            cmsUserOptions.ImageScalingSize = new Size(20, 20);
            cmsUserOptions.Name = "cmsUserOptions";
            cmsUserOptions.Size = new Size(211, 32);
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(32, 19);
            // 
            // messagesToolStripMenuItem
            // 
            messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            messagesToolStripMenuItem.Size = new Size(32, 19);
            // 
            // scheduleToolStripMenuItem
            // 
            scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            scheduleToolStripMenuItem.Size = new Size(32, 19);
            // 
            // gradesToolStripMenuItem
            // 
            gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            gradesToolStripMenuItem.Size = new Size(32, 19);
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(32, 19);
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
            panelLeft.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMainContent.ResumeLayout(false);
            grpAvailableCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).EndInit();
            grpJoinedCourses.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private Guna2DataGridView dgvAvailableCourses;
    }
}