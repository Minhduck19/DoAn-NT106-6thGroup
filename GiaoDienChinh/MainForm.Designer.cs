namespace APP_DOAN
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Các Control cơ bản
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel panelMainContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2GroupBox grpJoinedCourses;

        // --- THAY ĐỔI QUAN TRỌNG: Dùng FlowLayoutPanel thay cho ListView ---
        private System.Windows.Forms.FlowLayoutPanel flpCourses;

        // Các menu, button tìm kiếm giữ nguyên
        private System.Windows.Forms.ContextMenuStrip cmsUserOptions;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýMônHọcToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button guna2Button1; // Nút Chat
        private Guna.UI2.WinForms.Guna2Button Find;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtNameClass;

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
            this.components = new System.ComponentModel.Container();
            // Khai báo các biến giao diện GunaUI (giữ nguyên style của bạn)
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesPanelLeft = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesPanelLeftShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesBtnLogout = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesBtnLogoutShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesPanelTop = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesPanelTopShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesBtnChat = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesBtnChatShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesMainContent = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesMainContentShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesGrpBox = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesGrpBoxShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesBtnFind = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesBtnFindShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesTxtSearch = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges edgesTxtSearchShadow = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.lblWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelMainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.grpJoinedCourses = new Guna.UI2.WinForms.Guna2GroupBox();
            this.Find = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameClass = new Guna.UI2.WinForms.Guna2TextBox();

            // Khởi tạo FlowLayoutPanel
            this.flpCourses = new System.Windows.Forms.FlowLayoutPanel();

            this.cmsUserOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            this.grpJoinedCourses.SuspendLayout();
            this.cmsUserOptions.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Controls.Add(this.lblWelcome);
            this.panelLeft.CustomizableEdges = edgesPanelLeft;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.ShadowDecoration.CustomizableEdges = edgesPanelLeftShadow;
            this.panelLeft.Size = new System.Drawing.Size(250, 781);
            this.panelLeft.TabIndex = 2;

            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BorderRadius = 15;
            this.btnLogout.CustomizableEdges = edgesBtnLogout;
            this.btnLogout.FillColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(25, 720);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ShadowDecoration.CustomizableEdges = edgesBtnLogoutShadow;
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblWelcome.Location = new System.Drawing.Point(15, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(220, 80);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Chào, [User]";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.guna2Button1);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.CustomizableEdges = edgesPanelTop;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(250, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.ShadowDecoration.CustomizableEdges = edgesPanelTopShadow;
            this.panelTop.Size = new System.Drawing.Size(1524, 79);
            this.panelTop.TabIndex = 1;

            // 
            // guna2Button1 (Chat)
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.CustomizableEdges = edgesBtnChat;
            this.guna2Button1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(1310, 18);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.CustomizableEdges = edgesBtnChatShadow;
            this.guna2Button1.Size = new System.Drawing.Size(200, 45);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Chat";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);

            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard | Lớp học";

            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMainContent.Controls.Add(this.grpJoinedCourses);
            this.panelMainContent.CustomizableEdges = edgesMainContent;
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(250, 79);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelMainContent.ShadowDecoration.CustomizableEdges = edgesMainContentShadow;
            this.panelMainContent.Size = new System.Drawing.Size(1524, 702);
            this.panelMainContent.TabIndex = 0;

            // 
            // grpJoinedCourses
            // 
            this.grpJoinedCourses.BackColor = System.Drawing.Color.Transparent;
            this.grpJoinedCourses.BorderRadius = 15;
            this.grpJoinedCourses.Controls.Add(this.flpCourses); // Add FlowLayout vào đây
            this.grpJoinedCourses.Controls.Add(this.Find);
            this.grpJoinedCourses.Controls.Add(this.label1);
            this.grpJoinedCourses.Controls.Add(this.txtNameClass);
            this.grpJoinedCourses.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.grpJoinedCourses.CustomizableEdges = edgesGrpBox;
            this.grpJoinedCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpJoinedCourses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpJoinedCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpJoinedCourses.Location = new System.Drawing.Point(15, 15);
            this.grpJoinedCourses.Name = "grpJoinedCourses";
            this.grpJoinedCourses.Padding = new System.Windows.Forms.Padding(10);
            this.grpJoinedCourses.ShadowDecoration.CustomizableEdges = edgesGrpBoxShadow;
            this.grpJoinedCourses.Size = new System.Drawing.Size(1494, 672);
            this.grpJoinedCourses.TabIndex = 0;
            this.grpJoinedCourses.Text = "Tất cả khóa học";

            // 
            // flpCourses (THAY THẾ LISTVIEW)
            // 
            this.flpCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCourses.AutoScroll = true;
            this.flpCourses.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpCourses.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCourses.Location = new System.Drawing.Point(17, 94);
            this.flpCourses.Name = "flpCourses";
            this.flpCourses.Size = new System.Drawing.Size(1464, 557);
            this.flpCourses.TabIndex = 13;
            this.flpCourses.WrapContents = false;

            // 
            // Find
            // 
            this.Find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Find.BackColor = System.Drawing.Color.Transparent;
            this.Find.BorderRadius = 15;
            this.Find.CustomizableEdges = edgesBtnFind;
            this.Find.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.Find.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Find.ForeColor = System.Drawing.Color.Black;
            this.Find.Location = new System.Drawing.Point(1340, 53);
            this.Find.Name = "Find";
            this.Find.ShadowDecoration.CustomizableEdges = edgesBtnFindShadow;
            this.Find.Size = new System.Drawing.Size(140, 34);
            this.Find.TabIndex = 12;
            this.Find.Text = "Find";
            this.Find.Click += new System.EventHandler(this.Find_Click);

            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nhập tên lớp học:";

            // 
            // txtNameClass
            // 
            this.txtNameClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameClass.CustomizableEdges = edgesTxtSearch;
            this.txtNameClass.DefaultText = "";
            this.txtNameClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameClass.Location = new System.Drawing.Point(180, 54);
            this.txtNameClass.Name = "txtNameClass";
            this.txtNameClass.ShadowDecoration.CustomizableEdges = edgesTxtSearchShadow;
            this.txtNameClass.Size = new System.Drawing.Size(1140, 33);
            this.txtNameClass.TabIndex = 10;
            this.txtNameClass.TextChanged += new System.EventHandler(this.txtNameClass_TextChanged);

            // 
            // cmsUserOptions (Menu chuột phải)
            // 
            this.cmsUserOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.gradesToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.đăngKýMônHọcToolStripMenuItem});
            this.cmsUserOptions.Name = "cmsUserOptions";
            this.cmsUserOptions.Size = new System.Drawing.Size(203, 124);

            this.profileToolStripMenuItem.Text = "Hồ sơ";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);

            this.scheduleToolStripMenuItem.Text = "Lịch học";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click_1);

            this.gradesToolStripMenuItem.Text = "Điểm";
            this.gradesToolStripMenuItem.Click += new System.EventHandler(this.gradesToolStripMenuItem_Click_1);

            this.changePasswordToolStripMenuItem.Text = "Đổi mật khẩu";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);

            this.đăngKýMônHọcToolStripMenuItem.Text = "Tất cả các lớp học";
            this.đăngKýMônHọcToolStripMenuItem.Click += new System.EventHandler(this.đăngKýMônHọcToolStripMenuItem_Click);

            // 
            // MainForm Config
            // 
            this.ClientSize = new System.Drawing.Size(1774, 781);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Name = "MainForm";
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMainContent.ResumeLayout(false);
            this.grpJoinedCourses.ResumeLayout(false);
            this.cmsUserOptions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}