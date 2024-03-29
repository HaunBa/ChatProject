﻿namespace BamstiChat.Services
{
    public interface IFriendService
    {
        public Task<int> AddFriend(string username, string friendId);
        public Task<int> RemoveFriend(string username, string friendId);
        public Task<List<Friend>> GetAllFriendsAsync(string username);
        public List<Friend> GetAllFriends(string username);
    }
}