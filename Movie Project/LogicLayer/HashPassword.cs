using System.Security.Cryptography;
using System.Text;

namespace LogicLayer
{
    public static class HashPassword
    {
        public static string GenerateHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
        public static bool VerifyPassword(string password, string hash)
        {
            if (hash == null)
            {
                return false;
            }
            var hashedPassword = GenerateHash(password);
            return hash.Equals(hashedPassword);
        }
    }
}