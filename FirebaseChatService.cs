using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq; // Cần cài NuGet: System.Reactive
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.VisualBasic;

namespace APP_DOAN
{
    public class FirebaseChatService
    {
        // Khai báo biến chuẩn là _firebaseClient
        private readonly FirebaseClient _firebaseClient;

        public FirebaseChatService(string baseUrl, string authToken)
        {
            // Cấu hình kết nối với Auth Token
            _firebaseClient = new FirebaseClient(baseUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(authToken)
            });
        }

        // 1. Lấy danh sách toàn bộ user
        public async Task<Dictionary<string, User>> GetAllUsersAsync()
        {
            var users = await _firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            var result = new Dictionary<string, User>();
            foreach (var u in users)
            {
                result.Add(u.Key, u.Object);
            }
            return result;
        }

        // 2. Tạo Chat ID (Unique Key giữa 2 người)
        public string GenerateChatId(string uid1, string uid2)
        {
            // So sánh chuỗi để luôn tạo ra 1 ID giống nhau cho cặp đôi này
            // Ví dụ: A và B -> ID là "A_B". B và A -> ID vẫn là "A_B"
            return string.Compare(uid1, uid2) < 0 ? $"{uid1}_{uid2}" : $"{uid2}_{uid1}";
        }

        // 3. Gửi tin nhắn
        public async Task SendMessageAsync(string chatId, Message message)
        {
            await _firebaseClient
                .Child("chats")
                .Child(chatId)
                .Child("messages")
                .PostAsync(message);
        }

        // 4. Lắng nghe tin nhắn (Realtime)
        public IDisposable ListenForMessages(string chatId, Action<Message> onMessageReceived)
        {
            
            return _firebaseClient
                .Child("chats")
                .Child(chatId)
                .Child("messages")
                .AsObservable<Message>()
                .Subscribe(d =>
                {

                    var msg = d.Object; // Lấy nội dung tin nhắn
                    if (msg == null) return;

                    // --- THÊM DÒNG NÀY ---
                    msg.Key = d.Key;    // Lấy ID tin nhắn gán vào biến Key vừa tạo
                                        // ---------------------

                    onMessageReceived(msg);
                });
        }

        // --- CÁC HÀM NÂNG CẤP (TYPING, READ RECEIPT) ---

        // 5. Cập nhật trạng thái "Đang nhập..."
        public async Task SetTypingStatusAsync(string chatId, string userId, bool isTyping)
        {
            await _firebaseClient
                .Child("chats")
                .Child(chatId)
                .Child("typing")
                .Child(userId)
                .PutAsync(isTyping);
        }

        // 6. Lắng nghe đối phương gõ phím
        public IDisposable ListenForPartnerTyping(string chatId, string partnerUid, Action<bool> onTypingChanged)
        {
            return _firebaseClient
                .Child("chats")
                .Child(chatId)
                .Child("typing")
                .Child(partnerUid)
                .AsObservable<bool>()
                .Subscribe(d =>
                {
                    if (d.Key == partnerUid)
                    {
                        onTypingChanged(d.Object);
                    }
                });
        }

        // 7. Đánh dấu tin nhắn đã xem
        public async Task MarkMessageAsReadAsync(string chatId, string messageKey)
        {
            if (string.IsNullOrEmpty(messageKey)) return;

            await _firebaseClient
                .Child("chats")
                .Child(chatId)
                .Child("messages")
                .Child(messageKey)
                .Child("Status")
                .PutAsync("read");
        }
    }
}