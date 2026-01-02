using System;

namespace APP_DOAN
{
    public class AssignmentModel
    {
        // Phải có public và { get; set; } thì code bên kia mới đọc được
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }

        // Constructor mặc định (nếu cần)
        public AssignmentModel() { }
    }
}