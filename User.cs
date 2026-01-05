using Newtonsoft.Json;
using System;

namespace APP_DOAN
{
    public class User
    {
        // 🔥 QUAN TRỌNG: Nội dung trong ngoặc ("...") phải GIỐNG HỆT trên ảnh Firebase của bạn

        [JsonProperty("HoTen")] // Trong ảnh là "HoTen"
        public string HoTen { get; set; }

        [JsonProperty("MaGiangVien")]
        public string MaGiangVien { get; set; }

        [JsonProperty("MSSV")]
        public string MSSV { get; set; }

        [JsonProperty("NgaySinh")] // Trong ảnh là "NgaySinh"
        public string NgaySinh { get; set; }

        [JsonProperty("Sex")] // Trong ảnh là "Sex"
        public string Sex { get; set; }

        [JsonProperty("Khoa")] // Trong ảnh là "Khoa"
        public string Khoa { get; set; }

        [JsonProperty("ChucVu")] // Trong ảnh là "ChucVu"
        public string ChucVu { get; set; }

        [JsonProperty("Lop")] // Trong ảnh là "ChucVu"
        public string Lop { get; set; }

        [JsonProperty("Bang")] // Trong ảnh là "Bang"
        public string Bang { get; set; }

        [JsonProperty("Email")] // Trong ảnh là "Email"
        public string Email { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }

        [JsonProperty("IsOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("CreatedDate")]
        public string CreatedDate { get; set; }

        // Trường này có thể chưa có trên Firebase, nhưng cứ để mặc định để code không lỗi
        [JsonProperty("AvatarUrl")]
        public string AvatarUrl { get; set; } = "https://i.imgur.com/7vN3FAa.png";
    }
}