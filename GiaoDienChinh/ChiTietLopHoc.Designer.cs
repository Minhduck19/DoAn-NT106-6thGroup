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
            lblCourseName = new Label();
            lblInstructor = new Label();
            lblCourseId = new Label();
            SuspendLayout();
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Location = new Point(90, 102);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(94, 20);
            lblCourseName.TabIndex = 0;
            lblCourseName.Text = "CourseName";
            // 
            // lblInstructor
            // 
            lblInstructor.AutoSize = true;
            lblInstructor.Location = new Point(90, 201);
            lblInstructor.Name = "lblInstructor";
            lblInstructor.Size = new Size(71, 20);
            lblInstructor.TabIndex = 1;
            lblInstructor.Text = "Instructor";
            // 
            // lblCourseId
            // 
            lblCourseId.AutoSize = true;
            lblCourseId.Location = new Point(90, 305);
            lblCourseId.Name = "lblCourseId";
            lblCourseId.Size = new Size(67, 20);
            lblCourseId.TabIndex = 2;
            lblCourseId.Text = "CourseId";
            // 
            // ChiTietLopHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCourseId);
            Controls.Add(lblInstructor);
            Controls.Add(lblCourseName);
            Name = "ChiTietLopHoc";
            Text = "ChiTietLopHoc";
            Load += ChiTietLopHoc_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCourseName;
        private Label lblInstructor;
        private Label lblCourseId;
    }
}