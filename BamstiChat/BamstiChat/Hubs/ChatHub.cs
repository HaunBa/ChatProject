namespace BamstiChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string sender, string retriever, string message)
        {
            await _chatService.SendMessageToUser(message, sender, retriever);
            await Clients.Group(retriever).SendAsync("NewMessage", sender, message);
        }

        // join group to get notifications for username
        public async Task JoinGroup(string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, username);
        }
    }
}
