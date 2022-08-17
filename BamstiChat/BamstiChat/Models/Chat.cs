namespace BamstiChat.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public DateTime Since { get; set; }
        public List<Message> Messages { get; set; }
    }
}