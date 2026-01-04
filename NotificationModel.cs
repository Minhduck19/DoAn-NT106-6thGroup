namespace APP_DOAN
{
    public class NotificationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string DueDate { get; set; }   // ngày áp dụng / nhắc nhở
        public string FileUrl { get; set; }
        public long CreatedAt { get; set; }
    }
}
