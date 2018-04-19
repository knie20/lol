using BCrypt.Net;

namespace server.Utils
{
    public static class PasswordUtil
    {

        public static string HashPassword(string pw){
            string salt = "$2a$10$vI8aWBnW3fID.ZQ4/zo1G.q1lRps.9cGLcZEiGDMVr5yUP1KUOYTa";

            return BCrypt.Net.BCrypt.HashPassword(pw, salt);
        }

        public static bool VerifyPassword(string pw, string hashedPw){
            return SafeEquals(HashPassword(pw), hashedPw);
        }

        private static bool SafeEquals(string a, string b)
        {
            var diff = (uint) a.Length ^ (uint) b.Length;

            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint) a[i] ^ (uint) b[i];
            }

            return diff == 0;
        } 
    }
}