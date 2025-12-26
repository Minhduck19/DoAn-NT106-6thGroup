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
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblMessage = new Label();
            panelBubble.SuspendLayout();
            SuspendLayout();
            // 
            // panelBubble
            // 
            panelBubble.BorderRadius = 15;
            panelBubble.Controls.Add(lblStatus);
            panelBubble.Controls.Add(lblMessage);
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            panelBubble.CustomizableEdges = customizableEdges1;
            panelBubble.FillColor = Color.FromArgb(33, 150, 243);
            panelBubble.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBubble.Location = new Point(3, 4);
            panelBubble.Margin = new Padding(3, 4, 3, 4);
            panelBubble.Name = "panelBubble";
            panelBubble.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelBubble.Size = new Size(315, 91);
            panelBubble.TabIndex = 0;
            panelBubble.Paint += panelBubble_Paint;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(252, 59);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(44, 22);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "label1";
            lblStatus.Click += lblStatus_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(10, 10);
            lblMessage.Margin = new Padding(3, 4, 3, 4);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(161, 30);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Nội dung tin nhắn";
            lblMessage.UseCompatibleTextRendering = true;
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
            Size = new Size(339, 99);
            Load += UC_ChatItem_Load;
            panelBubble.ResumeLayout(false);
            panelBubble.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelBubble;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Label lblMessage;
    }
}