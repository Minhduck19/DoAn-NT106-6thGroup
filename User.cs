using Newtonsoft.Json;
using System;

namespace APP_DOAN
{
    public class User
    {
        public string HoTen { get; set; }
        public string MaGiangVien { get; set; }
        public string NgaySinh { get; set; }
        public string Sex { get; set; }
        public string Khoa { get; set; }
        public string ChucVu { get; set; }
        public string Bang { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsOnline { get; set; }
        public string CreatedDate { get; set; }
    }
}