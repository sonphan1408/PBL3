using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Utilities
{
    public class HashPassword
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public static string Hash(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    byte[] hash = pbkdf2.GetBytes(HashSize);
                    byte[] hashWithSalt = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashWithSalt, 0, SaltSize);
                    Array.Copy(hash, 0, hashWithSalt, SaltSize, HashSize);
                    return Convert.ToBase64String(hashWithSalt);
                }
            }
        }

        public static bool Verify(string inputPassword, string hashInDatabase)
        {
            if (string.IsNullOrWhiteSpace(inputPassword))
                return false;

            if (string.IsNullOrWhiteSpace(hashInDatabase))
                return false;

            try
            {
                byte[] hashWithSalt = Convert.FromBase64String(hashInDatabase);
                if (hashWithSalt.Length < SaltSize + HashSize)
                    return false;

                byte[] salt = new byte[SaltSize];
                Array.Copy(hashWithSalt, 0, salt, 0, SaltSize);

                byte[] storedHash = new byte[HashSize];
                Array.Copy(hashWithSalt, SaltSize, storedHash, 0, HashSize);

                using (var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    byte[] computedHash = pbkdf2.GetBytes(HashSize);
                    return CompareBytes(computedHash, storedHash);
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool CompareBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }
    }
}
