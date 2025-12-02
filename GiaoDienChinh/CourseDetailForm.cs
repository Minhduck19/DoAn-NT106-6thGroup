using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class CourseDetailForm : Form
    {
        private readonly string _courseId;
        private readonly string _courseName;
        private readonly string _idToken;
        private readonly string _teacherEmail;

        private readonly string firebaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;

        public CourseDetailForm(string courseId, string courseName, string token, string email)
        {
            InitializeComponent();

            _courseId = courseId;
            _courseName = courseName;
            _idToken = token;
            _teacherEmail = email;

            firebaseClient = new FirebaseClient(
                 firebaseUrl,
                 new FirebaseOptions
                 {
                     AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
                 });
        }

        private void CourseDetailForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"{_courseId} - {_courseName}";
            SetupListViews();

            _ = LoadStudents();
            _ = LoadJoinRequests();
        }

        private void SetupListViews()
        {
            lvStudents.Columns.Add("UID", 150);
            lvStudents.Columns.Add("Tên Sinh Viên", 200);

            lvRequests.Columns.Add("UID", 150);
            lvRequests.Columns.Add("Tên Sinh Viên", 200);
            lvRequests.Columns.Add("Trạng thái", 100);
        }

        private async Task LoadStudents()
        {
            lvStudents.Items.Clear();

            try
            {
                var students = await firebaseClient
                    .Child("Courses")
                    .Child(_courseId)
                    .Child("Students")
                    .OnceAsync<bool>();

                foreach (var student in students)
                {
                    var item = new ListViewItem(student.Key);
                    item.SubItems.Add("Tên SV chưa hỗ trợ");
                    item.Tag = student.Key;
                    lvStudents.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message);
            }
        }

        private async Task LoadJoinRequests()
        {
            lvRequests.Items.Clear();

            try
            {
                var requests = await firebaseClient
                    .Child("JoinRequests")
                    .Child(_courseId)
                    .OnceAsync<JoinRequest>();

                foreach (var req in requests)
                {
                    var item = new ListViewItem(req.Key);
                    item.SubItems.Add(req.Object.StudentName);
                    item.SubItems.Add(req.Object.Status);
                    item.Tag = req.Key;
                    lvRequests.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải yêu cầu: " + ex.Message);
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvRequests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn yêu cầu cần duyệt!");
                return;
            }

            string studentUid = lvRequests.SelectedItems[0].Tag.ToString();

            await firebaseClient
                .Child("Courses")
                .Child(_courseId)
                .Child("Students")
                .Child(studentUid)
                .PutAsync(true);

            await firebaseClient
                .Child("JoinRequests")
                .Child(_courseId)
                .Child(studentUid)
                .Child("Status")
                .PutAsync("approved");

            MessageBox.Show("Đã duyệt sinh viên!");
            await LoadStudents();
            await LoadJoinRequests();
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (lvRequests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn yêu cầu cần từ chối!");
                return;
            }

            string studentUid = lvRequests.SelectedItems[0].Tag.ToString();

            await firebaseClient
                .Child("JoinRequests")
                .Child(_courseId)
                .Child(studentUid)
                .Child("Status")
                .PutAsync("denied");

            MessageBox.Show("Đã từ chối yêu cầu!");
            await LoadJoinRequests();
        }

        private async void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (lvStudents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn sinh viên cần xóa!");
                return;
            }

            string studentUid = lvStudents.SelectedItems[0].Tag.ToString();

            await firebaseClient
                .Child("Courses")
                .Child(_courseId)
                .Child("Students")
                .Child(studentUid)
                .DeleteAsync();

            MessageBox.Show("Đã xóa sinh viên khỏi lớp!");
            await LoadStudents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJoinRequests();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
