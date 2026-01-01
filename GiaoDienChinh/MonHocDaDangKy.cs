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
        private bool _isLoading = false; // 🔥 CHỐNG LOAD LẶP

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

            lvCourses.Columns.Add("Mã Môn", 120);
            lvCourses.Columns.Add("Tên Môn Học", 300);
            lvCourses.Columns.Add("Giảng Viên", 200);
        }

        private async Task LoadCourses()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                lvCourses.Items.Clear();

                var courses = await firebaseClient
                    .Child("Courses")
                    .OnceAsync<CourseModel>();

                var courseStudents = await firebaseClient
                    .Child("CourseStudents")
                    .OnceAsync<Dictionary<string, bool>>();
                _allCourses.Clear();

                foreach (var c in courses)
                {
                    bool joined = courseStudents.Any(cs =>
                        cs.Key == c.Key && cs.Object.ContainsKey(_studentUid));

                    var course = new Course
                    {
                        Id = c.Key,
                        MaLop = c.Object.MaLop,
                        TenLop = c.Object.TenLop,
                        Instructor = c.Object.InstructorName,
                        IsJoined = joined
                    };

                    _allCourses.Add(course);

                    var item = new ListViewItem(course.MaLop ?? course.Id);
                    item.SubItems.Add(course.TenLop ?? "Không có tên");
                    item.SubItems.Add(course.Instructor ?? "Chưa rõ");

                    item.Tag = course.Id;

                    if (joined)
                        item.ForeColor = System.Drawing.Color.Green;

                    lvCourses.Items.Add(item);
                }

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
