using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Drawing;

namespace APP_DOAN
{
    public partial class frmMainChat : Form
    {
        private FirebaseChatService _chatService;
        private const string FIREBASE_URL = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _idToken;
        private readonly string _currentMaso;

        private string? _currentPartnerUid = null;
        private string? _currentChatId = null;

        private IDisposable? _messageSubscription;
        private System.Windows.Forms.Timer _typingTimer;

        private long? _previousMessageTimestamp = null;

        private Dictionary<string, long> _userLastMessageTime = new Dictionary<string, long>();
        private Dictionary<string, List<Message>> _messageCache = new Dictionary<string, List<Message>>();
        private Dictionary<string, long> _chatLastLoadTime = new Dictionary<string, long>();

        private int _chatViewportWidth = 0;
        private readonly HashSet<string> _seenUpdatedKeys = new HashSet<string>();

        private bool _isGroupMode = false;
        private string _currentUserRole = "SinhVien";

        public frmMainChat(string uid, string maso, string hoTen, string idToken)
        {
            InitializeComponent();

            _currentUserUid = uid;
            _currentUserName = hoTen;
            _idToken = idToken;
            _currentMaso = maso;

            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
            _typingTimer = new System.Windows.Forms.Timer();
            _typingTimer.Interval = 1500;
            _typingTimer.Tick += typingTimer_Tick;
            this.FormClosing += frmMainChat_FormClosing;

            btnSend.Click += btnSend_Click;
            btnUpload.Click += btnUpload_Click_1;
            txtMessage.KeyDown += txtMessage_KeyDown;

            txtMessage.TextChanged += txtMessage_TextChanged;

            if (guna2TextBox1 != null)
                guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;

            if (btnTabPersonal != null) btnTabPersonal.Click += (s, e) => SwitchTab(false);
            if (btnTabClass != null) btnTabClass.Click += (s, e) => SwitchTab(true);

            SetupAutoScroll();
        }

        private async void frmMainChat_Load(object sender, EventArgs e)
        {
            try
            {
                _currentUserRole = await GetUserRole(_currentUserUid);
            }
            catch { }

            flowUserListPanel.ControlAdded += (s, ev) =>
            {
                if (ev.Control is UC_UserContactItem contactItem)
                {
                    AdjustContactItemWidth(contactItem);
                }
            };

            SwitchTab(false);
        }

        private async void SwitchTab(bool isGroupMode)
        {
            _isGroupMode = isGroupMode;

            if (btnTabPersonal != null) btnTabPersonal.BackColor = isGroupMode ? Color.LightGray : Color.LightBlue;
            if (btnTabClass != null) btnTabClass.BackColor = isGroupMode ? Color.LightBlue : Color.LightGray;

            // Reset UI Chat
            flowUserListPanel.Controls.Clear();
            flowChatPanel.Controls.Clear();
            _currentChatId = null;
            _currentPartnerUid = null;

            lblInfoName.Text = "(Chọn cuộc trò chuyện)";
            lblInfoEmail.Text = "";
            lblInfoRole.Text = "";
            panelInput.Enabled = false;

            if (_isGroupMode)
            {
                await LoadClassListAsync();
            }
            else
            {
                await LoadUserListAsync();
            }
        }

        private async Task LoadUserListAsync()
        {
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

                    contactItem.SetData(uid, user.HoTen, user.Email, user.Role, "Nhấn để chat...", "", 0, user.AvatarUrl);
                    contactItem.UserClicked += ContactItem_Clicked;
                    contactItem.Tag = uid;

                    contactItem.DeleteConversation += async (s, targetUid) =>
                    {
                        try
                        {
                            string chatId = _chatService.GenerateChatId(_currentUserUid, (string)targetUid);
                            await _chatService.DeleteChatAsync(chatId);
                            if (_messageCache.ContainsKey((string)targetUid)) _messageCache.Remove((string)targetUid);
                            flowUserListPanel.Controls.Remove(contactItem);
                            if (_currentPartnerUid == (string)targetUid) { }
                        }
                        catch { }
                    };
                    contactItem.MuteNotification += (s, targetUid) => MessageBox.Show("Đã tắt thông báo");

                    flowUserListPanel.Controls.Add(contactItem);
                    _userLastMessageTime[uid] = 0;
                }

