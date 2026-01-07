using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    partial class ChamBai
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChamBai;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvChamBai = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamBai)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChamBai
            // 
            this.dgvChamBai.AllowUserToAddRows = false;
            this.dgvChamBai.AllowUserToDeleteRows = false;
            this.dgvChamBai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChamBai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamBai.BackgroundColor = System.Drawing.Color.White;
            this.dgvChamBai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamBai.GridColor = System.Drawing.Color.LightGray;
            this.dgvChamBai.Location = new System.Drawing.Point(12, 70);
            this.dgvChamBai.MultiSelect = false;
            this.dgvChamBai.Name = "dgvChamBai";
            this.dgvChamBai.ReadOnly = false;
            this.dgvChamBai.RowHeadersVisible = false;
            this.dgvChamBai.RowTemplate.Height = 28;
            this.dgvChamBai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChamBai.Size = new System.Drawing.Size(960, 400);
            this.dgvChamBai.TabIndex = 0;
            this.dgvChamBai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamBai_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 10;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(860, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "ĐÓNG";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 32);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "CHẤM BÀI: ...";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblStatus.Location = new System.Drawing.Point(12, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Đã nộp: 0/0";
            // 
            // ChamBai
            // 
            this.ClientSize = new System.Drawing.Size(984, 532);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvChamBai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChamBai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chấm bài";
            this.Load += new System.EventHandler(this.ChamBai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamBai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
