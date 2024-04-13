using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Salty
{
    public class SaltGenerator
    {
        private static SaltGenerator _instance;

        private SaltGenerator() { }

        public static SaltGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SaltGenerator();
            }

            return _instance;
        }

        public string GenerateSaltString()
        {
            int size = 11;

            byte[] salt = GenerateSalt(size);
            return Convert.ToBase64String(salt);
        }

        private byte[] GenerateSalt(int size)
        {
            byte[] salt = new byte[size];

            RandomNumberGenerator.Fill(salt);

            return salt;
        }
    }
}
