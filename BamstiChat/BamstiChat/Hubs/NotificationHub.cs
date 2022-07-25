namespace BamstiChat.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string retriever) => await Clients.Group(retriever).SendAsync("NewNotification");

        public async Task JoinGroup(string user) => await Groups.AddToGroupAsync(Context.ConnectionId, user);
    }
}
