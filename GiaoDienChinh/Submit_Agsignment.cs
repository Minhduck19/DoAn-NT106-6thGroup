using Firebase.Database;
using Firebase.Database.Query;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Submit_Agsignment : Form
    {
        public event Action OnSubmitSuccess;

        private readonly FirebaseClient _client;
        private readonly string _courseId;
        private readonly string _assignmentId;
        private readonly string _studentUid;

        public Submit_Agsignment(
            string assignmentTitle,
            string assignmentId,
            FirebaseClient client,
            string courseId,
            string studentUid)
        {
            InitializeComponent();

            lblAssignmentName.Text = assignmentTitle.ToUpper();

            _assignmentId = assignmentId;
            _client = client;
            _courseId = courseId;
            _studentUid = studentUid;
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog
            {
                Title = "Chọn file bài tập",
                Filter = "All files|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dlg.FileName;
            }
        }

        private async void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (!File.Exists(txtFilePath.Text))
            {
                new Guna2MessageDialog
                {
                    Caption = "Lỗi",
                    Text = "Vui lòng chọn file hợp lệ",
                    Icon = MessageDialogIcon.Error,
                    Buttons = MessageDialogButtons.OK,
                    Parent = this
                }.Show();
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                string fileUrl = await Task.Run(() =>
                    CloudinaryHelper.UploadFile(txtFilePath.Text)
                );

                Cursor = Cursors.Default;

                if (string.IsNullOrEmpty(fileUrl))
                    throw new Exception("Upload thất bại");

                // ✅ GHI ĐÚNG FIREBASE PATH
                await _client
                    .Child("Assignments")
                    .Child(_courseId)
                    .Child(_assignmentId)
                    .Child("Submissions")
                    .Child(_studentUid)
                    .PutAsync(new
                    {
                        TenFile = Path.GetFileName(txtFilePath.Text),
                        FileUrl = fileUrl,
                        ThoiGianNop = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                    });

                new Guna2MessageDialog
                {
                    Caption = "🎉 Thành công",
                    Text = "Nộp bài thành công!",
                    Icon = MessageDialogIcon.Information,
                    Buttons = MessageDialogButtons.OK,
                    Parent = this
                }.Show();

                OnSubmitSuccess?.Invoke();
                Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi nộp bài:\n" + ex.Message);
            }
        }
    }
}
