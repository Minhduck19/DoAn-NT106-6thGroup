namespace APP_DOAN.GiaoDienChinh
{
    partial class Notyfi
    {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            txtDesc = new Guna.UI2.WinForms.Guna2TextBox();
            btnChooseFile = new Guna.UI2.WinForms.Guna2Button();
            lblFile = new Label();
            ThongBao = new Label();
            dtpDue = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 5;
            btnSave.CustomizableEdges = customizableEdges13;
            btnSave.FillColor = Color.FromArgb(255, 128, 0);
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(39, 472);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSave.Size = new Size(183, 53);
            btnSave.TabIndex = 2;
            btnSave.Text = " Thêm Thông Báo";
            btnSave.Click += btnSave_Click;
            // 
            // txtDesc
            // 
            txtDesc.CustomizableEdges = customizableEdges15;
            txtDesc.DefaultText = "";
            txtDesc.Font = new Font("Segoe UI", 11F);
            txtDesc.Location = new Point(39, 270);
            txtDesc.Margin = new Padding(3, 4, 3, 4);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderText = "Thêm thông báo tới sinh viên ";
            txtDesc.SelectedText = "";
            txtDesc.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtDesc.Size = new Size(727, 183);
            txtDesc.TabIndex = 3;
            txtDesc.TextChanged += txtDesc_TextChanged;
            // 
            // btnChooseFile
            // 
            btnChooseFile.CustomizableEdges = customizableEdges17;
            btnChooseFile.FillColor = Color.DeepSkyBlue;
            btnChooseFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChooseFile.ForeColor = Color.White;
            btnChooseFile.Location = new Point(39, 90);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnChooseFile.Size = new Size(200, 45);
            btnChooseFile.TabIndex = 6;
            btnChooseFile.Text = "📎 Chọn file đề bài";
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.ForeColor = Color.Gray;
            lblFile.Location = new Point(259, 105);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(120, 20);
            lblFile.TabIndex = 7;
            lblFile.Text = "Chọn file nếu có ";
            // 
            // ThongBao
            // 
            ThongBao.AutoSize = true;
            ThongBao.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            ThongBao.ForeColor = Color.DeepSkyBlue;
            ThongBao.Location = new Point(39, 23);
            ThongBao.Name = "ThongBao";
            ThongBao.Size = new Size(268, 41);
            ThongBao.TabIndex = 8;
            ThongBao.Text = "TẠO THÔNG BÁO";
            // 
            // dtpDue
            // 
            dtpDue.Checked = true;
            dtpDue.CustomizableEdges = customizableEdges19;
            dtpDue.FillColor = Color.DeepSkyBlue;
            dtpDue.Font = new Font("Segoe UI", 10F);
            dtpDue.ForeColor = Color.White;
            dtpDue.Format = DateTimePickerFormat.Long;
            dtpDue.Location = new Point(39, 152);
            dtpDue.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDue.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDue.Name = "dtpDue";
            dtpDue.ShadowDecoration.CustomizableEdges = customizableEdges20;
            dtpDue.Size = new Size(420, 36);
            dtpDue.TabIndex = 9;
            dtpDue.Value = new DateTime(2026, 1, 2, 23, 11, 12, 107);
            dtpDue.ValueChanged += dtpDue_ValueChanged;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 5;
            guna2Button1.CustomizableEdges = customizableEdges21;
            guna2Button1.FillColor = Color.White;
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(259, 472);
            guna2Button1.Margin = new Padding(3, 4, 3, 4);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges22;
            guna2Button1.Size = new Size(183, 53);
            guna2Button1.TabIndex = 10;
            guna2Button1.Text = "Thoát";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // txtTitle
            // 
            txtTitle.CustomizableEdges = customizableEdges23;
            txtTitle.DefaultText = "";
            txtTitle.Font = new Font("Segoe UI", 11F);
            txtTitle.Location = new Point(39, 211);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Tiêu đề ";
            txtTitle.SelectedText = "";
            txtTitle.ShadowDecoration.CustomizableEdges = customizableEdges24;
            txtTitle.Size = new Size(420, 40);
            txtTitle.TabIndex = 11;
            // 
            // Notyfi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(txtTitle);
            Controls.Add(guna2Button1);
            Controls.Add(dtpDue);
            Controls.Add(ThongBao);
            Controls.Add(btnChooseFile);
            Controls.Add(lblFile);
            Controls.Add(txtDesc);
            Controls.Add(btnSave);
            Name = "Notyfi";
            Text = "Notyfi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtDesc;
        private Guna.UI2.WinForms.Guna2Button btnChooseFile;
        private Label lblFile;
        private Label ThongBao;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDue;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
    }
}