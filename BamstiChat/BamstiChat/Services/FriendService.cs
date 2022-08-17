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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Username of the User that is accepting the Request</param>
        /// <param name="senderId">Id of the User has sent the request</param>
        /// <returns></returns>
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

            Friend senderFriend = new()
            {
                Since = DateTime.Now,
                UserId = user.Id
            };

            sender.Friends.Add(newFriend);

            user.Friends.Add(senderFriend);

            await _userManager.UpdateAsync(user);

            return 1;
        }

        public async Task<List<Friend>> GetAllFriendsAsync(string username)
        {
            var user = await _userManager.Users.Include(x => x.Friends).FirstOrDefaultAsync(x => x.UserName == username);
            return user.Friends.ToList() ?? new List<Friend>();
        }

        public List<Friend> GetAllFriends(string username)
        {
            var user = _userManager.Users.Include(x => x.Friends).FirstOrDefault(x => x.UserName.Equals(username));
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