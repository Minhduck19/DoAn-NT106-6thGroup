using APP_DOAN.GiaoDienChinh; // Namespace chứa form nộp bài (Submit_Agsignment)
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class CourseDetailForm : Form
    {
        // 1. Các biến dữ liệu
        private readonly string _courseId;
        private readonly string _courseName;
        private readonly string _studentId;
        private readonly FirebaseClient _client;

        // 2. Constructor nhận dữ liệu từ MainForm
        public CourseDetailForm(string courseId, string courseName, string studentId, FirebaseClient client)
        {
            InitializeComponent();

            _courseId = courseId;
            _courseName = courseName;
            _studentId = studentId;
            _client = client;

            // Setup cơ bản cho Form (Nền tối)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 20, 20);
        }

        private async void CourseDetailForm_Load(object sender, EventArgs e)
        {
            this.Text = _courseName;

            // --- A. Vẽ Header Tên Môn Học ---
            Label lblHeader = new Label();
            lblHeader.Text = _courseName.ToUpper();
            lblHeader.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(51, 153, 255); // Xanh dương sáng
            lblHeader.AutoSize = true;
            lblHeader.Margin = new Padding(20, 10, 0, 20);
            flpContent.Controls.Add(lblHeader);

            // --- B. Vẽ Mục "General" ---
            RenderSectionHeader("General / Thông tin chung");

            // Thẻ thông báo mẫu (Loại "announcement")
            RenderCard("Thông báo từ giảng viên", "Chào mừng các em đến với lớp học.", "announcement");

            // --- C. Vẽ Mục "Bài tập" ---
            RenderSectionHeader("Bài tập & Kiểm tra");

            // Tạo Label Loading
            Label lblLoading = new Label();
            lblLoading.Text = "⏳ Đang tải dữ liệu từ Firebase...";
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            lblLoading.AutoSize = true;
            lblLoading.Margin = new Padding(40);
            flpContent.Controls.Add(lblLoading);

            // Gọi hàm tải dữ liệu
            await LoadAssignmentsFromFirebase(lblLoading);
        }

        // --- HÀM 1: Vẽ tiêu đề từng phần (Section Header) ---
        private void RenderSectionHeader(string title)
        {
            Label lbl = new Label();
            lbl.Text = "▼ " + title;
            lbl.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.AutoSize = true;
            lbl.Margin = new Padding(20, 20, 0, 10);
            flpContent.Controls.Add(lbl);
        }

        // --- HÀM 2: Tải bài tập từ Firebase ---
        private async Task LoadAssignmentsFromFirebase(Label lblLoading)
        {
            try
            {
                // Gọi data dùng Class Model riêng của bạn
                var assignments = await _client
                    .Child("Assignments")
                    .Child(_courseId)
                    .OnceAsync<AssignmentModel>();

                // Xóa chữ Loading
                flpContent.Controls.Remove(lblLoading);

                if (assignments.Count == 0)
                {
                    Label lblEmpty = new Label { Text = "Chưa có bài tập nào.", ForeColor = Color.DimGray, AutoSize = true, Margin = new Padding(40, 0, 0, 0) };
                    flpContent.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var item in assignments)
                {
                    // Truyền "assignment" để code nhận biết đây là bài tập
                    RenderCard(
                        item.Object.Title,
                        item.Object.Description ?? "Không có mô tả",
                        "assignment",
                        item.Key
                    );
                }
            }
            catch (Exception ex)
            {
                lblLoading.Text = "❌ Lỗi tải: " + ex.Message;
                lblLoading.ForeColor = Color.Red;
            }
        }

        // --- HÀM 3: Vẽ Thẻ (Render Card UI) ---
        private void RenderCard(string title, string description, string type, string assignmentId = "")
        {
            // 1. Tạo Panel bao ngoài (Card)
            Panel pnlCard = new Panel();
            pnlCard.Width = flpContent.ClientSize.Width - 60; // Tự co giãn
            pnlCard.Height = 90;
            pnlCard.BackColor = Color.FromArgb(35, 35, 38);
            pnlCard.Margin = new Padding(30, 5, 30, 10);
            pnlCard.Cursor = Cursors.Hand;

            // Vẽ viền
            pnlCard.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pnlCard.ClientRectangle,
                    Color.FromArgb(60, 60, 60), ButtonBorderStyle.Solid);
            };

            // 2. Icon
            Label lblIcon = new Label();
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI Emoji", 24, FontStyle.Regular);
            lblIcon.Location = new Point(15, 20);

            if (type == "announcement")
            {
                lblIcon.Text = "📢";
                lblIcon.ForeColor = Color.Orange;
            }
            else // Trường hợp là "assignment"
            {
                lblIcon.Text = "📝";
                lblIcon.ForeColor = Color.HotPink;
            }

            // 3. Tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = title ?? "Bài tập không tên";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(70, 15);
            lblTitle.AutoSize = true;

            // 4. Mô tả
            Label lblDesc = new Label();
            lblDesc.Text = description ?? "Nhấn để xem chi tiết...";
            lblDesc.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.Location = new Point(70, 45);
            lblDesc.AutoSize = true;

            // 5. Sự kiện Click
            EventHandler clickAction = (s, e) =>
            {
                // Kiểm tra đúng loại "assignment" để mở Form
                if (type == "assignment")
                {
                    // Mở Form Nộp Bài
                    Submit_Agsignment submitForm = new Submit_Agsignment(
     title,          // Tên bài tập
     assignmentId,   // 🔥 ID bài tập
     _client,
     _courseId,
     _studentId
 );


                    submitForm.ShowDialog();
                }
                else
                {
                    // Nếu là thông báo thì chỉ hiện lên xem
                    MessageBox.Show(description, "Thông báo chung", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Gán sự kiện click cho toàn bộ thành phần trong thẻ
            pnlCard.Click += clickAction;
            lblTitle.Click += clickAction;
            lblIcon.Click += clickAction;
            lblDesc.Click += clickAction;

            // Add vào Panel
            pnlCard.Controls.Add(lblIcon);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblDesc);

            // Add vào FlowLayout
            flpContent.Controls.Add(pnlCard);
        }

        private void flpContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}