                var userList = flowUserListPanel.Controls.Cast<Control>().OfType<UC_UserContactItem>().ToList();
                foreach (var contactItem in userList)
                {
                    string? uid = contactItem.Tag?.ToString();
                    if (!string.IsNullOrEmpty(uid)) await LoadAndCacheAllMessagesAsync(uid, contactItem);
                }
                ReorderContactList();
                AutoSelectFirstUser();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách user: " + ex.Message); }
        }

        private async Task LoadClassListAsync()
        {
            try
            {
                var myCourses = await _chatService.GetMyCoursesAsync(_currentUserUid, _currentUserRole);

                if (myCourses.Count == 0)
                {
                    Label lbl = new Label { Text = "Chưa tham gia lớp nào.", AutoSize = true, Padding = new Padding(10) };
                    flowUserListPanel.Controls.Add(lbl);
                    return;
                }

                foreach (var course in myCourses)
                {
                    string classId = course.Key;
                    string className = course.Value;

                    UC_UserContactItem item = new UC_UserContactItem();
                    AdjustContactItemWidth(item);

                    item.SetData(classId, className, "Mã lớp: " + classId, "Lớp học", "Nhấn để vào lớp...", "", 0, "");
                    item.UserClicked += ContactItem_Clicked;
                    item.Tag = classId;

                    flowUserListPanel.Controls.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lớp: " + ex.Message); }
        }

        private void AdjustContactItemWidth(UC_UserContactItem contactItem)
        {
            contactItem.Width = flowUserListPanel.ClientSize.Width - 20;
            contactItem.AutoSize = false;
        }

        private async void ContactItem_Clicked(object? sender, EventArgs e)
        {
            if (sender is not UC_UserContactItem clickedItem) return;

            _seenUpdatedKeys.Clear();
            foreach (Control ctrl in flowUserListPanel.Controls)
            {
                if (ctrl is UC_UserContactItem item) item.SetSelected(false);
            }
            clickedItem.SetSelected(true);

            if (_messageSubscription != null) { _messageSubscription.Dispose(); _messageSubscription = null; }
            flowChatPanel.Controls.Clear();
            _previousMessageTimestamp = null;

            if (_isGroupMode)
            {
                string classId = clickedItem.Tag.ToString();
                _currentChatId = classId;
                _currentPartnerUid = null;

                lblInfoName.Text = clickedItem.HoTen;
                lblInfoEmail.Text = "Mã lớp: " + classId;

                bool isGV = await _chatService.IsTeacherOfClassAsync(classId, _currentUserUid);
                if (isGV)
                {
                    lblInfoRole.Text = "Giảng viên (Quản trị)";
                    lblInfoRole.ForeColor = Color.Red;
                }
                else
                {
                    lblInfoRole.Text = "Thành viên";
                    lblInfoRole.ForeColor = Color.Black;
                }

                guna2CirclePictureBox1.Image = Properties.Resources.avatar_trang_1_cd729c335b1;
                panelInput.Enabled = true;

                LoadGroupChatMessages(classId);
            }
            else
            {
                _currentPartnerUid = clickedItem.UserId;
                _currentChatId = _chatService.GenerateChatId(_currentUserUid, _currentPartnerUid);

                lblInfoName.Text = clickedItem.HoTen;
                lblInfoEmail.Text = clickedItem.Email;
                lblInfoRole.Text = clickedItem.Role;
                lblInfoRole.ForeColor = Color.Black;

                string avatarUrl = clickedItem.AvatarUrl;
                if (!string.IsNullOrEmpty(avatarUrl)) { try { guna2CirclePictureBox1.LoadAsync(avatarUrl); } catch { } }
                else guna2CirclePictureBox1.Image = Properties.Resources.avatar_trang_1_cd729c335b1;

                panelInput.Enabled = true;
                DisplayCachedMessagesAndListenForNew();
            }
        }

        private async void LoadGroupChatMessages(string classId)
        {
            try
            {
                var messages = await _chatService.GetGroupMessagesAsync(classId);
                foreach (var msg in messages) DisplayMessageAsBubbleWithoutReorder(msg);

                _messageSubscription = _chatService.ListenForGroupMessages(classId, (msg) =>
                {
                    if (flowChatPanel.InvokeRequired) flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubble(msg)));
                    else DisplayMessageAsBubble(msg);
                });
            }
            catch (Exception ex) { MessageBox.Show("Lỗi chat nhóm: " + ex.Message); }
        }

