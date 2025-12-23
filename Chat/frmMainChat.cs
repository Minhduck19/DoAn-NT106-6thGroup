using System;
using System.Collections.Generic;
using System.Drawing; // Cần thêm cái này để dùng Point
using System.Windows.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class frmMainChat : Form
    {
        private FirebaseChatService _chatService;
        private const string FIREBASE_URL = "https://nt106-minhduc-default-rtdb.firebaseio.com/";
        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _idToken;
        private IDisposable _userStatusSubscription;

        private IDisposable _messageSubscription;
        private System.Windows.Forms.Timer _typingTimer; // Timer để tắt trạng thái typing
        private IDisposable _typingSubscription; // Để hủy lắng nghe typing
        public frmMainChat(string currentUserUid, string currentUserName, string idToken)
        {
            InitializeComponent();

            _currentUserUid = currentUserUid;
            _currentUserName = currentUserName;
            _idToken = idToken;

            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
            _typingTimer = new System.Windows.Forms.Timer();
            _typingTimer.Interval = 1500;
            _typingTimer.Tick += TypingTimer_Tick;

            // Gắn sự kiện thủ công (đề phòng chú em quên gắn bên Designer)
            this.Load += frmMainChat_Load;
            this.FormClosing += frmMainChat_FormClosing;

            // Sự kiện nút Gửi
            btnSend.Click += btnSend_Click;

            // [NÂNG CẤP 2] Sự kiện Enter để gửi
            txtMessage.KeyDown += txtMessage_KeyDown;

            // [NÂNG CẤP 4] Sự kiện Tìm kiếm
            // Chú ý: Đảm bảo chú đã thêm TextBox tên là 'txtSearchUser' vào Form
            if (guna2TextBox1_TextChanged != null)
                guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
        }
        // Khi Timer chạy hết 1.5s -> Tắt trạng thái typing
        private async void TypingTimer_Tick(object sender, EventArgs e)
        {
            _typingTimer.Stop();
            if (_currentChatId != null)
            {
                await _chatService.SetTypingStatusAsync(_currentChatId, _currentUserUid, false);
            }
        }

        // Xử lý sự kiện gõ phím (TextChanged của txtMessage)
        private async void txtMessage_TextChanged(object sender, EventArgs e)
        {
            // Nếu ô chat trống -> tắt typing ngay
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                _typingTimer.Stop();
                if (_currentChatId != null)
                    await _chatService.SetTypingStatusAsync(_currentChatId, _currentUserUid, false);
                return;
            }

            // Nếu đang gõ -> Gửi signal True lên Firebase
            if (_currentChatId != null)
            {
                // Reset timer (đếm lại từ đầu)
                _typingTimer.Stop();
                _typingTimer.Start();

                // Gọi service báo "Tao đang gõ nè"
                await _chatService.SetTypingStatusAsync(_currentChatId, _currentUserUid, true);
            }
        }

        // Hàm hiển thị trạng thái "Đang nhập..." (Sẽ được gọi từ Service)
        private void UpdateTypingStatusUI(bool isTyping)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateTypingStatusUI(isTyping)));
                return;
            }

            if (isTyping)
            {
                // Hiện chữ "Đang nhập..." (Chú em có thể dùng 1 Label nhỏ dưới tên user)
                lblInfoRole.Text = "Đang nhập...";
                lblInfoRole.ForeColor = Color.Green;
            }
            else
            {
                // Trả lại trạng thái cũ
                lblInfoRole.Text = "Offline"; // Hoặc lấy role cũ
                lblInfoRole.ForeColor = Color.Gray;
            }
        }
        private async void frmMainChat_Load(object sender, EventArgs e)
        {
            // Load tất cả user
            var users = await _chatService.GetAllUsersAsync();
            foreach (var kv in users)
            {
                if (kv.Key == _currentUserUid) continue; // bỏ qua bản thân

                UC_UserContactItem item = new UC_UserContactItem();
                item.SetData(kv.Key, kv.Value.HoTen, kv.Value.Email, kv.Value.Role, "", "", 0);
                flowUserListPanel.Controls.Add(item);
            }

            // Lắng nghe trạng thái online/offline
            _userStatusSubscription = _chatService.ListenForUserStatus((uid, isOnline) =>
            {
                var userControl = flowUserListPanel.Controls
                    .OfType<UC_UserContactItem>()
                    .FirstOrDefault(u => u.UserId == uid);

                if (userControl != null)
                    userControl.SetOnlineStatus(isOnline);
            });

            // Đặt bản thân online
            await _chatService.UpdateUserOnlineStatus(_currentUserUid, true);
        }

        private async void frmMainChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _userStatusSubscription?.Dispose();
            await _chatService.UpdateUserOnlineStatus(_currentUserUid, false);
        }

        private void flowUserListPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        // [NÂNG CẤP 2] Gửi bằng phím Enter
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Chặn tiếng bíp
                btnSend.PerformClick();    // Gọi hàm click
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || _currentPartnerUid == null) return;

            var message = new Message
            {
                SenderUid = _currentUserUid,
                SenderName = _currentUserName,
                Text = text,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };

            try
            {
                // Xóa text trước cho cảm giác nhanh (Optimistic UI)
                txtMessage.Clear();
                txtMessage.Focus();

                await _chatService.SendMessageAsync(_currentChatId, message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin: " + ex.Message);
            }
        }

        private void DisplayMessageAsBubble(Message msg)
        {
            if (msg == null) return;

            if (flowChatPanel.InvokeRequired)
            {
                flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubble(msg)));
            }
            else
            {
                // 1. TÌM KIẾM XEM TIN NHẮN NÀY ĐÃ TỒN TẠI TRÊN MÀN HÌNH CHƯA?
                UC_ChatItem existingBubble = null;

                // Duyệt ngược từ dưới lên cho nhanh (vì tin mới thường ở cuối)
                for (int i = flowChatPanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (flowChatPanel.Controls[i] is UC_ChatItem item && item.MessageID == msg.Key)
                    {
                        existingBubble = item;
                        break;
                    }
                }

                bool isMe = (msg.SenderUid == _currentUserUid);
                string status = msg.Status ?? "sent";

                // --- LOGIC ĐÁNH DẤU ĐÃ XEM (GIỮ NGUYÊN) ---
                if (!isMe && status != "read" && !string.IsNullOrEmpty(msg.Key))
                {
                    Task.Run(() => _chatService.MarkMessageAsReadAsync(_currentChatId, msg.Key));
                }

                // 2. XỬ LÝ HIỂN THỊ
                if (existingBubble != null)
                {
                    // A. NẾU ĐÃ CÓ -> CHỈ UPDATE STATUS (Không vẽ lại cả bong bóng -> Đỡ lag)
                    existingBubble.UpdateStatus(status);
                }
                else
                {
                    // B. NẾU CHƯA CÓ -> TẠO MỚI (Logic cũ)
                    UC_ChatItem bubble = new UC_ChatItem();

                    // Lưu ID để sau này còn tìm lại mà update
                    bubble.MessageID = msg.Key;

                    bubble.Width = flowChatPanel.ClientSize.Width - 25;
                    bubble.SetMessage(msg.Text, isMe, status);

                    flowChatPanel.Controls.Add(bubble);

                    // Auto scroll xuống dưới cùng
                    try { flowChatPanel.ScrollControlIntoView(bubble); } catch { }
                }
            }
        }


        private void frmMainChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _messageSubscription?.Dispose();
            _typingSubscription?.Dispose();

            // Dừng và hủy timer
            if (_typingTimer != null)
            {
                _typingTimer.Stop();
                _typingTimer.Dispose();
            }
        }

        // Các hàm label click thừa có thể xóa hoặc giữ tùy chú
        private void lblInfoEmail_Click(object sender, EventArgs e) { }
        private void lblInfoName_Click(object sender, EventArgs e) { }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.ToLower().Trim();
            flowUserListPanel.SuspendLayout();

            foreach (Control ctrl in flowUserListPanel.Controls)
            {
                if (ctrl is UC_UserContactItem item)
                {
                    // Logic tìm kiếm: So sánh tên hoặc email
                    // Yêu cầu: UC_UserContactItem phải public biến HoTen và Email
                    bool match = item.HoTen.ToLower().Contains(keyword) ||
                                 item.Email.ToLower().Contains(keyword);
                    item.Visible = match;
                }
            }
            flowUserListPanel.ResumeLayout();
        }
    }
}
