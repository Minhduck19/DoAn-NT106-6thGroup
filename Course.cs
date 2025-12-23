namespace APP_DOAN
{
    public class CourseInfo
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string GiangVien { get; set; }
        public int SiSo { get; set; } 
        public int SiSoHienTai { get; set; } 
        public List<string> Students { get; set; } = new List<string>(); 
        public int SoLuongHienTai => Students?.Count ?? 0;

        public string GiangVienUid { get; set; }
    }
}
