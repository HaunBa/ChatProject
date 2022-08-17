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

        public async Task<List<Message>> GetMessagesFromChatByUsers(string user1, string user2)
        {
            var sender = await _userManager.FindByNameAsync(user1);
            if (sender == null) return null;

            var retriever = await _userManager.FindByNameAsync(user2);
            if (retriever == null) return null;

            var chat = await _context.Chats.Include(x => x.Messages).FirstOrDefaultAsync(x => (x.User1 == user1 && x.User2 == user2) || (x.User2 == user1 && x.User1 == user2));
            if(chat == null) return null;

            return chat.Messages;
        }

        public async Task<List<Message>> GetMessagesFromChat(int id)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Id == id);
            return chat?.Messages;
        }

        public async Task<int> SendMessageToGroup(string chatName, string message, string senderId, string retrieverId)
        {
            var sender = await _userManager.FindByIdAsync(senderId);
            if(sender == null) return -2;

            var retriever = await _userManager.FindByIdAsync(retrieverId);
            if (retriever == null) return -3;

            var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Name == chatName);
            if (chat == null) await CreateGroupChat(chatName);

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

        public async Task<int> CreateGroupChat(string name)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Name == name);
            if (chat != null) return -1;

            await _context.Chats.AddAsync(new Chat { Name = name, Since = DateTime.Now });
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> SendMessageToUser(string message, string sender, string retriever)
        {
            var senderUser = await _userManager.FindByNameAsync(sender);
            if (senderUser == null) return -2;

            var retrieverUser = await _userManager.FindByNameAsync(retriever);
            if (retrieverUser == null) return -3;

            var chat = await _context.Chats.Include(x => x.Messages).FirstOrDefaultAsync(x => (x.User1 == sender && x.User2 == retriever) || (x.User2 == sender && x.User1 == retriever));
            if (chat == null) chat = await CreateChat(sender, retriever);

            var Message = new Message()
            {
                SentAt = DateTime.Now,
                DestinationUserId = retrieverUser.Id,
                SenderUserId = senderUser.Id,
                Text = message
            };

            chat.Messages.Add(Message);
            await _context.SaveChangesAsync();

            return 1;
        }

        public async Task<Chat> CreateChat(string user1, string user2)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(x => (x.User1 == user1 && x.User2 == user2) || (x.User2 == user1 && x.User1 == user2));
            if (chat != null) return null;
            var newChat = new Chat { User1 = user1, User2 = user2, Since = DateTime.Now, Messages = new() };
            await _context.Chats.AddAsync(newChat);
            await _context.SaveChangesAsync();
            return newChat;
        }
    }
}