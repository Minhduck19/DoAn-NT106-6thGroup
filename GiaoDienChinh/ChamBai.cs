using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class ChamBai : Form
    {
        private readonly string _courseId;
        private readonly string _assignmentId;
        private readonly FirebaseClient _client;

        public ChamBai(string courseId, string assignmentId, string tieuDe, FirebaseClient client)
        {
            InitializeComponent();

            _courseId = courseId;
            _assignmentId = assignmentId;
            _client = client;

            lblTitle.Text = "CHẤM BÀI: " + tieuDe.ToUpper();
            SetupGrid();
        }

        private async void ChamBai_Load(object sender, EventArgs e)
        {
            await LoadSubmissions();
        }

        private void SetupGrid()
        {
            dgvChamBai.AutoGenerateColumns = false;
            dgvChamBai.Columns.Clear();

            dgvChamBai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MSSV",
                DataPropertyName = "MSSV",
                HeaderText = "MSSV",
                Width = 90,
                ReadOnly = true
            });

            dgvChamBai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                DataPropertyName = "HoTen",
                HeaderText = "HỌ TÊN",
                Width = 180,
                ReadOnly = true
            });

            dgvChamBai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianNop",
                DataPropertyName = "ThoiGianNopText",
                HeaderText = "THỜI GIAN NỘP",
                Width = 150,
                ReadOnly = true
            });

            dgvChamBai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Diem",
                DataPropertyName = "Diem",
                HeaderText = "ĐIỂM",
                Width = 60
            });

            dgvChamBai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NhanXet",
                DataPropertyName = "NhanXet",
                HeaderText = "NHẬN XÉT",
                Width = 250
            });

            var btnSave = new DataGridViewButtonColumn
            {
                Name = "Luu",
                HeaderText = "LƯU",
                Text = "Lưu",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvChamBai.Columns.Add(btnSave);

            dgvChamBai.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }



        private async Task LoadSubmissions()
        {
            var students = await _client
                .Child($"CourseStudents/{_courseId}")
                .OnceAsync<UserProfile>();

            var submissions = await _client
                .Child($"Assignments/{_courseId}/{_assignmentId}/Submissions")
                .OnceAsync<SubmissionModel>();

            int daNop = submissions?.Count ?? 0;
            int tong = students.Count;
            lblStatus.Text = $"Đã nộp: {daNop}/{tong}";

            List<SubmissionModel> list = new List<SubmissionModel>();

            foreach (var s in students)
            {
                var sub = submissions?.FirstOrDefault(x => x.Key == s.Key)?.Object;

                list.Add(new SubmissionModel
                {
                    Uid = s.Key,
                    MSSV = s.Object.MSSV,
                    HoTen = s.Object.HoTen,
                    Diem = sub?.Diem,
                    NhanXet = sub?.NhanXet ?? "",
                    ThoiGianNop = sub?.ThoiGianNop
                });
            }

            dgvChamBai.DataSource = list;
        }


        private async void dgvChamBai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dataItem = dgvChamBai.Rows[e.RowIndex].DataBoundItem as SubmissionModel;
            if (dataItem == null) return;

            // Lưu điểm
            if (dgvChamBai.Columns[e.ColumnIndex].Name == "Luu")
            {
                if (!double.TryParse(
                    dgvChamBai.Rows[e.RowIndex].Cells["Diem"].Value?.ToString(),
                    out double diem))
                {
                    MessageBox.Show("Điểm không hợp lệ!");
                    return;
                }

                await _client
                    .Child($"Assignments/{_courseId}/{_assignmentId}/Submissions/{dataItem.Uid}")
                    .PatchAsync(new
                    {
                        Diem = diem,
                        NhanXet = dgvChamBai.Rows[e.RowIndex].Cells["NhanXet"].Value?.ToString()
                    });

                MessageBox.Show("Đã lưu điểm!");
            }
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
