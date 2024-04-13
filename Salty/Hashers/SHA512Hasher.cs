using Salty.Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Salty.Hashers
{
    public class SHA512Hasher : IHasher
    {

        public string HashString(string stringToHash)
        {
            SHA512 sha512 = SHA512.Create();
            return GetHash(sha512, stringToHash);
        }

        private string GetHash(SHA512 sha512, string stringToHash)
        {
            byte[] textBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
            var stringBuilder = new StringBuilder();

            for(int i = 0; i < textBytes.Length; i++)
            {
                stringBuilder.Append(textBytes[i].ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        public bool CheckHash(string stringToHash, string hash)
        {
            string hashedString = HashString(stringToHash);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hash, hashedString) == 0;
        }
    }
}
