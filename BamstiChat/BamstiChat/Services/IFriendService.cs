namespace BamstiChat.Services
{
    public interface IFriendService
    {
        public Task<int> AddFriend(string friendId);
        public Task<int> RemoveFriend(string friendId);
        public Task<int> SendFriendRequest(string friendId);
    }
}
