using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var students = await firebaseClient.Child("CourseStudents").Child(_courseId).OnceAsync<object>();

            foreach (var student in students)
            {
                // Tải thông tin từ node Users bằng class User của bạn
                var userNode = await firebaseClient
                    .Child("Users")
                    .Child(student.Key)
                    .OnceSingleAsync<User>();

                var item = new ListViewItem(student.Key);
                // Lấy trực tiếp .HoTen từ class User
                item.SubItems.Add(userNode?.HoTen ?? "Không rõ");
                item.Tag = student.Key;
                lvStudents.Items.Add(item);
            }
        }

        private async Task LoadJoinRequests()
        {
            lvRequests.Items.Clear();
            var requests = await firebaseClient.Child("JoinRequests").Child(_courseId).OnceAsync<JoinRequest>();

            foreach (var req in requests)
            {
                if (req.Object != null && req.Object.Status == "pending")
                {
                    var item = new ListViewItem(req.Key);
                    // Sửa từ StudentName thành HoTen theo class JoinRequest mới
                    item.SubItems.Add(req.Object.HoTen ?? "N/A");
                    item.SubItems.Add("Đang chờ");
                    item.Tag = req.Key;
                    lvRequests.Items.Add(item);
                }
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvRequests.SelectedItems.Count == 0) return;

            string studentUid = lvRequests.SelectedItems[0].Tag.ToString();
            string studentName = lvRequests.SelectedItems[0].SubItems[1].Text;

            try
            {
                // 1. Thêm vào node chính thức của lớp
                await firebaseClient
                    .Child("CourseStudents")
                    .Child(_courseId)
                    .Child(studentUid)
                    .PutAsync(true);

                // 2. Cập nhật trạng thái thành "approved" để không hiện ở mục chờ nữa
                await firebaseClient
                    .Child("JoinRequests")
                    .Child(_courseId)
                    .Child(studentUid)
                    .PutAsync(new JoinRequest
                    {
                        HoTen = studentName,
                        Status = "approved"
                    });

                MessageBox.Show($"Đã duyệt sinh viên {studentName} vào lớp!");

                // 3. Làm mới dữ liệu: SV sẽ biến mất ở lvRequests và hiện ở lvStudents
                await LoadJoinRequests();
                await LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi duyệt: " + ex.Message);
            }
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (lvRequests.SelectedItems.Count == 0) return;

            string studentUid = lvRequests.SelectedItems[0].Tag.ToString();
            string studentName = lvRequests.SelectedItems[0].SubItems[1].Text;

            try
            {
                await firebaseClient
                    .Child("JoinRequests")
                    .Child(_courseId)
                    .Child(studentUid)
                    .PutAsync(new JoinRequest
                    {
                        HoTen = studentName,
                        Status = "denied"
                    });

                MessageBox.Show("Đã từ chối yêu cầu.");
                await LoadJoinRequests(); // Tự động xóa khỏi ListView vì status không còn là pending
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (lvStudents.SelectedItems.Count == 0) return;

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này khỏi lớp?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string studentUid = lvStudents.SelectedItems[0].Tag.ToString();

            try
            {
                await firebaseClient
                    .Child("CourseStudents")
                    .Child(_courseId)
                    .Child(studentUid)
                    .DeleteAsync();

                MessageBox.Show("Đã xóa sinh viên khỏi lớp!");
                await LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        public class UserInfo
        {
            public string displayName { get; set; }
            public string Role { get; set; }
        }

        public class JoinRequest
        {
            public string HoTen { get; set; } // Đổi từ StudentName thành HoTen
            public string Status { get; set; }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJoinRequests();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
