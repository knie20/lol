using BCrypt.Net;

namespace server.Utils
{
    public static class PasswordUtil
    {
        private static string salt = "k5#";

        public static string HashPassword(string pw){
            return BCrypt.Net.BCrypt.HashPassword(pw, salt);
        }

        public static bool VerifyPassword(string pw, string hashedPw){
            return BCrypt.Net.BCrypt.Verify(HashPassword(pw), hashedPw);
        }
    }
}