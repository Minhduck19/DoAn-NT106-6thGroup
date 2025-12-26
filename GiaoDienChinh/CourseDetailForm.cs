using Firebase.Database;
using Firebase.Database.Query;
using System;
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

        private async void CourseDetailForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"{_courseId} - {_courseName}";
            SetupListViews();

            await LoadStudents();
            await LoadJoinRequests();
        }

        private void SetupListViews()
        {
            // ===== SINH VIÊN ĐÃ DUYỆT =====
            lvStudents.Clear();
            lvStudents.View = View.Details;
            lvStudents.FullRowSelect = true;
            lvStudents.GridLines = true;

            lvStudents.Columns.Add("Mã SV", 150);
            lvStudents.Columns.Add("Họ tên", 250);

            // ===== YÊU CẦU CHỜ DUYỆT =====
            lvRequests.Clear();
            lvRequests.View = View.Details;
            lvRequests.FullRowSelect = true;
            lvRequests.GridLines = true;

            lvRequests.Columns.Add("Mã SV", 150);
            lvRequests.Columns.Add("Họ tên", 250);
            lvRequests.Columns.Add("Trạng thái", 120);
        }


        private async Task LoadStudents()
        {
            lvStudents.Items.Clear();

            try
            {
                var students = await firebaseClient
                    .Child("CourseStudents")
                    .Child(_courseId)
                    .OnceAsync<bool>();

                foreach (var student in students)
                {
                    var user = await firebaseClient
                        .Child("Users")
                        .Child(student.Key)
                        .OnceSingleAsync<User>();

                    var item = new ListViewItem(student.Key);
                    item.SubItems.Add(user?.HoTen ?? "Không rõ");

                    item.Tag = student.Key;
                    lvStudents.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sinh viên: " + ex.Message);
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
                    // ✅ PHÒNG LỖI NULL
                    if (req.Object == null || req.Object.Status != "pending")
                        continue;

                    var user = await firebaseClient
                        .Child("Users")
                        .Child(req.Key)
                        .OnceSingleAsync<User>();

                    var item = new ListViewItem(req.Key);
                    item.SubItems.Add(user?.HoTen ?? "Không rõ");
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
                MessageBox.Show("Chọn sinh viên cần duyệt!");
                return;
            }

            string studentUid = lvRequests.SelectedItems[0].Tag.ToString();

            try
            {
                await firebaseClient
                    .Child("CourseStudents")
                    .Child(_courseId)
                    .Child(studentUid)
                    .PutAsync(true);

                await firebaseClient
                    .Child("JoinRequests")
                    .Child(_courseId)
                    .Child(studentUid)
                    .DeleteAsync();

                MessageBox.Show("Đã duyệt sinh viên!");

                await LoadStudents();
                await LoadJoinRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
            if (lvStudents.SelectedItems.Count == 0) return;

            string studentUid = lvStudents.SelectedItems[0].Tag.ToString();

            await firebaseClient
                .Child("CourseStudents")
                .Child(_courseId)
                .Child(studentUid)
                .DeleteAsync();

            MessageBox.Show("Đã xóa sinh viên khỏi lớp!");
            await LoadStudents();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadJoinRequests();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewAssignments_Click(object sender, EventArgs e)
        {

        }



        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnViewAssignments_Click_1(object sender, EventArgs e)
        {
            Assignment frm = new Assignment(_courseId);
            frm.ShowDialog();
        }

        private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
