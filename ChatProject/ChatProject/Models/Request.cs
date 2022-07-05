namespace ChatProject.Models
{
    public class Request
    {
        public int Id { get; set; }
        public ReqType Type { get; set; }
        public DateTime Date { get; set; }
        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public int RetrieverId { get; set; }
        public ApplicationUser Retriever { get; set; }
    }
}
