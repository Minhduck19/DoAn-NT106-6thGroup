using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DOAN
{
    internal class Teacher_Data
    {
    }
    public class GiangVienData
    {
        public string HoTen { get; set; }       // Họ và tên
        public string MaGiangVien { get; set; } // Mã giảng viên
        public string NgaySinh { get; set; }    // Ngày sinh
        public string Khoa { get; set; }        // Khoa
        public string MonHoc { get; set; }      // Môn học / lớp dạy
        public string Bang { get; set; }        // Bằng cấp
        public string Email { get; set; }       // Email
    }
}
