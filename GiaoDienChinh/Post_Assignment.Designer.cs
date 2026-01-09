namespace APP_DOAN.GiaoDienChinh
{
    partial class Post_Assignment
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

        private void InitializeComponent()
        {
            this.txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFilePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.btnPost = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 23);
            this.lblTitle.Text = "Tiêu đề bài tập";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(30, 50);
            this.txtTitle.Size = new System.Drawing.Size(520, 40);
            this.txtTitle.PlaceholderText = "Nhập tiêu đề bài tập / câu hỏi";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(30, 100);
            this.lblDescription.Text = "Nội dung";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(30, 125);
            this.txtDescription.Size = new System.Drawing.Size(520, 120);
            this.txtDescription.Multiline = true;
            this.txtDescription.PlaceholderText = "Nhập nội dung bài tập hoặc câu hỏi...";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFile.Location = new System.Drawing.Point(30, 260);
            this.lblFile.Text = "Tệp đính kèm (tuỳ chọn)";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(30, 285);
            this.txtFilePath.Size = new System.Drawing.Size(400, 40);
            this.txtFilePath.ReadOnly = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(440, 285);
            this.btnBrowse.Size = new System.Drawing.Size(110, 40);
            this.btnBrowse.Text = "Chọn file";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(30, 345);
            this.btnPost.Size = new System.Drawing.Size(520, 45);
            this.btnPost.Text = "Đăng bài tập";
            this.btnPost.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // Post_Assignment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnPost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giảng viên đăng bài tập";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtFilePath;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private Guna.UI2.WinForms.Guna2Button btnPost;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFile;
    }
}