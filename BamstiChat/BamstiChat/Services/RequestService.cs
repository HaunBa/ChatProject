namespace BamstiChat.Services
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFriendService _friendService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RequestService(ApplicationDbContext context, IFriendService friendService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _friendService = friendService;
            _userManager = userManager;
        }

        /// <summary>
        /// Accept incoming Request
        /// </summary>
        /// <param name="username">Username of the User that is accepting the Request</param>
        /// <param name="reqId">Id of the Request another User has sent</param>
        /// <returns>Result Code of the Operation</returns>
        public async Task<int> AcceptRequestFromUserWithId(string username, int reqId)
        {
            var request = await _context.Requests.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == reqId);
            var fUser = await _userManager.Users.Include(x => x.Friends).FirstOrDefaultAsync(x => x.UserName == username);
            
            // error Handling
            if (fUser == null || request == null)
            {
                return -1;
            }

            switch (request.Type.Type)
            {
                case "Friend":
                    var res = await _friendService.AddFriend(username, request.Sender.Id);
                    if(res == 1) _context.Requests.Remove(request);
                    await _context.SaveChangesAsync();
                    return res;
                case "Group":
                    // Add To Group Functionality
                    return 2;
                default:
                    return -2;
            }
        }

        public async Task<int> ClearAllRequestsFromUserWithId(string username)
        {
            var fUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

            // error Handling
            if (fUser == null)
            {
                return -1;
            }

            var users = _context.Requests.Where(x => x.Retriever.Id == fUser.Id);

            foreach (var item in users)
            {
                _context.Requests.Remove(item);
            }

            await _context.SaveChangesAsync();

            return 1;
        }

        public async Task<List<Request>> GetAllRequestsFromUser(string username)
        {
            var fUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            var res = await _context.Requests.Include(x => x.Type).Include(x => x.Sender).Where(x => x.Retriever == fUser).ToListAsync();
            return res;
        }

        public Task<int> RejectRequestFromUserWithId(string username, int reqId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Sends a request to the Specified User with given Code
        /// </summary>
        /// <param name="sender">User that is sending the request</param>
        /// <param name="reciever">Code of the Reciever</param>
        /// <returns>-1 when Sender cannot be found, -2 when Reciever cannot be found, 1 when succeded</returns>
        public async Task<int> SendRequestToUser(string sender, string reciever)
        {
            var findByName = _userManager.FindByNameAsync(sender);
            var user = await findByName;
            if (user == null) return -1;
            var recUser = await _userManager.Users.FirstOrDefaultAsync(x => x.FriendCode == reciever);
            if (recUser == null) return -2;

            var req = await _context.Requests.FirstOrDefaultAsync(x => x.SenderId == user.Id && x.RetrieverId == recUser.Id);
            if (req != null) return -3;

            //if (user.Id == recUser.Id) return -4;

            var friendType = await _context.ReqTypes.FirstOrDefaultAsync(x => x.Type == "Friend");

            req = new Request()
            {                
                Date = DateTime.Now,
                RetrieverId = recUser.Id,
                SenderId = user.Id,
                Type = friendType
            };

            _context.Requests.Add(req);
            await _context.SaveChangesAsync();

            return 1;
        }
    }
}