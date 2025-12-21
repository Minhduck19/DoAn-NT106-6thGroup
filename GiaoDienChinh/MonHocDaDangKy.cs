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

                // Lấy toàn bộ danh sách khóa học
                var courseData = await firebaseClient
                    .Child("Courses")
                    .OnceAsync<CourseModel>();

                bool hasJoinedAny = false;

                foreach (var c in courseData)
                {
                    var course = c.Object;

                    if (course.Students != null && course.Students.Contains(_studentUid))
                    {
                        string displayId = !string.IsNullOrEmpty(course.MaLop) ? course.MaLop : c.Key;

                        ListViewItem item = new ListViewItem(displayId);

                        // THAY ĐỔI TẠI ĐÂY: Ưu tiên lấy TenLop, nếu null thì lấy Name
                        string tenHienThi = course.TenLop ??  "Không có tên";
                        item.SubItems.Add(tenHienThi);

                        item.SubItems.Add(course.InstructorName ?? "Chưa rõ");
                        item.Tag = c.Key;
                        lvCourses.Items.Add(item);
                        hasJoinedAny = true;
                    }
                }

                // Tự động căn chỉnh độ rộng cột theo nội dung sau khi thêm dữ liệu
                if (lvCourses.Items.Count > 0)
                {
                    // Giãn các cột theo nội dung dài nhất bên trong
                    lvCourses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                    // Riêng cột Tên Môn Học nếu quá ngắn thì tối thiểu là 250
                    if (lvCourses.Columns[1].Width < 250) lvCourses.Columns[1].Width = 250;
                }
                else
                {
                    // Nếu không có dữ liệu, giãn theo tiêu đề
                    lvCourses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    MessageBox.Show("Bạn chưa tham gia môn học nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        StudentName = "Học viên", // Có thể lấy tên từ Profile nếu có
                        Status = "pending"
                    });

                MessageBox.Show("Gửi yêu cầu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
        public string StudentName { get; set; }
        public string Status { get; set; } // pending, approved, denied
    }
}