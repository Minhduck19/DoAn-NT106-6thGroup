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
        private System.Windows.Forms.Timer _typingTimer;

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

            // 1. "Bỏ chọn" TẤT CẢ item khác
            foreach (Control ctrl in flowUserListPanel.Controls)
            {
                if (ctrl is UC_UserContactItem item)
                {
                    item.SetSelected(false);
                }
            }

            // 2. "Chọn" item vừa click
            clickedItem.SetSelected(true);

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

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            // Tắt trạng thái typing sau 1.5s
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

            flowUserListPanel.SuspendLayout(); // Tối ưu hiệu năng vẽ

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
                string trangThai = msg.Status ?? "sent";
                string type = msg.Type ?? "text"; // Lấy type từ Message
                bubble.SetMessage(msg.Text, isMe, trangThai, type);
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

        private void flowUserListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContacts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            _chatService.SetTypingStatus(_currentChatId, _currentUserUid, true);

            _typingTimer.Stop();
            _typingTimer.Start();
        }
        private void typingTimer_Tick(object sender, EventArgs e)
        {
            _chatService.SetTypingStatus(_currentChatId, _currentUserUid, false);
            _typingTimer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnSend_Click_1(object sender, EventArgs e)
        {

        }


        private async void btnUpload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    panelInput.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    // 1. Upload ảnh qua CloudinaryHelper
                    string imageUrl = CloudinaryHelper.UploadImage(open.FileName);

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
                        Text = imageUrl, // Nội dung tin nhắn chính là Link ảnh
                        Type = "image", // Đánh dấu đây là ảnh
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                        Status = "sent"
                    };

                    await _chatService.SendMessageAsync(_currentChatId, msg);
                    MessageBox.Show("Gửi ảnh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       
    }
}