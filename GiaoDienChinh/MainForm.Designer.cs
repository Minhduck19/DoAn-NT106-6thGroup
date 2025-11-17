using APP_DOAN.GiaoDienChinh;
using Guna.UI2.WinForms;

namespace APP_DOAN
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel panelLeft;
        private Guna2Panel panelTop;
        private Guna2Panel panelMainContent;
        private Guna2HtmlLabel lblWelcome;
        private Guna2Button btnLogout;
        private Guna2HtmlLabel lblTitle;

        private Guna2GroupBox grpJoinedCourses;
        private Guna2GroupBox grpAvailableCourses;

        // Giữ lại ListView và DataGridView (chỉ đổi style)
        private ListView lvJoinedCourses;
        private DataGridView dgvAvailableCourses;

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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvAvailableCourses = new DataGridView();
            colCourseId = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colInstructor = new DataGridViewTextBoxColumn();
            colJoin = new DataGridViewButtonColumn();
            panelLeft = new Guna2Panel();
            btnLogout = new Guna2Button();
            lblWelcome = new Guna2HtmlLabel();
            panelTop = new Guna2Panel();
            lblTitle = new Guna2HtmlLabel();
            panelMainContent = new Guna2Panel();
            grpAvailableCourses = new Guna2GroupBox();
            grpJoinedCourses = new Guna2GroupBox();
            lvJoinedCourses = new ListView();
            cmsUserOptions = new ContextMenuStrip(components);
            profileToolStripMenuItem = new ToolStripMenuItem();
            messagesToolStripMenuItem = new ToolStripMenuItem();
            scheduleToolStripMenuItem = new ToolStripMenuItem();
            gradesToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            DangKiMonHocToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).BeginInit();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            grpAvailableCourses.SuspendLayout();
            grpJoinedCourses.SuspendLayout();
            cmsUserOptions.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAvailableCourses
            // 
            dgvAvailableCourses.AllowUserToAddRows = false;
            dgvAvailableCourses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvAvailableCourses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAvailableCourses.BackgroundColor = Color.White;
            dgvAvailableCourses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAvailableCourses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvAvailableCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvAvailableCourses.ColumnHeadersHeight = 40;
            dgvAvailableCourses.Columns.AddRange(new DataGridViewColumn[] { colCourseId, colCourseName, colInstructor, colJoin });
            dgvAvailableCourses.Dock = DockStyle.Fill;
            dgvAvailableCourses.GridColor = Color.FromArgb(236, 240, 241);
            dgvAvailableCourses.Location = new Point(10, 50);
            dgvAvailableCourses.MultiSelect = false;
            dgvAvailableCourses.Name = "dgvAvailableCourses";
            dgvAvailableCourses.RowHeadersVisible = false;
            dgvAvailableCourses.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dgvAvailableCourses.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvAvailableCourses.RowTemplate.Height = 35;
            dgvAvailableCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableCourses.Size = new Size(537, 587);
            dgvAvailableCourses.TabIndex = 0;
            dgvAvailableCourses.CellContentClick += dgvAvailableCourses_CellContentClick;
            // 
            // colCourseId
            // 
            colCourseId.HeaderText = "Mã Khóa học";
            colCourseId.MinimumWidth = 6;
            colCourseId.Name = "colCourseId";
            colCourseId.Visible = false;
            colCourseId.Width = 50;
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
            colInstructor.HeaderText = "Giảng viên Phụ trách";
            colInstructor.MinimumWidth = 6;
            colInstructor.Name = "colInstructor";
            colInstructor.Width = 200;
            // 
            // colJoin
            // 
            colJoin.HeaderText = "Thao tác";
            colJoin.MinimumWidth = 6;
            colJoin.Name = "colJoin";
            colJoin.Text = "Tham gia";
            colJoin.UseColumnTextForButtonValue = true;
            colJoin.Width = 90;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(52, 152, 219);
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.CustomizableEdges = customizableEdges15;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.ShadowDecoration.CustomizableEdges = customizableEdges16;
            panelLeft.ShadowDecoration.Depth = 10;
            panelLeft.ShadowDecoration.Enabled = true;
            panelLeft.Size = new Size(240, 747);
            panelLeft.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BorderRadius = 15;
            btnLogout.CustomizableEdges = customizableEdges13;
            btnLogout.FillColor = Color.FromArgb(255, 255, 255);
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(20, 680);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges14;
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
            panelTop.CustomizableEdges = customizableEdges17;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(240, 0);
            panelTop.Name = "panelTop";
            panelTop.ShadowDecoration.CustomizableEdges = customizableEdges18;
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
            panelMainContent.CustomizableEdges = customizableEdges23;
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(240, 70);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(15);
            panelMainContent.ShadowDecoration.CustomizableEdges = customizableEdges24;
            panelMainContent.Size = new Size(1187, 677);
            panelMainContent.TabIndex = 0;
            // 
            // grpAvailableCourses
            // 
            grpAvailableCourses.BackColor = Color.Transparent;
            grpAvailableCourses.BorderRadius = 15;
            grpAvailableCourses.Controls.Add(dgvAvailableCourses);
            grpAvailableCourses.CustomBorderColor = Color.FromArgb(46, 204, 113);
            grpAvailableCourses.CustomizableEdges = customizableEdges19;
            grpAvailableCourses.Dock = DockStyle.Fill;
            grpAvailableCourses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpAvailableCourses.ForeColor = Color.FromArgb(52, 73, 94);
            grpAvailableCourses.Location = new Point(615, 15);
            grpAvailableCourses.Name = "grpAvailableCourses";
            grpAvailableCourses.Padding = new Padding(10);
            grpAvailableCourses.ShadowDecoration.CustomizableEdges = customizableEdges20;
            grpAvailableCourses.ShadowDecoration.Enabled = true;
            grpAvailableCourses.Size = new Size(557, 647);
            grpAvailableCourses.TabIndex = 1;
            grpAvailableCourses.Text = "Khóa học khả dụng";
            // 
            // grpJoinedCourses
            // 
            grpJoinedCourses.BackColor = Color.Transparent;
            grpJoinedCourses.BorderRadius = 15;
            grpJoinedCourses.Controls.Add(lvJoinedCourses);
            grpJoinedCourses.CustomBorderColor = Color.FromArgb(52, 152, 219);
            grpJoinedCourses.CustomizableEdges = customizableEdges21;
            grpJoinedCourses.Dock = DockStyle.Left;
            grpJoinedCourses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpJoinedCourses.ForeColor = Color.FromArgb(52, 73, 94);
            grpJoinedCourses.Location = new Point(15, 15);
            grpJoinedCourses.Name = "grpJoinedCourses";
            grpJoinedCourses.Padding = new Padding(10);
            grpJoinedCourses.ShadowDecoration.CustomizableEdges = customizableEdges22;
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
            cmsUserOptions.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, messagesToolStripMenuItem, scheduleToolStripMenuItem, gradesToolStripMenuItem, changePasswordToolStripMenuItem, DangKiMonHocToolStripMenuItem });
            cmsUserOptions.Name = "cmsUserOptions";
            cmsUserOptions.Size = new Size(211, 176);
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
            // DangKiMonHocToolStripMenuItem
            // 
            DangKiMonHocToolStripMenuItem.Name = "DangKiMonHocToolStripMenuItem";
            DangKiMonHocToolStripMenuItem.Size = new Size(210, 24);
            DangKiMonHocToolStripMenuItem.Text = "Đăng kí môn học";
            DangKiMonHocToolStripMenuItem.Click += ddToolStripMenuItem_Click;
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
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).EndInit();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMainContent.ResumeLayout(false);
            grpAvailableCourses.ResumeLayout(false);
            grpJoinedCourses.ResumeLayout(false);
            cmsUserOptions.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void gradesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void profileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Student_Information profileForm = new Student_Information(this.loggedInEmail, this.userRole);
            profileForm.ShowDialog();
            this.Show();
        }

        private void messagesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void scheduleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private ToolStripMenuItem DangKiMonHocToolStripMenuItem;
    }
}