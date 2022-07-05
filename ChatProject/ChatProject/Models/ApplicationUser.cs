using Microsoft.AspNetCore.Identity;

namespace ChatProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FriendCode { get; set; }
        public List<Friend> Friends { get; set; } = new List<Friend>();
    }
}
