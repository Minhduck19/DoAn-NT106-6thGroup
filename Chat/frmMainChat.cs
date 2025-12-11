using System;
using System.Linq;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class frmMainChat : Form
    {
        private readonly string _currentUserUid;
        private readonly string _currentUserName;
        private readonly string _idToken;
        private readonly FirebaseChatService _chatService;
        private IDisposable _userStatusSubscription;

        private const string FIREBASE_URL = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        public frmMainChat(string currentUserUid, string currentUserName, string idToken)
        {
            InitializeComponent();

            _currentUserUid = currentUserUid;
            _currentUserName = currentUserName;
            _idToken = idToken;

            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);
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
    }
}
