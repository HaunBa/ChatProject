namespace BamstiChat.Services
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext _context;
        public RequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Accept incoming Request
        /// </summary>
        /// <param name="username">Username of the User that is accepting the Request</param>
        /// <param name="reqId">Id of the Request another User has sent</param>
        /// <returns>Result Code of the Operation</returns>
        public async Task<int> AcceptRequestFromUserWithId(string username, int reqId)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == reqId);
            var fUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            
            // error Handling
            if (fUser == null || request == null)
            {
                return -1;
            }

            switch (request.Type.Type)
            {
                case "Friend":
                    // Add Friend functionality
                    return 1;
                case "Group":
                    // Add To Group Functionality
                    return 2;
                default:
                    return -2;
            }
        }

        public Task<int> ClearAllRequestsFromUserWithId(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetAllRequestsFromUser(string username)
        {
            var fUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            return _context.Requests.Where(x => x.Retriever == fUser).ToList();
        }

        public Task<int> RejectRequestFromUserWithId(string username, int reqId)
        {
            throw new NotImplementedException();
        }
    }
}
