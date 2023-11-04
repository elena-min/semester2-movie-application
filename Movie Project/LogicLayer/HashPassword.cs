using System.Security.Cryptography;
using System.Text;

namespace LogicLayer
{
    public static class HashPassword
    {
        public static string GenerateHash(string password, out string salt)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);

                using (var sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] saltedPassword = new byte[passwordBytes.Length + saltBytes.Length];
                    Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                    Buffer.BlockCopy(saltBytes, 0, saltedPassword, passwordBytes.Length, saltBytes.Length);

                    var hashedBytes = sha256.ComputeHash(saltedPassword);
                    var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                    salt = Convert.ToBase64String(saltBytes);
                    return hash;
                }
            }
        }

        public static bool VerifyPassword(string password, string hash, string salt)
        {
            if (hash == null || salt == null)
            {
                return false;
            }

            byte[] saltBytes = Convert.FromBase64String(salt);
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, saltedPassword, passwordBytes.Length, saltBytes.Length);

                var hashedBytes = sha256.ComputeHash(saltedPassword);
                var computedHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash.Equals(computedHash);
            }
        }
    }

}