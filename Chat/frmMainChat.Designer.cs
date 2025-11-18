
namespace APP_DOAN
{
    partial class frmMainChat
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            flowUserListPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowUserListPanel
            // 
            flowUserListPanel.AutoScroll = true;
            flowUserListPanel.BackColor = Color.White;
            flowUserListPanel.Dock = DockStyle.Fill;
            flowUserListPanel.FlowDirection = FlowDirection.TopDown;
            flowUserListPanel.Location = new Point(0, 0);
            flowUserListPanel.Margin = new Padding(3, 4, 3, 4);
            flowUserListPanel.Name = "flowUserListPanel";
            flowUserListPanel.Size = new Size(400, 750);
            flowUserListPanel.TabIndex = 0;
            flowUserListPanel.WrapContents = false;
            flowUserListPanel.Paint += flowUserListPanel_Paint;
            // 
            // frmMainChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 750);
            Controls.Add(flowUserListPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMainChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh Bạ Chat";
            Load += frmMainChat_Load;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowUserListPanel;
    }
}