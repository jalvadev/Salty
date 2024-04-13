using Salty.Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Salty.Hashers
{
    public class SHA256Hasher : IHasher
    {
        public string HashString(string stringToHash)
        {
            string hash;

            using (SHA256 sha256 = SHA256.Create())
            {
                hash = GetHash(sha256, stringToHash);
            }

            return hash;
        }

        private string GetHash(SHA256 sha256, string stringToHash)
        {
            byte[] textBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));

            var stringBuilder = new StringBuilder();

            for(int i = 0; i < textBytes.Length; i++)
            {
                stringBuilder.Append(textBytes[i].ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        public bool CheckHash(string stringToHash, string hash)
        {
            string hashedString;

            using(SHA256 sha256 = SHA256.Create())
            {
                hashedString = GetHash(sha256, stringToHash);
            }

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashedString, hash) == 0;
        }
    }
}
