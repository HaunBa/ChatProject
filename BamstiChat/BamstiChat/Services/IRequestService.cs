namespace BamstiChat.Services
{
    public interface IRequestService
    {
        public Task<List<Request>> GetAllRequestsFromUser(string username);
        public Task<int> AcceptRequestFromUserWithId(string username, int reqId);
        public Task<int> RejectRequestFromUserWithId(string username, int reqId);
        public Task<int> ClearAllRequestsFromUserWithId(string username);
    } 
}