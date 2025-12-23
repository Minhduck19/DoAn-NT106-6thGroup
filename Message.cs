namespace APP_DOAN 
{
    public class Message
    {
        
            // ... các thuộc tính cũ (SenderUid, Text, Timestamp)...

            // Thêm cái này: Trạng thái (sent, delivered, read)
        public string Status { get; set; } = "sent"; // Mặc định là đã gửi
        public string Key { get; set; }
        public string SenderUid { get; set; }    // UID của người gửi
        public string SenderName { get; set; }   // Tên của người gửi
        public string Text { get; set; }         // Nội dung tin nhắn
        public long Timestamp { get; set; }      // Dấu thời gian (Unix)
    }
}