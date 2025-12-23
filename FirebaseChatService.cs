using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
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

        public async Task<string> UploadImage(System.IO.Stream imageStream, string fileName)
        {
            // Lưu stream vào file tạm thời
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);
            
            try
            {
                using (var fileStream = System.IO.File.Create(tempFilePath))
                {
                    await imageStream.CopyToAsync(fileStream);
                }

                // Dùng CloudinaryHelper để upload
                string imageUrl = CloudinaryHelper.UploadImage(tempFilePath);
                
                return imageUrl;
            }
            finally
            {
                // Xóa file tạm thời sau khi upload
                if (System.IO.File.Exists(tempFilePath))
                {
                    System.IO.File.Delete(tempFilePath);
                }
            }
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

        public async Task DeleteMessageAsync(string chatId, string messageId)
        {
            await _firebaseClient
                .Child("Chats")
                .Child(chatId)
                .Child("Messages")
                .Child(messageId)
                .DeleteAsync();
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
                    if (userEvent.Object != null)
                    {
                        var userObj = userEvent.Object;
                        string uid = userEvent.Key;

                        if (userEvent.EventType == Firebase.Database.Streaming.FirebaseEventType.Delete)
                        {
                            // Xử lý khi user bị xóa (nếu cần)
                        }
                        else
                        {
                            onStatusChanged?.Invoke(uid, userObj.IsOnline);
                        }
                    }
                });
        }

        public async Task SetTypingStatus(string chatId, string uid, bool isTyping)
        {
            await _firebaseClient.Child("Chats").Child(chatId).Child("Typing").Child(uid).PutAsync(isTyping);
        }

        // Lắng nghe người kia gõ
        public IDisposable ListenForTyping(string chatId, string partnerUid, Action<bool> onTypingChanged)
        {
            return _firebaseClient.Child("Chats").Child(chatId).Child("Typing").Child(partnerUid)
                .AsObservable<bool>()
                .Subscribe(evt => onTypingChanged?.Invoke(evt.Object));
        }
    }
}
