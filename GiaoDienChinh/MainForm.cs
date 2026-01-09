using APP_DOAN.GiaoDienChinh;
using APP_DOAN.Môn_học;
using APP_DOAN.Services;
using Firebase.Database;
using Firebase.Database.Query;
using Guna.UI2.WinForms;
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
        private bool _isInitialLoadDone;

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
                _firebaseClient = FirebaseService.Instance.Client;
            }
            catch
            {
                _firebaseClient = new FirebaseClient(
                    "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );
            }

            btnNavRegister.Click += đăngKýMônHọcToolStripMenuItem_Click;
            btnNavProfile.Click += profileToolStripMenuItem_Click;
            btnNavHome.Click += (s, e) => { _ = LoadClassDataFromFirebase(); };
            btnChat.Click += guna2Button1_Click;
            txtSearch.TextChanged += txtNameClass_TextChanged;

            Shown += MainForm_Shown;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try { FirebaseService.Initialize(_idToken); } catch { }

            lblUserNameHeader.Text = _currentUserName;
            lblWelcomeBig.Text = $"Chào mừng, {_currentUserName}!";
            lblDate.Text = "Hôm nay là: " + DateTime.Now.ToString("dd/MM/yyyy");

            btnNavHome.FillColor = Color.FromArgb(235, 240, 255);
            btnNavHome.ForeColor = Color.FromArgb(94, 148, 255);

        }

        private async void MainForm_Shown(object? sender, EventArgs e)
        {
            if (_isInitialLoadDone)
            {
                return;
            }

            _isInitialLoadDone = true;

            try
            {
                UseWaitCursor = true;
                await LoadClassDataFromFirebase();
                ListenCourseChanges();
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private async Task LoadClassDataFromFirebase()
        {
            try
            {
                if (_allCourses.Count == 0)
                {
                    flpCourses.Controls.Clear();
                    Guna2Button btnLoading = new Guna2Button()
                    {
                        Text = "Đang đồng bộ dữ liệu...",
                        FillColor = Color.Transparent,
                        ForeColor = Color.Gray,
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        AutoSize = true
                    };
                    flpCourses.Controls.Add(btnLoading);
                }

                var taskAllCourses = _firebaseClient.Child("Courses").OnceAsync<Course>();
                var taskStudentMap = _firebaseClient.Child("CourseStudents").OnceAsync<Dictionary<string, StudentInfo>>();

                await Task.WhenAll(taskAllCourses, taskStudentMap);

                var firebaseCourses = taskAllCourses.Result;
                var courseStudentsSnapshot = taskStudentMap.Result;

                var joinedCourseIds = new HashSet<string>();
                if (courseStudentsSnapshot != null)
                {
                    joinedCourseIds = new HashSet<string>(
                        courseStudentsSnapshot
                            .Where(cs => cs.Object != null && cs.Object.ContainsKey(_currentUserUid))
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
                MessageBox.Show("Lỗi tải lớp:\n" + ex.Message, "Firebase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            lblSectionTitle.Text = $"Khóa học của tôi ({joinedCourses.Count})";

            if (joinedCourses.Count == 0)
            {
                Label lblEmpty = new Label()
                {
                    Text = "Bạn chưa đăng ký khóa học nào.",
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    ForeColor = Color.DimGray,
                    AutoSize = true,
                    Margin = new Padding(20)
                };
                flpCourses.Controls.Add(lblEmpty);
                return;
            }

            foreach (var c in joinedCourses)
            {
                Guna2Panel pnlCard = new Guna2Panel();
                pnlCard.Size = new Size(280, 180);
                pnlCard.FillColor = Color.White;
                pnlCard.BorderRadius = 15;
                pnlCard.Margin = new Padding(15);
                pnlCard.Cursor = Cursors.Hand;
                pnlCard.Tag = c.Id;

                pnlCard.ShadowDecoration.Enabled = true;
                pnlCard.ShadowDecoration.Color = Color.Gray;
                pnlCard.ShadowDecoration.Depth = 5;
                pnlCard.ShadowDecoration.Shadow = new Padding(3, 3, 5, 5);
                pnlCard.ShadowDecoration.BorderRadius = 15;

                Guna2Panel pnlHeaderColor = new Guna2Panel();
                pnlHeaderColor.Dock = DockStyle.Top;
                pnlHeaderColor.Height = 10;
                pnlHeaderColor.FillColor = GetRandomColor(c.Id);
                pnlHeaderColor.CustomizableEdges.BottomLeft = false;
                pnlHeaderColor.CustomizableEdges.BottomRight = false;
                pnlCard.Controls.Add(pnlHeaderColor);

                Label lblName = new Label();
                lblName.Text = c.TenLop;
                lblName.Font = new Font("Segoe UI", 13, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(50, 50, 50);
                lblName.Location = new Point(15, 30);
                lblName.Size = new Size(250, 60);
                lblName.AutoEllipsis = true;
                lblName.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);
                pnlCard.Controls.Add(lblName);

                Label lblGV = new Label();
                lblGV.Text = $"GV: {c.Instructor}";
                lblGV.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                lblGV.ForeColor = Color.Gray;
                lblGV.Location = new Point(15, 100);
                lblGV.AutoSize = true;
                lblGV.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);
                pnlCard.Controls.Add(lblGV);

                Guna2Button btnAction = new Guna2Button();
                btnAction.Text = "Truy cập";
                btnAction.BorderRadius = 12;
                btnAction.FillColor = Color.FromArgb(240, 245, 255);
                btnAction.ForeColor = Color.FromArgb(94, 148, 255);
                btnAction.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btnAction.Size = new Size(100, 30);
                btnAction.Location = new Point(160, 135);
                btnAction.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);
                pnlCard.Controls.Add(btnAction);

                pnlCard.Click += (s, e) => OpenCourseDetail(c.Id, c.TenLop);

                pnlCard.MouseEnter += (s, e) => { pnlCard.Top -= 2; };
                pnlCard.MouseLeave += (s, e) => { pnlCard.Top += 2; };

                flpCourses.Controls.Add(pnlCard);
            }
        }

        private Color GetRandomColor(string seed)
        {
            int hash = seed.GetHashCode();
            if (hash % 4 == 0) return Color.FromArgb(255, 118, 117);
            if (hash % 4 == 1) return Color.FromArgb(9, 132, 227);
            if (hash % 4 == 2) return Color.FromArgb(0, 184, 148);
            return Color.FromArgb(253, 203, 110);
        }

        private void OpenCourseDetail(string courseId, string courseName)
        {
            CourseDetailForm frm = new CourseDetailForm(courseId, courseName, _currentUserUid, _firebaseClient, _loggedInEmail, _currentUserName);
            frm.ShowDialog();
        }

        private void txtNameClass_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMainChat chat = new frmMainChat(_currentUserUid, _currentMaSo, _currentUserName, _idToken);
            chat.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Information frm = new Student_Information(_currentUserUid, _idToken, _loggedInEmail);
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

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword frm = new ChangePassword(_loggedInEmail, _idToken);
            frm.ShowDialog();
            this.Show();
        }

        private void Find_Click(object sender, EventArgs e) { }
        private void lblWelcome_Click(object sender, EventArgs e) { }
        private void cmsUserOptions_Opening_1(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void grpJoinedCourses_Click_1(object sender, EventArgs e) { }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) { }
        private void flpCourses_Paint(object sender, PaintEventArgs e) { }
    }

    public class StudentInfo
    {
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string MSSV { get; set; }
    }
}