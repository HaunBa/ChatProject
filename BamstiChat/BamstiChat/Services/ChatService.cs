namespace BamstiChat.Services
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Message>> GetMessagesFromChat(int id)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Id == id);
            return chat?.Messages;
        }

        public async Task<int> SendMessageToUser(string chatName, string message, string senderId, string retrieverId)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Name == chatName);
            if (chat == null) return -1;

            var sender = await _userManager.FindByIdAsync(senderId);
            if(sender == null) return -2;

            var retriever = await _userManager.FindByIdAsync(retrieverId);
            if (retriever == null) return -3;

            var Message = new Message()
            {
                SentAt = DateTime.Now,
                DestinationUserId = retriever.Id,
                SenderUserId = sender.Id,
                Text = message
            };

            chat.Messages.Add(Message);
            await _context.SaveChangesAsync();

            return 1;
        }

        public async Task<int> CreateChat(string name)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Name == name);
            if (chat != null) return -1;

            await _context.Chats.AddAsync(new Chat { Name = name, Since = DateTime.Now });
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}