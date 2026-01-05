namespace APP_DOAN
{
    partial class CourseDetailForm
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
            flpContent = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpContent
            // 
            flpContent.AutoScroll = true;
            flpContent.BackColor = Color.FromArgb(20, 20, 20);
            flpContent.Dock = DockStyle.Fill;
            flpContent.FlowDirection = FlowDirection.TopDown;
            flpContent.Location = new Point(0, 0);
            flpContent.Name = "flpContent";
            flpContent.Padding = new Padding(10);
            flpContent.Size = new Size(1182, 753);
            flpContent.TabIndex = 0;
            flpContent.WrapContents = false;
            flpContent.Paint += flpContent_Paint;
            // 
            // CourseDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1182, 753);
            Controls.Add(flpContent);
            Name = "CourseDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết khóa học";
            Load += CourseDetailForm_Load;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContent;
    }
}