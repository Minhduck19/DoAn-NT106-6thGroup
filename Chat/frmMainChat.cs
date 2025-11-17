using Firebase.Database;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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



        public frmMainChat(string uid, string hoTen,string idToken)
        {
            InitializeComponent();
            _currentUserUid = uid;
            _currentUserName = hoTen;
            _idToken = idToken;
            _chatService = new FirebaseChatService(FIREBASE_URL, _idToken);


            



            this.Text = $"Chào mừng, {hoTen}!";
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

                    if (uid == _currentUserUid)
                    {
                        continue;
                    }

                    UC_UserContactItem contactItem = new UC_UserContactItem();
                    contactItem.Width = flowUserListPanel.ClientSize.Width - 25;

                    contactItem.SetData(
                        uid: uid,
                        hoTen: user.HoTen,
                        lastMessage: $"Email: {user.Email}",
                        timestamp: user.Role,
                        unreadCount: 0
                    );

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

            // Đảm bảo bạn truyền 5 THAM SỐ (thêm _idToken)
            frmChat chatForm = new frmChat(
                currentUserUid: _currentUserUid,
                currentUserName: _currentUserName,
                partnerUid: clickedItem.UserId,
                partnerName: clickedItem.HoTen,
                idToken: _idToken // <-- Phải có dòng này
            );
            chatForm.Show();
        }

        private void flowUserListPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}