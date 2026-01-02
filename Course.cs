using System.Collections.Generic;

namespace APP_DOAN
{
    public class Course
    {
        // --- 1. CÁC THUỘC TÍNH BẮT BUỘC ĐỂ MAINFORM CHẠY ---
        public string Id { get; set; } // Key của Firebase
        public string TenLop { get; set; }
        public string Instructor { get; set; } // Giảng viên (MainForm đang gọi cái này)
        public bool IsJoined { get; set; }     // Trạng thái đã tham gia hay chưa

        // --- 2. CÁC THUỘC TÍNH BỔ SUNG CỦA BẠN (GIỮ LẠI ĐỂ DÙNG SAU) ---
        public string MaLop { get; set; }
        public int SiSo { get; set; }
        public int SiSoHienTai { get; set; }

        // Để mapping dữ liệu nếu trên Firebase bạn lưu là "GiangVien" thay vì "Instructor"
        public string GiangVien
        {
            get => Instructor;
            set => Instructor = value;
        }

        public List<string> Students { get; set; } = new List<string>();
        public string GiangVienUid { get; set; }

        // --- 3. CÁC CONSTRUCTOR QUAN TRỌNG (FIX LỖI CS1729) ---

        // Constructor rỗng: BẮT BUỘC để Firebase tải data về
        public Course() { }

        // Constructor có tham số: BẮT BUỘC để code MainForm dòng new Course(...) chạy được
        public Course(string id, string tenLop, string instructor, bool isJoined)
        {
            Id = id;
            TenLop = tenLop;
            Instructor = instructor;
            IsJoined = isJoined;

            // Mặc định mấy cái này để tránh null
            Students = new List<string>();
        }
    }
}