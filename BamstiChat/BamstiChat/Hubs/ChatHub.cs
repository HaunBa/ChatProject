namespace BamstiChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string sender, string retriever) => await Clients.Group(retriever).SendAsync("NewMessage", sender);

        // join group to get notifications for username
        public async Task JoinGroup(string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, username);
        }
    }
}
