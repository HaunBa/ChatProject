namespace BamstiChat.Services
{
    public interface IChatService
    {
        public Task<List<Message>> GetMessagesFromChat(int id);
        public Task<int> CreateChat(string name);
        public Task<int> SendMessageToUser(string chatName, string message, string senderId, string retrieverId);
    }
}
