namespace APP_DOAN
{
    public class AssignmentSubmitResult
    {
        public string TenLop { get; set; }
        public string TenFile { get; set; }
        public string FileUrl { get; set; }

        public long ThoiGianNop { get; set; }   // 🔥 UnixTime

        public string StudentUid { get; set; }
        public string AssignmentId { get; set; }

        public AssignmentSubmitResult() { }
    }
}
