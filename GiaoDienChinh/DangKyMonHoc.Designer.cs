using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class DangKyMonHoc
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelContainer;
        private Guna2GradientButton btnRefresh;
        private Guna2GradientButton btnSendRequest;
        private Label lblTitle;
        private ListView lvCourses;
        private ColumnHeader colCourseId;
        private ColumnHeader colCourseName;
        private ColumnHeader colInstructor;
        private Guna2Elipse formElipse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formElipse = new Guna2Elipse(components);
            lblTitle = new Label();
            panelContainer = new Guna2Panel();
            lvCourses = new ListView();
            colCourseId = new ColumnHeader();
            colCourseName = new ColumnHeader();
            colInstructor = new ColumnHeader();
            btnRefresh = new Guna2GradientButton();
            btnSendRequest = new Guna2GradientButton();
            btnThoat = new Guna2GradientButton();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(13, 71, 161);
            lblTitle.Location = new Point(58, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(980, 61);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ MÔN HỌC";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.Transparent;
            panelContainer.BorderRadius = 18;
            panelContainer.Controls.Add(lvCourses);
            panelContainer.CustomizableEdges = customizableEdges1;
            panelContainer.FillColor = Color.White;
            panelContainer.Location = new Point(114, 138);
            panelContainer.Name = "panelContainer";
            panelContainer.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelContainer.ShadowDecoration.Depth = 15;
            panelContainer.ShadowDecoration.Enabled = true;
            panelContainer.Size = new Size(900, 420);
            panelContainer.TabIndex = 1;
            // 
            // lvCourses
            // 
            lvCourses.BorderStyle = BorderStyle.None;
            lvCourses.Columns.AddRange(new ColumnHeader[] { colCourseId, colCourseName, colInstructor });
            lvCourses.Font = new Font("Segoe UI", 10F);
            lvCourses.ForeColor = Color.FromArgb(33, 33, 33);
            lvCourses.FullRowSelect = true;
            lvCourses.Location = new Point(18, 22);
            lvCourses.Name = "lvCourses";
            lvCourses.Size = new Size(865, 380);
            lvCourses.TabIndex = 0;
            lvCourses.UseCompatibleStateImageBehavior = false;
            lvCourses.View = View.Details;
            // 
            // btnRefresh
            // 
            btnRefresh.BorderRadius = 10;
            btnRefresh.CustomizableEdges = customizableEdges3;
            btnRefresh.FillColor = Color.FromArgb(33, 150, 243);
            btnRefresh.FillColor2 = Color.FromArgb(30, 136, 229);
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(186, 598);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRefresh.Size = new Size(200, 48);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Tải lại danh sách";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSendRequest
            // 
            btnSendRequest.BorderRadius = 10;
            btnSendRequest.CustomizableEdges = customizableEdges5;
            btnSendRequest.FillColor = Color.FromArgb(21, 101, 192);
            btnSendRequest.FillColor2 = Color.FromArgb(13, 71, 161);
            btnSendRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSendRequest.ForeColor = Color.White;
            btnSendRequest.Location = new Point(703, 598);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSendRequest.Size = new Size(230, 48);
            btnSendRequest.TabIndex = 3;
            btnSendRequest.Text = "Gửi yêu cầu tham gia";
            btnSendRequest.Click += btnSendRequest_Click;
            // 
            // btnThoat
            // 
            btnThoat.BorderRadius = 10;
            btnThoat.CustomizableEdges = customizableEdges7;
            btnThoat.FillColor = Color.Red;
            btnThoat.FillColor2 = Color.FromArgb(255, 128, 0);
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(446, 684);
            btnThoat.Name = "btnThoat";
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnThoat.Size = new Size(200, 48);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // DangKyMonHoc
            // 
            BackColor = Color.FromArgb(232, 241, 250);
            ClientSize = new Size(1164, 744);
            Controls.Add(btnThoat);
            Controls.Add(lblTitle);
            Controls.Add(panelContainer);
            Controls.Add(btnRefresh);
            Controls.Add(btnSendRequest);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DangKyMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Load += DangKyMonHoc_Load;
            panelContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Guna2GradientButton btnThoat;
    }
}
