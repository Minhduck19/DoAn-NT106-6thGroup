namespace APP_DOAN 
{
    public class Message
    {
        public string SenderUid { get; set; }    // UID của người gửi
        public string SenderName { get; set; }   // Tên của người gửi
        public string Text { get; set; }         // Nội dung tin nhắn
        public long Timestamp { get; set; }      // Dấu thời gian (Unix)
    }
}