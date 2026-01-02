using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN
{
    public class FirebaseChatService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseChatService(string dbUrl, string idToken)
        {
            var jsonSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeNonAscii,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            _firebaseClient = new FirebaseClient(dbUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(idToken),
                JsonSerializerSettings = jsonSettings
            });
        }

        public async Task<string> UploadImage(System.IO.Stream imageStream, string fileName)
        {
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);

            try
            {
                using (var fileStream = System.IO.File.Create(tempFilePath))
                {
                    await imageStream.CopyToAsync(fileStream);
                }

                string imageUrl = CloudinaryHelper.UploadImage(tempFilePath);
                return imageUrl;
            }
            finally
            {
                if (System.IO.File.Exists(tempFilePath))
                {
                    System.IO.File.Delete(tempFilePath);
                }
            }
        }

        public async Task<string> UploadFile(System.IO.Stream fileStream, string fileName)
        {
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);

            try
            {
                using (var file = System.IO.File.Create(tempFilePath))
                {
                    await fileStream.CopyToAsync(file);
                }

                string fileUrl = CloudinaryHelper.UploadFile(tempFilePath);
                return fileUrl;
            }
            finally
            {
                if (System.IO.File.Exists(tempFilePath))
                {
                    System.IO.File.Delete(tempFilePath);
                }
            }
        }

        public string GenerateChatId(string uid1, string uid2)
        {
            return string.Compare(uid1, uid2) > 0 ? $"{uid2}_{uid1}" : $"{uid1}_{uid2}";
        }

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

        public async Task<List<Message>> GetMessagesAsync(string chatId)
        {
            try
            {
                var messages = await _firebaseClient
                    .Child("Chats")
                    .Child(chatId)
                    .Child("Messages")
                    .OnceAsync<Message>();

                return messages.Select(m => m.Object).OrderBy(m => m.Timestamp).ToList();
            }
            catch
            {
                return new List<Message>();
            }
        }

        public IDisposable ListenForMessages(string chatId, Action<Message> onMessageReceived)
        {
            return _firebaseClient
                .Child("Chats")
                .Child(chatId)
                .Child("Messages")
                .AsObservable<Message>()
                .Subscribe(firebaseEvent =>
                {
                    if (firebaseEvent.Object != null)
                    {
                        var msg = firebaseEvent.Object;
                        onMessageReceived?.Invoke(msg);
                    }
                });
        }

        public async Task<Dictionary<string, User>> GetAllUsersAsync()
        {
            var users = await _firebaseClient.Child("Users").OnceAsync<User>();
            return users.ToDictionary(item => item.Key, item => item.Object);
        }

        public async Task UpdateUserOnlineStatus(string uid, bool isOnline)
        {
            await _firebaseClient.Child("Users").Child(uid).Child("IsOnline").PutAsync(isOnline);
        }

        public IDisposable ListenForUserStatus(Action<string, bool> onStatusChanged)
        {
            return _firebaseClient.Child("Users").AsObservable<User>()
                .Subscribe(userEvent =>
                {
                    if (userEvent.Object != null)
                    {
                        var userObj = userEvent.Object;
                        string uid = userEvent.Key;

                        if (userEvent.EventType != Firebase.Database.Streaming.FirebaseEventType.Delete)
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

        public IDisposable ListenForTyping(string chatId, string partnerUid, Action<bool> onTypingChanged)
        {
            return _firebaseClient.Child("Chats").Child(chatId).Child("Typing").Child(partnerUid)
                .AsObservable<bool>()
                .Subscribe(evt => onTypingChanged?.Invoke(evt.Object));
        }

        public async Task DeleteChatAsync(string chatId)
        {
            await _firebaseClient.Child("Chats").Child(chatId).DeleteAsync();
        }
    }
}
