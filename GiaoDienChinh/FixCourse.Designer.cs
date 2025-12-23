using Guna.UI2.WinForms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class FixCourse
    {

        private Guna2Panel panelMain;
        private Guna2TextBox txtMaLop;
        private Guna2TextBox txtTenLop;
        private Guna2TextBox txtSiSo;
        private Guna2Button btnCapNhat;
        private Guna2Button btnDong;
        private Guna2HtmlLabel lblTitle;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelMain = new Guna2Panel();
            lblTitle = new Guna2HtmlLabel();
            txtMaLop = new Guna2TextBox();
            txtTenLop = new Guna2TextBox();
            txtSiSo = new Guna2TextBox();
            btnCapNhat = new Guna2Button();
            btnDong = new Guna2Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.BorderRadius = 20;
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(txtMaLop);
            panelMain.Controls.Add(txtTenLop);
            panelMain.Controls.Add(txtSiSo);
            panelMain.Controls.Add(btnCapNhat);
            panelMain.Controls.Add(btnDong);
            panelMain.CustomizableEdges = customizableEdges11;
            panelMain.Dock = DockStyle.Fill;
            panelMain.FillColor = Color.FromArgb(240, 248, 255);
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelMain.ShadowDecoration.Depth = 15;
            panelMain.ShadowDecoration.Enabled = true;
            panelMain.Size = new Size(587, 538);
            panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 90, 200);
            lblTitle.Location = new Point(141, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 52);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SỬA LỚP HỌC";
            // 
            // txtMaLop
            // 
            txtMaLop.BorderRadius = 12;
            txtMaLop.CustomizableEdges = customizableEdges1;
            txtMaLop.DefaultText = "";
            txtMaLop.FillColor = Color.Gainsboro;
            txtMaLop.Font = new Font("Segoe UI", 12F);
            txtMaLop.Location = new Point(60, 120);
            txtMaLop.Margin = new Padding(3, 4, 3, 4);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.PlaceholderText = "Mã lớp (không đổi)";
            txtMaLop.ReadOnly = true;
            txtMaLop.SelectedText = "";
            txtMaLop.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMaLop.Size = new Size(420, 55);
            txtMaLop.TabIndex = 1;
            // 
            // txtTenLop
            // 
            txtTenLop.BorderRadius = 12;
            txtTenLop.CustomizableEdges = customizableEdges3;
            txtTenLop.DefaultText = "";
            txtTenLop.Font = new Font("Segoe UI", 12F);
            txtTenLop.Location = new Point(60, 200);
            txtTenLop.Margin = new Padding(3, 4, 3, 4);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.PlaceholderText = "Nhập tên lớp";
            txtTenLop.SelectedText = "";
            txtTenLop.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTenLop.Size = new Size(420, 55);
            txtTenLop.TabIndex = 2;
            // 
            // txtSiSo
            // 
            txtSiSo.BorderRadius = 12;
            txtSiSo.CustomizableEdges = customizableEdges5;
            txtSiSo.DefaultText = "";
            txtSiSo.Font = new Font("Segoe UI", 12F);
            txtSiSo.Location = new Point(60, 280);
            txtSiSo.Margin = new Padding(3, 4, 3, 4);
            txtSiSo.Name = "txtSiSo";
            txtSiSo.PlaceholderText = "Nhập sĩ số";
            txtSiSo.SelectedText = "";
            txtSiSo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSiSo.Size = new Size(420, 55);
            txtSiSo.TabIndex = 3;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BorderRadius = 12;
            btnCapNhat.CustomizableEdges = customizableEdges7;
            btnCapNhat.FillColor = Color.FromArgb(0, 122, 255);
            btnCapNhat.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(60, 380);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCapNhat.Size = new Size(200, 55);
            btnCapNhat.TabIndex = 4;
            btnCapNhat.Text = "CẬP NHẬT";
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnDong
            // 
            btnDong.BorderRadius = 12;
            btnDong.CustomizableEdges = customizableEdges9;
            btnDong.FillColor = Color.Gray;
            btnDong.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(280, 380);
            btnDong.Name = "btnDong";
            btnDong.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnDong.Size = new Size(200, 55);
            btnDong.TabIndex = 5;
            btnDong.Text = "ĐÓNG";
            btnDong.Click += btnDong_Click;
            // 
            // FixCourse
            // 
            BackColor = Color.FromArgb(220, 235, 255);
            ClientSize = new Size(587, 538);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FixCourse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa Lớp";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}