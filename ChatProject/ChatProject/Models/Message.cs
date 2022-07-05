namespace ChatProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime SentAt { get; set; }
        public int FromUserId { get; set; }
        public ApplicationUser SenderUser { get; set; }
        public int ToUserId { get; set; }
        public ApplicationUser DestinationUser { get; set; }
        public string Text { get; set; }
        public byte[] ImageData { get; set; }
    }
}