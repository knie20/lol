namespace server.Models
{
    public class LoginCredentials{
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPw { get; set; }
    }
}