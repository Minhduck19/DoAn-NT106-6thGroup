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

        // Giữ lại ListView và DataGridView (chỉ đổi style)
        private ListView lvJoinedCourses;

        private System.Windows.Forms.ContextMenuStrip cmsUserOptions;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLeft = new Guna2Panel();
            btnLogout = new Guna2Button();
            lblWelcome = new Guna2HtmlLabel();
            panelTop = new Guna2Panel();
            guna2Button1 = new Guna2Button();
            lblTitle = new Guna2HtmlLabel();
            panelMainContent = new Guna2Panel();
            grpJoinedCourses = new Guna2GroupBox();
            lvJoinedCourses = new ListView();
            cmsUserOptions = new ContextMenuStrip(components);
            profileToolStripMenuItem = new ToolStripMenuItem();
            scheduleToolStripMenuItem = new ToolStripMenuItem();
            gradesToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            đăngKýMônHọcToolStripMenuItem = new ToolStripMenuItem();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelMainContent.SuspendLayout();
            grpJoinedCourses.SuspendLayout();
            cmsUserOptions.SuspendLayout();
            SuspendLayout();
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
            panelLeft.Size = new Size(410, 781);
            panelLeft.TabIndex = 2;
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
            btnLogout.Location = new Point(83, 683);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogout.Size = new Size(200, 45);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = false;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Cursor = Cursors.Hand;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(236, 240, 241);
            lblWelcome.Location = new Point(20, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(371, 100);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Chào, [User]";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(guna2Button1);
            panelTop.Controls.Add(lblTitle);
            panelTop.CustomizableEdges = customizableEdges7;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(410, 0);
            panelTop.Name = "panelTop";
            panelTop.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelTop.Size = new Size(1364, 79);
            panelTop.TabIndex = 1;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Bottom;
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.FillColor = Color.DeepSkyBlue;
            guna2Button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(1152, 18);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(200, 45);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Chat";
            guna2Button1.Click += guna2Button1_Click;
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
            panelMainContent.Controls.Add(grpJoinedCourses);
            panelMainContent.CustomizableEdges = customizableEdges11;
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(410, 79);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(15);
            panelMainContent.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelMainContent.Size = new Size(1364, 702);
            panelMainContent.TabIndex = 0;
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
            grpJoinedCourses.Size = new Size(1349, 672);
            grpJoinedCourses.TabIndex = 0;
            grpJoinedCourses.Text = "Các khóa học đã tham gia";
            grpJoinedCourses.Click += grpJoinedCourses_Click_1;
            // 
            // lvJoinedCourses
            // 
            lvJoinedCourses.Anchor = AnchorStyles.None;
            lvJoinedCourses.FullRowSelect = true;
            lvJoinedCourses.GridLines = true;
            lvJoinedCourses.Location = new Point(158, 50);
            lvJoinedCourses.MultiSelect = false;
            lvJoinedCourses.Name = "lvJoinedCourses";
            lvJoinedCourses.Size = new Size(1033, 612);
            lvJoinedCourses.TabIndex = 0;
            lvJoinedCourses.UseCompatibleStateImageBehavior = false;
            lvJoinedCourses.View = View.Details;
            lvJoinedCourses.SelectedIndexChanged += lvJoinedCourses_SelectedIndexChanged;
            lvJoinedCourses.MouseDoubleClick += lvJoinedCourses_ItemActivate;
            // 
            // cmsUserOptions
            // 
            cmsUserOptions.ImageScalingSize = new Size(20, 20);
            cmsUserOptions.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, scheduleToolStripMenuItem, gradesToolStripMenuItem, changePasswordToolStripMenuItem, đăngKýMônHọcToolStripMenuItem });
            cmsUserOptions.Name = "cmsUserOptions";
            cmsUserOptions.Size = new Size(195, 124);
            cmsUserOptions.Opening += cmsUserOptions_Opening_1;
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(194, 24);
            profileToolStripMenuItem.Text = "Hồ sơ";
            profileToolStripMenuItem.Click += profileToolStripMenuItem_Click;
            // 
            // scheduleToolStripMenuItem
            // 
            scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            scheduleToolStripMenuItem.Size = new Size(194, 24);
            scheduleToolStripMenuItem.Text = "Lịch học";
            scheduleToolStripMenuItem.Click += scheduleToolStripMenuItem_Click_1;
            // 
            // gradesToolStripMenuItem
            // 
            gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            gradesToolStripMenuItem.Size = new Size(194, 24);
            gradesToolStripMenuItem.Text = "Điểm";
            gradesToolStripMenuItem.Click += gradesToolStripMenuItem_Click_1;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(194, 24);
            changePasswordToolStripMenuItem.Text = "Đổi mật khẩu";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // đăngKýMônHọcToolStripMenuItem
            // 
            đăngKýMônHọcToolStripMenuItem.Name = "đăngKýMônHọcToolStripMenuItem";
            đăngKýMônHọcToolStripMenuItem.Size = new Size(194, 24);
            đăngKýMônHọcToolStripMenuItem.Text = "Đăng ký môn học";
            đăngKýMônHọcToolStripMenuItem.Click += đăngKýMônHọcToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1774, 781);
            Controls.Add(panelMainContent);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Name = "MainForm";
            Text = "Trang chủ";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            panelLeft.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMainContent.ResumeLayout(false);
            grpJoinedCourses.ResumeLayout(false);
            cmsUserOptions.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private ToolStripMenuItem đăngKýMônHọcToolStripMenuItem;
        private Guna2Button guna2Button1;
    }
}