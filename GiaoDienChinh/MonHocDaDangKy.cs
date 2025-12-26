using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class MonHocDaDangKy : Form
    {
        private readonly string _studentUid;
        private readonly string _idToken;
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;

        public MonHocDaDangKy(string studentUid, string idToken)
        {
            InitializeComponent();
            _studentUid = studentUid;
            _idToken = idToken;

            // Khởi tạo Firebase Client
            firebaseClient = new FirebaseClient(
                firebaseDatabaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
                });
        }

        private void DangKyMonHoc_Load(object sender, EventArgs e)
        {
            SetupListView();
            _ = LoadCourses();
        }

        private void SetupListView()
        {
            lvCourses.View = View.Details;
            lvCourses.FullRowSelect = true;
            lvCourses.GridLines = true;
            lvCourses.Columns.Clear();

            // Khởi tạo các cột với độ rộng mặc định
            lvCourses.Columns.Add("Mã Môn", 100, HorizontalAlignment.Left);
            lvCourses.Columns.Add("Tên Môn Học", 300, HorizontalAlignment.Left);
            lvCourses.Columns.Add("Giảng Viên", 200, HorizontalAlignment.Left);
        }

        private async Task LoadCourses()
        {
            try
            {
                lvCourses.Items.Clear();

                // 1. Chỉ lấy những ID lớp học mà sinh viên này THỰC SỰ tham gia
                // Chúng ta sẽ truy cập thẳng vào node của sinh viên đó
                var joinedCourses = await firebaseClient
                    .Child("CourseStudents")
                    .OnceAsync<object>();

                foreach (var courseNode in joinedCourses)
                {
                    // Kiểm tra xem trong lớp này có UID của sinh viên hiện tại không
                    var studentInCourse = await firebaseClient
                        .Child("CourseStudents")
                        .Child(courseNode.Key) // courseNode.Key là ID lớp
                        .Child(_studentUid)
                        .OnceSingleAsync<object>(); // Dùng object để tránh lỗi ép kiểu bool null

                    if (studentInCourse != null)
                    {
                        // 2. Nếu tìm thấy sinh viên, mới đi lấy thông tin chi tiết môn học từ node "Courses"
                        var courseDetail = await firebaseClient
                            .Child("Courses")
                            .Child(courseNode.Key)
                            .OnceSingleAsync<CourseModel>();

                        if (courseDetail != null)
                        {
                            string displayId = !string.IsNullOrEmpty(courseDetail.MaLop) ? courseDetail.MaLop : courseNode.Key;
                            ListViewItem item = new ListViewItem(displayId);
                            item.SubItems.Add(courseDetail.TenLop ?? "Không có tên");
                            item.SubItems.Add(courseDetail.InstructorName ?? "Chưa rõ");
                            item.Tag = courseNode.Key;
                            lvCourses.Items.Add(item);
                        }
                    }
                }

                if (lvCourses.Items.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có môn học nào được duyệt!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Logic gửi yêu cầu tham gia lớp mới (nếu cần dùng) ---
        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp trong danh sách!", "Thông báo");
                return;
            }

            string courseKey = lvCourses.SelectedItems[0].Tag.ToString();

            try
            {
                // Kiểm tra yêu cầu trùng lặp
                var request = await firebaseClient
                    .Child("JoinRequests")
                    .Child(courseKey)
                    .Child(_studentUid)
                    .OnceSingleAsync<JoinRequest>();

                if (request != null && request.Status == "pending")
                {
                    MessageBox.Show("Yêu cầu của bạn đang chờ giảng viên xét duyệt!", "Thông báo");
                    return;
                }

                await firebaseClient
                    .Child("JoinRequests")
                    .Child(courseKey)
                    .Child(_studentUid)
                    .PutAsync(new JoinRequest
                    {
                        HoTen = "Học viên", // Có thể lấy tên từ Profile nếu có
                        Status = "pending"
                    });

                MessageBox.Show("Gửi yêu cầu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    // Model đồng bộ với cấu trúc Firebase của bạn
    public class CourseModel
    {
        public string TenLop { get; set; }// Tên môn học
        public string InstructorName { get; set; } // Tên giảng viên
        public string MaLop { get; set; }          // Mã lớp (tùy chọn)
        public List<string> Students { get; set; } = new List<string>(); // Danh sách UID sinh viên
    }

    public class JoinRequest
    {
        public string HoTen { get; set; } // Đổi từ StudentName thành HoTen
        public string Status { get; set; }
    }
}