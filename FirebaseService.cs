using APP_DOAN;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FirebaseService
{
    private static FirebaseService _instance;
    public static FirebaseService Instance =>
        _instance ?? throw new Exception("FirebaseService chưa được khởi tạo!");

    public readonly FirebaseClient _client;

    private FirebaseService(string idToken)
    {
        _client = new FirebaseClient(
            "https://nt106-minhduc-default-rtdb.firebaseio.com/",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(idToken)
            });
    }

    public static void Initialize(string idToken)
    {
        _instance = new FirebaseService(idToken);
    }

    // 🔥 GIÁO VIÊN: LẤY TOÀN BỘ BÀI NỘP CỦA MÔN HỌC
    public async Task<List<AssignmentSubmitResult>> GetAssignmentsByCourseAsync(string courseId)
    {
        var results = new List<AssignmentSubmitResult>();

        try
        {
            // 1. Lấy danh sách bài tập
            var assignments = await _client
                .Child("Assignments")
                .Child(courseId)
                .OnceAsync<object>();

            foreach (var assignment in assignments)
            {
                string assignmentId = assignment.Key;

                // 2. Lấy bài nộp của sinh viên trong mỗi bài tập
                var submissions = await _client
                    .Child("Assignments")
                    .Child(courseId)
                    .Child(assignmentId)
                    .Child("Submissions")
                    .OnceAsync<AssignmentSubmitResult>();

                foreach (var sub in submissions)
                {
                    if (sub.Object != null)
                    {
                        sub.Object.StudentUid = sub.Key;
                        sub.Object.AssignmentId = assignmentId;

                        results.Add(sub.Object);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Firebase error: " + ex.Message);
        }

        return results;
    }
}
