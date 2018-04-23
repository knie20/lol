namespace server.Models
{
    public class Application{
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set; }
        public int PositionId { get; set; }
        public string ResumePath { get; set;}
    }
}