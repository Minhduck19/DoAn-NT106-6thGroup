namespace APP_DOAN 
{
    partial class UC_ChatItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblStatus = new Label();
            lblMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lnkDownloadFile = new System.Windows.Forms.LinkLabel();
            panelBubble.SuspendLayout();
            SuspendLayout();
            // 
            // panelBubble
            // 
            panelBubble.BorderRadius = 15;
            panelBubble.Controls.Add(lblStatus);
            panelBubble.Controls.Add(lblMessage);
            panelBubble.Controls.Add(lnkDownloadFile);
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            panelBubble.CustomizableEdges = customizableEdges1;
            panelBubble.FillColor = Color.FromArgb(33, 150, 243);
            panelBubble.Location = new Point(3, 4);
            panelBubble.Margin = new Padding(3, 4, 3, 4);
            panelBubble.Name = "panelBubble";
            panelBubble.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelBubble.Size = new Size(315, 89);
            panelBubble.TabIndex = 0;
            panelBubble.Paint += panelBubble_Paint;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(252, 59);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "label1";
            lblStatus.Click += lblStatus_Click;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(10, 10);
            lblMessage.Margin = new Padding(3, 4, 3, 4);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(122, 22);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Nội dung tin nhắn";
            // 
            // lnkDownloadFile
            // 
            lnkDownloadFile.AutoSize = true;
            lnkDownloadFile.Location = new Point(15, 35);
            lnkDownloadFile.Name = "lnkDownloadFile";
            lnkDownloadFile.Size = new Size(80, 15);
            lnkDownloadFile.TabIndex = 2;
            lnkDownloadFile.TabStop = true;
            lnkDownloadFile.Text = "📥 Tải file";
            // UC_ChatItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(panelBubble);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_ChatItem";
            Size = new Size(339, 97);
            Load += UC_ChatItem_Load;
            panelBubble.ResumeLayout(false);
            panelBubble.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelBubble;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMessage;
        private Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkDownloadFile;
    }
}