using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Windows.Forms;
namespace APP_DOAN.GiaoDienChinh
{
    public partial class CreateAssignment : Form
    {
        private readonly FirebaseClient _client;
        private readonly string _courseId;
        private string _fileUrl;
        public CreateAssignment(string courseId, FirebaseClient client)
        {
            InitializeComponent();
            _client = client;
            _courseId = courseId;
        }

        public CreateAssignment(FirebaseClient client, string courseId)
        {
            _client = client;
            _courseId = courseId;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                _fileUrl = CloudinaryHelper.UploadFile(dlg.FileName);
                Cursor.Current = Cursors.Default;

                if (_fileUrl != null)
                {
                    lblFile.Text = "✔ Đã upload file";
                    lblFile.ForeColor = System.Drawing.Color.LimeGreen;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!");
                return;
            }

            var assignment = new AssignmentModel
            {
                Title = txtTitle.Text.Trim(),
                Description = txtDesc.Text.Trim(),
                DueDate = dtpDue.Value.ToString("dd/MM/yyyy"),
                FileUrl = _fileUrl,
                CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            try
            {
                await _client
                    .Child("Assignments")
                    .Child(_courseId)
                    .PostAsync(assignment);

                MessageBox.Show("🎉 Đăng bài tập thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi Firebase:\n" + ex.Message);
            }


            MessageBox.Show("🎉 Đăng bài tập thành công!");
            this.Close();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
