namespace BamstiChat.Models
{
    public class Request
    {
        public int Id { get; set; }
        public ReqType Type { get; set; }
        public DateTime Date { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public string RetrieverId { get; set; }
        public ApplicationUser Retriever { get; set; }
    }
}