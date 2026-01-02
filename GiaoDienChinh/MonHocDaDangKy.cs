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
        private IDisposable _courseStudentListener;
        private bool _isLoading = false;

        private readonly string _studentUid;
        private readonly string _idToken;
        private readonly string firebaseDatabaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        private List<Course> _allCourses = new();

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
            await LoadCourses();
            ListenCourseStudentChanges();
        }

        private void ListenCourseStudentChanges()
        {
            _courseStudentListener = firebaseClient
                .Child("CourseStudents")
                .AsObservable<object>()
                .Subscribe(_ =>
                {
                    if (!IsHandleCreated || _isLoading) return;

                    BeginInvoke(new Action(async () =>
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
            lvCourses.Columns.Add("Sĩ Số", 80);
        }

        private async Task LoadCourses()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                lvCourses.Items.Clear();

                // Tải dữ liệu song song để tối ưu tốc độ
                var taskCourses = firebaseClient.Child("Courses").OnceAsync<CourseModel>();
                var taskStudents = firebaseClient.Child("CourseStudents").OnceAsync<Dictionary<string, StudentInfo>>();

                await Task.WhenAll(taskCourses, taskStudents);

                var courses = taskCourses.Result;
                var courseStudentsSnapshot = taskStudents.Result;

                // Lưu trữ sĩ số của từng môn: Key là CourseID, Value là số lượng sinh viên
                var enrollmentCounts = courseStudentsSnapshot?.ToDictionary(
                    cs => cs.Key,
                    cs => cs.Object?.Count ?? 0
                ) ?? new Dictionary<string, int>();

                // Danh sách ID các môn mà sinh viên hiện tại đã tham gia
                var joinedCourseIds = courseStudentsSnapshot?
                    .Where(cs => cs.Object != null && cs.Object.ContainsKey(_studentUid))
                    .Select(cs => cs.Key)
                    .ToHashSet() ?? new HashSet<string>();

                _allCourses.Clear();

                foreach (var c in courses)
                {
                    if (c.Object == null) continue;

                    bool joined = joinedCourseIds.Contains(c.Key);
                    int siSo = enrollmentCounts.ContainsKey(c.Key) ? enrollmentCounts[c.Key] : 0;

                    var course = new Course
                    {
                        Id = c.Key,
                        MaLop = c.Object.MaLop,
                        TenLop = c.Object.TenLop,
                        Instructor = c.Object.InstructorName,
                        IsJoined = joined,
                        SiSo = siSo // Gán sĩ số vào object
                    };

                    _allCourses.Add(course);

                    // Thêm vào ListView
                    var item = new ListViewItem(course.MaLop ?? course.Id);
                    item.SubItems.Add(course.TenLop ?? "Không có tên");
                    item.SubItems.Add(course.Instructor ?? "Chưa rõ");
                    item.SubItems.Add(course.SiSo.ToString()); // Hiển thị sĩ số lên cột thứ 4
                    item.Tag = course.Id;

                    if (joined)
                        item.ForeColor = System.Drawing.Color.Green;

                    lvCourses.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0) return;

            var item = lvCourses.SelectedItems[0];
            if (item.Tag == null) return;

            string courseId = item.Tag.ToString();

            var course = _allCourses.FirstOrDefault(c => c.Id == courseId);
            if (course == null) return;

            ChiTietLopHoc form = new ChiTietLopHoc(course, _studentUid, _idToken);
            form.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            string searchText = txtNameClass.Text.ToLower().Trim();
            lvCourses.Items.Clear();

            var filtered = _allCourses
                .Where(c => c.TenLop?.ToLower().Contains(searchText) == true)
                .ToList();

            foreach (var c in filtered)
            {
                var item = new ListViewItem(c.MaLop ?? c.Id);
                item.SubItems.Add(c.TenLop);
                item.SubItems.Add(c.Instructor);
                item.SubItems.Add(c.SiSo.ToString()); // Hiển thị lại sĩ số
                item.Tag = c.Id;

                if (c.IsJoined)
                    item.ForeColor = System.Drawing.Color.Green;

                lvCourses.Items.Add(item);
            }
        }
    }

    public class CourseModel
    {
        public string TenLop { get; set; }
        public string InstructorName { get; set; }
        public string MaLop { get; set; }
    }
}
