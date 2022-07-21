namespace BamstiChat.Services
{
    public class FriendService : IFriendService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FriendService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // TODO: Add friend functionality
        public async Task<int> AddFriend(string username, string senderId)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return -1;
            var sender = await _userManager.FindByIdAsync(senderId);
            if (sender == null) return -2;

            Friend newFriend = new()
            {
                Since = DateTime.Now,
                UserId = senderId
            };

            user.Friends.Add(newFriend);

            await _userManager.UpdateAsync(user);

            return 1;
        }

        public async Task<List<Friend>> GetAllFriends(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user.Friends.ToList();
        }

        public async Task<int> RemoveFriend(string username, string friendId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var friend = await _context.Friends.FindAsync(friendId);
            if (friend == null) return -1;
            
            user.Friends.Remove(friend);
            await _userManager.UpdateAsync(user);
            return 1;
        }        
    }
}