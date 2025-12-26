using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;


namespace APP_DOAN.GiaoDienChinh
{
    public partial class Assignment : Form
    {
        private readonly string _courseId;

        private async void Assignment_Load(object sender, EventArgs e)
        {
            lvCourses.View = View.Details;
            lvCourses.FullRowSelect = true;
            lvCourses.GridLines = true;

            lvCourses.Columns.Clear();
            lvCourses.Columns.Add("Lớp học", 150);
            lvCourses.Columns.Add("Tên file", 200);
            lvCourses.Columns.Add("Link bài nộp", 300);
            lvCourses.Columns.Add("Thời gian nộp", 150);

            // 🔥 LOAD BÀI NỘP TỪ FIREBASE
            await LoadAssignmentsFromFirebase();
        }


        public Assignment(string courseId)
        {
            InitializeComponent();
            _courseId = courseId;
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCourses.SelectedItems.Count == 0) return;

            var item = lvCourses.SelectedItems[0];
            string fileUrl = item.Tag.ToString();
            string fileName = item.SubItems[1].Text;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = fileName;
                saveFileDialog.Title = "Lưu bài tập";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await DownloadFileAsync(fileUrl, saveFileDialog.FileName);

                    MessageBox.Show(
                        "Tải bài tập thành công!",
                        "Hoàn tất",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }
        public void Frm_OnSubmitSuccess(AssignmentSubmitResult result)
        {
            ListViewItem item = new ListViewItem(result.TenLop);
            item.SubItems.Add(result.TenFile);
            item.SubItems.Add(result.FileUrl);
            item.SubItems.Add(result.ThoiGianNop.ToString("dd/MM/yyyy HH:mm"));

            // Lưu URL vào Tag để dùng tải file
            item.Tag = result.FileUrl;

            lvCourses.Items.Add(item);
        }

        private async Task LoadAssignmentsFromFirebase()
        {
            var submissions =
            await FirebaseService.Instance.GetAssignmentsByCourseAsync(_courseId);

            lvCourses.Items.Clear();

            foreach (var s in submissions)
            {
                ListViewItem item = new ListViewItem(s.TenLop);
                item.SubItems.Add(s.TenFile);
                item.SubItems.Add(s.FileUrl);
                item.SubItems.Add(s.ThoiGianNop.ToString("dd/MM/yyyy HH:mm"));
                item.Tag = s.FileUrl;

                lvCourses.Items.Add(item);
            }
        }


        private async Task DownloadFileAsync(string url, string savePath)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var data = await client.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(savePath, data);
            }
        }


    }

   
}
