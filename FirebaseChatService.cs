using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
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

        public async Task UpdateMessageStatusAsync(string chatId, string messageKey, string status)
        {
            await _firebaseClient
                .Child("Chats")
                .Child(chatId)
                .Child("Messages") 
                .Child(messageKey)
                .Child("Status")
                .PutAsync($"\"{status}\""); 
        }

        public IDisposable ListenForMessagesWithKey(string chatId, Action<string, Message> onMessageReceived)
        {
            return _firebaseClient
                .Child("Chats")
                .Child(chatId)
                .Child("Messages")
                .AsObservable<Message>()
                .Subscribe(firebaseEvent =>
                {
                    if (firebaseEvent.Object != null && !string.IsNullOrEmpty(firebaseEvent.Key))
                    {
                        onMessageReceived?.Invoke(firebaseEvent.Key, firebaseEvent.Object);
                    }
                });
        }
        public async Task<List<Message>> GetGroupMessagesAsync(string classId)
        {
            try
            {
                var messages = await _firebaseClient
                    .Child("Groups")
                    .Child(classId)
                    .Child("Messages")
                    .OnceAsync<Message>();

                return messages.Select(m => m.Object).ToList();
            }
            catch
            {
                return new List<Message>();
            }
        }

       
        public async Task SendGroupMessageAsync(string classId, Message message)
        {
            await _firebaseClient
                .Child("Groups")
                .Child(classId)
                .Child("Messages")
                .PostAsync(message);
        }

      
        public IDisposable ListenForGroupMessages(string classId, Action<Message> onMessageReceived)
        {
            return _firebaseClient
                .Child("Groups")
                .Child(classId)
                .Child("Messages")
                .AsObservable<Message>()
                .Subscribe(d =>
                {
                    // Chỉ nhận tin nhắn mới thêm vào (EventType.InsertOrUpdate)
                    if (d.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate && d.Object != null)
                    {
                        onMessageReceived(d.Object);
                    }
                });
        }

        public async Task<Dictionary<string, string>> GetMyCoursesAsync(string userUid, string userRole)
        {
            var myCourses = new Dictionary<string, string>(); // Key: ClassID, Value: Tên Lớp

            try
            {
                if (userRole == "GiangVien")
                {
                    var courses = await _firebaseClient
                        .Child("Courses")
                        .OrderBy("GiangVienUid")
                        .EqualTo(userUid)
                        .OnceAsync<object>();

                    foreach (var c in courses)
                    {
                        string name = $"Lớp {c.Key}";

                        try
                        {
                            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(c.Object?.ToString() ?? string.Empty)
                                       ?? new Dictionary<string, object>();

                            if (data.TryGetValue("TenLop", out var tenLopObj) && tenLopObj != null)
                                name = tenLopObj.ToString();
                            else if (data.TryGetValue("CourseName", out var courseNameObj) && courseNameObj != null)
                                name = courseNameObj.ToString();
                            else if (data.TryGetValue("Name", out var nameObj) && nameObj != null)
                                name = nameObj.ToString();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Parse course name error: " + ex.Message);
                        }

                        if (!myCourses.ContainsKey(c.Key))
                            myCourses.Add(c.Key, name);
                    }
                }
                else
                {
                    var allCourseStudents = await _firebaseClient.Child("CourseStudents").OnceAsync<object>();

                    foreach (var courseNode in allCourseStudents)
                    {
                        string courseId = courseNode.Key;

                        var isEnrolled = await _firebaseClient
                            .Child("CourseStudents")
                            .Child(courseId)
                            .Child(userUid)
                            .OnceSingleAsync<object>();

                        if (isEnrolled == null)
                            continue;

                        string className = $"Lớp {courseId}";

                        try
                        {
                            var courseObj = await _firebaseClient
                                .Child("Courses")
                                .Child(courseId)
                                .OnceSingleAsync<object>();

                            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(courseObj?.ToString() ?? string.Empty)
                                       ?? new Dictionary<string, object>();

                            if (data.TryGetValue("TenLop", out var tenLopObj) && tenLopObj != null)
                                className = tenLopObj.ToString();
                            else if (data.TryGetValue("CourseName", out var courseNameObj) && courseNameObj != null)
                                className = courseNameObj.ToString();
                            else if (data.TryGetValue("Name", out var nameObj) && nameObj != null)
                                className = nameObj.ToString();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Load course name error: " + ex.Message);
                        }

                        if (!myCourses.ContainsKey(courseId))
                            myCourses.Add(courseId, className);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi load lớp: " + ex.Message);
            }

            return myCourses;
        }
        public async Task<bool> IsTeacherOfClassAsync(string classId, string userUid)
        {
            try
            {
                var teacherId = await _firebaseClient
                    .Child("Courses")
                    .Child(classId)
                    .Child("GiangVienUid") // Lấy GiangVienUid để so sánh
                    .OnceSingleAsync<string>();

                return teacherId == userUid;
            }
            catch
            {
                return false;
            }
        }
    }
}
