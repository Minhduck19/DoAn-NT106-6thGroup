using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class SoLuongSinhVienTrongLop
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
            formElipse = new Guna2Elipse(components);
            lblTitle = new Label();
            panelContainer = new Guna2Panel();
            lvCourses = new ListView();
            colCourseId = new ColumnHeader();
            colCourseName = new ColumnHeader();
            colInstructor = new ColumnHeader();
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
            lblTitle.Text = "Danh Sách Sinh Viên ";
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
            lvCourses.Location = new Point(18, 22);
            lvCourses.Name = "lvCourses";
            lvCourses.Size = new Size(865, 477);
            lvCourses.TabIndex = 0;
            lvCourses.UseCompatibleStateImageBehavior = false;
            lvCourses.View = View.Details;
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
            // 
            // SoLuongSinhVienTrongLop
            // 
            AutoSize = true;
            BackColor = Color.FromArgb(232, 241, 250);
            ClientSize = new Size(1164, 744);
            Controls.Add(btnThoat);
            Controls.Add(lblTitle);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SoLuongSinhVienTrongLop";
            StartPosition = FormStartPosition.CenterScreen;
            panelContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Guna2GradientButton btnThoat;
    }
}
