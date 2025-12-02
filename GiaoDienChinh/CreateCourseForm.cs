using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class CreateCourseForm : Form
    {
        private readonly FirebaseClient firebaseClient;
        private readonly string currentUid;
        private readonly string currentDisplayName;

        public CreateCourseForm(FirebaseClient client, string uid, string displayName)
        {
            InitializeComponent();
            firebaseClient = client;
            currentUid = uid;
            currentDisplayName = displayName ?? "Giảng viên";
        }

        private void CreateCourseForm_Load(object sender, EventArgs e)
        {
            txtMaLop.Focus();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập mã lớp và tên lớp!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã lớp đã tồn tại chưa
            try
            {
                var exist = await firebaseClient
                    .Child("Courses")
                    .Child(maLop)
                    .OnceSingleAsync<object>();

                if (exist != null)
                {
                    MessageBox.Show("Mã lớp đã tồn tại! Hãy chọn mã khác.", "Trùng mã",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMaLop.SelectAll();
                    return;
                }
            }
            catch
            {
                // Không tồn tại hoặc lỗi mạng → vẫn tiếp tục
            }

            btnCreate.Enabled = false;
            btnCreate.Text = "Đang tạo...";

            try
            {
                var newCourse = new
                {
                    CourseName = tenLop,
                    TeacherId = currentUid,                    // QUAN TRỌNG NHẤT
                    TeacherName = currentDisplayName,
                    Description = string.IsNullOrWhiteSpace(moTa) ? "" : moTa,
                    CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                };

                await firebaseClient
                    .Child("Courses")
                    .Child(maLop)
                    .PutAsync(newCourse);

                MessageBox.Show($"Tạo lớp thành công!\nMã lớp: {maLop}\nTên lớp: {tenLop}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo lớp:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCreate.Enabled = true;
                btnCreate.Text = "Tạo lớp";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}