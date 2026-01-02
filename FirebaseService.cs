using APP_DOAN;
using Firebase.Database;
using Firebase.Database.Query;

public class FirebaseService
{
    private static FirebaseService _instance;
    // Singleton không khởi tạo trực tiếp ở đây vì cần Token
    public static FirebaseService Instance => _instance ?? throw new Exception("FirebaseService chưa được khởi tạo với Token!");

    public  readonly FirebaseClient _client;

    // 1. Chuyển Constructor thành private để bảo vệ Singleton
    private FirebaseService(string idToken)
    {
        _client = new FirebaseClient(
            "https://nt106-minhduc-default-rtdb.firebaseio.com/",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(idToken)
            });
    }

    // 2. Hàm khởi tạo dùng sau khi Login thành công
    public static void Initialize(string idToken)
    {
        _instance = new FirebaseService(idToken);
    }

    // 🔥 LẤY BÀI NỘP THEO MÔN (GV)
    public async Task<List<AssignmentSubmitResult>> GetAssignmentsByCourseAsync(string courseId)
    {
        var result = new List<AssignmentSubmitResult>();
        try
        {
            var snapshot = await _client
                .Child("Assignments")
                .Child(courseId)
                .OnceAsync<AssignmentSubmitResult>();

            if (snapshot != null)
            {
                foreach (var s in snapshot)
                {
                    if (s.Object != null)
                    {
                        // Gán thêm Key (UID sinh viên) nếu cần quản lý
                        result.Add(s.Object);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log lỗi tại đây (ví dụ: lỗi 403 Forbidden do Rules)
            Console.WriteLine(ex.Message);
        }
        return result;
    }
}

