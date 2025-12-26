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
            if (_isLoading) return;   // 🔥 CHẶN GỌI CHỒNG
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

                foreach (var c in courses)
                {
                    bool joined = courseStudents.Any(cs =>
                        cs.Key == c.Key && cs.Object.ContainsKey(_studentUid));

                    if (!joined) continue;

                    var course = c.Object;

                    var item = new ListViewItem(course.MaLop ?? c.Key);
                    item.SubItems.Add(course.TenLop ?? "Không có tên");
                    item.SubItems.Add(course.InstructorName ?? "Chưa rõ");
                    item.Tag = c.Key;

                    lvCourses.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                _isLoading = false; // 🔥 MỞ KHÓA
            }
        }

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0) return;

            var item = lvCourses.SelectedItems[0];
            string courseId = item.Tag.ToString();      // ID môn học
            string tenLop = item.SubItems[1].Text;

            // FORM GIẢNG VIÊN / DANH SÁCH BÀI
            Assignment frmAssignment = new Assignment(courseId);
            frmAssignment.Show();

            // FORM SINH VIÊN NỘP BÀI
            Submit_Agsignment frmSubmit = new Submit_Agsignment(
                tenLop,
                firebaseClient,
                courseId,
                _studentUid
            );

            frmSubmit.OnSubmitSuccess += frmAssignment.Frm_OnSubmitSuccess;
            frmSubmit.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class CourseModel
    {
        public string TenLop { get; set; }
        public string InstructorName { get; set; }
        public string MaLop { get; set; }
    }
}
