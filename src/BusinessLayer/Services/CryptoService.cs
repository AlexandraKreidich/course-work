using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    internal struct PasswordObject
    {
        [NotNull]
        public byte[] PasswordHash { get; set; }
        [NotNull]
        public byte[] Salt { get; set; }
    }

    internal static class CryptoService
    {
        [NotNull]
        private static byte[] Combine([NotNull] byte[] a, [NotNull] byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }

        [NotNull]
        private static byte[] GetSalt()
        {
            byte[] salt = new byte[50];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(salt);
            }

            return salt;
        }

        public static PasswordObject GetHash([NotNull] string str, [CanBeNull] byte[] salt = null)
        {
            if (salt == null)
            {
                salt = GetSalt();
            }

            byte[] data = Encoding.UTF8.GetBytes(str);

            byte[] saltedPass = Combine(data, salt);

            byte[] hashedInputBytes;

            using (SHA512 shaM = new SHA512Managed())
            {
                hashedInputBytes = shaM.ComputeHash(saltedPass);
            }

            return new PasswordObject()
            {
                PasswordHash = hashedInputBytes,
                Salt = salt
            };
        }
    }
}
