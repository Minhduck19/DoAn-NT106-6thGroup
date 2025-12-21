namespace APP_DOAN.GiaoDienChinh
{
    partial class ChiTietLopHoc
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            btnAgree = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 36);
            label1.Name = "label1";
            label1.Size = new Size(510, 69);
            label1.TabIndex = 0;
            label1.Text = "Bạn chắc chắn đăng ký lớp học này!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAgree
            // 
            btnAgree.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgree.BackColor = Color.Transparent;
            btnAgree.BorderRadius = 15;
            btnAgree.CustomizableEdges = customizableEdges1;
            btnAgree.FillColor = Color.DeepSkyBlue;
            btnAgree.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAgree.ForeColor = Color.Black;
            btnAgree.Location = new Point(79, 108);
            btnAgree.Name = "btnAgree";
            btnAgree.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgree.Size = new Size(200, 45);
            btnAgree.TabIndex = 3;
            btnAgree.Text = "Đăng ký";
            btnAgree.Click += btnAgree_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 15;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.FillColor = Color.FromArgb(255, 128, 0);
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(333, 108);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(200, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // ChiTietLopHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(613, 193);
            Controls.Add(btnCancel);
            Controls.Add(btnAgree);
            Controls.Add(label1);
            Name = "ChiTietLopHoc";
            Text = "Đăng ký lớp học";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAgree;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}