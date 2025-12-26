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
        public event Action<AssignmentSubmitResult> OnSubmitSuccess;
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

        private async void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
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

            try
            {
                // Hiển thị dialog đang upload
                Cursor = Cursors.WaitCursor;

                // Upload file lên Cloudinary
                string fileUrl = await Task.Run(() =>
                    CloudinaryHelper.UploadFile(txtFilePath.Text)
                );

                Cursor = Cursors.Default;

                if (string.IsNullOrEmpty(fileUrl))
                {
                    Guna2MessageDialog failDialog = new Guna2MessageDialog
                    {
                        Caption = "Thất bại",
                        Text = "Không thể upload bài tập. Vui lòng thử lại.",
                        Icon = MessageDialogIcon.Error,
                        Buttons = MessageDialogButtons.OK,
                        Parent = this
                    };
                    failDialog.Show();
                    return;
                }

                // Thành công
                Guna2MessageDialog successDialog = new Guna2MessageDialog
                {
                    Caption = "Nộp bài thành công 🎉",
                    Text =
                        $"Lớp: {this.TenLopHoc}\n\n" +
                        $"Tệp: {Path.GetFileName(txtFilePath.Text)}\n\n" +
                        $"Link bài nộp:\n{fileUrl}",
                    Icon = MessageDialogIcon.Information,
                    Buttons = MessageDialogButtons.OK,
                    Parent = this
                };
                successDialog.Show();

                // TODO: Lưu fileUrl vào DB (Firebase / SQL) nếu cần

                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi nộp bài: " + ex.Message);
            }
        }

    }
}