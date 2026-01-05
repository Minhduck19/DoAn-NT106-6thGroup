using APP_DOAN.GiaoDienChinh;
using APP_DOAN.Môn_học;
using APP_DOAN.Services;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class MainForm : Form
    {
        private IDisposable _courseListener;
        private readonly string _currentUserUid;
        private readonly string _currentMaSo;
        private readonly string _currentUserName;
        private readonly string _loggedInEmail;
        private readonly string _idToken;
        private FirebaseClient _firebaseClient;

        private bool isLoggingOut = false;
        private List<Course> _allCourses = new();

        public MainForm(string uid, string MSSV, string hoTen, string email, string token)
        {
            InitializeComponent();
            _currentMaSo = MSSV;
            _currentUserUid = uid;
            _currentUserName = hoTen;
            _loggedInEmail = email;
            _idToken = token;

            try
            {
                _firebaseClient = FirebaseService.Instance._client;
            }
            catch
            {
                _firebaseClient = new FirebaseClient(
                    "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try { FirebaseService.Initialize(_idToken); } catch { }

            lblWelcome.Text = $"Chào mừng,\n{_currentUserName} (Sinh viên)";

            await LoadClassDataFromFirebase();
            ListenCourseChanges();
        }

        private async Task LoadClassDataFromFirebase()
        {
            try
            {
                if (_allCourses.Count == 0)
                {
                    flpCourses.Controls.Clear();
                    Label lblLoading = new Label()
                    {
                        Text = "Đang tải dữ liệu...",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Location = new Point(20, 20)
                    };
                    flpCourses.Controls.Add(lblLoading);
                }

                var taskAllCourses = _firebaseClient
                    .Child("Courses")
                    .OnceAsync<Course>();

                var taskStudentMap = _firebaseClient
                    .Child("CourseStudents")
                    .OnceAsync<Dictionary<string, StudentInfo>>();

                await Task.WhenAll(taskAllCourses, taskStudentMap);

                var firebaseCourses = taskAllCourses.Result;
                var courseStudentsSnapshot = taskStudentMap.Result;

                var joinedCourseIds = new HashSet<string>();

                if (courseStudentsSnapshot != null)
                {
                    joinedCourseIds = new HashSet<string>(
                        courseStudentsSnapshot
                            .Where(cs => cs.Object != null &&
                                         cs.Object.ContainsKey(_currentUserUid))
                            .Select(cs => cs.Key)
                    );
                }

                _allCourses.Clear();

                foreach (var c in firebaseCourses)
                {
                    if (c.Object == null) continue;

                    bool isJoined = joinedCourseIds.Contains(c.Key);

                    _allCourses.Add(new Course(
                        c.Key,
                        c.Object.TenLop ?? "Chưa đặt tên",
                        c.Object.Instructor ?? "N/A",
                        isJoined
                    ));
                }

                PopulateAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải lớp:\n" + ex.Message,
                    "Firebase Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ListenCourseChanges()
        {
            _courseListener = _firebaseClient
                .Child("CourseStudents")
                .AsObservable<object>()
                .Subscribe(_ =>
                {
                    if (!IsHandleCreated) return;
                    BeginInvoke(new Action(async () =>
                    {
                        await LoadClassDataFromFirebase();
                    }));
                });
        }

        private void PopulateAllCourses(List<Course> listToDisplay = null)
        {
            var sourceList = listToDisplay ?? _allCourses;
            var joinedCourses = sourceList.Where(c => c.IsJoined).ToList();

            flpCourses.Controls.Clear();

            if (joinedCourses.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Chưa tham gia khóa học nào.";
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.ForeColor = Color.DimGray;
                lblEmpty.AutoSize = true;
                lblEmpty.Margin = new Padding(20);
                flpCourses.Controls.Add(lblEmpty);
                return;
            }

            foreach (var c in joinedCourses)
            {
                Panel pnlCard = new Panel();
                pnlCard.Size = new Size(flpCourses.Width - 40, 110);
                pnlCard.BackColor = Color.White;
                pnlCard.Margin = new Padding(10, 5, 10, 15);
                pnlCard.Cursor = Cursors.Hand;
                pnlCard.Tag = c.Id;

                pnlCard.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);

                Label lblName = new Label();
                lblName.Text = c.TenLop ?? "Chưa đặt tên";
                lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(51, 153, 255);
                lblName.Location = new Point(20, 15);
                lblName.AutoSize = true;
                lblName.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);
                pnlCard.Controls.Add(lblName);

                Label lblGV = new Label();
                lblGV.Text = $"GV: {c.Instructor ?? "N/A"}";
                lblGV.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                lblGV.ForeColor = Color.LightGray;
                lblGV.Location = new Point(20, 50);
                lblGV.AutoSize = true;
                lblGV.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);
                pnlCard.Controls.Add(lblGV);

                Label lblStatus = new Label();
                lblStatus.Text = "✅ Đã tham gia";
                lblStatus.ForeColor = Color.LightGreen;
                lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                lblStatus.AutoSize = true;
                lblStatus.Location = new Point(pnlCard.Width - 120, 15);
                lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                pnlCard.Controls.Add(lblStatus);

                flpCourses.Controls.Add(pnlCard);
            }
        }

        private void OpenCourseDetail(string courseId, string courseName)
        {
            CourseDetailForm frm = new CourseDetailForm(courseId, courseName, _currentUserUid, _firebaseClient);
            frm.ShowDialog();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtNameClass_TextChanged(object sender, EventArgs e)
        {
        }

        private void PerformSearch()
        {
            string keyword = txtNameClass.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                PopulateAllCourses();
                return;
            }

            var filteredList = _allCourses
                .Where(c => (c.TenLop != null && c.TenLop.ToLower().Contains(keyword)))
                .ToList();

            PopulateAllCourses(filteredList);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.isLoggingOut = true;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _courseListener?.Dispose();

            if (!isLoggingOut)
            {
                var result = MessageBox.Show("Thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void lblWelcome_Click(object sender, EventArgs e) => cmsUserOptions.Show(lblWelcome, new Point(0, lblWelcome.Height));
        private void cmsUserOptions_Opening_1(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Information frm = new Student_Information(_currentUserUid, _idToken, _loggedInEmail);
            frm.ShowDialog();
            this.Show();
        }
        private void scheduleToolStripMenuItem_Click_1(object sender, EventArgs e) => MessageBox.Show("Chức năng Lịch học đang phát triển.");
        private void gradesToolStripMenuItem_Click_1(object sender, EventArgs e) => MessageBox.Show("Chức năng Điểm đang phát triển.");

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword frm = new ChangePassword(_loggedInEmail, _idToken);
            frm.ShowDialog();
            this.Show();
        }

        private void đăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonHocDaDangKy frm = new MonHocDaDangKy(_currentUserUid, _idToken);
            frm.ShowDialog();
            this.Show();
            _ = LoadClassDataFromFirebase();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMainChat chat = new frmMainChat(_currentUserUid, _currentMaSo, _currentUserName, _idToken);
            chat.Show();
        }

        private void grpJoinedCourses_Click_1(object sender, EventArgs e) { }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) { }

        private void flpCourses_Paint(object sender, PaintEventArgs e)
        {
        }
    }

    public class StudentInfo
    {
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string MSSV { get; set; }
    }
}