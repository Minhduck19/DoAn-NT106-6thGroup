using System.Drawing; // Cần thêm using này để sử dụng Font, Point, SizeF, Color...
using System.Windows.Forms; // Cần thêm using này để sử dụng AutoScaleMode
using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Drawing; // Dùng cho SizeF và Color
using System.Windows.Forms; // Dùng cho Form, AutoScaleMode, Controls, MaximizeBox, v.v.
//...

namespace APP_DOAN.GiaoDienChinh
{
    // Giả sử Submit_AgsignmentBase là lớp cơ sở tùy chỉnh của bạn
    // Nếu lớp cơ sở của bạn là System.Windows.Forms.Form, bạn nên sửa lại là : Form
    public partial class Submit_Agsignment : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Controls Guna.UI2
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAssignmentName;
        private Guna.UI2.WinForms.Guna2TextBox txtFilePath;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblAssignmentName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtFilePath = new Guna.UI2.WinForms.Guna2TextBox();
            btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            // 
            // lblAssignmentName
            // 
            lblAssignmentName.BackColor = Color.Transparent;
            lblAssignmentName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAssignmentName.ForeColor = Color.FromArgb(25, 118, 210);
            lblAssignmentName.Location = new Point(30, 30);
            lblAssignmentName.Name = "lblAssignmentName";
            lblAssignmentName.Size = new Size(466, 43);
            lblAssignmentName.TabIndex = 3;
            lblAssignmentName.Text = "NỘP BÀI TẬP LỚP: TÊN LỚP HỌC";
            // 
            // txtFilePath
            // 
            txtFilePath.BorderRadius = 10;
            txtFilePath.CustomizableEdges = customizableEdges1;
            txtFilePath.DefaultText = "";
            txtFilePath.FillColor = Color.FromArgb(240, 240, 240);
            txtFilePath.Font = new Font("Segoe UI", 9F);
            txtFilePath.ForeColor = Color.Black;
            txtFilePath.Location = new Point(30, 100);
            txtFilePath.Margin = new Padding(3, 4, 3, 4);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Đường dẫn tệp bài tập (chưa chọn tệp)";
            txtFilePath.ReadOnly = true;
            txtFilePath.SelectedText = "";
            txtFilePath.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtFilePath.Size = new Size(400, 40);
            txtFilePath.TabIndex = 2;
            txtFilePath.TextOffset = new Point(10, 0);
            // 
            // btnBrowse
            // 
            btnBrowse.BorderRadius = 10;
            btnBrowse.CustomizableEdges = customizableEdges3;
            btnBrowse.FillColor = Color.FromArgb(66, 165, 245);
            btnBrowse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(450, 100);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnBrowse.Size = new Size(120, 40);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "CHỌN TỆP";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.BorderRadius = 15;
            btnSubmit.CustomizableEdges = customizableEdges5;
            btnSubmit.FillColor = Color.FromArgb(25, 118, 210);
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(30, 220);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSubmit.ShadowDecoration.Enabled = true;
            btnSubmit.Size = new Size(250, 50);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "HOÀN TẤT VÀ NỘP BÀI";
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.ContainerControl = this;
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // Submit_Agsignment
            // 
            // ... (Các đoạn code khai báo control và thiết lập CustomizableEdges)

            // KẾT THÚC CỦA guna2DragControl1
            // 
            // Submit_Agsignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F); // THÊM "this."
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;  // THÊM "this."
            this.BackColor = System.Drawing.Color.White;                   // THÊM "this."
            this.ClientSize = new System.Drawing.Size(600, 350);           // THÊM "this."
            this.Controls.Add(this.btnSubmit);                             // THÊM "this."
            this.Controls.Add(this.btnBrowse);                             // THÊM "this."
            this.Controls.Add(this.txtFilePath);                           // THÊM "this."
            this.Controls.Add(this.lblAssignmentName);                     // THÊM "this."
            this.MaximizeBox = false;                                      // THÊM "this."
            this.MinimizeBox = false;                                      // THÊM "this."
            this.Name = "Submit_Agsignment";                               // THÊM "this."
            this.StartPosition = FormStartPosition.CenterScreen;                         // THÊM "this."
            this.ResumeLayout(false);                                     // THÊM "this."
            this.PerformLayout();                                          // THÊM "this."

            // ... (Các đoạn code khác)
        }

        #endregion
    }
}