namespace BamstiChat.Services
{
    public interface IRequestService
    {
        public Task<List<Request>> GetAllRequestsFromUser(string username);
        public Task<int> AcceptRequestFromUserWithId(string username, int reqId);
        public Task<int> RejectRequestFromUserWithId(string username, int reqId);
        public Task<int> ClearAllRequestsFromUserWithId(string username);
        /// <summary>
        ///  Sends a request to the Specified User with given Code
        /// </summary>
        /// <param name="sender">User that is sending the request</param>
        /// <param name="reciever">Code of the Reciever</param>
        /// <returns>-1 when Sender cannot be found, -2 when Reciever cannot be found, 1 when succeded</returns>
        public Task<int> SendRequestToUser(string sender, string reciever);
    }
}