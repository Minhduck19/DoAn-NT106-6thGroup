namespace APP_DOAN.GiaoDienChinh
{
    partial class CreateAssignment
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            txtDesc = new Guna.UI2.WinForms.Guna2TextBox();
            dtpDue = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnChooseFile = new Guna.UI2.WinForms.Guna2Button();
            lblFile = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DeepSkyBlue;
            lblTitle.Location = new Point(160, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẠO BÀI TẬP";
            // 
            // txtTitle
            // 
            txtTitle.CustomizableEdges = customizableEdges21;
            txtTitle.DefaultText = "";
            txtTitle.Font = new Font("Segoe UI", 11F);
            txtTitle.Location = new Point(50, 80);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Tiêu đề bài tập";
            txtTitle.SelectedText = "";
            txtTitle.ShadowDecoration.CustomizableEdges = customizableEdges22;
            txtTitle.Size = new Size(420, 40);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtDesc
            // 
            txtDesc.CustomizableEdges = customizableEdges23;
            txtDesc.DefaultText = "";
            txtDesc.Font = new Font("Segoe UI", 11F);
            txtDesc.Location = new Point(50, 140);
            txtDesc.Margin = new Padding(3, 4, 3, 4);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderText = "Mô tả / yêu cầu bài tập";
            txtDesc.SelectedText = "";
            txtDesc.ShadowDecoration.CustomizableEdges = customizableEdges24;
            txtDesc.Size = new Size(420, 100);
            txtDesc.TabIndex = 2;
            // 
            // dtpDue
            // 
            dtpDue.Checked = true;
            dtpDue.CustomizableEdges = customizableEdges25;
            dtpDue.FillColor = Color.DeepSkyBlue;
            dtpDue.Font = new Font("Segoe UI", 10F);
            dtpDue.ForeColor = Color.White;
            dtpDue.Format = DateTimePickerFormat.Long;
            dtpDue.Location = new Point(50, 260);
            dtpDue.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDue.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDue.Name = "dtpDue";
            dtpDue.ShadowDecoration.CustomizableEdges = customizableEdges26;
            dtpDue.Size = new Size(420, 36);
            dtpDue.TabIndex = 3;
            dtpDue.Value = new DateTime(2026, 1, 2, 23, 11, 12, 107);
            // 
            // btnChooseFile
            // 
            btnChooseFile.CustomizableEdges = customizableEdges27;
            btnChooseFile.FillColor = Color.DeepSkyBlue;
            btnChooseFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChooseFile.ForeColor = Color.White;
            btnChooseFile.Location = new Point(50, 320);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnChooseFile.Size = new Size(200, 45);
            btnChooseFile.TabIndex = 4;
            btnChooseFile.Text = "📎 Chọn file đề bài";
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.ForeColor = Color.Gray;
            lblFile.Location = new Point(270, 335);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(104, 20);
            lblFile.TabIndex = 5;
            lblFile.Text = "Chưa chọn file";
            // 
            // btnSave
            // 
            btnSave.CustomizableEdges = customizableEdges29;
            btnSave.FillColor = Color.DeepSkyBlue;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(50, 400);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges30;
            btnSave.Size = new Size(420, 50);
            btnSave.TabIndex = 6;
            btnSave.Text = "🚀 Đăng bài tập";
            btnSave.Click += btnSave_Click;
            // 
            // CreateAssignment
            // 
            BackColor = Color.White;
            ClientSize = new Size(520, 520);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(txtDesc);
            Controls.Add(dtpDue);
            Controls.Add(btnChooseFile);
            Controls.Add(lblFile);
            Controls.Add(btnSave);
            ForeColor = Color.FromArgb(128, 255, 255);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CreateAssignment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo bài tập mới";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFile;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtDesc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDue;
        private Guna.UI2.WinForms.Guna2Button btnChooseFile;
        private Guna.UI2.WinForms.Guna2Button btnSave;

        #endregion
    }
}