        private void DisplayCachedMessagesAndListenForNew()
        {
            try
            {
                if (string.IsNullOrEmpty(_currentChatId)) return;
                if (_messageCache.ContainsKey(_currentChatId))
                {
                    var cachedMessages = _messageCache[_currentChatId];
                    foreach (var msg in cachedMessages) DisplayMessageAsBubbleWithoutReorder(msg);
                    UpdateLastMessageStatus();
                    if (cachedMessages.Any())
                    {
                        var latestMessage = cachedMessages.OrderByDescending(m => m.Timestamp).First();
                        _userLastMessageTime[_currentPartnerUid] = latestMessage.Timestamp;
                        UpdateContactItemWithLatestMessage(_currentPartnerUid, latestMessage);
                    }
                }
                _messageSubscription?.Dispose();
                _messageSubscription = _chatService.ListenForMessagesWithKey(_currentChatId, DisplayMessageAsBubbleWithKey);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hiển thị chat: " + ex.Message); }
        }

        private void DisplayMessageAsBubbleWithKey(string messageKey, Message msg)
        {
            if (flowChatPanel.IsDisposed) return;
            if (flowChatPanel.InvokeRequired) { flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubbleWithKey(messageKey, msg))); return; }

            bool isMe = (msg.SenderUid == _currentUserUid);

