using System;
using System.Collections.Generic;
using System.Drawing; // Thêm thư viện để dùng Color
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class MonHocDaDangKy : Form
    {
        private IDisposable _courseStudentListener;
        private readonly string _studentUid;
        private readonly string _idToken;
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        private List<Course> _allCourses = new();

        // Cờ kiểm soát việc đang tải để tránh gọi chồng chéo
        private bool _isLoading = false;

        public MonHocDaDangKy(string studentUid, string idToken)
        {
            InitializeComponent();
            _studentUid = studentUid;
            _idToken = idToken;

            firebaseClient = new FirebaseClient(
                firebaseDatabaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
                });
        }

        private async void DangKyMonHoc_Load(object sender, EventArgs e)
        {
            SetupListView();
            await LoadCourses(); // Tải lần đầu
            ListenCourseStudentChanges(); // Bắt đầu lắng nghe thay đổi
        }

        private void ListenCourseStudentChanges()
        {
            // Lắng nghe thay đổi ở bảng CourseStudents (đăng ký/hủy đăng ký)
            _courseStudentListener = firebaseClient
                .Child("CourseStudents")
                .AsObservable<object>()
                .Subscribe(d =>
                {
                    if (!IsHandleCreated) return;

                    // Dùng Invoke để đảm bảo luồng UI, nhưng hoãn lại 1 chút để tránh spam
                    this.Invoke(new Action(async () =>
                    {
                        await LoadCourses();
                    }));
                });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _courseStudentListener?.Dispose();
            base.OnFormClosing(e);
        }

        private void SetupListView()
        {
            lvCourses.View = View.Details;
            lvCourses.FullRowSelect = true;
            lvCourses.GridLines = true;
            lvCourses.Columns.Clear();

            lvCourses.Columns.Add("Mã Môn", 100);
            lvCourses.Columns.Add("Tên Môn Học", 250);
            lvCourses.Columns.Add("Giảng Viên", 180);
            lvCourses.Columns.Add("Sĩ Số", 100); // Mở rộng cột sĩ số chút
        }

        private async Task LoadCourses()
        {
            // Nếu đang tải dở thì bỏ qua yêu cầu mới để tránh spam/trùng lặp
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                // 1. Tải dữ liệu song song
                var taskCourses = firebaseClient.Child("Courses").OnceAsync<Course>();
                var taskStudents = firebaseClient.Child("CourseStudents").OnceAsync<Dictionary<string, StudentInfo>>();

                await Task.WhenAll(taskCourses, taskStudents);

                var courses = taskCourses.Result;
                var courseStudentsSnapshot = taskStudents.Result;

                // 2. Xử lý dữ liệu trong bộ nhớ (không đụng UI)
                var enrollmentCounts = courseStudentsSnapshot?.ToDictionary(
                    cs => cs.Key,
                    cs => cs.Object?.Count ?? 0
                ) ?? new Dictionary<string, int>();

                var joinedCourseIds = courseStudentsSnapshot?
                    .Where(cs => cs.Object != null && cs.Object.ContainsKey(_studentUid))
                    .Select(cs => cs.Key)
                    .ToHashSet() ?? new HashSet<string>();

                List<Course> tempList = new List<Course>();

                foreach (var c in courses)
                {
                    if (c.Object == null) continue;

                    bool joined = joinedCourseIds.Contains(c.Key);
                    int siSoHienTai = enrollmentCounts.ContainsKey(c.Key) ? enrollmentCounts[c.Key] : 0;

                    int maxSiSo = c.Object.SiSo;

                    var course = new Course
                    {
                        Id = c.Key,
                        MaLop = c.Object.MaLop,
                        TenLop = c.Object.TenLop,
                        Instructor = c.Object.Instructor,
                        IsJoined = joined,
                        SiSoHienTai = siSoHienTai,
                        SiSo = maxSiSo // Gán vào thuộc tính SiSo
                    };
                    tempList.Add(course);
                }

                // 3. Cập nhật UI (Lúc này mới Clear để tránh nhấp nháy và trùng lặp)
                _allCourses = tempList; // Lưu vào biến toàn cục
                RefreshListView(_allCourses); // Gọi hàm vẽ lại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
            finally
            {
                _isLoading = false; // Mở khóa cho lần tải sau
            }
        }

        // Hàm helper để render listview (Dùng chung cho Load và Search)
        private void RefreshListView(List<Course> dataToShow)
        {
            lvCourses.Items.Clear();

            foreach (var course in dataToShow)
            {
                var item = new ListViewItem(course.MaLop ?? course.Id);

                item.Tag = course.Id;

                item.SubItems.Add(course.TenLop ?? "Không có tên");
                item.SubItems.Add(course.Instructor ?? "Chưa rõ");
                item.SubItems.Add($"{course.SiSoHienTai}/{course.SiSo}");

                if (course.IsJoined)
                {
                    item.ForeColor = Color.Green;
                }
                else if (course.SiSoHienTai >= course.SiSo)
                {
                    item.ForeColor = Color.Red;
                }

                lvCourses.Items.Add(item);
            }
        }


        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            string searchText = txtNameClass.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                RefreshListView(_allCourses); // Nếu ô tìm kiếm trống, hiện tất cả
            }
            else
            {
                var filtered = _allCourses
                .Where(c =>
                    (c.TenLop != null && c.TenLop.ToLower().Contains(searchText)) ||
                    (c.MaLop != null && c.MaLop.ToLower().Contains(searchText))
                ).ToList();

                RefreshListView(filtered); // Sử dụng lại hàm vẽ để giữ nguyên logic màu đỏ/xanh
            }
        }

        private void lvCourses_DoubleClick(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0) return;

            var item = lvCourses.SelectedItems[0];
            if (item.Tag == null) return;

            string courseId = item.Tag.ToString();
            var course = _allCourses.FirstOrDefault(c => c.Id == courseId);
            if (course == null) return;

            // Chặn nếu lớp đầy và chưa tham gia
            if (!course.IsJoined && course.SiSoHienTai >= course.SiSo)
            {
                MessageBox.Show(
                    $"❌ Lớp học đã đủ sĩ số ({course.SiSoHienTai}/{course.SiSo}).\nBạn không thể đăng ký lớp này.",
                    "Lớp đã đầy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            ChiTietLopHoc form = new ChiTietLopHoc(course, _studentUid, _idToken);
            form.ShowDialog();
        }
    }

    public class CourseModel
    {
        public string TenLop { get; set; }
        public string InstructorName { get; set; }
        public string MaLop { get; set; }
        // Phải để public set thì Firebase mới ghi dữ liệu vào được
        public int SiSo { get; set; }
    }
}