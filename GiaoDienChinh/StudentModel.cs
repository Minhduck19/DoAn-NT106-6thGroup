using Newtonsoft.Json;

namespace APP_DOAN
{
    public class UserProfile
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MSSV { get; set; }
        public string Role { get; set; }
    }

    public class RequestModel
    {
        public string StudentName { get; set; } // Khớp với ảnh 2
        public string StudentUid { get; set; }  // Khớp với ảnh 2
        public string Status { get; set; }
        public string RequestTime { get; set; }
    }
}