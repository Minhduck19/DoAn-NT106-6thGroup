using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System.IO; // Để dùng Path.GetFileName
using System.ComponentModel;

namespace APP_DOAN.GiaoDienChinh
{
    // Form logic
    public partial class Submit_Agsignment
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TenLopHoc { get; set; }

        public Submit_Agsignment(string tenLop = "Bài tập chung")
        {
            InitializeComponent();
            this.TenLopHoc = tenLop;

            // Cập nhật các control đã tạo trong Designer
            if (lblAssignmentName != null)
            {
                lblAssignmentName.Text = $"NỘP BÀI TẬP LỚP: {this.TenLopHoc.ToUpper()}";
            }
            // Gán giá trị cho thuộc tính Text được thừa kế từ Form
            this.Text = "Nộp Bài Tập: " + TenLopHoc;
        }


        

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn tệp bài tập để nộp";
                openFileDialog.Filter = "Tệp Bài Tập (*.doc;*.docx;*.pdf;*.zip;*.rar)|*.doc;*.docx;*.pdf;*.zip;*.rar|Tất cả tệp (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text) || txtFilePath.Text.Contains("chưa chọn tệp"))
            {
                Guna2MessageDialog errorDialog = new Guna2MessageDialog
                {
                    Caption = "Lỗi",
                    Text = "Vui lòng chọn một tệp bài tập hợp lệ trước khi nộp.",
                    Icon = MessageDialogIcon.Error,
                    Buttons = MessageDialogButtons.OK,
                    Parent = this
                };
                errorDialog.Show();
                return;
            }

            // Giả lập xử lý nộp bài
            Guna2MessageDialog successDialog = new Guna2MessageDialog
            {
                Caption = "Thành Công!",
                Text = $"Đã nộp tệp: \n{Path.GetFileName(txtFilePath.Text)}\n\n cho lớp {this.TenLopHoc}.",
                Icon = MessageDialogIcon.Information,
                Buttons = MessageDialogButtons.OK,
                Parent = this
            };
            successDialog.Show();

            this.Close();
        }
    }
}