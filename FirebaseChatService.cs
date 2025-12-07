using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace APP_DOAN
{
    public class FirebaseChatService
    {
        private readonly FirebaseClient _client;
        private readonly string _firebaseDatabaseUrl;


        public FirebaseChatService(string dbUrl, string idToken)
        {
            _firebaseDatabaseUrl = dbUrl;
            _client = new FirebaseClient(
                _firebaseDatabaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(idToken)
                });
        }

        // Hàm tạo ID phòng chat
        public string GenerateChatId(string uid1, string uid2)
        {
            if (string.Compare(uid1, uid2) > 0)
                return $"{uid2}_{uid1}";
            return $"{uid1}_{uid2}";
        }

        // Hàm Gửi tin nhắn
        public async Task SendMessageAsync(string chatId, Message message)
        {
            await _client
                .Child("Chats")
                .Child(chatId)
                .Child("Messages")
                .PostAsync(message);
        }

        // Hàm Lắng nghe (Real-time)
        public IDisposable ListenForMessages(string chatId, Action<Message> onMessageReceived)
        {
            var subscription = _client
                .Child("Chats")
                .Child(chatId)
                .Child("Messages")
                .AsObservable<Message>()
                .Where(e => e.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                .Subscribe(firebaseEvent =>
                {
                    if (firebaseEvent.Object != null)
                    {
                        onMessageReceived?.Invoke(firebaseEvent.Object);
                    }
                });

            return subscription;
        }
        /// <summary>
        /// Tải tất cả người dùng từ Firebase
        /// </summary>
        /// <returns>Một Dictionary<string, User> 
        ///          trong đó Key là UID, Value là thông tin User
        /// </returns>
        public async Task<Dictionary<string, User>> GetAllUsersAsync()
        {
            var users = await _client
                .Child("Users")
                .OnceAsync<User>();

            return users.ToDictionary(item => item.Key, item => item.Object);
        }
    }
}