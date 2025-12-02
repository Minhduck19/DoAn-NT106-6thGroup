namespace APP_DOAN.GiaoDienChinh
{
    partial class CourseDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel panelMain;

        private System.Windows.Forms.ListView lvStudents;
        private System.Windows.Forms.ListView lvRequests;

        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private Guna.UI2.WinForms.Guna2Button btnReject;
        private Guna.UI2.WinForms.Guna2Button btnRemoveStudent;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelTop = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelMain = new Guna.UI2.WinForms.Guna2Panel();
            guna2btnThoat = new Guna.UI2.WinForms.Guna2Button();
            lvStudents = new ListView();
            lvRequests = new ListView();
            btnApprove = new Guna.UI2.WinForms.Guna2Button();
            btnReject = new Guna.UI2.WinForms.Guna2Button();
            btnRemoveStudent = new Guna.UI2.WinForms.Guna2Button();
            btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTitle);
            panelTop.CustomizableEdges = customizableEdges1;
            panelTop.Dock = DockStyle.Top;
            panelTop.FillColor = Color.FromArgb(0, 122, 204);
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelTop.Size = new Size(900, 65);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(219, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết lớp học";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(guna2btnThoat);
            panelMain.Controls.Add(lvStudents);
            panelMain.Controls.Add(lvRequests);
            panelMain.Controls.Add(btnApprove);
            panelMain.Controls.Add(btnReject);
            panelMain.Controls.Add(btnRemoveStudent);
            panelMain.Controls.Add(btnRefresh);
            panelMain.CustomizableEdges = customizableEdges13;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 65);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelMain.Size = new Size(900, 535);
            panelMain.TabIndex = 0;
            // 
            // guna2btnThoat
            // 
            guna2btnThoat.CustomizableEdges = customizableEdges3;
            guna2btnThoat.FillColor = Color.IndianRed;
            guna2btnThoat.Font = new Font("Segoe UI", 9F);
            guna2btnThoat.ForeColor = Color.White;
            guna2btnThoat.Location = new Point(498, 480);
            guna2btnThoat.Name = "guna2btnThoat";
            guna2btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2btnThoat.Size = new Size(356, 40);
            guna2btnThoat.TabIndex = 6;
            guna2btnThoat.Text = "Thoát";
            guna2btnThoat.Click += guna2Button1_Click;
            // 
            // lvStudents
            // 
            lvStudents.FullRowSelect = true;
            lvStudents.GridLines = true;
            lvStudents.Location = new Point(20, 20);
            lvStudents.Name = "lvStudents";
            lvStudents.Size = new Size(400, 450);
            lvStudents.TabIndex = 0;
            lvStudents.UseCompatibleStateImageBehavior = false;
            lvStudents.View = View.Details;
            // 
            // lvRequests
            // 
            lvRequests.FullRowSelect = true;
            lvRequests.GridLines = true;
            lvRequests.Location = new Point(450, 20);
            lvRequests.Name = "lvRequests";
            lvRequests.Size = new Size(425, 350);
            lvRequests.TabIndex = 1;
            lvRequests.UseCompatibleStateImageBehavior = false;
            lvRequests.View = View.Details;
            // 
            // btnApprove
            // 
            btnApprove.CustomizableEdges = customizableEdges5;
            btnApprove.FillColor = Color.SeaGreen;
            btnApprove.Font = new Font("Segoe UI", 9F);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(450, 390);
            btnApprove.Name = "btnApprove";
            btnApprove.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnApprove.Size = new Size(130, 40);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Duyệt";
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.CustomizableEdges = customizableEdges7;
            btnReject.FillColor = Color.IndianRed;
            btnReject.Font = new Font("Segoe UI", 9F);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(590, 390);
            btnReject.Name = "btnReject";
            btnReject.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnReject.Size = new Size(130, 40);
            btnReject.TabIndex = 3;
            btnReject.Text = "Từ chối";
            btnReject.Click += btnReject_Click;
            // 
            // btnRemoveStudent
            // 
            btnRemoveStudent.CustomizableEdges = customizableEdges9;
            btnRemoveStudent.FillColor = Color.DarkOrange;
            btnRemoveStudent.Font = new Font("Segoe UI", 9F);
            btnRemoveStudent.ForeColor = Color.White;
            btnRemoveStudent.Location = new Point(20, 480);
            btnRemoveStudent.Name = "btnRemoveStudent";
            btnRemoveStudent.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRemoveStudent.Size = new Size(200, 40);
            btnRemoveStudent.TabIndex = 4;
            btnRemoveStudent.Text = "Xóa SV khỏi lớp";
            btnRemoveStudent.Click += btnRemoveStudent_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.CustomizableEdges = customizableEdges11;
            btnRefresh.FillColor = Color.RoyalBlue;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(755, 390);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Làm mới";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // CourseDetailForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(panelMain);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CourseDetailForm";
            Load += CourseDetailForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Guna.UI2.WinForms.Guna2Button guna2btnThoat;
    }
}
