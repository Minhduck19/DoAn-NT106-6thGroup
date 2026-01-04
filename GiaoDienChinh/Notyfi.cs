using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Notyfi : Form
    {
        private readonly FirebaseClient _client;
        private readonly string _courseId;
        private string _fileUrl;

        public Notyfi(string courseId, FirebaseClient client)
        {
            InitializeComponent();

            _client = client;
            _courseId = courseId;

            // ✅ Gán text đúng cách
            ThongBao.Text = "Thêm Thông Báo";
            dtpDue.Value = DateTime.Today;
        }

        // ❗ Constructor phụ PHẢI gọi InitializeComponent
        public Notyfi(FirebaseClient client, string courseId)
        {
            InitializeComponent();

            _client = client;
            _courseId = courseId;
        }

        // 📎 Chọn & upload file
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                _fileUrl = CloudinaryHelper.UploadFile(dlg.FileName);
                Cursor.Current = Cursors.Default;

                if (!string.IsNullOrEmpty(_fileUrl))
                {
                    lblFile.Text = "✔ Đã upload file";
                    lblFile.ForeColor = System.Drawing.Color.LimeGreen;
                }
            }
        }

        // 💾 Lưu thông báo
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề thông báo!");
                return;
            }

            if (_client == null)
            {
                MessageBox.Show("FirebaseClient bị null!");
                return;
            }

            if (string.IsNullOrWhiteSpace(_courseId))
            {
                MessageBox.Show("CourseId không hợp lệ!");
                return;
            }

            var notify = new NotificationModel
            {
                Title = txtTitle.Text.Trim(),
                Content = txtDesc.Text.Trim(),
                DueDate = dtpDue.Value.ToString("dd/MM/yyyy"),
                FileUrl = _fileUrl,
                CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            try
            {
                await _client
                    .Child("Notifications")
                    .Child(_courseId)
                    .PostAsync(notify);

                MessageBox.Show("🔔 Đăng thông báo thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi Firebase:\n" + ex.Message);
            }
        }

        private void dtpDue_ValueChanged(object sender, EventArgs e) { }
        private void txtTitle_TextChanged(object sender, EventArgs e) { }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