            if (!_isGroupMode && !isMe && _currentChatId != null && msg.Status != "seen" && !_seenUpdatedKeys.Contains(messageKey))
            {
                _seenUpdatedKeys.Add(messageKey);
                Task.Run(async () => { try { await _chatService.UpdateMessageStatusAsync(_currentChatId, messageKey, "seen"); } catch { } });
                msg.Status = "seen";
            }
            DisplayMessageAsBubble(msg);
        }

        private void DisplayMessageAsBubble(Message msg)
        {
            if (flowChatPanel.IsDisposed) return;
            if (flowChatPanel.InvokeRequired)
            {
                flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubble(msg)));
                return;
            }

            string msgId = GenerateMessageId(msg);

            if (!_isGroupMode)
            {
                if (!_messageCache.ContainsKey(_currentChatId)) _messageCache[_currentChatId] = new List<Message>();

                var cachedMsg = _messageCache[_currentChatId].FirstOrDefault(m => GenerateMessageId(m) == msgId);
                if (cachedMsg != null) cachedMsg.Status = msg.Status;
                else _messageCache[_currentChatId].Add(msg);
            }

            var existingBubble = flowChatPanel.Controls.Cast<Control>()
                                              .OfType<UC_ChatItem>()
                                              .FirstOrDefault(b => b.MessageId == msgId);
            if (existingBubble != null)
            {
                if (!_isGroupMode) UpdateLastMessageStatus();
                return;
            }

            UC_ChatItem newBubble = new UC_ChatItem();
            UpdateChatViewportWidthCache();
            newBubble.Width = _chatViewportWidth - 25;
            newBubble.MessageId = msgId;

            bool isMe = (msg.SenderUid == _currentUserUid);
            string type = msg.Type ?? "text";

            string avatarUrl = _isGroupMode ? "" : GetUserAvatarUrl(_currentPartnerUid);

            string status = _isGroupMode ? "" : (msg.Status == "sent" ? "Đã gửi" : msg.Status);

            // 5. Đổ dữ liệu vào bong bóng
            if (type == "file" || type == "image")
            {
                newBubble.SetMessage(msg.Text, isMe, status, type, msg.Timestamp, _previousMessageTimestamp, msg.FileUrl, msg.FileName, avatarUrl);
            }
            else
            {
                newBubble.SetMessage(
                        msg.Text,
                        isMe,
                        status,
                        type,
                        msg.Timestamp,
                        _previousMessageTimestamp,
                        null,
                        null,
                        avatarUrl,
                        _isGroupMode ? msg.SenderName + " - " + msg.SenderId : ""
                    );
            }

            _previousMessageTimestamp = msg.Timestamp;
            newBubble.HideStatusAndSeen();
            if (isMe)
            {
                newBubble.HideAvatar();
            }
            else
            {
                newBubble.ShowAvatarBelow();

                if (_isGroupMode)
                {
                    newBubble.ShowSenderName(msg.SenderName + " - " + msg.SenderId);
                }
            }

            flowChatPanel.Controls.Add(newBubble);
            flowChatPanel.ScrollControlIntoView(newBubble);

            if (!_isGroupMode)
            {
                UpdateLastMessageStatus();


                if (!string.IsNullOrEmpty(_currentPartnerUid))
                {
                    _userLastMessageTime[_currentPartnerUid] = msg.Timestamp;
                    UpdateContactItemWithLatestMessage(_currentPartnerUid, msg);
                    ReorderContactList();
                }
            }
        }
        private void DisplayMessageAsBubbleWithoutReorder(Message msg)
        {
            if (flowChatPanel.InvokeRequired) { flowChatPanel.Invoke(new Action(() => DisplayMessageAsBubbleWithoutReorder(msg))); return; }
            DisplayMessageAsBubble(msg);
        }

        private async void btnSend_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentUserUid))
            {
                MessageBox.Show("UID người dùng đang bị rỗng. Kiểm tra luồng đăng nhập/mở form chat.");
                return;
            }

            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(_currentChatId)) return;

            var message = new Message
            {
                SenderUid = _currentUserUid,
                SenderName = _currentUserName,
                SenderId = _currentMaso,
                Text = text,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Status = "sent",
                Type = "text"
            };

            System.Diagnostics.Debug.WriteLine($"Message payload: SenderUid={message.SenderUid}, SenderId={message.SenderId}");

            try
            {
                if (_isGroupMode) await _chatService.SendGroupMessageAsync(_currentChatId, message);
                else await _chatService.SendMessageAsync(_currentChatId, message);
                txtMessage.Clear(); txtMessage.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message); }
        }

        private async void btnUpload_Click_1(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentChatId)) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Supported|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = System.IO.Path.GetFileName(filePath);
                        bool isImage = IsImageFile(System.IO.Path.GetExtension(filePath));
                        MessageBox.Show("Đang tải file...", "Thông báo");

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

                            if (_isGroupMode) await _chatService.SendGroupMessageAsync(_currentChatId, fileMessage);
                            else await _chatService.SendMessageAsync(_currentChatId, fileMessage);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"Lỗi gửi file: {ex.Message}"); }
                }
            }
        }

        private async Task<string> GetUserRole(string uid)
        {
            try
            {
                var allUsers = await _chatService.GetAllUsersAsync();
                if (allUsers.TryGetValue(uid, out var user) && !string.IsNullOrEmpty(user.Role))
                    return user.Role;
                return "SinhVien";
            }
            catch
            {
                return "SinhVien";
            }
        }

        private void UpdateLastMessageStatus()
        {
            if (_isGroupMode) return;
            var allBubbles = flowChatPanel.Controls.Cast<Control>().OfType<UC_ChatItem>().ToList();
            foreach (var bubble in allBubbles) { bubble.HideStatusAndSeen(); if (!bubble.IsMe) bubble.ShowAvatarBelow(); }
            var myBubbles = allBubbles.Where(b => b.IsMe).ToList();
            if (myBubbles.Count == 0 || !_messageCache.ContainsKey(_currentChatId)) return;
            var chatMessages = _messageCache[_currentChatId];
            var lastSeenBubble = myBubbles.Where(b =>
            {
                var msgObj = chatMessages.FirstOrDefault(m => GenerateMessageId(m) == b.MessageId);
                return msgObj != null && msgObj.Status == "seen";
            }).LastOrDefault();
            var absolutelyLastBubble = myBubbles.LastOrDefault();
            if (lastSeenBubble != null) lastSeenBubble.SetStatusMode("seen", GetUserAvatarUrl(_currentPartnerUid));
            if (absolutelyLastBubble != null && absolutelyLastBubble != lastSeenBubble) absolutelyLastBubble.SetStatusMode("sent", "");
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
            var contactItem = flowUserListPanel.Controls.Cast<Control>().OfType<UC_UserContactItem>().FirstOrDefault(item => item.Tag?.ToString() == partnerId);
            if (contactItem != null)
            {
                contactItem.SetData(partnerId, contactItem.HoTen, contactItem.Email, contactItem.Role, msg.Text, ConvertTimestampToTime(msg.Timestamp), 0, contactItem.AvatarUrl);
            }
        }

        private void ReorderContactList()
        {
            var sorted = flowUserListPanel.Controls.Cast<Control>().OfType<UC_UserContactItem>()
                .OrderByDescending(c => _userLastMessageTime.ContainsKey(c.Tag?.ToString() ?? "") ? _userLastMessageTime[c.Tag.ToString()] : 0).ToList();
            flowUserListPanel.Controls.Clear();
            flowUserListPanel.Controls.AddRange(sorted.ToArray());
        }

        private void txtMessage_TextChanged(object? sender, EventArgs e)
        {
            if (!_isGroupMode && !string.IsNullOrEmpty(_currentChatId)) _chatService.SetTypingStatus(_currentChatId, _currentUserUid, true);
            _typingTimer.Stop(); _typingTimer.Start();
        }
        private void typingTimer_Tick(object? sender, EventArgs e)
        {
            if (!_isGroupMode && !string.IsNullOrEmpty(_currentChatId)) _chatService.SetTypingStatus(_currentChatId, _currentUserUid, false);
            _typingTimer.Stop();
        }
        private void txtMessage_KeyDown(object? sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter && !e.Shift) { e.SuppressKeyPress = true; btnSend_Click(null, EventArgs.Empty); } }
        private void guna2TextBox1_TextChanged(object? sender, EventArgs e) { }
        private void button1_Click(object? sender, EventArgs e) { }
        private string ConvertTimestampToTime(long timestamp) { return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timestamp).ToLocalTime().ToString("HH:mm"); }
        private string GenerateMessageId(Message msg) { return $"{msg.SenderUid}_{msg.Timestamp}"; }
        private bool IsImageFile(string ext) { string[] exts = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }; return exts.Contains(ext, StringComparer.OrdinalIgnoreCase); }
        private string GetUserAvatarUrl(string uid) { try { var c = flowUserListPanel.Controls.OfType<UC_UserContactItem>().FirstOrDefault(x => x.Tag?.ToString() == uid); return c?.AvatarUrl ?? ""; } catch { return ""; } }
        private void AutoSelectFirstUser() { try { var f = flowUserListPanel.Controls.OfType<UC_UserContactItem>().FirstOrDefault(); if (f != null) ContactItem_Clicked(f, EventArgs.Empty); } catch { } }
        private void SetupAutoScroll() { flowChatPanel.ControlAdded += (s, ev) => { UpdateChatViewportWidthCache(); flowChatPanel.ScrollControlIntoView(ev.Control); }; flowChatPanel.SizeChanged += (s, e) => UpdateChatViewportWidthCache(); this.Shown += (s, e) => UpdateChatViewportWidthCache(); }
        private void UpdateChatViewportWidthCache() { int w = flowChatPanel.DisplayRectangle.Width; if (w <= 0) w = flowChatPanel.ClientSize.Width; _chatViewportWidth = w; }
        private int GetChatViewportWidth() { return _chatViewportWidth; }
        private void frmMainChat_FormClosing(object? sender, FormClosingEventArgs e) { _messageSubscription?.Dispose(); _messageSubscription = null; }
        protected override void Dispose(bool disposing) { if (disposing) { _messageSubscription?.Dispose(); _typingTimer?.Dispose(); } base.Dispose(disposing); }
        private void lblInfoEmail_Click(object? sender, EventArgs e) { }
        private void lblInfoName_Click(object? sender, EventArgs e) { }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) { }

        private void lblInfoRole_Click(object sender, EventArgs e)
        {

        }
        private EmojiPickerForm _emojiForm;
        private int _txtMessageCaretIndex = 0;
        private int _lastCaretIndex = 0;

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            if (_emojiForm != null && !_emojiForm.IsDisposed)
            {
                _emojiForm.Close();
                _emojiForm = null;
                return;
            }

            _emojiForm = new EmojiPickerForm();

            _emojiForm.EmojiSelected += (s, emojiChar) =>
            {
                txtMessage.Focus();

                if (_lastCaretIndex < 0 || _lastCaretIndex > txtMessage.Text.Length)
                    _lastCaretIndex = txtMessage.Text.Length;

                string text = txtMessage.Text;

                txtMessage.Text =
                    text.Substring(0, _lastCaretIndex) +
                    emojiChar +
                    text.Substring(_lastCaretIndex);

                _lastCaretIndex += emojiChar.Length;
                txtMessage.SelectionStart = _lastCaretIndex;
            };


            Point btnLocation = btnEmoji.PointToScreen(Point.Empty);
            _emojiForm.Location = new Point(btnLocation.X - 150, btnLocation.Y - 330);

            _emojiForm.Show(this);
        }

    }
}