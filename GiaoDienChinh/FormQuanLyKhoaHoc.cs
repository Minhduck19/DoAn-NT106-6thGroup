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
    public partial class FormQuanLyKhoaHoc : Form
    {
        private string _courseId;
        private string _courseName;
        private string _token;
        private FirebaseClient _client;
        private IDisposable _studentListener;
        private IDisposable _requestListener;

        // Các component giao diện bổ sung
        private Guna2DragControl _dragControl;
        private Guna2ShadowForm _shadowForm;      // 🔥 Tạo bóng đổ
        private Guna2BorderlessForm _borderlessForm; 
        private Guna.UI2.WinForms.Guna2ResizeForm _resizeForm;

        public FormQuanLyKhoaHoc(string courseId, string courseName, string token)
        {
            InitializeComponent();
            _courseId = courseId;
            _courseName = courseName;
            _token = token;

            this.Padding = new System.Windows.Forms.Padding(1); // Tạo khoảng hở 1px
            this.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);

            _dragControl = new Guna2DragControl();
            _dragControl.TargetControl = this.pnlHeader; // Kéo form bằng Header

            // --- 2. TẠO HIỆU ỨNG VIỀN & BÓNG ĐỔ ---
            _shadowForm = new Guna2ShadowForm(); 
            _shadowForm.TargetForm = this;

            _borderlessForm = new Guna2BorderlessForm(); 
            _borderlessForm.ContainerControl = this;
            _borderlessForm.BorderRadius = 15; // Bo góc
            _borderlessForm.ShadowColor = Color.DimGray;

            // Khởi tạo Firebase
            try
            {
                _client = FirebaseService.Instance._client;
            }
            catch
            {
                _client = new FirebaseClient(
                    "https://nt106-minhduc-default-rtdb.firebaseio.com/",
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );
            }
        }

        private void FormQuanLyKhoaHoc_Load(object sender, EventArgs e)
        {
            lblCourseName.Text = _courseName.ToUpper();

            // Setup cột
            SetupGunaColumns();

            // Load dữ liệu
            LoadAssignments();
            SubscribeStudents();
            SubscribeRequests();
        }

        private void SetupGunaColumns()
        {
            // --- Bảng Yêu Cầu (Requests) ---
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();

            // 1. Cột Tên Sinh Viên
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenSV",              // <-- Đặt tên để gọi code
                DataPropertyName = "TenSV",  // <-- Tên biến trong List data hiển thị
                HeaderText = "SINH VIÊN YÊU CẦU",
                FillWeight = 60
            });

            // 2. Cột MSSV (Lấy từ bảng Users)
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MSSV",
                DataPropertyName = "MSSV",
                HeaderText = "MSSV",
                Width = 100
            });

            // 3. Cột Trạng Thái
            var statusCol = new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                DataPropertyName = "TrangThai",
                HeaderText = "TRẠNG THÁI",
                FillWeight = 40
            };
            statusCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            statusCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequests.Columns.Add(statusCol);

            // 4. Cột Ẩn chứa UID (🔥 SỬA LỖI TẠI ĐÂY)
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentUid",           // <--- QUAN TRỌNG: Phải có dòng này thì nút Duyệt mới tìm thấy
                DataPropertyName = "StudentUid",
                HeaderText = "UID",
                Visible = false                // Ẩn đi không cho người dùng thấy
            });


            // --- Bảng Sinh Viên (Students) ---
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { Name = "MSSV", DataPropertyName = "MSSV", HeaderText = "MSSV", Width = 100 });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", DataPropertyName = "HoTen", HeaderText = "HỌ VÀ TÊN" });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", DataPropertyName = "Email", HeaderText = "EMAIL" });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Uid", DataPropertyName = "Uid", HeaderText = "UID", Visible = false });

            // --- Bảng Bài Tập ---
            dgvAssignments.AutoGenerateColumns = false;
            dgvAssignments.Columns.Clear();
            dgvAssignments.Columns.Add(new DataGridViewTextBoxColumn { Name = "TieuDe", DataPropertyName = "TieuDe", HeaderText = "TIÊU ĐỀ BÀI TẬP" });
            dgvAssignments.Columns.Add(new DataGridViewTextBoxColumn { Name = "HanNop", DataPropertyName = "HanNop", HeaderText = "HẠN NỘP" });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _studentListener?.Dispose();
            _requestListener?.Dispose();
            base.OnFormClosing(e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabAssignments) LoadAssignments();
        }


        private async void LoadAssignments()
        {
            try
            {
                var data = await FirebaseApi.Get<Dictionary<string, AssignmentModel>>($"Assignments/{_courseId}");
                if (data == null) { dgvAssignments.DataSource = null; return; }

                dgvAssignments.DataSource = data.Select(x => new
                {
                    ID = x.Key,
                    TieuDe = x.Value.Title,
                    NoiDung = x.Value.Description,
                    HanNop = x.Value.DueDate,
                }).ToList();
            }
            catch { dgvAssignments.DataSource = null; }
        }

        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            // Hiệu ứng click Guna đã tự lo, chỉ cần code logic
            MessageBox.Show("Chức năng thêm bài tập đang phát triển.");
        }

        private void SubscribeStudents()
        {
            var path = $"CourseStudents/{_courseId}";
            _studentListener = _client.Child(path).AsObservable<UserProfile>().Subscribe(d =>
            {
                if (!IsHandleCreated || IsDisposed) return;
                BeginInvoke(new Action(async () => await ReloadStudentList(path)));
            });
        }

        private async Task ReloadStudentList(string path)
        {
            try
            {
                var items = await _client.Child(path).OnceAsync<UserProfile>();
                dgvStudents.DataSource = items.Select(x => new
                {
                    Uid = x.Key,
                    MSSV = x.Object.MSSV ?? "---",
                    HoTen = x.Object.HoTen,
                    Email = x.Object.Email
                }).OrderBy(s => s.MSSV).ToList();
            }
            catch { }
        }

        private void SubscribeRequests()
        {
            var path = $"JoinRequests/{_courseId}";
            _requestListener = _client.Child(path).AsObservable<RequestModel>().Subscribe(d =>
            {
                if (!IsHandleCreated || IsDisposed) return;
                BeginInvoke(new Action(async () => await ReloadRequestList(path)));
            });
        }

        private async Task ReloadRequestList(string path)
        {
            try
            {
                // 1. Lấy danh sách yêu cầu từ Firebase
                var requestItems = await _client.Child(path).OnceAsync<RequestModel>();

                // Tạo list chứa dữ liệu hiển thị
                var displayList = new List<object>();

                // 2. Duyệt qua từng yêu cầu để lấy thông tin chi tiết từ Users
                foreach (var item in requestItems)
                {
                    string uid = item.Object.StudentUid;

                    // Tìm thông tin User dựa trên UID
                    var userProfile = await _client.Child($"Users/{uid}").OnceSingleAsync<UserProfile>();

                    if (userProfile != null)
                    {
                        // Nếu tìm thấy User, lấy Tên thật và MSSV
                        displayList.Add(new
                        {
                            StudentUid = uid,
                            TenSV = userProfile.HoTen, // Lấy tên thật từ Users
                            MSSV = userProfile.MSSV,   // Lấy MSSV từ Users
                            TrangThai = item.Object.Status
                        });
                    }
                    else
                    {
                        // Nếu không tìm thấy User (lỗi data), lấy tạm thông tin từ Request
                        displayList.Add(new
                        {
                            StudentUid = uid,
                            TenSV = item.Object.StudentName + " (Chưa cập nhật)",
                            MSSV = "---",
                            TrangThai = item.Object.Status
                        });
                    }
                }

                // 3. Đổ dữ liệu vào GridView
                dgvRequests.DataSource = displayList;

                // Cập nhật text cho Tab
                if (displayList.Count > 0)
                    tabRequests.Text = $"Phê duyệt ({displayList.Count})";
                else
                    tabRequests.Text = "Phê duyệt tham gia";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load request: " + ex.Message);
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần duyệt!", "Thông báo");
                return;
            }

            try
            {
                // Lấy UID và Tên
                var cellUid = dgvRequests.CurrentRow.Cells["StudentUid"].Value;
                var cellName = dgvRequests.CurrentRow.Cells["TenSV"].Value;
                if (cellUid == null) return;

                string uid = cellUid.ToString();
                string nameHienThi = cellName?.ToString() ?? "Sinh viên";

                if (MessageBox.Show($"Duyệt sinh viên: {nameHienThi}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    // 1. Lấy thông tin User gốc
                    var userProfile = await _client.Child($"Users/{uid}").OnceSingleAsync<UserProfile>();

                    if (userProfile != null)
                    {
                        var studentToAdd = new UserProfile
                        {
                            HoTen = userProfile.HoTen,
                            MSSV = userProfile.MSSV,
                            Email = userProfile.Email
                        };

                        // 2. Thêm vào lớp (CourseStudents)
                        await _client.Child($"CourseStudents/{_courseId}/{uid}").PutAsync(studentToAdd);

                        // 3. Xóa yêu cầu (JoinRequests)
                        await _client.Child($"JoinRequests/{_courseId}/{uid}").DeleteAsync();

                        // 🔥 BƯỚC MỚI: CẬP NHẬT SĨ SỐ LÊN FIREBASE 🔥
                        await UpdateStudentCount();

                        MessageBox.Show("Duyệt thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không tìm thấy thông tin Users.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // 🔥 Hàm riêng để đếm và update sĩ số (Dùng lại được nhiều nơi)
        private async Task UpdateStudentCount()
        {
            try
            {
                // 1. Đếm số lượng sinh viên thực tế trong nhánh CourseStudents
                var students = await _client.Child($"CourseStudents/{_courseId}").OnceAsync<object>();
                int currentCount = students.Count;

                // 2. Cập nhật con số này vào trường "SiSoHienTai" của khóa học
                // Dùng PatchAsync để chỉ sửa 1 trường này, không ảnh hưởng tên lớp hay giảng viên
                await _client.Child($"Courses/{_courseId}").PatchAsync(new
                {
                    SiSoHienTai = currentCount
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật sĩ số: " + ex.Message);
            }
        }
    }
}