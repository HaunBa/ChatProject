namespace BamstiChat.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Message> GetAllMessagesBetweenUsers(string user1, string user2)
        {
            var User1 = _userManager.Users.FirstOrDefault(x => x.UserName == user1);
            var User2 = _userManager.Users.FirstOrDefault(x => x.UserName == user2);
        }
    }
}
