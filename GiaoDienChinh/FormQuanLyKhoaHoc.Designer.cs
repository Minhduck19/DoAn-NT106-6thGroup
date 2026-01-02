namespace APP_DOAN
{
    partial class FormQuanLyKhoaHoc
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox(); // Nút tắt form xịn

            this.tabControl1 = new Guna.UI2.WinForms.Guna2TabControl();

            this.tabAssignments = new System.Windows.Forms.TabPage();
            this.dgvAssignments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddAssignment = new Guna.UI2.WinForms.Guna2Button();

            this.tabStudents = new System.Windows.Forms.TabPage();
            this.dgvStudents = new Guna.UI2.WinForms.Guna2DataGridView();

            this.tabRequests = new System.Windows.Forms.TabPage();
            this.dgvRequests = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();

            this.pnlHeader.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.tabRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // 
            // --- 1. HEADER HIỆN ĐẠI (MÀU GRADIENT HOẶC TRẮNG) ---
            // 
            this.pnlHeader.Controls.Add(this.guna2ControlBox1);
            this.pnlHeader.Controls.Add(this.lblCourseName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.ShadowDecoration.Depth = 10;
            this.pnlHeader.ShadowDecoration.Enabled = true; // Tạo bóng đổ nhẹ xuống dưới
            this.pnlHeader.Size = new System.Drawing.Size(950, 60);

            this.lblCourseName.AutoSize = true;
            this.lblCourseName.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCourseName.ForeColor = System.Drawing.Color.FromArgb(94, 148, 255); // Màu xanh Guna
            this.lblCourseName.Location = new System.Drawing.Point(20, 12);
            this.lblCourseName.Text = "TÊN LỚP HỌC";

            // Nút tắt Form (Góc trên phải)
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(890, 10);
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);

            // 
            // --- 2. TAB CONTROL (Kiểu nút bấm phẳng) ---
            // 
            this.tabControl1.Controls.Add(this.tabAssignments);
            this.tabControl1.Controls.Add(this.tabStudents);
            this.tabControl1.Controls.Add(this.tabRequests);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(192, 255, 192); // Màu khi di chuột
            this.tabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.tabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(94, 148, 255); // Gạch dưới màu xanh
            this.tabControl1.TabMenuBackColor = System.Drawing.Color.White;
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 540);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);

            // --- TAB BÀI TẬP ---
            this.tabAssignments.Text = "Bài Tập";
            this.tabAssignments.BackColor = System.Drawing.Color.White;
            this.tabAssignments.Controls.Add(this.btnAddAssignment);
            this.tabAssignments.Controls.Add(this.dgvAssignments);

            // Nút Guna Button (Bo tròn, bóng đổ)
            this.btnAddAssignment.BorderRadius = 5;
            this.btnAddAssignment.FillColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.btnAddAssignment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddAssignment.ForeColor = System.Drawing.Color.White;
            this.btnAddAssignment.Location = new System.Drawing.Point(20, 15);
            this.btnAddAssignment.Size = new System.Drawing.Size(160, 40);
            this.btnAddAssignment.Text = "+ Tạo Bài Tập";
            this.btnAddAssignment.Click += new System.EventHandler(this.btnAddAssignment_Click);

            // GridView Guna (Cực đẹp)
            ConfigureGunaGrid(this.dgvAssignments);
            this.dgvAssignments.Location = new System.Drawing.Point(20, 70);
            this.dgvAssignments.Size = new System.Drawing.Size(900, 420);
            this.dgvAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            // --- TAB SINH VIÊN ---
            this.tabStudents.Text = "Sinh Viên";
            this.tabStudents.BackColor = System.Drawing.Color.White;
            this.tabStudents.Controls.Add(this.dgvStudents);

            ConfigureGunaGrid(this.dgvStudents);
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;

            // --- TAB PHÊ DUYỆT ---
            this.tabRequests.Text = "Phê Duyệt";
            this.tabRequests.BackColor = System.Drawing.Color.White;
            this.tabRequests.Controls.Add(this.btnApprove);
            this.tabRequests.Controls.Add(this.dgvRequests);

            this.btnApprove.BorderRadius = 5;
            this.btnApprove.FillColor = System.Drawing.Color.FromArgb(255, 128, 0); // Màu Cam
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(20, 15);
            this.btnApprove.Size = new System.Drawing.Size(160, 40);
            this.btnApprove.Text = "✓ Duyệt Tham Gia";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            ConfigureGunaGrid(this.dgvRequests);
            this.dgvRequests.Location = new System.Drawing.Point(20, 70);
            this.dgvRequests.Size = new System.Drawing.Size(900, 420);
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            // Form Main
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Không viền (dùng GunaControlBox để tắt)
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormQuanLyKhoaHoc_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAssignments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.tabRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);

            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.Location = new System.Drawing.Point(890, 10); // Góc phải cùng

            // --- CẤU HÌNH NÚT PHÓNG TO (MAXIMIZE) ---
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox; // 🔥 Loại nút Maximize
            this.btnMaximize.FillColor = System.Drawing.Color.White;
            this.btnMaximize.IconColor = System.Drawing.Color.Gray;
            this.btnMaximize.Location = new System.Drawing.Point(840, 10); // Đặt bên cạnh nút tắt
            this.btnMaximize.Size = new System.Drawing.Size(45, 29);
            this.pnlHeader.Controls.Add(this.btnMaximize); // Nhớ thêm vào Panel Header

            // --- CẤU HÌNH BẢNG (GRIDVIEW) ĐỂ TỰ GIÃN ---
            // Tìm đoạn cấu hình dgvRequests, dgvStudents, dgvAssignments và THÊM dòng Anchor này:

            // Ví dụ cho dgvRequests:
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // 🔥 Quan trọng: Neo 4 góc

            // Ví dụ cho dgvStudents:
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // Ví dụ cho dgvAssignments:
            this.dgvAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        }

        // Hàm hỗ trợ cài đặt Grid Guna cho đẹp (Code reuse)
        private void ConfigureGunaGrid(Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            // 1. Style Header (Màu xanh đậm hơn cho dễ đọc)
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(94, 148, 255); // Xanh Guna chuẩn
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(94, 148, 255);
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            // 2. Style Dòng dữ liệu
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94); // Màu chữ xám đậm
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255); // Màu nền khi chọn (tím nhạt)
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);

            // 3. Style dòng xen kẽ (Zebra) -> Giúp dễ nhìn hơn
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(249, 249, 249); // Xám rất nhạt

            dgv.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke; // 🔥 Đổi nền Grid thành xám nhẹ thay vì trắng tinh
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // 🔥 Thêm viền cho bảng
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 45;
            dgv.EnableHeadersVisualStyles = false;

            dgv.GridColor = System.Drawing.Color.FromArgb(231, 229, 255); // Màu đường kẻ

            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle = rowStyle;

            // Theme Guna (Reset để custom style có hiệu lực)
            dgv.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            dgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(94, 148, 255);
            dgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblCourseName;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAssignments;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAssignments;
        private Guna.UI2.WinForms.Guna2Button btnAddAssignment;
        private System.Windows.Forms.TabPage tabStudents;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStudents;
        private System.Windows.Forms.TabPage tabRequests;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRequests;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
    }
}