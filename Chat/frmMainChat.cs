using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Linq;

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
        private IDisposable _onlineStatusSubscription; // Lắng nghe online
        private System.Windows.Forms.Timer _typingTimer;

        // Dictionary để quản lý nhanh các Item theo UID
        private Dictionary<string, UC_UserContactItem> _contactItems = new Dictionary<string, UC_UserContactItem>();

        public frmMainChat(string uid, string hoTen, string idToken)
        {
            InitializeComponent();

            _currentUserUid = uid;
            _currentUserName = hoTen;
            _idToken = idToken;

            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
            _typingTimer = new System.Windows.Forms.Timer();
            _typingTimer.Interval = 1500;
            _typingTimer.Tick += TypingTimer_Tick;
            this.FormClosing += frmMainChat_FormClosing;

            btnSend.Click += btnSend_Click;
            txtMessage.KeyDown += txtMessage_KeyDown;

            if (guna2TextBox1_TextChanged != null)
                guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
        }

        private async void frmMainChat_Load(object sender, EventArgs e)
        {
            try
            {
                var allUsers = await _chatService.GetAllUsersAsync();
                flowUserListPanel.Controls.Clear();
                _contactItems.Clear();

                foreach (var entry in allUsers)
                {
                    string uid = entry.Key;
                    User user = entry.Value;

                    if (uid == _currentUserUid) continue;

                    UC_UserContactItem contactItem = new UC_UserContactItem();
                    contactItem.Width = flowUserListPanel.ClientSize.Width - 25;

                    contactItem.SetData(
                        uid: uid,
                        hoTen: user.HoTen,
                        email: user.Email,
                        role: user.Role,
                        lastMessage: "Nhấn để chat...",
                        timestamp: "",
                        unreadCount: 0
                    );

                    // Set trạng thái online ban đầu
                    contactItem.SetOnlineStatus(user.IsOnline);

                    contactItem.UserClicked += ContactItem_Clicked;
                    flowUserListPanel.Controls.Add(contactItem);

                    // Thêm vào Dictionary để quản lý realtime
                    _contactItems[uid] = contactItem;
                }

                // Bắt đầu lắng nghe thay đổi trạng thái online từ Firebase
                ListenForOnlineStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void ListenForOnlineStatus()
        {
            // Sử dụng FirebaseClient trực tiếp để lắng nghe node Users
            var client = new FirebaseClient(FIREBASE_URL, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
            });

            _onlineStatusSubscription = client
                .Child("Users")
                .AsObservable<User>()
                .Subscribe(item => {
                    if (_contactItems.ContainsKey(item.Key))
                    {
                        // Cập nhật đèn trạng thái cho đúng item trong danh sách
                        _contactItems[item.Key].SetOnlineStatus(item.Object.IsOnline);
                    }
                });
        }

        private void ContactItem_Clicked(object sender, EventArgs e)
        {
            UC_UserContactItem clickedItem = (UC_UserContactItem)sender;

            // 1. "Bỏ chọn" TẤT CẢ item thông qua Dictionary
            foreach (var item in _contactItems.Values)
            {
                item.SetSelected(false);
            }

            // 2. "Chọn" item vừa click
            clickedItem.SetSelected(true);

            // 3. Dọn dẹp Subscription cũ
            _messageSubscription?.Dispose();

            // 4. Dọn dẹp Khung Chat
            flowChatPanel.Controls.Clear();

            // 5. Cập nhật "người đang chat"
            _currentPartnerUid = clickedItem.UserId;
            _currentChatId = _chatService.GenerateChatId(_currentUserUid, _currentPartnerUid);

            // 6. Cập nhật Thông tin
            lblInfoName.Text = clickedItem.HoTen;
            lblInfoEmail.Text = clickedItem.Email;
            lblInfoRole.Text = clickedItem.Role;

            // 7. Mở đường dây nóng mới
            _messageSubscription = _chatService.ListenForMessages(_currentChatId, DisplayMessageAsBubble);

            // 8. Bật ô gõ phím
            panelInput.Enabled = true;
            txtMessage.Focus();
        }

        // --- CÁC PHẦN DƯỚI ĐÂY GIỮ NGUYÊN NHƯ CODE CŨ CỦA BẠN ---

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || _currentPartnerUid == null) return;

            var message = new Message
            {
                SenderUid = _currentUserUid,
                SenderName = _currentUserName,
                Text = text,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Status = "sent"
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
                bubble.SetMessage(msg.Text, isMe, msg.Status ?? "sent");
                flowChatPanel.Controls.Add(bubble);
                flowChatPanel.ScrollControlIntoView(bubble);
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(null, null);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim().ToLower();
            flowUserListPanel.SuspendLayout();
            foreach (var item in _contactItems.Values)
            {
                bool match = (item.HoTen?.ToLower().Contains(keyword) ?? false) ||
                             (item.Email?.ToLower().Contains(keyword) ?? false);
                item.Visible = match;
            }
            flowUserListPanel.ResumeLayout();
        }

        private void frmMainChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _messageSubscription?.Dispose();
            _onlineStatusSubscription?.Dispose(); // Hủy lắng nghe online
        }

        private void TypingTimer_Tick(object sender, EventArgs e) { }
        private void lblInfoEmail_Click(object sender, EventArgs e) { }
        private void lblInfoName_Click(object sender, EventArgs e) { }
        private void flowUserListPanel_Paint(object sender, PaintEventArgs e) { }
        private void panelContacts_Paint(object sender, PaintEventArgs e) { }
    }
}