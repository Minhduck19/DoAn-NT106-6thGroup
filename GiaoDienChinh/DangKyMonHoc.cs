using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class DangKyMonHoc : Form
    {
        private readonly string _studentUid;
        private readonly string _idToken;

        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;

        public DangKyMonHoc(string studentUid, string idToken)
        {
            InitializeComponent();
            _studentUid = studentUid;
            _idToken = idToken;

            // Khởi tạo Firebase Client kèm token
            firebaseClient = new FirebaseClient(
                firebaseDatabaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
                });

            _ = LoadCourses(); // load ngay khi mở form
        }

        public DangKyMonHoc()
        {
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        private async Task LoadCourses()
        {
            try
            {
                lvCourses.Items.Clear();

                var courseData = await firebaseClient
                    .Child("Courses")
                    .OnceAsync<CourseModel>();

                foreach (var c in courseData)
                {
                    var item = new ListViewItem(c.Key); // Mã lớp
                    item.SubItems.Add(c.Object.Name); // Tên lớp
                    item.SubItems.Add(c.Object.InstructorName); // Giảng viên
                    lvCourses.Items.Add(item);
                }

                if (lvCourses.Items.Count == 0)
                {
                    MessageBox.Show("Chưa có lớp học nào!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Thông báo");
                return;
            }

            string courseId = lvCourses.SelectedItems[0].SubItems[0].Text;

            try
            {
                // Kiểm tra sinh viên đã trong lớp chưa
                var course = await firebaseClient
                    .Child("Courses")
                    .Child(courseId)
                    .Child("Students")
                    .Child(_studentUid)
                    .OnceSingleAsync<bool>();

                if (course == true)
                {
                    MessageBox.Show("Bạn đã ở trong lớp này rồi!", "Thông báo");
                    return;
                }

                // Kiểm tra đã gửi request trước đó chưa
                var request = await firebaseClient
                    .Child("JoinRequests")
                    .Child(courseId)
                    .Child(_studentUid)
                    .OnceSingleAsync<JoinRequest>();

                if (request != null && request.Status == "pending")
                {
                    MessageBox.Show("Bạn đã gửi yêu cầu trước đó và đang chờ xét duyệt!", "Thông báo");
                    return;
                }

                // Lưu request
                await firebaseClient
                    .Child("JoinRequests")
                    .Child(courseId)
                    .Child(_studentUid)
                    .PutAsync(new JoinRequest
                    {
                        StudentName = lvCourses.SelectedItems[0].SubItems[1].Text,
                        Status = "pending"
                    });

                MessageBox.Show("Đã gửi yêu cầu tham gia lớp! Vui lòng chờ giảng viên duyệt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        //Giao Diện khi Load Form
        private void DangKyMonHoc_Load(object sender, EventArgs e)
        {
            lvCourses.View = View.Details;
            lvCourses.FullRowSelect = true;
            lvCourses.UseCompatibleStateImageBehavior = false;
            lvCourses.GridLines = true;

            colCourseId.Text = "Mã Môn";
            colCourseName.Text = "Tên Môn Học";
            colInstructor.Text = "Giảng Viên";

            lvCourses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class CourseModel
    {
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public string InstructorName { get; set; }
    }

    public class JoinRequest
    {
        public string StudentName { get; set; }
        public string Status { get; set; } // pending, approved, denied
    }
}
