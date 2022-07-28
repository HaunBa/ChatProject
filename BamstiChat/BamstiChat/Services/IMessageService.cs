namespace BamstiChat.Services
{
    public interface IMessageService
    {
        public List<Message> GetAllMessagesBetweenUsers(string user1, string user2);
    }
}
