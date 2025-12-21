using APP_DOAN.GiaoDienChinh;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APP_DOAN
{
    public partial class MainForm_GiangVien : Form
    {
        private string loggedInEmail;
        private string idToken;
        private bool isLoggingOut = false;
        private string currentUid;
        private string currentDisplayName;
        private TextBox txtFind;


        public MainForm_GiangVien(string uid, string displayName, string token)
        {
            InitializeComponent();
            this.idToken = token;
            this.currentUid = uid;
            this.currentDisplayName = displayName;

            this.txtFind = new TextBox
            {
                Name = "txtFind",
                Width = 200,
                Location = new System.Drawing.Point(20, 60)
            };
            this.Controls.Add(txtFind);
        }

        private void MainForm_GiangVien_Load(object sender, EventArgs e)
        {
            string username = currentDisplayName;
            lblWelcome.Text = $"Chào mừng,\nGV. {username}";

            SetupListViewColumns();

            LoadMyCoursesData();
        }

        private void SetupListViewColumns()
        {
            lvMyCourses.Columns.Clear();
            lvMyCourses.Columns.Add("Mã Lớp", 100);
            lvMyCourses.Columns.Add("Tên Lớp Học", 350);
            lvMyCourses.Columns.Add("Sĩ số", 100);
        }

        private void LoadMyCoursesData()
        {
            lvMyCourses.Items.Clear();

            var item1 = new ListViewItem("DB202");
            item1.SubItems.Add("Cơ sở dữ liệu");
            item1.SubItems.Add("40");
            item1.Tag = "DB202";
            lvMyCourses.Items.Add(item1);

            var item2 = new ListViewItem("NET301");
            item2.SubItems.Add("Lập trình .NET");
            item2.SubItems.Add("35");
            item2.Tag = "NET301";
            lvMyCourses.Items.Add(item2);
        }

        private void AddCourseToListView(string maLop, string tenLop, int siSo)
        {
            var item = new ListViewItem(maLop);
            item.SubItems.Add(tenLop);
            item.SubItems.Add(siSo.ToString());
            item.Tag = maLop;

            lvMyCourses.Items.Add(item);
        }


        private async void btnCreateCourse_Click_1(object sender, EventArgs e)
        {
            CreateCourse createCourse = new CreateCourse();
            createCourse.OnCourseCreated += (maLop, tenLop, siSo) =>
            {
                AddCourseToListView(maLop, tenLop, siSo);
            };

            createCourse.ShowDialog();


            var firebaseClient = new FirebaseClient(
                "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(idToken)
                });

            var createForm = new CreateCourseForm(firebaseClient, currentUid, currentDisplayName);

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Tạo lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditCourse_Click_1(object sender, EventArgs e, FixCourse fixCourse)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Chưa chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvMyCourses.SelectedItems[0];
            string maLop = item.Text;
            string tenLop = item.SubItems[1].Text;
            int siSo = int.Parse(item.SubItems[2].Text);

            FixCourse editForm = new FixCourse(maLop, tenLop, siSo);
            editForm.OnCourseUpdated = (updatedMaLop, updatedTenLop, updatedSiSo) =>
            {
                item.SubItems[1].Text = updatedTenLop;
                item.SubItems[2].Text = updatedSiSo.ToString();
            };
            fixCourse.ShowDialog();
        }

        private void btnDeleteCourse_Click_1(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa.", "Chưa chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string courseId = lvMyCourses.SelectedItems[0].Tag.ToString();
            string courseName = lvMyCourses.SelectedItems[0].SubItems[1].Text;

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp '{courseName}' (ID: {courseId}) không? Hành động này không thể hoàn tác.",
                                        "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show($"Đã xóa lớp (ID: {courseId}).", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMyCoursesData();
            }
        }

        private void MainForm_GiangVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                var result = MessageBox.Show("Bạn có muốn thoát hoàn toàn ứng dụng?", "Xác nhận Thoát",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void lvMyCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher_Information profileForm = new Teacher_Information(currentUid, idToken, loggedInEmail);
            profileForm.ShowDialog();
            this.Show();
        }

        private void btnFindCourse_Click(object sender, EventArgs e)
        {
            string searchText = txtFind.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadMyCoursesData();
                return;
            }

            foreach (ListViewItem item in lvMyCourses.Items)
            {

                string courseCode = item.Text.ToLower();
                string courseName = item.SubItems[1].Text.ToLower();

                if (courseCode.Contains(searchText) || courseName.Contains(searchText))
                {
                    item.Selected = true;
                    item.BackColor = System.Drawing.Color.LightYellow;
                    item.EnsureVisible();
                }
                else
                {
                    item.Selected = false;
                    item.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Chưa chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvMyCourses.SelectedItems[0];
            string maLop = item.Text;
            string tenLop = item.SubItems[1].Text;
            int siSo = int.Parse(item.SubItems[2].Text);

            FixCourse editForm = new FixCourse(maLop, tenLop, siSo);
            editForm.OnCourseUpdated = (updatedMaLop, updatedTenLop, updatedSiSo) =>
            {
                item.SubItems[1].Text = updatedTenLop;
                item.SubItems[2].Text = updatedSiSo.ToString();
            };
            editForm.ShowDialog();
        }
        private void lvMyCourses_DoubleClick_1(object sender, EventArgs e)
        {
            if (lvMyCourses.SelectedItems.Count == 0)
                return;

            string courseId = lvMyCourses.SelectedItems[0].Tag.ToString();
            string courseName = lvMyCourses.SelectedItems[0].SubItems[1].Text;

            var form = new CourseDetailForm(courseId, courseName, idToken, loggedInEmail);
            form.ShowDialog();

            LoadMyCoursesData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận Đăng xuất",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isLoggingOut = true;
                this.Close();
            }
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}