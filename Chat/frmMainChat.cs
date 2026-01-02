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

            btnSend.Click += btnSend_Click;
            btnUpload.Click += btnUpload_Click_1;
            txtMessage.KeyDown += txtMessage_KeyDown;

            if (guna2TextBox1_TextChanged != null)
                guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;

            SetupAutoScroll();
        }

        // Load danh sách người dùng và cache tin nhắn khi form khởi động
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
                        unreadCount: 0
                    );

                    contactItem.UserClicked += ContactItem_Clicked;
                    contactItem.Tag = uid;
                    flowUserListPanel.Controls.Add(contactItem);

                    _userLastMessageTime[uid] = 0;

                    contactItem.DeleteConversation += async (s, uid) =>
                    {
                        try
                        {
                            // Xóa toàn bộ cuộc trò chuyện từ Firebase
                            string chatId = _chatService.GenerateChatId(_currentUserUid, (string)uid);
                            await _chatService.DeleteChatAsync(chatId);

                            // Xóa từ cache
                            if (_messageCache.ContainsKey((string)uid))
                                _messageCache.Remove((string)uid);
                            if (_chatLastLoadTime.ContainsKey((string)uid))
                                _chatLastLoadTime.Remove((string)uid);

                            // Xóa từ giao diện
                            flowUserListPanel.Controls.Remove(contactItem);

                            // Nếu đang chat với người này thì reset
                            if (_currentPartnerUid == (string)uid)
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
                            MessageBox.Show($"Lỗi xóa cuộc trò chuyện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    contactItem.MuteNotification += (s, uid) =>
                    {
                        // Xử lý tắt thông báo cho contact này
                        MessageBox.Show("Đã tắt thông báo cho " + contactItem.HoTen);
                    };
                }

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

                ReorderContactList();
                AutoSelectFirstUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void AdjustContactItemWidth(UC_UserContactItem contactItem)
        {
            contactItem.Width = flowUserListPanel.ClientSize.Width - 20;
            contactItem.AutoSize = false;
        }

        // Cập nhật dữ liệu chat từ Firebase
        private async Task RefreshChatDataAsync()
        {
            try
            {
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

                if (!string.IsNullOrEmpty(_currentChatId))
                {
                    _messageSubscription?.Dispose();
                    flowChatPanel.Controls.Clear();
                    _previousMessageTimestamp = null;
                    _messageSubscription = _chatService.ListenForMessages(_currentChatId, DisplayMessageAsBubble);
                }

                ReorderContactList();
            }
            catch
            {
            }
        }

        // Lấy tin nhắn mới nhất cho một người dùng
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
                }
            } catch
            {
            }
        }

        // Chuyển đổi timestamp Unix sang định dạng giờ (HH:mm)
        private string ConvertTimestampToTime(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timestamp);
            var localDateTime = dateTime.ToLocalTime();
            return localDateTime.ToString("HH:mm");
        }

        // Xử lý sự kiện khi người dùng click vào một contact
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

            panelInput.Enabled = true;

            DisplayCachedMessagesAndListenForNew();
        }

        // Tự động chọn contact đầu tiên khi form load
        private void AutoSelectFirstUser()
        {
            try
            {
                var firstContact = flowUserListPanel.Controls.Cast<Control>()
                    .OfType<UC_UserContactItem>()
                    .FirstOrDefault();

                if (firstContact != null)
                {
                    ContactItem_Clicked(firstContact, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error auto-selecting first user: {ex.Message}");
            }
        }

        // Cache tất cả tin nhắn cho một người dùng
        private async Task LoadAndCacheAllMessagesAsync(string partnerId, UC_UserContactItem contactItem)
        {
            try
            {
                string chatId = _chatService.GenerateChatId(_currentUserUid, partnerId);

                var messages = await _chatService.GetMessagesAsync(chatId);

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
            }
        }

        // Hiển thị tin nhắn đã cache và nghe tin nhắn mới
        private void DisplayCachedMessagesAndListenForNew()
        {
            try
            {
                if (string.IsNullOrEmpty(_currentChatId))
                    return;

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

                _messageSubscription = _chatService.ListenForMessages(_currentChatId, DisplayMessageAsBubble);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Thay thế GetUserAvatarUrl và sửa cả DisplayMessageAsBubble
        private string GetUserAvatarUrl(string uid)
        {
            try
            {
                var contactItem = flowUserListPanel.Controls.Cast<Control>()
                    .OfType<UC_UserContactItem>()
                    .FirstOrDefault(c => c.Tag?.ToString() == uid);
                
                // TODO: Update để lấy avatar riêng cho từng user sau
                // Tạm thời trả về rỗng
                return "";
            }
            catch
            {
                return "";
            }
        }

        // Hiển thị tin nhắn mà không sắp xếp lại danh sách contact
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
                string rawStatus = msg.Status ?? "sent";
                string trangThai = (rawStatus == "sent") ? "Đã gửi" : rawStatus;
                // ----------------------------

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
        }

        // Thêm variable để track tin nhắn cuối cùng và avatar của nó
        private UC_ChatItem _lastMessageBubble = null;

        // Hiển thị tin nhắn mới và cập nhật danh sách contact
        private void DisplayMessageAsBubble(Message msg)
        {
            // Safety check: Ensure control and form are not disposed
            if (flowChatPanel.IsDisposed)
            {
                return;
            }

            if (flowChatPanel.InvokeRequired)
            {
                try
                {
                    flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubble(msg)));
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }
            else
            {
                bool messageExists = flowChatPanel.Controls.Cast<Control>()
                    .OfType<UC_ChatItem>()
                    .Any(bubble => bubble.MessageId == GenerateMessageId(msg));

                if (messageExists)
                {
                    return;
                }

                UC_ChatItem newBubble = new UC_ChatItem();
                newBubble.Width = flowChatPanel.ClientSize.Width - 25;
                bool isMe = (msg.SenderUid == _currentUserUid);
                string rawStatus = msg.Status ?? "sent";
                string trangThai = (rawStatus == "sent") ? "Đã gửi" : rawStatus;
                // -----------------------------------------------------

                string type = msg.Type ?? "text";
                newBubble.MessageId = GenerateMessageId(msg);
                string avatarUrl = GetUserAvatarUrl(_currentPartnerUid);
                newBubble.MessageId = GenerateMessageId(msg);
                
            
                
                // Debug log
                System.Diagnostics.Debug.WriteLine($"Message Type: {type}, FileUrl: {msg.FileUrl}, FileName: {msg.FileName}, AvatarUrl: {avatarUrl}");
                
                // Truyền avatarUrl cho ảnh/file
                if (type == "file" || type == "image")
                {
                    newBubble.SetMessage(
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
                    newBubble.SetMessage(msg.Text, isMe, trangThai, type, msg.Timestamp, _previousMessageTimestamp, avatarUrl: avatarUrl);
                }

                _previousMessageTimestamp = msg.Timestamp;

                flowChatPanel.Controls.Add(newBubble);
                flowChatPanel.ScrollControlIntoView(newBubble);

                if (isMe)
                {
                    var myMessages = flowChatPanel.Controls.Cast<Control>()
                        .OfType<UC_ChatItem>()
                        .Where(b =>
                        {
                            var parts = b.MessageId.Split('_');
                            return parts.Length > 0 && parts[0] == _currentUserUid;
                        })
                        .ToList();

                    foreach (var msg_bubble in myMessages)
                    {
                        msg_bubble.HideStatus();
                        msg_bubble.HideAvatar();
                    }

                    newBubble.ShowStatus();
                }
                else
                {
                    // Với tin nhắn của người khác, hiển thị avatar
                    newBubble.ShowAvatarBelow();
                }

                // Hiển thị avatar dưới tin nhắn cuối cùng
                newBubble.picAvatarStatus.Visible = true;
                newBubble.picAvatarStatus.ImageLocation = avatarUrl;
                newBubble.picAvatarStatus.Location = new Point(flowChatPanel.ClientSize.Width - 40, newBubble.Bottom - 30);

                if (!string.IsNullOrEmpty(_currentPartnerUid))
                {
                    _userLastMessageTime[_currentPartnerUid] = msg.Timestamp;

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

        // Sắp xếp danh sách contact theo thời gian tin nhắn mới nhất
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

        // Cập nhật thông tin tin nhắn mới nhất của contact
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
                    unreadCount: 0
                );

                contactItem.Invalidate();
            }
        }

        // Gửi tin nhắn văn bản
        private async void btnSend_Click(object? sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(_currentPartnerUid) || string.IsNullOrEmpty(_currentChatId))
            {
                return;
            }

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
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message);
            }
        }

        private void TypingTimer_Tick(object? sender, EventArgs e)
        {
        }

        // Gửi tin nhắn khi nhấn Enter
        private void txtMessage_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(null, EventArgs.Empty);
            }
        }

        // Tìm kiếm contact theo tên hoặc email
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _messageSubscription?.Dispose();
                _typingTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmMainChat_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _messageSubscription?.Dispose();
            _messageSubscription = null;
        }

        private void lblInfoEmail_Click(object? sender, EventArgs e)
        {
            lblInfoEmail.Text = _currentUserName;
        }

        private void lblInfoName_Click(object? sender, EventArgs e)
        {
            lblInfoName.Text = _currentUserName;
        }

        // Đặt trạng thái typing khi người dùng nhập tin nhắn
        private void txtMessage_TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentChatId))
            {
                _chatService.SetTypingStatus(_currentChatId, _currentUserUid, true);
            }

            _typingTimer.Stop();
            _typingTimer.Start();
        }

        // Tắt trạng thái typing khi hết thời gian timeout
        private void typingTimer_Tick(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentChatId))
            {
                _chatService.SetTypingStatus(_currentChatId, _currentUserUid, false);
            }
            _typingTimer.Stop();
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            Button btnEmoji = sender as Button;
            Point buttonLocation = btnEmoji?.PointToScreen(new Point(0, btnEmoji.Height)) ?? Cursor.Position;

            EmojiPickerForm emojiForm = new EmojiPickerForm();
            emojiForm.Location = buttonLocation;

            // Khi chọn emoji, thêm vào ô tin nhắn
            emojiForm.EmojiSelected += (s, emoji) =>
            {
                if (txtMessage.InvokeRequired)
                {
                    txtMessage.Invoke(new Action(() =>
                    {
                        txtMessage.Text += emoji + " ";
                        txtMessage.Focus();
                        txtMessage.SelectionStart = txtMessage.Text.Length;
                    }));
                }
                else
                {
                    txtMessage.Text += emoji + " ";
                    txtMessage.Focus();
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                }
            };

            emojiForm.ShowDialog();
        }

        // Tự động scroll khi có tin nhắn mới
        private void SetupAutoScroll()
        {
            flowChatPanel.ControlAdded += (s, ev) =>
            {
                flowChatPanel.ScrollControlIntoView(ev.Control);
            };
        }

        // Gửi hình ảnh hoặc file qua chat
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

                        // Xác định loại file (ảnh hay tài liệu)
                        bool isImage = IsImageFile(fileExtension);

                        // Hiển thị thông báo đang upload
                        MessageBox.Show("Đang tải file...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        using (var fileStream = System.IO.File.OpenRead(filePath))
                        {
                            string fileUrl = await _chatService.UploadFile(fileStream, fileName);

                            // Tạo tin nhắn phù hợp dựa trên loại file
                            Message fileMessage;

                            if (isImage)
                            {
                                // Tin nhắn ảnh
                                fileMessage = new Message
                                {
                                    SenderUid = _currentUserUid,
                                    SenderName = _currentUserName,
                                    Text = fileName,  // Chỉ tên file, không URL
                                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                                    Status = "sent",
                                    Type = "image",
                                    FileUrl = fileUrl,  // URL riêng
                                    FileName = fileName
                                };
                            }
                            else
                            {
                                // Tin nhắn file thường
                                fileMessage = new Message
                                {
                                    SenderUid = _currentUserUid,
                                    SenderName = _currentUserName,
                                    Text = fileName,  // Chỉ tên file, không emoji lồng
                                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                                    Status = "sent",
                                    Type = "file",
                                    FileUrl = fileUrl,  // URL riêng
                                    FileName = fileName
                                };
                            }

                            // Gửi tin nhắn
                            await _chatService.SendMessageAsync(_currentChatId, fileMessage);

                            MessageBox.Show("Gửi file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi gửi file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Tạo ID duy nhất cho mỗi tin nhắn
        private string GenerateMessageId(Message msg)
        {
            return $"{msg.SenderUid}_{msg.Timestamp}";
        }

        private bool IsImageFile(string extension)
        {
            // List of supported image file extensions
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Updates the status display of the last message bubble in the chat panel.
        /// </summary>
        private void UpdateLastMessageStatus()
        {
            // Hide status for all message bubbles except the last one sent by the current user
            var myMessages = flowChatPanel.Controls.Cast<Control>()
                .OfType<UC_ChatItem>()
                .Where(b =>
                {
                    var parts = b.MessageId.Split('_');
                    return parts.Length > 0 && parts[0] == _currentUserUid;
                })
                .ToList();

            foreach (var msg_bubble in myMessages)
            {
                msg_bubble.HideStatus();
            }

            // Show status for the last message sent by the current user
            var lastMyMessage = myMessages.OrderByDescending(b =>
            {
                var parts = b.MessageId.Split('_');
                return parts.Length > 1 && long.TryParse(parts[1], out var ts) ? ts : 0;
            }).FirstOrDefault();

            lastMyMessage?.ShowStatus();
        }
    }
}