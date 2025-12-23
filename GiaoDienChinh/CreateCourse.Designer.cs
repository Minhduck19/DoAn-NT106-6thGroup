using Guna.UI2.WinForms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class CreateCourse
    {
        private Guna2Panel panelMain;
        private Guna2TextBox txtMaLop;
        private Guna2TextBox txtTenLop;
        private Guna2TextBox txtSiSo;
        private Guna2Button btnLuu;
        private Guna2Button btnThoat;
        private Guna2HtmlLabel lblTitle;


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
            btnLuu = new Guna2Button();
            btnThoat = new Guna2Button();
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
            panelMain.Controls.Add(btnLuu);
            panelMain.Controls.Add(btnThoat);
            panelMain.CustomizableEdges = customizableEdges11;
            panelMain.Dock = DockStyle.Fill;
            panelMain.FillColor = Color.FromArgb(240, 248, 255);
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelMain.ShadowDecoration.Depth = 15;
            panelMain.ShadowDecoration.Enabled = true;
            panelMain.Size = new Size(650, 520);
            panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 90, 200);
            lblTitle.Location = new Point(180, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 52);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẠO LỚP HỌC";
            // 
            // txtMaLop
            // 
            txtMaLop.BorderRadius = 12;
            txtMaLop.CustomizableEdges = customizableEdges1;
            txtMaLop.DefaultText = "";
            txtMaLop.Font = new Font("Segoe UI", 12F);
            txtMaLop.Location = new Point(120, 110);
            txtMaLop.Margin = new Padding(3, 4, 3, 4);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.PlaceholderText = "Mã lớp";
            txtMaLop.SelectedText = "";
            txtMaLop.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMaLop.Size = new Size(400, 50);
            txtMaLop.TabIndex = 1;
            // 
            // txtTenLop
            // 
            txtTenLop.BorderRadius = 12;
            txtTenLop.CustomizableEdges = customizableEdges3;
            txtTenLop.DefaultText = "";
            txtTenLop.Font = new Font("Segoe UI", 12F);
            txtTenLop.Location = new Point(120, 190);
            txtTenLop.Margin = new Padding(3, 4, 3, 4);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.PlaceholderText = "Tên lớp";
            txtTenLop.SelectedText = "";
            txtTenLop.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTenLop.Size = new Size(400, 50);
            txtTenLop.TabIndex = 2;
            // 
            // txtSiSo
            // 
            txtSiSo.BorderRadius = 12;
            txtSiSo.CustomizableEdges = customizableEdges5;
            txtSiSo.DefaultText = "";
            txtSiSo.Font = new Font("Segoe UI", 12F);
            txtSiSo.Location = new Point(120, 270);
            txtSiSo.Margin = new Padding(3, 4, 3, 4);
            txtSiSo.Name = "txtSiSo";
            txtSiSo.PlaceholderText = "Sĩ số";
            txtSiSo.SelectedText = "";
            txtSiSo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSiSo.Size = new Size(400, 50);
            txtSiSo.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.BorderRadius = 12;
            btnLuu.CustomizableEdges = customizableEdges7;
            btnLuu.FillColor = Color.FromArgb(0, 122, 255);
            btnLuu.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(120, 360);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLuu.Size = new Size(180, 55);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.Click += btnLuu_Click_1;
            // 
            // btnThoat
            // 
            btnThoat.BorderRadius = 12;
            btnThoat.CustomizableEdges = customizableEdges9;
            btnThoat.FillColor = Color.Gray;
            btnThoat.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(340, 360);
            btnThoat.Name = "btnThoat";
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnThoat.Size = new Size(180, 55);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // CreateCourse
            // 
            BackColor = Color.FromArgb(220, 235, 255);
            ClientSize = new Size(650, 520);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CreateCourse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo Lớp";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

    }
}