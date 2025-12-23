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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblStatus = new Label();
            lblMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            picImage = new Guna.UI2.WinForms.Guna2PictureBox();
            panelBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // panelBubble
            // 
            panelBubble.BorderRadius = 15;
            panelBubble.Controls.Add(picImage);
            panelBubble.Controls.Add(lblStatus);
            panelBubble.Controls.Add(lblMessage);
            customizableEdges3.BottomLeft = false;
            customizableEdges3.BottomRight = false;
            customizableEdges3.TopLeft = false;
            customizableEdges3.TopRight = false;
            panelBubble.CustomizableEdges = customizableEdges3;
            panelBubble.FillColor = Color.FromArgb(230, 230, 230);
            panelBubble.Location = new Point(3, 4);
            panelBubble.Margin = new Padding(3, 4, 3, 4);
            panelBubble.Name = "panelBubble";
            panelBubble.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelBubble.Size = new Size(245, 89);
            panelBubble.TabIndex = 0;
            panelBubble.Paint += panelBubble_Paint;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(147, 58);
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
            lblMessage.Location = new Point(10, 10);
            lblMessage.Margin = new Padding(3, 4, 3, 4);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(122, 22);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Nội dung tin nhắn";
            // 
            // picImage
            // 
            picImage.BorderRadius = 15;
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            picImage.CustomizableEdges = customizableEdges1;
            picImage.Dock = DockStyle.None;
            picImage.ImageRotate = 0F;
            picImage.Location = new Point(0, 0);
            picImage.Name = "picImage";
            customizableEdges2.BottomLeft = false;
            customizableEdges2.BottomRight = false;
            customizableEdges2.TopLeft = false;
            customizableEdges2.TopRight = false;
            picImage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            picImage.Size = new Size(245, 89);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 2;
            picImage.TabStop = false;
            picImage.Visible = false;
            picImage.Click += guna2PictureBox1_Click;
            // 
            // UC_ChatItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(panelBubble);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_ChatItem";
            Size = new Size(251, 97);
            panelBubble.ResumeLayout(false);
            panelBubble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelBubble;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMessage;
        private Label lblStatus;
        private Guna.UI2.WinForms.Guna2PictureBox picImage;
    }
}