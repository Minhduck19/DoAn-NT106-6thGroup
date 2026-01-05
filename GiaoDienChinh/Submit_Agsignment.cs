using Firebase.Database;
using Firebase.Database.Query;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Guna.UI2.WinForms.Suite;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Submit_Agsignment : Form
    {
        private const long MAX_FILE_SIZE = 10 * 1024 * 1024; // 10 MB

        public event Action OnSubmitSuccess;

        private readonly FirebaseClient _client;
        private readonly string _courseId;
        private readonly string _assignmentId;
        private readonly string _studentUid;
        private string title;
        private string studentId;

        // Sửa Constructor chính để nhận thêm tham số dueDate
        public Submit_Agsignment(
            string assignmentTitle,
            string assignmentDescription,
            string assignmentDueDate, // Thêm tham số này
            string assignmentId,
            FirebaseClient client,
            string courseId,
            string studentUid)
        {
            InitializeComponent();

            lblAssignmentName.Text = "Nộp bài tập: " + assignmentTitle.ToUpper();

            _assignmentId = assignmentId;
            _client = client;
            _courseId = courseId;
            _studentUid = studentUid;

            txtTitle.Text = assignmentTitle;
            txtDesc.Text = assignmentDescription;

            // Gán dữ liệu vào Label hạn nộp
            lbDl.Text = "Hạn nộp: " + assignmentDueDate;
        }
        public Submit_Agsignment(string title, string assignmentId, FirebaseClient client, string courseId, string studentId)
        {
            this.title = title;
            _assignmentId = assignmentId;
            _client = client;
            _courseId = courseId;
            this.studentId = studentId;
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
                FileInfo fileInfo = new FileInfo(dlg.FileName);

                if (fileInfo.Length > MAX_FILE_SIZE)
                {
                    new Guna2MessageDialog
                    {
                        Caption = "File quá lớn",
                        Text = "Dung lượng file không được vượt quá 10 MB",
                        Icon = MessageDialogIcon.Warning,
                        Buttons = MessageDialogButtons.OK,
                        Parent = this
                    }.Show();
                    return;
                }

                txtFilePath.Text = dlg.FileName;
                string ext = Path.GetExtension(txtFilePath.Text).ToLower();
                string[] allowed = { ".pdf", ".docx", ".zip" };
                if (!allowed.Contains(ext))
                {
                    MessageBox.Show("Chỉ cho phép file PDF, DOCX hoặc ZIP");
                    return;
                }
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
                string ext = Path.GetExtension(txtFilePath.Text).ToLower();
                string[] allowed = { ".pdf", ".docx", ".zip" };
                if (!allowed.Contains(ext))
                {
                    MessageBox.Show("Chỉ cho phép file PDF, DOCX hoặc ZIP");
                    return;
                }
                FileInfo fileInfo = new FileInfo(txtFilePath.Text);

                if (fileInfo.Length > MAX_FILE_SIZE)
                {
                    new Guna2MessageDialog
                    {
                        Caption = "File quá lớn",
                        Text = "Dung lượng file vượt quá 10 MB. Vui lòng chọn file khác.",
                        Icon = MessageDialogIcon.Error,
                        Buttons = MessageDialogButtons.OK,
                        Parent = this
                    }.Show();
                    return;
                }


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

        private void lblAssignmentName_Click(object sender, EventArgs e)
        {

        }
    }
}
