namespace BamstiChat.Pages
{
    public class oldAllFriendsModel : PageModel
    {
        private readonly BamstiChat.Data.ApplicationDbContext _context;
        private readonly IFriendService _friendService;

        public oldAllFriendsModel(ApplicationDbContext context, IFriendService friendService)
        {
            _context = context;
            _friendService = friendService;
        }

        public IActionResult OnGet()
        {
            ViewData["Friends"] = _friendService.GetAllFriends(User.Identity.Name);
            return Page();
        }

        [BindProperty]
        public Friend Friend { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Friends.Add(Friend);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
