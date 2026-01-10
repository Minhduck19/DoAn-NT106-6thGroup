using APP_DOAN;
using APP_DOAN.Môn_học;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class Assignment : Form
    {
        private readonly string _courseId;

        public Assignment(string courseId)
        {
            InitializeComponent();
            _courseId = courseId;
        }

        private async void Assignment_Load(object sender, EventArgs e)
        {
            lvCourses.View = View.Details;
            lvCourses.FullRowSelect = true;
            lvCourses.GridLines = true;

            lvCourses.Columns.Clear();
            lvCourses.Columns.Add("Bài tập", 160);
            lvCourses.Columns.Add("Sinh viên", 180);
            lvCourses.Columns.Add("MSSV", 120);
            lvCourses.Columns.Add("Tên file", 200);
            lvCourses.Columns.Add("Thời gian nộp", 180);

            await LoadAssignmentsFromFirebase();
        }

        private async Task LoadAssignmentsFromFirebase()
        {
            lvCourses.Items.Clear();

            var submissions =
                await FirebaseService.Instance.GetAssignmentsByCourseAsync(_courseId);

            foreach (var s in submissions)
            {
                var submitTime =
                    DateTimeOffset.FromUnixTimeSeconds(s.ThoiGianNop)
                                  .LocalDateTime
                                  .ToString("dd/MM/yyyy HH:mm");

                var user = await FirebaseService.Instance.GetUserByUidAsync(s.StudentUid);
                var hoTen = user?.HoTen ?? s.StudentUid;
                var mssv = user?.MSSV ?? string.Empty;

                ListViewItem item = new ListViewItem(s.TieuDe ?? s.AssignmentId);
                item.SubItems.Add(hoTen);
                item.SubItems.Add(mssv);
                item.SubItems.Add(s.TenFile);
                item.SubItems.Add(submitTime);
                item.Tag = s.FileUrl;
                lvCourses.Items.Add(item);

                if (!s.EmailSent)
                {

                }
            }
        }


        private async void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0) return;

            var item = lvCourses.SelectedItems[0];

            string fileUrl = item.Tag.ToString();
            string fileName = item.SubItems[3].Text;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.FileName = fileName;
                dlg.Title = "Lưu bài nộp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    await CloudinaryHelper.DownloadFileAsync(fileUrl, dlg.FileName);
                    MessageBox.Show("✅ Tải file thành công!");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton1ChamBai_Click(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bài tập cần chấm!");
                return;
            }

            var item = lvCourses.SelectedItems[0];

            string assignmentId = item.Text;
            string tieuDe = item.Text;
            var client = FirebaseService.Instance.Client;

            ChamBai cb = new ChamBai(
                _courseId,
                assignmentId,
                tieuDe,
                client
            );

            cb.Show();
        }
    }
}
