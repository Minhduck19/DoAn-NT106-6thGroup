namespace APP_DOAN
{
    partial class MainForm_GiangVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.borderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtFind = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCreateNew = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.flpMyCourses = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();

            this.SuspendLayout();

            // 
            // 1. BO TRÒN FORM (Borderless)
            // 
            this.borderlessForm.BorderRadius = 20;
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.ShadowColor = System.Drawing.Color.DimGray;

            // 
            // 2. LABEL CHÀO MỪNG
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(120, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào!";

            // 
            // 3. THANH TÌM KIẾM (Guna TextBox)
            // 
            this.txtFind.BorderRadius = 18;
            this.txtFind.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFind.DefaultText = "";
            this.txtFind.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFind.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFind.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFind.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFind.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFind.Location = new System.Drawing.Point(30, 80);
            this.txtFind.Name = "txtFind";
            this.txtFind.PasswordChar = '\0';
            this.txtFind.PlaceholderText = "Tìm kiếm lớp học...";
            this.txtFind.SelectedText = "";
            this.txtFind.Size = new System.Drawing.Size(350, 40);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);

            // 
            // 4. NÚT TẠO LỚP (Guna Button - Gradient)
            // 
            this.btnCreateNew.BorderRadius = 10;
            this.btnCreateNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateNew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212))))); 
            this.btnCreateNew.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateNew.ForeColor = System.Drawing.Color.White;
            this.btnCreateNew.Location = new System.Drawing.Point(400, 80);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(160, 40);
            this.btnCreateNew.TabIndex = 2;
            this.btnCreateNew.Text = "+ Tạo Lớp Mới";
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);

            // 
            // 5. NÚT ĐĂNG XUẤT
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.BorderColor = System.Drawing.Color.IndianRed;
            this.btnLogOut.BorderRadius = 10;
            this.btnLogOut.BorderThickness = 1;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FillColor = System.Drawing.Color.White;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLogOut.Location = new System.Drawing.Point(1000, 30);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(120, 40);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Đăng xuất";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);

            // 
            // 6. KHUNG CHỨA THẺ (FlowLayoutPanel)
            // 
            this.flpMyCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMyCourses.AutoScroll = true;
            this.flpMyCourses.Location = new System.Drawing.Point(30, 150);
            this.flpMyCourses.Name = "flpMyCourses";
            this.flpMyCourses.Size = new System.Drawing.Size(1140, 600);
            this.flpMyCourses.TabIndex = 4;

            // 
            // Nút Tắt & Minimize (Góc phải trên)
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.IconColor = System.Drawing.Color.Gray;
            this.btnExit.Location = new System.Drawing.Point(1150, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 29);
            this.btnExit.TabIndex = 5;

            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconColor = System.Drawing.Color.Gray;
            this.btnMinimize.Location = new System.Drawing.Point(1100, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 29);
            this.btnMinimize.TabIndex = 6;

            // 
            // MainForm_GiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245))))); // Màu nền xám Facebook
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.flpMyCourses);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm_GiangVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm_GiangVien";
            this.Load += new System.EventHandler(this.MainForm_GiangVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private System.Windows.Forms.Label lblWelcome;
        private Guna.UI2.WinForms.Guna2TextBox txtFind;
        private Guna.UI2.WinForms.Guna2Button btnCreateNew;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private System.Windows.Forms.FlowLayoutPanel flpMyCourses;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
    }
}