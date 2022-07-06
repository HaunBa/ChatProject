namespace BamstiChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime SentAt { get; set; }
        public int SenderUserId { get; set; }
        public ApplicationUser SenderUser { get; set; }
        public int DestinationUserId { get; set; }
        public ApplicationUser DestinationUser { get; set; }
        public string Text { get; set; }
        public byte[] ImageData { get; set; }
    }
}
