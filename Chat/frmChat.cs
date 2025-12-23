using System;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class frmChat : Form
    {
        // === Thông tin này sẽ được truyền vào khi mở form chat ===
        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _partnerUid;

        // === THÊM BIẾN NÀY VÀO ===
        private readonly string _idToken; // "Vé vào cửa"

        // ===
        private readonly FirebaseChatService _chatService;
        private readonly string _chatId;
        private IDisposable _messageSubscription; // Biến để "hủy" lắng nghe

        private const string FIREBASE_URL = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        // === SỬA HÀM CONSTRUCTOR (Thêm tham số idToken) ===
        public frmChat(string currentUserUid, string currentUserName, string partnerUid, string partnerName, string idToken)
        {
            InitializeComponent();

            // 1. Lưu thông tin
            _currentUserUid = currentUserUid;
            _currentUserName = currentUserName;
            _partnerUid = partnerUid;
            _idToken = idToken; // <-- LƯU LẠI "VÉ"

            // 2. Đặt tiêu đề form
            this.Text = $"Chat với {partnerName}";

            // 3. === SỬA DÒNG LỖI: Truyền "vé" cho Service ===
            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
            _chatId = _chatService.GenerateChatId(_currentUserUid, _partnerUid);
        }

        // Sự kiện Form Load
        private void frmChat_Load(object sender, EventArgs e)
        {
            // 4. Bắt đầu "Lắng nghe" tin nhắn
            _messageSubscription = _chatService.ListenForMessages(_chatId, DisplayMessageAsBubble);

            // Tùy chỉnh (để control con tự co giãn theo chiều rộng)
            flowChatPanel.ControlAdded += (s, ev) =>
            {
                ev.Control.Width = flowChatPanel.ClientSize.Width - 25;
            };
        }

        // Sự kiện Nút Gửi
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            // 5. Tạo đối tượng tin nhắn
            var message = new Message
            {
                SenderUid = _currentUserUid,
                SenderName = _currentUserName,
                Text = text,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };

            try
            {
                // 6. Gửi tin nhắn
                await _chatService.SendMessageAsync(_chatId, message);
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message);
            }
        }

        // === HÀM HIỂN THỊ BONG BÓNG MỚI (Giữ nguyên) ===
        private void DisplayMessageAsBubble(Message msg)
        {
            if (flowChatPanel.InvokeRequired)
            {
                flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubble(msg)));
            }
            else
            {
                UC_ChatItem bubble = new UC_ChatItem();
                bubble.Width = flowChatPanel.ClientSize.Width - 25;

                bool isMe = (msg.SenderUid == _currentUserUid);

                // --- SỬA DÒNG NÀY ---
                // Lấy status từ tin nhắn, nếu null (tin cũ) thì mặc định là "sent"
                string trangThai = msg.Status ?? "sent";

                // Gọi đủ 3 tham số: Text, isMe, Status
                bubble.SetMessage(msg.Text, isMe, trangThai);
                // --------------------

                flowChatPanel.Controls.Add(bubble);
                flowChatPanel.ScrollControlIntoView(bubble);
            }
        }

        // 7. Hủy lắng nghe khi đóng form (Giữ nguyên)
        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _messageSubscription?.Dispose();
        }

        // Hàm rỗng (Giữ nguyên)
        private void flowChatPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}