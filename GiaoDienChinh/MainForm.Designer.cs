namespace APP_DOAN
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // --- KHAI BÁO CONTROL ---
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;

        // Sidebar Controls
        private System.Windows.Forms.Label lblBrand;
        private Guna.UI2.WinForms.Guna2Button btnNavHome;
        private Guna.UI2.WinForms.Guna2Button btnNavProfile;
        private Guna.UI2.WinForms.Guna2Button btnNavSchedule;
        private Guna.UI2.WinForms.Guna2Button btnNavGrades;
        private Guna.UI2.WinForms.Guna2Button btnNavRegister;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Separator separatorSidebar;

        // Header Controls
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnChat;
        private System.Windows.Forms.Label lblUserNameHeader;

        // Content Controls
        private Guna.UI2.WinForms.Guna2Panel pnlBanner;
        private System.Windows.Forms.Label lblWelcomeBig;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSectionTitle;
        private System.Windows.Forms.FlowLayoutPanel flpCourses;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnNavHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavRegister = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.separatorSidebar = new Guna.UI2.WinForms.Guna2Separator();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnChat = new Guna.UI2.WinForms.Guna2Button();
            this.lblUserNameHeader = new System.Windows.Forms.Label();
            this.pnlBanner = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcomeBig = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.flpCourses = new System.Windows.Forms.FlowLayoutPanel();

            // --- 1. SIDEBAR CONFIGURATION ---
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(260, 800);
            this.pnlSidebar.FillColor = System.Drawing.Color.White;
            this.pnlSidebar.ShadowDecoration.Depth = 10;
            this.pnlSidebar.ShadowDecoration.Enabled = true;
            this.pnlSidebar.Controls.Clear();

            this.lblBrand.Text = "EDU MANAGER";
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.lblBrand.Location = new System.Drawing.Point(20, 30);
            this.lblBrand.Size = new System.Drawing.Size(220, 40);
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            SetupButton(this.btnNavHome, "Trang chủ", 100);
            SetupButton(this.btnNavRegister, "Đăng ký môn", 160);
            SetupButton(this.btnNavProfile, "Hồ sơ cá nhân", 220);

            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(255, 235, 238);
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.BorderRadius = 10;
            this.btnLogout.Location = new System.Drawing.Point(20, 700);
            this.btnLogout.Size = new System.Drawing.Size(220, 45);
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.separatorSidebar.Location = new System.Drawing.Point(30, 80);
            this.separatorSidebar.Size = new System.Drawing.Size(200, 10);
            this.separatorSidebar.FillColor = System.Drawing.Color.LightGray;

            this.pnlSidebar.Controls.Add(lblBrand);
            this.pnlSidebar.Controls.Add(separatorSidebar);
            this.pnlSidebar.Controls.Add(btnNavHome);
            this.pnlSidebar.Controls.Add(btnNavRegister);
            this.pnlSidebar.Controls.Add(btnNavSchedule);
            this.pnlSidebar.Controls.Add(btnNavGrades);
            this.pnlSidebar.Controls.Add(btnNavProfile);
            this.pnlSidebar.Controls.Add(btnLogout);

            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(248, 249, 253);
            this.pnlHeader.Controls.Clear();

            this.txtSearch.PlaceholderText = "Tìm kiếm khóa học...";
            this.txtSearch.BorderRadius = 20;
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(30, 20);
            this.txtSearch.Size = new System.Drawing.Size(400, 40);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtNameClass_TextChanged);

            this.btnChat.Text = "Chat";
            this.btnChat.BorderRadius = 15;
            this.btnChat.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Location = new System.Drawing.Point(0, 20); // Sẽ set Anchor right
            this.btnChat.Size = new System.Drawing.Size(100, 40);
            this.btnChat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnChat.Click += new System.EventHandler(this.guna2Button1_Click);

            this.lblUserNameHeader.Text = "Sinh viên";
            this.lblUserNameHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserNameHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserNameHeader.Size = new System.Drawing.Size(200, 40);
            this.lblUserNameHeader.Location = new System.Drawing.Point(0, 20); // Sẽ set Anchor right
            this.lblUserNameHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            this.pnlHeader.Controls.Add(txtSearch);
            this.btnChat.Location = new System.Drawing.Point(1000, 20);
            this.lblUserNameHeader.Location = new System.Drawing.Point(1120, 20);

            this.pnlHeader.Controls.Add(btnChat);
            this.pnlHeader.Controls.Add(lblUserNameHeader);

            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.FillColor = System.Drawing.Color.FromArgb(248, 249, 253);
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30);

            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Height = 140;
            this.pnlBanner.BorderRadius = 20;
            this.pnlBanner.FillColor = System.Drawing.Color.FromArgb(100, 149, 237);

            this.lblWelcomeBig.Text = "Chào mừng trở lại!";
            this.lblWelcomeBig.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeBig.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeBig.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeBig.Location = new System.Drawing.Point(30, 25);
            this.lblWelcomeBig.AutoSize = true;

            this.lblDate.Text = "10/01/2026";
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Location = new System.Drawing.Point(35, 80);
            this.lblDate.AutoSize = true;

            this.pnlBanner.Controls.Add(lblWelcomeBig);
            this.pnlBanner.Controls.Add(lblDate);

            this.lblSectionTitle.Text = "Khóa học của tôi";
            this.lblSectionTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblSectionTitle.Location = new System.Drawing.Point(30, 200);
            this.lblSectionTitle.AutoSize = true;

            this.flpCourses.Location = new System.Drawing.Point(30, 240);
            this.flpCourses.Size = new System.Drawing.Size(1200, 500);
            this.flpCourses.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.flpCourses.AutoScroll = true;
            this.flpCourses.BackColor = System.Drawing.Color.Transparent;

            this.pnlContent.Controls.Add(flpCourses);
            this.pnlContent.Controls.Add(lblSectionTitle);
            this.pnlContent.Controls.Add(pnlBanner);

            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 800);

            this.Controls.Add(this.pnlContent); 
            this.Controls.Add(this.pnlHeader);  
            this.Controls.Add(this.pnlSidebar); 

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Hệ thống quản lý sinh viên";

            this.Resize += new System.EventHandler(this.MainForm_Resize);

            this.ResumeLayout(false);
        }
        private void SetupButton(Guna.UI2.WinForms.Guna2Button btn, string text, int top)
        {
            btn.Text = text;
            btn.FillColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.DimGray;
            btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            btn.TextOffset = new System.Drawing.Point(20, 0);
            btn.Location = new System.Drawing.Point(10, top);
            btn.Size = new System.Drawing.Size(240, 50);
            btn.BorderRadius = 10;
            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(235, 240, 255);
            btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(94, 148, 255);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            if (this.btnChat != null && this.pnlHeader != null)
            {
                this.btnChat.Location = new System.Drawing.Point(this.pnlHeader.Width - 140, 20);
                this.lblUserNameHeader.Location = new System.Drawing.Point(this.pnlHeader.Width - 350, 20);
            }
        }

        #endregion
    }
}