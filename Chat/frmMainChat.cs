using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Firebase.Database;
using System.Threading.Tasks; 

namespace APP_DOAN
{
    public partial class frmMainChat : Form
    {
        private FirebaseChatService _chatService;
        private const string FIREBASE_URL = "https://nt106-minhduc-default-rtdb.firebaseio.com/";


        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _idToken;

        private string _currentPartnerUid = null;
        private string _currentChatId = null;


        private IDisposable _messageSubscription;

        public frmMainChat(string uid, string hoTen, string idToken)
        {
            InitializeComponent();
            _currentUserUid = uid;
            _currentUserName = hoTen;
            _idToken = idToken;


            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
        }

        private async void frmMainChat_Load(object sender, EventArgs e)
        {

            try
            {
                var allUsers = await _chatService.GetAllUsersAsync();
                foreach (var entry in allUsers)
                {
                    string uid = entry.Key;
                    User user = entry.Value;

                    if (uid == _currentUserUid) continue; // Bỏ qua chính mình

                    UC_UserContactItem contactItem = new UC_UserContactItem();
                    contactItem.Width = flowUserListPanel.ClientSize.Width - 25;

                    // "Bơm" dữ liệu
                    contactItem.SetData(
                    uid: uid,
                    hoTen: user.HoTen,
                    email: user.Email,   
                    role: user.Role,     
                    lastMessage: "Nhấn để chat...", 
                    timestamp: "", 
                    unreadCount: 0
                );

                    // Gắn sự kiện Click
                    contactItem.UserClicked += ContactItem_Clicked;
                    flowUserListPanel.Controls.Add(contactItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void ContactItem_Clicked(object sender, EventArgs e)
        {
            UC_UserContactItem clickedItem = (UC_UserContactItem)sender;

            // --- BƯỚC NÂNG CẤP HIỆU ỨNG ---
            // 1. "Bỏ chọn" TẤT CẢ item khác
            foreach (Control ctrl in flowUserListPanel.Controls)
            {
                if (ctrl is UC_UserContactItem item)
                {
                    item.Deselect();
                }
            }
            // 2. "Chọn" item vừa click
            clickedItem.Select();
            // --- KẾT THÚC NÂNG CẤP ---


            // 3. Dọn dẹp "đường dây nóng" cũ
            _messageSubscription?.Dispose();

            // 4. Dọn dẹp Cột 2 (Khung Chat)
            flowChatPanel.Controls.Clear();

            // 5. Cập nhật "người đang chat"
            _currentPartnerUid = clickedItem.UserId;
            _currentChatId = _chatService.GenerateChatId(_currentUserUid, _currentPartnerUid);

            // 6. Cập nhật Cột 3 (Thông tin)
            lblInfoName.Text = clickedItem.HoTen;
            lblInfoEmail.Text = clickedItem.Email;
            lblInfoRole.Text = clickedItem.Role;

            // 7. Mở "đường dây nóng" MỚI
            _messageSubscription = _chatService.ListenForMessages(_currentChatId, DisplayMessageAsBubble);

            // 8. Bật ô gõ phím
            panelInput.Enabled = true;
            txtMessage.Focus();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || _currentPartnerUid == null)
            {
                return;
            }

            var message = new Message
            {
                SenderUid = _currentUserUid,
                SenderName = _currentUserName,
                Text = text,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };

            try
            {
                await _chatService.SendMessageAsync(_currentChatId, message);
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message);
            }
        }

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
                bubble.SetMessage(msg.Text, isMe);
                flowChatPanel.Controls.Add(bubble);
                flowChatPanel.ScrollControlIntoView(bubble);
            }
        }

        private void frmMainChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dọn dẹp khi đóng Form
            _messageSubscription?.Dispose();
        }

        private void lblInfoEmail_Click(object sender, EventArgs e)
        {
            lblInfoEmail.Text = _currentUserName;
        }

        private void lblInfoName_Click(object sender, EventArgs e)
        {
            lblInfoName.Text = _currentUserName;
        }

        // (Xóa hàm flowUserListPanel_Paint rỗng)
    }
}