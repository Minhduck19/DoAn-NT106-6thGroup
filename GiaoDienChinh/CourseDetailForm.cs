using APP_DOAN.GiaoDienChinh;
using APP_DOAN.Môn_học;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class CourseDetailForm : Form
    {
        private readonly string _courseId;
        private readonly string _courseName;
        private readonly string _studentId;
        private readonly FirebaseClient _client;
        private readonly string _studentEmail;
        private readonly string _studentName;

        public CourseDetailForm(string courseId, string courseName, string studentId, FirebaseClient client, string studentEmail, string studentName)
        {
            InitializeComponent();
            _courseId = courseId;
            _courseName = courseName;
            _studentId = studentId;
            _client = client;
            _studentEmail = studentEmail;
            _studentName = studentName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 20, 20);

            // Bật tính năng cuộn cho FlowLayoutPanel
            flpContent.AutoScroll = true;
            flpContent.FlowDirection = FlowDirection.TopDown;
            flpContent.WrapContents = false;
        }

        private async void CourseDetailForm_Load(object sender, EventArgs e)
        {
            this.Text = _courseName;

            // --- A. Vẽ Header Tên Môn Học ---
            Label lblHeader = new Label();
            lblHeader.Text = _courseName.ToUpper();
            lblHeader.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(51, 153, 255);
            lblHeader.AutoSize = true;
            lblHeader.Margin = new Padding(20, 10, 0, 20);
            flpContent.Controls.Add(lblHeader);

            // --- B. Vẽ Mục "General" (Thông báo) ---
            RenderSectionHeader("General / Thông báo");

            // Tạo Label Loading cho thông báo
            Label lblLoadingNotify = CreateLoadingLabel();
            flpContent.Controls.Add(lblLoadingNotify);

            // 🔥 TẢI THÔNG BÁO TỪ FIREBASE
            await LoadNotificationsFromFirebase(lblLoadingNotify);

            // --- C. Vẽ Mục "Bài tập" ---
            RenderSectionHeader("Bài tập & Kiểm tra");

            // Tạo Label Loading cho bài tập
            Label lblLoadingAssign = CreateLoadingLabel();
            flpContent.Controls.Add(lblLoadingAssign);

            // Tải bài tập
            await LoadAssignmentsFromFirebase(lblLoadingAssign);
        }

        // Hàm tạo Label Loading nhanh
        private Label CreateLoadingLabel()
        {
            return new Label
            {
                Text = "⏳ Đang tải dữ liệu...",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                AutoSize = true,
                Margin = new Padding(40, 5, 0, 20)
            };
        }

        // --- HÀM MỚI: Tải Thông Báo ---
        private async Task LoadNotificationsFromFirebase(Label lblLoading)
        {
            try
            {
                var notifies = await _client
                    .Child("Notifications")
                    .Child(_courseId)
                    .OnceAsync<NotificationModel>();

                flpContent.Controls.Remove(lblLoading);

                if (notifies.Count == 0)
                {
                    RenderEmptyLabel("Chưa có thông báo nào.");
                    return;
                }

                // Sắp xếp: Mới nhất lên đầu (OrderByDescending theo CreatedAt)
                var sortedList = notifies.OrderByDescending(x => x.Object.CreatedAt).ToList();

                foreach (var item in sortedList)
                {
                    RenderCard(
                        item.Object.Title,
                        item.Object.Content,
                        "announcement", // Loại thông báo
                        "",             // Không cần ID bài tập
                        item.Object.FileUrl // 🔥 Truyền thêm FileUrl (nếu có)
                    );
                }
            }
            catch (Exception ex)
            {
                lblLoading.Text = "❌ Lỗi tải thông báo: " + ex.Message;
                lblLoading.ForeColor = Color.Red;
            }
        }

        private async Task LoadAssignmentsFromFirebase(Label lblLoading)
        {
            try
            {
                var assignments = await _client
                    .Child("Assignments")
                    .Child(_courseId)
                    .OnceAsync<AssignmentModel>();

                flpContent.Controls.Remove(lblLoading);

                if (assignments.Count == 0)
                {
                    RenderEmptyLabel("Chưa có bài tập nào.");
                    return;
                }

                var sortedList = assignments.OrderByDescending(x => x.Object.CreatedAt).ToList();

                foreach (var item in sortedList)
                {
                    RenderCard(
                        item.Object.Title,
                        item.Object.Description,
                        "assignment",
                        item.Key,
                        "",
                        item.Object.DueDate // 🔥 LẤY GIÁ TRỊ TỪ MODEL FIREBASE
                    );
                }
            }
            catch (Exception ex)
            {
                lblLoading.Text = "❌ Lỗi: " + ex.Message;
            }
        }

        // Thêm sự kiện Resize cho Form hoặc FlowLayoutPanel
        private void flpContent_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpContent.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    pnl.Width = flpContent.ClientSize.Width - 60;
                    // Cập nhật lại các Label bên trong Panel nếu cần
                    foreach (Control subCtrl in pnl.Controls)
                    {
                        if (subCtrl is Label) subCtrl.Width = pnl.Width - 80;
                    }
                }
            }
        }

        private void RenderSectionHeader(string title)
        {
            Label lbl = new Label();
            lbl.Text = "▼ " + title;
            lbl.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.AutoSize = true;
            // 🔥 Tăng Margin trên (Top) lên 40 và Margin dưới (Bottom) lên 20
            lbl.Margin = new Padding(20, 40, 0, 20);
            flpContent.Controls.Add(lbl);
        }

        private void RenderEmptyLabel(string text)
        {
            Label lbl = new Label
            {
                Text = text,
                ForeColor = Color.DimGray,
                AutoSize = true,
                Margin = new Padding(40, 0, 0, 20)
            };
            flpContent.Controls.Add(lbl);
        }

        // --- HÀM 3: Vẽ Thẻ (CẬP NHẬT THÊM fileUrl) ---
        private void RenderCard(string title, string description, string type, string assignmentId = "", string fileUrl = "", string dueDate = "")
        {
            Panel pnlCard = new Panel();
            pnlCard.Width = flpContent.ClientSize.Width - 60;
            pnlCard.Height = 90;
            pnlCard.BackColor = Color.FromArgb(35, 35, 38);
            pnlCard.Margin = new Padding(30, 5, 30, 10);
            pnlCard.Cursor = Cursors.Hand;

            pnlCard.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pnlCard.ClientRectangle,
                    Color.FromArgb(60, 60, 60), ButtonBorderStyle.Solid);
            };

            Label lblIcon = new Label();
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI Emoji", 24, FontStyle.Regular);
            lblIcon.Location = new Point(15, 20);

            // Icon khác nhau tùy loại
            if (type == "announcement")
            {
                lblIcon.Text = "📢";
                lblIcon.ForeColor = Color.Orange;
            }
            else
            {
                lblIcon.Text = "📝";
                lblIcon.ForeColor = Color.HotPink;
            }

            // 3. Tiêu đề (Sửa để không đè lên Icon)
            Label lblTitle = new Label();
            lblTitle.Text = title ?? "Không tiêu đề";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(75, 15); // Đẩy sang phải một chút để tránh Icon (tọa độ x=75)
            lblTitle.Width = pnlCard.Width - 90;    // Giới hạn chiều rộng (trừ đi phần Icon và lề phải)
            lblTitle.Height = 25;                  // Cố định chiều cao
            lblTitle.AutoSize = false;             // TẮT AutoSize để kiểm soát Width
            lblTitle.AutoEllipsis = true;          // Nếu tên quá dài sẽ tự có dấu "..."

            // Cập nhật phần hiển thị mô tả để kèm hạn nộp nếu là bài tập
            Label lblDesc = new Label();
            string infoText = description ?? "";
            if (type == "assignment" && !string.IsNullOrEmpty(dueDate))
            {
                infoText += $" (Hạn: {dueDate})";
            }
            if (!string.IsNullOrEmpty(fileUrl)) infoText += " [📎 File]";

            lblDesc.Text = infoText;
            // 4. Mô tả
            string fileIndicator = !string.IsNullOrEmpty(fileUrl) ? " [📎 Có tệp đính kèm]" : "";
            lblDesc.Text = (description ?? "") + fileIndicator;
            lblDesc.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.Location = new Point(75, 45); // Căn lề x=75 giống tiêu đề
            lblDesc.Width = pnlCard.Width - 90;    // Giới hạn chiều rộng
            lblDesc.Height = 35;                  // Cố định chiều cao (đủ cho khoảng 1-2 dòng)
            lblDesc.AutoSize = false;             // TẮT AutoSize
            lblDesc.AutoEllipsis = true;          // Tự động rút gọn nếu mô tả quá dài

            // --- XỬ LÝ CLICK ---
            EventHandler clickAction = async (s, e) =>
            {
                if (type == "assignment")
                {
                    // TRUYỀN THÊM dueDate VÀO ĐÂY
                    Submit_Agsignment submitForm = new Submit_Agsignment(
                        title,
                        description,
                        dueDate, // Truyền biến dueDate đã nhận từ Firebase
                        assignmentId,
                        _client,
                        _courseId,
                        _studentId,
                        _studentEmail,
                        _studentName
                    );
                    submitForm.ShowDialog();
                }
                else if (type == "announcement")
                {
                    if (!string.IsNullOrEmpty(fileUrl))
                    {
                        // Hiển thị lựa chọn cho người dùng
                        DialogResult result = MessageBox.Show(
                            description + "\n\nBạn có muốn TẢI VỀ tệp đính kèm này không?",
                            "Thông báo",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                // Lấy tên file gốc từ URL hoặc đặt tên mặc định
                                string fileName = "TaiLieu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                                // Cố gắng lấy phần mở rộng file từ URL (ví dụ: .pdf, .docx)
                                string extension = Path.GetExtension(fileUrl).Split('?')[0];
                                if (string.IsNullOrEmpty(extension)) extension = ".pdf"; // Mặc định nếu không thấy

                                using (SaveFileDialog dlg = new SaveFileDialog())
                                {
                                    dlg.FileName = fileName + extension;
                                    dlg.Filter = "All files (*.*)|*.*";
                                    dlg.Title = "Lưu tài liệu đính kèm";

                                    if (dlg.ShowDialog() == DialogResult.OK)
                                    {
                                        // Hiển thị trạng thái đang tải (tùy chọn)
                                        this.Cursor = Cursors.WaitCursor;

                                        // Gọi hàm tải file đã viết trong CloudinaryHelper
                                        await CloudinaryHelper.DownloadFileAsync(fileUrl, dlg.FileName);

                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("✅ Tải file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi hệ thống");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(description, "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };


            lblDesc.Click += clickAction;
            pnlCard.Controls.Add(lblDesc);

            pnlCard.Click += clickAction;
            lblTitle.Click += clickAction;
            lblIcon.Click += clickAction;
            lblDesc.Click += clickAction;

            pnlCard.Controls.Add(lblIcon);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblDesc);

            flpContent.Controls.Add(pnlCard);
        }

        private void flpContent_Paint(object sender, PaintEventArgs e) { }
    }
}