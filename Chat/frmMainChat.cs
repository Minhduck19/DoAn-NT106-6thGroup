using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Drawing; // Thêm để dùng Point, Color, Image

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

        // Các biến Cache và theo dõi trạng thái
        private Dictionary<string, long> _userLastMessageTime = new Dictionary<string, long>();
        private Dictionary<string, List<Message>> _messageCache = new Dictionary<string, List<Message>>();
        private Dictionary<string, long> _chatLastLoadTime = new Dictionary<string, long>();

        private int _chatViewportWidth = 0;

        // Biến quan trọng để tránh spam update seen liên tục
        private readonly HashSet<string> _seenUpdatedKeys = new HashSet<string>();

        public frmMainChat(string uid, string hoTen, string idToken)
        {
            InitializeComponent();

            _currentUserUid = uid;
            _currentUserName = hoTen;
            _idToken = idToken;

            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
            _typingTimer = new System.Windows.Forms.Timer();
            _typingTimer.Interval = 1500;
            _typingTimer.Tick += typingTimer_Tick; // Sửa tên hàm cho khớp
            this.FormClosing += frmMainChat_FormClosing;

            btnSend.Click += btnSend_Click;
            btnUpload.Click += btnUpload_Click_1;
            txtMessage.KeyDown += txtMessage_KeyDown;

            // Sự kiện gõ text để đổi trạng thái typing
            txtMessage.TextChanged += txtMessage_TextChanged;

            if (guna2TextBox1 != null)
                guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;

            SetupAutoScroll();
        }

        private async void frmMainChat_Load(object sender, EventArgs e)
        {
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
                        unreadCount: 0,
                        avatarUrl: user.AvatarUrl
                    );

                    contactItem.UserClicked += ContactItem_Clicked;
                    contactItem.Tag = uid;
                    flowUserListPanel.Controls.Add(contactItem);

                    _userLastMessageTime[uid] = 0;

                    // Xử lý sự kiện xóa cuộc trò chuyện
                    contactItem.DeleteConversation += async (s, targetUid) =>
                    {
                        try
                        {
                            string chatId = _chatService.GenerateChatId(_currentUserUid, (string)targetUid);
                            await _chatService.DeleteChatAsync(chatId);

                            if (_messageCache.ContainsKey((string)targetUid))
                                _messageCache.Remove((string)targetUid);
                            if (_chatLastLoadTime.ContainsKey((string)targetUid))
                                _chatLastLoadTime.Remove((string)targetUid);

                            flowUserListPanel.Controls.Remove(contactItem);

                            if (_currentPartnerUid == (string)targetUid)
                            {
                                _currentPartnerUid = null;
                                _currentChatId = null;
                                flowChatPanel.Controls.Clear();
                                panelInput.Enabled = false;
                                lblInfoName.Text = "(Chọn để chat)";
                                lblInfoEmail.Text = "(Email)";
                                lblInfoRole.Text = "(Vai trò)";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    contactItem.MuteNotification += (s, targetUid) =>
                    {
                        MessageBox.Show("Đã tắt thông báo cho " + contactItem.HoTen);
                    };
                }

                // Load tin nhắn sơ bộ để sắp xếp list
                var userList = flowUserListPanel.Controls.Cast<Control>().OfType<UC_UserContactItem>().ToList();
                foreach (var contactItem in userList)
                {
                    string? uid = contactItem.Tag?.ToString();
                    if (!string.IsNullOrEmpty(uid))
                    {
                        await LoadAndCacheAllMessagesAsync(uid, contactItem);
                    }
                }

                ReorderContactList();
                AutoSelectFirstUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách user: " + ex.Message);
            }
        }

        private void AdjustContactItemWidth(UC_UserContactItem contactItem)
        {
            contactItem.Width = flowUserListPanel.ClientSize.Width - 20;
            contactItem.AutoSize = false;
        }


        private void ContactItem_Clicked(object? sender, EventArgs e)
        {
            if (sender is not UC_UserContactItem clickedItem) return;

            _seenUpdatedKeys.Clear();

            // UI selection
            foreach (Control ctrl in flowUserListPanel.Controls)
            {
                if (ctrl is UC_UserContactItem item) item.SetSelected(false);
            }
            clickedItem.SetSelected(true);

            // Hủy lắng nghe cũ
            if (_messageSubscription != null)
            {
                _messageSubscription.Dispose();
                _messageSubscription = null;
            }

            flowChatPanel.Controls.Clear();

            _currentPartnerUid = clickedItem.UserId;
            _currentChatId = _chatService.GenerateChatId(_currentUserUid, _currentPartnerUid);

            // Cập nhật thông tin Header
            lblInfoName.Text = clickedItem.HoTen;
            lblInfoEmail.Text = clickedItem.Email;
            lblInfoRole.Text = clickedItem.Role;

            string avatarUrl = clickedItem.AvatarUrl;
            if (!string.IsNullOrEmpty(avatarUrl))
            {
                try { guna2CirclePictureBox1.LoadAsync(avatarUrl); }
                catch { guna2CirclePictureBox1.Image = Properties.Resources.avatar_trang_1_cd729c335b1; }
            }
            else
            {
                guna2CirclePictureBox1.Image = Properties.Resources.avatar_trang_1_cd729c335b1;
            }

            _previousMessageTimestamp = null;
            panelInput.Enabled = true;

            DisplayCachedMessagesAndListenForNew();
        }

        private void DisplayCachedMessagesAndListenForNew()
        {
            try
            {
                if (string.IsNullOrEmpty(_currentChatId)) return;

                // 1. Hiển thị tin nhắn từ Cache trước (nếu có)
                if (_messageCache.ContainsKey(_currentChatId))
                {
                    var cachedMessages = _messageCache[_currentChatId];
                    foreach (var msg in cachedMessages)
                    {
                        DisplayMessageAsBubbleWithoutReorder(msg);
                    }
                    UpdateLastMessageStatus();

                    if (cachedMessages.Any())
                    {
                        var latestMessage = cachedMessages.OrderByDescending(m => m.Timestamp).First();
                        _userLastMessageTime[_currentPartnerUid] = latestMessage.Timestamp;
                        UpdateContactItemWithLatestMessage(_currentPartnerUid, latestMessage);
                    }
                }

                // 2. Bắt đầu lắng nghe tin nhắn mới từ Firebase (kèm Key để update status)
                _messageSubscription?.Dispose();
                _messageSubscription = _chatService.ListenForMessagesWithKey(_currentChatId, DisplayMessageAsBubbleWithKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chat: " + ex.Message);
            }
        }

        // [FIX QUAN TRỌNG 2] Hàm nhận tin nhắn real-time và update status SEEN
        private void DisplayMessageAsBubbleWithKey(string messageKey, Message msg)
        {
            if (flowChatPanel.IsDisposed) return;

            if (flowChatPanel.InvokeRequired)
            {
                try { flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubbleWithKey(messageKey, msg))); }
                catch (ObjectDisposedException) { }
                return;
            }

            bool isMe = (msg.SenderUid == _currentUserUid);

            if (!isMe && _currentChatId != null && msg.Status != "seen" && !_seenUpdatedKeys.Contains(messageKey))
            {
                _seenUpdatedKeys.Add(messageKey); 

                Task.Run(async () =>
                {
                    try
                    {
                        await _chatService.UpdateMessageStatusAsync(_currentChatId, messageKey, "seen");
                        Debug.WriteLine($"Đã update seen cho key: {messageKey}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Lỗi update seen: " + ex.Message);
                    }
                });

                msg.Status = "seen";
            }

            DisplayMessageAsBubble(msg);
        }

        private void DisplayMessageAsBubble(Message msg)
        {
            if (flowChatPanel.IsDisposed) return;

            if (flowChatPanel.InvokeRequired)
            {
                try { flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubble(msg))); }
                catch (ObjectDisposedException) { }
                return;
            }

            string msgId = GenerateMessageId(msg);

            if (!_messageCache.ContainsKey(_currentChatId)) _messageCache[_currentChatId] = new List<Message>();
            var cachedMsg = _messageCache[_currentChatId].FirstOrDefault(m => GenerateMessageId(m) == msgId);

            if (cachedMsg != null) cachedMsg.Status = msg.Status;
            else _messageCache[_currentChatId].Add(msg);

            var existingBubble = flowChatPanel.Controls.Cast<Control>()
                .OfType<UC_ChatItem>()
                .FirstOrDefault(b => b.MessageId == msgId);

            if (existingBubble != null)
            {
                UpdateLastMessageStatus();
                return;
            }

            UC_ChatItem newBubble = new UC_ChatItem();
            UpdateChatViewportWidthCache();
            newBubble.Width = _chatViewportWidth - 25;
            newBubble.MessageId = msgId;

            bool isMe = (msg.SenderUid == _currentUserUid);
            string type = msg.Type ?? "text";
            string avatarUrl = GetUserAvatarUrl(_currentPartnerUid);

            if (type == "file" || type == "image")
                newBubble.SetMessage(msg.Text, isMe, msg.Status, type, msg.Timestamp, _previousMessageTimestamp, msg.FileUrl, msg.FileName, avatarUrl);
            else
                newBubble.SetMessage(msg.Text, isMe, msg.Status, type, msg.Timestamp, _previousMessageTimestamp, null, null, avatarUrl);

            _previousMessageTimestamp = msg.Timestamp;

            newBubble.HideStatusAndSeen();

            if (isMe)
            {
                newBubble.HideAvatar();
            }
            else
            {
                newBubble.ShowAvatarBelow();
                newBubble.picAvatarStatus.ImageLocation = avatarUrl;
            }

            flowChatPanel.Controls.Add(newBubble);
            flowChatPanel.ScrollControlIntoView(newBubble);

            UpdateLastMessageStatus();

            // Cập nhật lại list bên trái nếu có tin mới
            if (!string.IsNullOrEmpty(_currentPartnerUid))
            {
                _userLastMessageTime[_currentPartnerUid] = msg.Timestamp;
                UpdateContactItemWithLatestMessage(_currentPartnerUid, msg);
                ReorderContactList();
            }
        }

        private void DisplayMessageAsBubbleWithoutReorder(Message msg)
        {
            if (flowChatPanel.InvokeRequired)
            {
                flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubbleWithoutReorder(msg)));
                return;
            }

            UC_ChatItem bubble = new UC_ChatItem();
            UpdateChatViewportWidthCache();
            bubble.Width = _chatViewportWidth - 25;
            bool isMe = (msg.SenderUid == _currentUserUid);
            string rawStatus = msg.Status ?? "sent";
            string trangThai = (rawStatus == "sent") ? "Đã gửi" : rawStatus;

            string type = msg.Type ?? "text";
            string avatarUrl = GetUserAvatarUrl(_currentPartnerUid);
            bubble.MessageId = GenerateMessageId(msg);

            if (type == "file" || type == "image")
            {
                bubble.SetMessage(
                    text: msg.Text,
                    isMe: isMe,
                    status: trangThai,
                    type: type,
                    timestamp: msg.Timestamp,
                    previousTimestamp: _previousMessageTimestamp,
                    fileUrl: msg.FileUrl ?? "",
                    fileName: msg.FileName ?? "",
                    avatarUrl: avatarUrl
                );
            }
            else
            {
                bubble.SetMessage(msg.Text, isMe, trangThai, type, msg.Timestamp, _previousMessageTimestamp, avatarUrl: avatarUrl);
            }
            bubble.HideStatus();

            _previousMessageTimestamp = msg.Timestamp;
            flowChatPanel.Controls.Add(bubble);
            flowChatPanel.ScrollControlIntoView(bubble);
        }


        private void UpdateLastMessageStatus()
        {
            var allBubbles = flowChatPanel.Controls.Cast<Control>().OfType<UC_ChatItem>().ToList();

            foreach (var bubble in allBubbles)
            {
                bubble.HideStatusAndSeen();
                if (!bubble.IsMe) bubble.ShowAvatarBelow();
            }

            var myBubbles = allBubbles.Where(b => b.IsMe).ToList();
            if (myBubbles.Count == 0) return;

            if (_messageCache.ContainsKey(_currentChatId))
            {
                var chatMessages = _messageCache[_currentChatId];

                // Tìm tin nhắn cuối cùng ĐÃ XEM
                var lastSeenBubble = myBubbles
                    .Where(b =>
                    {
                        var msgObj = chatMessages.FirstOrDefault(m => GenerateMessageId(m) == b.MessageId);
                        return msgObj != null && msgObj.Status == "seen";
                    })
                    .LastOrDefault();

                // Tin nhắn cuối cùng bất kỳ
                var absolutelyLastBubble = myBubbles.LastOrDefault();
                string partnerAvatarUrl = GetUserAvatarUrl(_currentPartnerUid);

                // Hiển thị avatar người xem
                if (lastSeenBubble != null)
                {
                    lastSeenBubble.SetStatusMode("seen", partnerAvatarUrl);
                }

                // Nếu tin cuối chưa xem -> hiện "Đã gửi"
                if (absolutelyLastBubble != null && absolutelyLastBubble != lastSeenBubble)
                {
                    absolutelyLastBubble.SetStatusMode("sent", "");
                }
            }
        }

        private async Task LoadAndCacheAllMessagesAsync(string partnerId, UC_UserContactItem contactItem)
        {
            try
            {
                string chatId = _chatService.GenerateChatId(_currentUserUid, partnerId);
                var messages = await _chatService.GetMessagesAsync(chatId);

                if (!_messageCache.ContainsKey(chatId)) _messageCache[chatId] = new List<Message>();
                _messageCache[chatId] = messages.ToList();
                _chatLastLoadTime[chatId] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                if (messages.Any())
                {
                    var latestMsg = messages.OrderByDescending(m => m.Timestamp).First();
                    UpdateContactItemWithLatestMessage(partnerId, latestMsg);
                    _userLastMessageTime[partnerId] = latestMsg.Timestamp;
                }
            }
            catch { }
        }

        private void UpdateContactItemWithLatestMessage(string partnerId, Message msg)
        {
            var contactItem = flowUserListPanel.Controls.Cast<Control>()
                .OfType<UC_UserContactItem>()
                .FirstOrDefault(item => item.Tag?.ToString() == partnerId);

            if (contactItem != null)
            {
                string timeStr = ConvertTimestampToTime(msg.Timestamp);
                contactItem.SetData(
                    uid: partnerId,
                    hoTen: contactItem.HoTen,
                    email: contactItem.Email,
                    role: contactItem.Role,
                    lastMessage: msg.Text,
                    timestamp: timeStr,
                    unreadCount: 0,
                    avatarUrl: contactItem.AvatarUrl
                );
                contactItem.Invalidate();
            }
        }

        private void ReorderContactList()
        {
            var sortedContacts = flowUserListPanel.Controls.Cast<Control>()
                .Where(c => c is UC_UserContactItem)
                .Cast<UC_UserContactItem>()
                .OrderByDescending(c =>
                {
                    string? uid = c.Tag?.ToString();
                    return uid != null && _userLastMessageTime.ContainsKey(uid) ? _userLastMessageTime[uid] : 0;
                })
                .ToList();

            flowUserListPanel.Controls.Clear();
            flowUserListPanel.SuspendLayout();
            foreach (var contact in sortedContacts)
            {
                AdjustContactItemWidth(contact);
                flowUserListPanel.Controls.Add(contact);
            }
            flowUserListPanel.ResumeLayout();
        }

        private async void btnSend_Click(object? sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(_currentPartnerUid) || string.IsNullOrEmpty(_currentChatId)) return;

            var message = new Message
            {
                SenderUid = _currentUserUid,
                SenderName = _currentUserName,
                Text = text,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Status = "sent",
                Type = "text"
            };

            try
            {
                await _chatService.SendMessageAsync(_currentChatId, message);
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message);
            }
        }


        private void txtMessage_TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentChatId))
            {
                _chatService.SetTypingStatus(_currentChatId, _currentUserUid, true);
            }
            _typingTimer.Stop();
            _typingTimer.Start();
        }

        private void typingTimer_Tick(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentChatId))
            {
                _chatService.SetTypingStatus(_currentChatId, _currentUserUid, false);
            }
            _typingTimer.Stop();
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
            flowUserListPanel.SuspendLayout();
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

        private async void btnUpload_Click_1(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPartnerUid))
            {
                MessageBox.Show("Vui lòng chọn người để chat trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tất cả file hỗ trợ (*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf;*.docx;*.doc;*.xlsx;*.xls;*.txt;*.pptx)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf;*.docx;*.doc;*.xlsx;*.xls;*.txt;*.pptx|Hình ảnh (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tài liệu PDF (*.pdf)|*.pdf|Word (*.docx;*.doc)|*.docx;*.doc|Excel (*.xlsx;*.xls)|*.xlsx;*.xls|Text (*.txt)|*.txt|PowerPoint (*.pptx)|*.pptx|Tất cả file (*.*)|*.*";
                openFileDialog.Title = "Chọn hình ảnh hoặc file để gửi";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = System.IO.Path.GetFileName(filePath);
                        string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
                        bool isImage = IsImageFile(fileExtension);

                        MessageBox.Show("Đang tải file...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        using (var fileStream = System.IO.File.OpenRead(filePath))
                        {
                            string fileUrl = await _chatService.UploadFile(fileStream, fileName);
                            Message fileMessage = new Message
                            {
                                SenderUid = _currentUserUid,
                                SenderName = _currentUserName,
                                Text = fileName,
                                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                                Status = "sent",
                                Type = isImage ? "image" : "file",
                                FileUrl = fileUrl,
                                FileName = fileName
                            };

                            await _chatService.SendMessageAsync(_currentChatId, fileMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi gửi file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            Button btnEmoji = sender as Button;
            Point buttonLocation = btnEmoji?.PointToScreen(new Point(0, btnEmoji.Height)) ?? Cursor.Position;
            EmojiPickerForm emojiForm = new EmojiPickerForm();
            emojiForm.Location = buttonLocation;
            emojiForm.EmojiSelected += (s, emoji) =>
            {
                if (txtMessage.InvokeRequired)
                    txtMessage.Invoke(new Action(() => { txtMessage.Text += emoji + " "; txtMessage.Focus(); txtMessage.SelectionStart = txtMessage.Text.Length; }));
                else
                {
                    txtMessage.Text += emoji + " "; txtMessage.Focus(); txtMessage.SelectionStart = txtMessage.Text.Length;
                }
            };
            emojiForm.ShowDialog();
        }

        private string ConvertTimestampToTime(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timestamp);
            return dateTime.ToLocalTime().ToString("HH:mm");
        }

        private string GenerateMessageId(Message msg)
        {
            return $"{msg.SenderUid}_{msg.Timestamp}";
        }

        private bool IsImageFile(string extension)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private string GetUserAvatarUrl(string uid)
        {
            try
            {
                var contactItem = flowUserListPanel.Controls.Cast<Control>()
                    .OfType<UC_UserContactItem>()
                    .FirstOrDefault(c => c.Tag?.ToString() == uid);
                return contactItem != null && !string.IsNullOrEmpty(contactItem.AvatarUrl) ? contactItem.AvatarUrl : "";
            }
            catch { return ""; }
        }

        private void AutoSelectFirstUser()
        {
            try
            {
                var firstContact = flowUserListPanel.Controls.Cast<Control>().OfType<UC_UserContactItem>().FirstOrDefault();
                if (firstContact != null) ContactItem_Clicked(firstContact, EventArgs.Empty);
            }
            catch { }
        }

        private void SetupAutoScroll()
        {
            flowChatPanel.ControlAdded += (s, ev) =>
            {
                UpdateChatViewportWidthCache();
                flowChatPanel.ScrollControlIntoView(ev.Control);
            };
            flowChatPanel.SizeChanged += (s, e) => UpdateChatViewportWidthCache();
            this.Shown += (s, e) => UpdateChatViewportWidthCache();
        }

        private int GetChatViewportWidth()
        {
            int w = flowChatPanel.DisplayRectangle.Width;
            if (w <= 0) w = flowChatPanel.ClientSize.Width;
            return w;
        }

        private void UpdateChatViewportWidthCache()
        {
            _chatViewportWidth = GetChatViewportWidth();
        }

        private void frmMainChat_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _messageSubscription?.Dispose();
            _messageSubscription = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _messageSubscription?.Dispose();
                _typingTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void lblInfoEmail_Click(object? sender, EventArgs e) { }
        private void lblInfoName_Click(object? sender, EventArgs e) { }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) { }
    }
}