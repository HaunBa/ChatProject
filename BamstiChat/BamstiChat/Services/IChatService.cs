namespace BamstiChat.Services
{
    public interface IChatService
    {
        public Task<List<Message>> GetMessagesFromChat(int id);
        public Task<List<Message>> GetMessagesFromChatByUsers(string user1, string user2);
        public Task<int> CreateGroupChat(string name);
        public Task<Chat> CreateChat(string user1, string user2);
        public Task<int> SendMessageToGroup(string chatName, string message, string senderId, string retrieverId);
        public Task<int> SendMessageToUser(string message, string sender, string retriever);
    } 
}
