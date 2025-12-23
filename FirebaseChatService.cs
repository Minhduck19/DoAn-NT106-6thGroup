using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace APP_DOAN
{
    public class FirebaseChatService
    {
        // Khai báo biến chuẩn là _firebaseClient
        private readonly FirebaseClient _firebaseClient;

        public FirebaseChatService(string dbUrl, string idToken)
        {
            // Cấu hình kết nối với Auth Token
            _firebaseClient = new FirebaseClient(dbUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(idToken)
            });
        }

        // Tạo chatId
        public string GenerateChatId(string uid1, string uid2)
        {
            return string.Compare(uid1, uid2) > 0 ? $"{uid2}_{uid1}" : $"{uid1}_{uid2}";
        }

        // Gửi tin nhắn
        public async Task SendMessageAsync(string chatId, Message message)
        {
            await _firebaseClient.Child("Chats").Child(chatId).Child("Messages").PostAsync(message);
        }

        // Lắng nghe tin nhắn realtime
        public IDisposable ListenForMessages(string chatId, Action<Message> onMessageReceived)
        {
            return _firebaseClient
                .Child("Chats")
                .Child(chatId)
                .Child("Messages")
                .AsObservable<Message>()
                .Where(e => e.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                .Subscribe(firebaseEvent =>
                {
                    if (firebaseEvent.Object != null)
                        onMessageReceived?.Invoke(firebaseEvent.Object);
                });
        }

        // Lấy tất cả user
        public async Task<Dictionary<string, User>> GetAllUsersAsync()
        {
            var users = await _firebaseClient.Child("Users").OnceAsync<User>();
            return users.ToDictionary(item => item.Key, item => item.Object);
        }

        // Cập nhật trạng thái online/offline
        public async Task UpdateUserOnlineStatus(string uid, bool isOnline)
        {
            await _firebaseClient.Child("Users").Child(uid).Child("IsOnline").PutAsync(isOnline);
        }

        // Lắng nghe trạng thái online/offline realtime
        public IDisposable ListenForUserStatus(Action<string, bool> onStatusChanged)
        {
            return _firebaseClient.Child("Users").AsObservable<User>()
                .Subscribe(userEvent =>
                {
                    if (userEvent.Object != null && userEvent.Key != null)
                    {
                        bool isOnline = false;
                        var prop = userEvent.Object.GetType().GetProperty("IsOnline");
                        if (prop != null)
                            isOnline = Convert.ToBoolean(prop.GetValue(userEvent.Object));
                        onStatusChanged?.Invoke(userEvent.Key, isOnline);
                    }
                });
        }
    }
}
