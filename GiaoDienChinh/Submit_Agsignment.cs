using Firebase.Database;
using Firebase.Database.Query;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO; // Để dùng Path.GetFileName
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    

    // Form logic
    public partial class Submit_Agsignment : Form
    {
        public event Action<AssignmentSubmitResult> OnSubmitSuccess;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TenLopHoc { get; set; }

        private readonly FirebaseClient firebaseClient;

        private readonly string courseId;
        private readonly string studentUid;

        public Submit_Agsignment(
     string tenLop,
     FirebaseClient firebaseClient,
     string courseId,
     string studentUid)
        {
            InitializeComponent();

            TenLopHoc = tenLop;
            this.firebaseClient = firebaseClient;
            this.courseId = courseId;
            this.studentUid = studentUid;

            lblAssignmentName.Text = $"NỘP BÀI TẬP LỚP: {tenLop.ToUpper()}";
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

                //Kiểm tra kích thước tệp
                const long MAX_FILE_SIZE = 50 * 1024 * 1024; // 50MB
                FileInfo fileInfo = new FileInfo(txtFilePath.Text);

                if (fileInfo.Length > MAX_FILE_SIZE)
                {
                    Guna2MessageDialog sizeDialog = new Guna2MessageDialog
                    {
                        Caption = "Tệp quá lớn",
                        Text = "Dung lượng tệp vượt quá 50MB.\nVui lòng chọn tệp nhỏ hơn.",
                        Icon = MessageDialogIcon.Warning,
                        Buttons = MessageDialogButtons.OK,
                        Parent = this
                    };
                    sizeDialog.Show();
                    return;
                }

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


                await firebaseClient
                 .Child("Assignments")
                 .Child(courseId)          // ID môn học
                 .Child(studentUid)        // UID sinh viên
                 .PutAsync(new
                 {
                       TenFile = Path.GetFileName(txtFilePath.Text),
                       FileUrl = fileUrl,
                       ThoiGianNop = DateTime.Now
                 });


                OnSubmitSuccess?.Invoke(new AssignmentSubmitResult
                {
                    TenLop = this.TenLopHoc,
                    TenFile = Path.GetFileName(txtFilePath.Text),
                    FileUrl = fileUrl,
                    ThoiGianNop = DateTime.Now
                });

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