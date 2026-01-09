namespace APP_DOAN
{
    public class AssignmentSubmitResult
    {
        // 🔑 Firebase key
        public string SubmissionId { get; set; }

        // 🔗 Liên kết
        public string CourseId { get; set; }
        public string AssignmentId { get; set; }
        public string StudentUid { get; set; }

        // 📄 File
        public string TenFile { get; set; }
        public string FileUrl { get; set; }

        // ⏰ Thời gian
        public long ThoiGianNop { get; set; }

        // 📧 Trạng thái email
        public bool EmailSent { get; set; }

        // (OPTIONAL) Dùng hiển thị
        public string TenLop { get; set; }

        public AssignmentSubmitResult() { }
    }
}
