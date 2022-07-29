using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BamstiChat.Pages
{
    public class ChatModel : PageModel
    {
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;

        public ChatModel(IChatService chatService, IMessageService messageService)
        {
            _chatService = chatService;
            _messageService = messageService;
        }

        [Parameter]
        public string Username { get; set; }

        public List<Message> Messages { get; set; }

        public void OnGet()
        {
            Messages = _messageService.GetAllMessagesBetweenUsers(User.Identity.Name, Username);
        }
    }
}
