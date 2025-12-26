using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Diagnostics;

namespace APP_DOAN
{
    public partial class frmMainChat : Form
    {
        private FirebaseChatService _chatService;
        private const string FIREBASE_URL = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _idToken;

        private string? _currentPartnerUid = null;
        private string? _currentChatId = null;

        private IDisposable? _messageSubscription;
        private System.Windows.Forms.Timer _typingTimer;

        private long? _previousMessageTimestamp = null;

        private Dictionary<string, long> _userLastMessageTime = new Dictionary<string, long>();
        
        // *** FIX: Thêm cache tin nhắn ***
        private Dictionary<string, List<Message>> _messageCache = new Dictionary<string, List<Message>>();
        private Dictionary<string, long> _chatLastLoadTime = new Dictionary<string, long>();

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

            // Sự kiện nút Gửi
            btnSend.Click += btnSend_Click;

            // [NÂNG CẤP 2] Sự kiện Enter để gửi
            txtMessage.KeyDown += txtMessage_KeyDown;

            // [NÂNG CẤP 4] Sự kiện Tìm kiếm
            if (guna2TextBox1_TextChanged != null)
                guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            
            SetupAutoScroll();
        }

        private async void frmMainChat_Load(object sender, EventArgs e)
        {
            // Set width cho item mỗi khi load
            flowUserListPanel.ControlAdded += (s, ev) =>
            {
                if (ev.Control is UC_UserContactItem contactItem)
                {
                    AdjustContactItemWidth(contactItem);
                }
            };

            try
            {
                var allUsers = await _chatService.GetAllUsersAsync();
                foreach (var entry in allUsers)
                {
                    string uid = entry.Key;
                    User user = entry.Value;

                    if (uid == _currentUserUid) continue;

                    UC_UserContactItem contactItem = new UC_UserContactItem();
                    AdjustContactItemWidth(contactItem);

                    contactItem.SetData(
                        uid: uid,
                        hoTen: user.HoTen,
                        email: user.Email,
                        role: user.Role,
                        lastMessage: "Nhấn để chat...",
                        timestamp: "",
                        unreadCount: 0
                    );

                    contactItem.UserClicked += ContactItem_Clicked;
                    contactItem.Tag = uid;
                    flowUserListPanel.Controls.Add(contactItem);
            
                    _userLastMessageTime[uid] = 0;
                }

                // *** FIX: Load tất cả tin nhắn vào cache lần đầu ***
                var userList = flowUserListPanel.Controls.Cast<Control>()
                    .OfType<UC_UserContactItem>()
                    .ToList();

                foreach (var contactItem in userList)
                {
                    string? uid = contactItem.Tag?.ToString();
                    if (!string.IsNullOrEmpty(uid))
                    {
                        await LoadAndCacheAllMessagesAsync(uid, contactItem);
                    }
                }
        
                // *** FIX: Sắp xếp lại danh sách user theo thứ tự mới nhất sau khi load tất cả tin nhắn ***
                ReorderContactList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        // Hàm helper để adjust chiều rộng
        private void AdjustContactItemWidth(UC_UserContactItem contactItem)
        {
            contactItem.Width = flowUserListPanel.ClientSize.Width - 20;  // -20 để account cho scrollbar
            contactItem.AutoSize = false;
        }

        // [MỚI] Refresh dữ liệu trò chuyện mỗi khi vào phần chat
        private async Task RefreshChatDataAsync()
        {
            try
            {
                // Refresh tin nhắn gần đây nhất cho tất cả liên hệ
                foreach (Control control in flowUserListPanel.Controls)
                {
                    if (control is UC_UserContactItem contactItem)
                    {
                        string? uid = contactItem.UserId ?? contactItem.Tag?.ToString();
                        if (!string.IsNullOrEmpty(uid))
                        {
                            await LoadLatestMessageAsync(uid, contactItem);
                        }
                    }
                }

                // Nếu đang chat với ai đó, refresh tin nhắn trong cuộc trò chuyện hiện tại
                if (!string.IsNullOrEmpty(_currentChatId))
                {
                    _messageSubscription?.Dispose();
                    flowChatPanel.Controls.Clear();
                    _previousMessageTimestamp = null;
                    _messageSubscription = _chatService.ListenForMessages(_currentChatId, DisplayMessageAsBubble);
                }

                // Sắp xếp lại danh sách liên hệ theo tin nhắn mới nhất
                ReorderContactList();
            }
            catch
            {
                // Log lỗi nếu cần, không làm gián đoạn UI
            }
        }

        private async Task LoadLatestMessageAsync(string partnerId, UC_UserContactItem contactItem)
        {
            try
            {
                string chatId = _chatService.GenerateChatId(_currentUserUid, partnerId);

                var messages = await _chatService.GetMessagesAsync(chatId);

                if (messages.Any())
                {
                    var latestMsg = messages.OrderByDescending(m => m.Timestamp).First();
                    contactItem.SetData(
                        uid: partnerId,
                        hoTen: contactItem.HoTen,
                        email: contactItem.Email,
                        role: contactItem.Role,
                        lastMessage: latestMsg.Text,
                        timestamp: ConvertTimestampToTime(latestMsg.Timestamp),
                        unreadCount: 0
                    );

                    _userLastMessageTime[partnerId] = latestMsg.Timestamp;
                    
                    // KHÔNG gọi ReorderContactList() ở đây!
                }
            }
            catch
            {
                // Log lỗi nếu cần, không làm gián đoạn UI
            }
        }

        private string ConvertTimestampToTime(long timestamp)
        {
            // *** FIX: Dùng UTC DateTime (1970-01-01 UTC) thay vì local time ***
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timestamp);
            // *** FIX: Chuyển sang múi giờ địa phương ***
            var localDateTime = dateTime.ToLocalTime();
            return localDateTime.ToString("HH:mm");
        }

        private void ContactItem_Clicked(object? sender, EventArgs e)
        {
            if (sender is not UC_UserContactItem clickedItem)
                return;

            foreach (Control ctrl in flowUserListPanel.Controls)
            {
                if (ctrl is UC_UserContactItem item)
                {
                    item.SetSelected(false);
                }
            }

            clickedItem.SetSelected(true);
            
            // *** FIX: Dọn dẹp subscription cũ ***
            if (_messageSubscription != null)
            {
                _messageSubscription.Dispose();
                _messageSubscription = null;
            }
            
            flowChatPanel.Controls.Clear();

            _currentPartnerUid = clickedItem.UserId;
            _currentChatId = _chatService.GenerateChatId(_currentUserUid, _currentPartnerUid);

            lblInfoName.Text = clickedItem.HoTen;
            lblInfoEmail.Text = clickedItem.Email;
            lblInfoRole.Text = clickedItem.Role;

            _previousMessageTimestamp = null;

            // *** FIX: Bật khung nhập tin nhắn ***
            panelInput.Enabled = true;

            // *** FIX: Hiển thị tin nhắn từ cache ngay lập tức ***
            DisplayCachedMessagesAndListenForNew();
        }

        // *** FIX: Hiển thị tin nhắn từ cache và lắng nghe tin nhắn mới ***
        private void DisplayCachedMessagesAndListenForNew()
        {
            try
            {
                if (string.IsNullOrEmpty(_currentChatId))
                    return;

                // Hiển thị tin nhắn từ cache
                if (_messageCache.ContainsKey(_currentChatId))
                {
                    var cachedMessages = _messageCache[_currentChatId];
                    foreach (var msg in cachedMessages)
                    {
                        DisplayMessageAsBubbleWithoutReorder(msg);
                    }
                    Debug.WriteLine($"Displayed {cachedMessages.Count} cached messages");
                }

                // Lắng nghe tin nhắn mới từ hiện tại
                _messageSubscription = _chatService.ListenForMessages(_currentChatId, DisplayMessageAsBubble);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void DisplayMessageAsBubbleWithoutReorder(Message msg)
        {
            if (flowChatPanel.InvokeRequired)
            {
                flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubbleWithoutReorder(msg)));
            }
            else
            {
                UC_ChatItem bubble = new UC_ChatItem();
                bubble.Width = flowChatPanel.ClientSize.Width - 25;
                bool isMe = (msg.SenderUid == _currentUserUid);
                string trangThai = msg.Status ?? "sent";
                string type = msg.Type ?? "text";
                
                // *** FIX: Set MessageId để phát hiện duplicate sau này ***
                bubble.MessageId = GenerateMessageId(msg);
                
                bubble.SetMessage(msg.Text, isMe, trangThai, type, msg.Timestamp, _previousMessageTimestamp);
                
                _previousMessageTimestamp = msg.Timestamp;
                
                flowChatPanel.Controls.Add(bubble);
                flowChatPanel.ScrollControlIntoView(bubble);
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
                // *** FIX: Kiểm tra tin nhắn này đã tồn tại chưa (để tránh load 2 lần) ***
                bool messageExists = flowChatPanel.Controls.Cast<Control>()
                    .OfType<UC_ChatItem>()
                    .Any(bubble => bubble.MessageId == GenerateMessageId(msg));

                if (messageExists)
                {
                    Debug.WriteLine($"Message {GenerateMessageId(msg)} already exists, skipping...");
                    return;
                }

                UC_ChatItem newBubble = new UC_ChatItem();
                newBubble.Width = flowChatPanel.ClientSize.Width - 25;
                bool isMe = (msg.SenderUid == _currentUserUid);
                string trangThai = msg.Status ?? "sent";
                string type = msg.Type ?? "text";
                
                newBubble.MessageId = GenerateMessageId(msg);
                newBubble.SetMessage(msg.Text, isMe, trangThai, type, msg.Timestamp, _previousMessageTimestamp);
                
                _previousMessageTimestamp = msg.Timestamp;
                
                flowChatPanel.Controls.Add(newBubble);
                flowChatPanel.ScrollControlIntoView(newBubble);
                
                // CẬP NHẬT THỜI GIAN TIN NHẮN CUỐI CÙNG VÀ SẮP XẾP LẠI DANH SÁCH LIÊN HỆ
                if (!string.IsNullOrEmpty(_currentPartnerUid))
                {
                    _userLastMessageTime[_currentPartnerUid] = msg.Timestamp;
                    
                    // *** FIX: Đảm bảo chạy trên UI thread và cập nhật cache ***
                    if (flowUserListPanel.InvokeRequired)
                    {
                        flowUserListPanel.Invoke(new Action(() => 
                        {
                            UpdateContactItemWithLatestMessage(_currentPartnerUid, msg);
                            ReorderContactList();
                        }));
                    }
                    else
                    {
                        UpdateContactItemWithLatestMessage(_currentPartnerUid, msg);
                        ReorderContactList();
                    }
                }
            }
        }

        // *** FIX: Hàm mới để cập nhật user item với tin nhắn mới nhất ***
        private void UpdateContactItemWithLatestMessage(string partnerId, Message msg)
        {
            // Tìm user item trong danh sách
            var contactItem = flowUserListPanel.Controls.Cast<Control>()
                .OfType<UC_UserContactItem>()
                .FirstOrDefault(item => item.Tag?.ToString() == partnerId);

            if (contactItem != null)
            {
                string timeStr = ConvertTimestampToTime(msg.Timestamp);
                
                // Cập nhật thông tin với tin nhắn mới nhất
                contactItem.SetData(
                    uid: partnerId,
                    hoTen: contactItem.HoTen,
                    email: contactItem.Email,
                    role: contactItem.Role,
                    lastMessage: msg.Text,
                    timestamp: timeStr,
                    unreadCount: 0
                );
                
                Debug.WriteLine($"Updated {contactItem.HoTen}: '{msg.Text}' at {timeStr}");
                
                // *** FIX: Refresh UI ngay lập tức ***
                contactItem.Invalidate();
            }
        }

        private void ReorderContactList()
        {
            // Sắp xếp các contact theo thời gian tin nhắn cuối cùng (mới nhất trước)
            var sortedContacts = flowUserListPanel.Controls.Cast<Control>()
                .Where(c => c is UC_UserContactItem)
                .Cast<UC_UserContactItem>()
                .OrderByDescending(c => 
                {
                    string? uid = c.Tag?.ToString();
                    return uid != null && _userLastMessageTime.ContainsKey(uid) ? _userLastMessageTime[uid] : 0;
                })
                .ToList();

            // Xóa tất cả controls hiện tại
            flowUserListPanel.Controls.Clear();
            
            // *** FIX: Suspend layout để tránh flicker ***
            flowUserListPanel.SuspendLayout();
            
            // Thêm lại theo thứ tự mới và adjust width
            foreach (var contact in sortedContacts)
            {
                AdjustContactItemWidth(contact);
                flowUserListPanel.Controls.Add(contact);
            }
            
            // *** FIX: Resume layout ***
            flowUserListPanel.ResumeLayout();
        }

        private async void btnSend_Click(object? sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(_currentPartnerUid))
            {
                return;
            }

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

        private void TypingTimer_Tick(object? sender, EventArgs e)
        {
            // Tắt trạng thái typing sau 1.5s
        }

        private void txtMessage_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(null, EventArgs.Empty);
            }
        }

        private void guna2TextBox1_TextChanged(object? sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim().ToLower();

            flowUserListPanel.SuspendLayout(); // Tối ưu hiệu suất vẽ

            foreach (Control control in flowUserListPanel.Controls)
            {
                if (control is UC_UserContactItem item)
                {
                    bool matchName = item.HoTen != null && item.HoTen.ToLower().Contains(keyword);
                    bool matchEmail = item.Email != null && item.Email.ToLower().Contains(keyword);

                    item.Visible = matchName || matchEmail;
                }
            }

            flowUserListPanel.ResumeLayout();
        }

        private void frmMainChat_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Dọn dẹp khi đóng Form
            _messageSubscription?.Dispose();
        }

        private void lblInfoEmail_Click(object? sender, EventArgs e)
        {
            lblInfoEmail.Text = _currentUserName;
        }

        private void lblInfoName_Click(object? sender, EventArgs e)
        {
            lblInfoName.Text = _currentUserName;
        }

        private void flowUserListPanel_Paint(object? sender, PaintEventArgs e)
        {
        }

        private void panelContacts_Paint(object? sender, PaintEventArgs e)
        {
        }

        private void txtMessage_TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentChatId))
            {
                _ = _chatService.SetTypingStatus(_currentChatId, _currentUserUid, true);
            }

            _typingTimer.Stop();
            _typingTimer.Start();
        }
        
        private void typingTimer_Tick(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentChatId))
            {
                _ = _chatService.SetTypingStatus(_currentChatId, _currentUserUid, false);
            }
            _typingTimer.Stop();
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            txtMessage.Focus();
            SendKeys.Send("^{.}");
        }
        
        private void SetupAutoScroll()
        {
            flowChatPanel.ControlAdded += (s, ev) =>
            {
                flowChatPanel.ScrollControlIntoView(ev.Control);
            };
        }

        private void btnSend_Click_1(object? sender, EventArgs e)
        {
        }

        private async void btnUpload_Click_1(object? sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // *** FIX: Kiểm tra xem đã chọn user chưa ***
                    if (string.IsNullOrEmpty(_currentPartnerUid) || string.IsNullOrEmpty(_currentChatId))
                    {
                        MessageBox.Show("Vui lòng chọn một người để chat trước khi gửi ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    panelInput.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    // 1. Upload ảnh qua CloudinaryHelper
                    string? imageUrl = CloudinaryHelper.UploadImage(open.FileName);

                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        MessageBox.Show("Không thể upload ảnh. Vui lòng thử lại.", "Lỗi Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Gửi tin nhắn với Type = "image"
                    var msg = new Message
                    {
                        SenderUid = _currentUserUid,
                        SenderName = _currentUserName,
                        Text = imageUrl,
                        Type = "image",
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                        Status = "sent"
                    };

                    await _chatService.SendMessageAsync(_currentChatId, msg);
                    // *** FIX: Xóa MessageBox "Gửi ảnh thành công" ***
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panelInput.Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
        }

        private string GenerateMessageId(Message msg)
        {
            // Compose a unique ID for the message based on its properties
            // (adjust as needed to match your actual message uniqueness logic)
            return $"{msg.SenderUid}_{msg.Timestamp}";
        }

        // *** FIX: Load tất cả tin nhắn và cache lại ***
        private async Task LoadAndCacheAllMessagesAsync(string partnerId, UC_UserContactItem contactItem)
        {
            try
            {
                string chatId = _chatService.GenerateChatId(_currentUserUid, partnerId);

                var messages = await _chatService.GetMessagesAsync(chatId);

                // Cache tin nhắn
                if (!_messageCache.ContainsKey(chatId))
                {
                    _messageCache[chatId] = new List<Message>();
                }
                _messageCache[chatId] = messages.ToList();
                _chatLastLoadTime[chatId] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                if (messages.Any())
                {
                    var latestMsg = messages.OrderByDescending(m => m.Timestamp).First();
                    contactItem.SetData(
                        uid: partnerId,
                        hoTen: contactItem.HoTen,
                        email: contactItem.Email,
                        role: contactItem.Role,
                        lastMessage: latestMsg.Text,
                        timestamp: ConvertTimestampToTime(latestMsg.Timestamp),
                        unreadCount: 0
                    );

                    _userLastMessageTime[partnerId] = latestMsg.Timestamp;
                }
            }
            catch
            {
                // Log lỗi nếu cần
            }
        }
    }
}