namespace ChatProject.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int UseId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Since { get; set; }
    }
}
