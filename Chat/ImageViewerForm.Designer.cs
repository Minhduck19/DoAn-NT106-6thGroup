namespace APP_DOAN
{
    partial class ImageViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewerForm));
            this.picViewer = new System.Windows.Forms.PictureBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // picViewer
            // 
            this.picViewer.BackColor = System.Drawing.Color.Black;
            this.picViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picViewer.Location = new System.Drawing.Point(0, 0);
            this.picViewer.Name = "picViewer";
            this.picViewer.Size = new System.Drawing.Size(1920, 1080);
            this.picViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picViewer.TabIndex = 0;
            this.picViewer.TabStop = false;
            
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelButtons.Controls.Add(this.btnDownload);
            this.panelButtons.Controls.Add(this.btnForward);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 1030);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons.Size = new System.Drawing.Size(1920, 50);
            this.panelButtons.TabIndex = 1;
            
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(20, 10);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(130, 30);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "⬇️ Tải về";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            this.btnDownload.MouseEnter += (s, e) => btnDownload.BackColor = System.Drawing.Color.FromArgb(120, 170, 220);
            this.btnDownload.MouseLeave += (s, e) => btnDownload.BackColor = System.Drawing.Color.FromArgb(100, 150, 200);
            
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(120)))));
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnForward.ForeColor = System.Drawing.Color.White;
            this.btnForward.Location = new System.Drawing.Point(160, 10);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(130, 30);
            this.btnForward.TabIndex = 1;
            this.btnForward.Text = "➡️ Chuyển tiếp";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.BtnForward_Click);
            this.btnForward.MouseEnter += (s, e) => btnForward.BackColor = System.Drawing.Color.FromArgb(140, 190, 140);
            this.btnForward.MouseLeave += (s, e) => btnForward.BackColor = System.Drawing.Color.FromArgb(120, 170, 120);
            
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(300, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✖️ Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = System.Drawing.Color.FromArgb(200, 120, 120);
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = System.Drawing.Color.FromArgb(180, 100, 100);
            
            // 
            // ImageViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.picViewer);
            this.Controls.Add(this.panelButtons);
            this.Name = "ImageViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem ảnh";
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picViewer;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnClose;
    }
}