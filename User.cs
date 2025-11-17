namespace APP_DOAN
{
    public class User
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Lop { get; set; }
        public string MSSV { get; set; }
        public string NganhHoc { get; set; }
        public string NgaySinh { get; set; }

        // Các trường của GV (có thể là null nếu là SV)
        public string MaGiangVien { get; set; }
        public string Khoa { get; set; }
        public string ChucVu { get; set; }
    }
}