namespace APP_DOAN
{
    partial class frmChat
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelInput = new Guna.UI2.WinForms.Guna2Panel();
            txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            btnSend = new Guna.UI2.WinForms.Guna2Button();
            flowChatPanel = new FlowLayoutPanel();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // panelInput
            // 
            panelInput.Controls.Add(txtMessage);
            panelInput.Controls.Add(btnSend);
            panelInput.CustomizableEdges = customizableEdges5;
            panelInput.Dock = DockStyle.Bottom;
            panelInput.FillColor = Color.White;
            panelInput.Location = new Point(0, 675);
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(10, 10, 10, 10);
            panelInput.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelInput.ShadowDecoration.Depth = 5;
            panelInput.ShadowDecoration.Enabled = true;
            panelInput.ShadowDecoration.Shadow = new Padding(0, -5, 0, 0);
            panelInput.Size = new Size(800, 75);
            panelInput.TabIndex = 0;
            // 
            // txtMessage
            // 
            txtMessage.BorderRadius = 8;
            txtMessage.Cursor = Cursors.IBeam;
            txtMessage.CustomizableEdges = customizableEdges1;
            txtMessage.DefaultText = "";
            txtMessage.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMessage.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMessage.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMessage.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMessage.Font = new Font("Segoe UI", 9F);
            txtMessage.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMessage.Location = new Point(10, 10);
            txtMessage.Margin = new Padding(3, 5, 3, 5);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Nhập tin nhắn...";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMessage.Size = new Size(680, 55);
            txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Animated = true;
            btnSend.BorderRadius = 8;
            btnSend.CustomizableEdges = customizableEdges3;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.Dock = DockStyle.Right;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(690, 10);
            btnSend.Margin = new Padding(3, 4, 3, 4);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSend.Size = new Size(100, 55);
            btnSend.TabIndex = 1;
            btnSend.Text = "Gửi";
            btnSend.Click += btnSend_Click;
            // 
            // flowChatPanel
            // 
            flowChatPanel.AutoScroll = true;
            flowChatPanel.BackColor = Color.White;
            flowChatPanel.Dock = DockStyle.Fill;
            flowChatPanel.FlowDirection = FlowDirection.TopDown;
            flowChatPanel.Location = new Point(0, 0);
            flowChatPanel.Margin = new Padding(3, 4, 3, 4);
            flowChatPanel.Name = "flowChatPanel";
            flowChatPanel.Padding = new Padding(10, 12, 0, 12);
            flowChatPanel.Size = new Size(800, 675);
            flowChatPanel.TabIndex = 1;
            flowChatPanel.WrapContents = false;
            flowChatPanel.Paint += flowChatPanel_Paint;
            // 
            // frmChat
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 750);
            Controls.Add(flowChatPanel);
            Controls.Add(panelInput);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat";
            FormClosing += frmChat_FormClosing;
            Load += frmChat_Load;
            panelInput.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelInput;
        private Guna.UI2.WinForms.Guna2TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private System.Windows.Forms.FlowLayoutPanel flowChatPanel;
    }
}