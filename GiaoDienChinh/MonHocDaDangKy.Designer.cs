using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class MonHocDaDangKy
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelContainer;
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
            btnThoat = new Guna2GradientButton();
            Find = new Guna2Button();
            label1 = new Label();
            txtNameClass = new Guna2TextBox();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(13, 71, 161);
            lblTitle.Location = new Point(61, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(980, 61);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh Sách Tất Cả Các Môn Học";
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
            panelContainer.Size = new Size(900, 502);
            panelContainer.TabIndex = 1;
            // 
            // lvCourses
            // 
            lvCourses.BorderStyle = BorderStyle.None;
            lvCourses.Columns.AddRange(new ColumnHeader[] { colCourseId, colCourseName, colInstructor });
            lvCourses.Font = new Font("Segoe UI", 10F);
            lvCourses.ForeColor = Color.FromArgb(33, 33, 33);
            lvCourses.FullRowSelect = true;
            lvCourses.Location = new Point(17, 22);
            lvCourses.Name = "lvCourses";
            lvCourses.Size = new Size(865, 477);
            lvCourses.TabIndex = 0;
            lvCourses.UseCompatibleStateImageBehavior = false;
            lvCourses.View = View.Details;
            lvCourses.SelectedIndexChanged += lvCourses_SelectedIndexChanged;
            // 
            // btnThoat
            // 
            btnThoat.BorderRadius = 10;
            btnThoat.CustomizableEdges = customizableEdges3;
            btnThoat.FillColor = Color.Red;
            btnThoat.FillColor2 = Color.FromArgb(255, 128, 0);
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(446, 684);
            btnThoat.Name = "btnThoat";
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnThoat.Size = new Size(200, 48);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // Find
            // 
            Find.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Find.BackColor = Color.Transparent;
            Find.BorderRadius = 15;
            Find.CustomizableEdges = customizableEdges5;
            Find.FillColor = Color.DeepSkyBlue;
            Find.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Find.ForeColor = Color.Black;
            Find.Location = new Point(874, 93);
            Find.Name = "Find";
            Find.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Find.Size = new Size(140, 34);
            Find.TabIndex = 15;
            Find.Text = "Find";
            Find.Click += Find_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 102);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 14;
            label1.Text = "Nhập tên lớp học:";
            // 
            // txtNameClass
            // 
            txtNameClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNameClass.CustomizableEdges = customizableEdges7;
            txtNameClass.DefaultText = "";
            txtNameClass.Font = new Font("Segoe UI", 9F);
            txtNameClass.Location = new Point(280, 98);
            txtNameClass.Margin = new Padding(3, 4, 3, 4);
            txtNameClass.Name = "txtNameClass";
            txtNameClass.PlaceholderText = "";
            txtNameClass.SelectedText = "";
            txtNameClass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtNameClass.Size = new Size(570, 33);
            txtNameClass.TabIndex = 13;
            // 
            // MonHocDaDangKy
            // 
            AutoSize = true;
            BackColor = Color.FromArgb(232, 241, 250);
            ClientSize = new Size(1164, 744);
            Controls.Add(Find);
            Controls.Add(label1);
            Controls.Add(txtNameClass);
            Controls.Add(btnThoat);
            Controls.Add(lblTitle);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MonHocDaDangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Load += DangKyMonHoc_Load;
            panelContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Guna2GradientButton btnThoat;
        private Guna2Button Find;
        private Label label1;
        private Guna2TextBox txtNameClass;
    }
}
