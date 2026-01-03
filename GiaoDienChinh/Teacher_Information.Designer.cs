namespace APP_DOAN.GiaoDienChinh
{
    partial class Teacher_Information
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnChangeAvatar = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTeacherID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBang = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSex = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBirthday = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFaculty = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClass = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();

            // 
            // 1. Cấu hình Form
            // 
            this.borderlessForm.BorderRadius = 20;
            this.borderlessForm.ContainerControl = this;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // 
            // 2. Avatar & Nút bên trái
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Text = "Chào, Giảng viên";

            this.picAvatar.Location = new System.Drawing.Point(50, 80);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.ShadowDecoration.Enabled = true;
            this.picAvatar.Size = new System.Drawing.Size(120, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabStop = false;

            this.btnChangeAvatar.BorderRadius = 15;
            this.btnChangeAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangeAvatar.ForeColor = System.Drawing.Color.White;
            this.btnChangeAvatar.Location = new System.Drawing.Point(60, 215);
            this.btnChangeAvatar.Name = "btnChangeAvatar";
            this.btnChangeAvatar.Size = new System.Drawing.Size(100, 30);
            this.btnChangeAvatar.Text = "Đổi ảnh";
            this.btnChangeAvatar.Click += new System.EventHandler(this.btnChangeAvatar_Click);

            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, 480);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnLogout.BorderRadius = 10;
            this.btnLogout.FillColor = System.Drawing.Color.Gray;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(30, 535);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 45);
            this.btnLogout.Text = "Thoát";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // 3. Khung nhập liệu bên phải
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(400, 30);
            this.lblTitle.Text = "THÔNG TIN GIẢNG VIÊN";

            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.BorderRadius = 15;
            this.pnlContainer.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContainer.Location = new System.Drawing.Point(250, 80);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.ShadowDecoration.Enabled = true;
            this.pnlContainer.Size = new System.Drawing.Size(600, 500);
            this.pnlContainer.Controls.Add(this.label1); this.pnlContainer.Controls.Add(this.txtTeacherID);
            this.pnlContainer.Controls.Add(this.label2); this.pnlContainer.Controls.Add(this.txtFullName);
            this.pnlContainer.Controls.Add(this.label3); this.pnlContainer.Controls.Add(this.txtBang);
            this.pnlContainer.Controls.Add(this.label4); this.pnlContainer.Controls.Add(this.txtSex);
            this.pnlContainer.Controls.Add(this.label5); this.pnlContainer.Controls.Add(this.txtBirthday);
            this.pnlContainer.Controls.Add(this.label6); this.pnlContainer.Controls.Add(this.txtFaculty);
            this.pnlContainer.Controls.Add(this.label7); this.pnlContainer.Controls.Add(this.txtClass);
            this.pnlContainer.Controls.Add(this.label8); this.pnlContainer.Controls.Add(this.txtEmail);

            // 
            // Cấu hình vị trí Label và TextBox
            // 
            SetupLabel(this.label1, "Mã số giảng viên:", 30, 30);
            SetupTextBox(this.txtTeacherID, 180, 25, 300);

            SetupLabel(this.label2, "Họ và tên:", 30, 80);
            SetupTextBox(this.txtFullName, 30, 105, 250);

            SetupLabel(this.label3, "Bằng cấp:", 300, 80);
            SetupTextBox(this.txtBang, 300, 105, 250);

            SetupLabel(this.label4, "Giới tính:", 80, 160);
            SetupTextBox(this.txtSex, 180, 155, 370);

            // --- SỬA "NĂM SINH" THÀNH "NGÀY SINH" ---
            SetupLabel(this.label5, "Ngày sinh:", 80, 210);
            SetupTextBox(this.txtBirthday, 180, 205, 370);

            SetupLabel(this.label6, "Khoa:", 80, 260);
            SetupTextBox(this.txtFaculty, 180, 255, 370);

            // --- SỬA "DANH SÁCH LỚP" THÀNH "CHỨC VỤ" ---
            // Đổi X từ 30 -> 80 để thẳng hàng với "Khoa", "Email"
            SetupLabel(this.label7, "Chức vụ:", 80, 310);
            SetupTextBox(this.txtClass, 180, 305, 370);

            SetupLabel(this.label8, "Email:", 80, 360);
            SetupTextBox(this.txtEmail, 180, 355, 370);
            this.txtEmail.Enabled = false;

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.btnChangeAvatar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLogout);
            this.Load += new System.EventHandler(this.Teacher_Information_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = text;
        }

        private void SetupTextBox(Guna.UI2.WinForms.Guna2TextBox txt, int x, int y, int w)
        {
            txt.BorderRadius = 5;
            txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(w, 36);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private System.Windows.Forms.Label lblTitle, lblWelcome;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChangeAvatar, btnSave, btnLogout;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2TextBox txtTeacherID, txtFullName, txtBang, txtSex, txtBirthday, txtFaculty, txtClass, txtEmail;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7, label8;
    }
}