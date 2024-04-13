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
        private const int SIZE = 11;

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
            

            byte[] salt = GenerateSalt(SIZE);

            string saltString = Convert.ToBase64String(salt);
            saltString = saltString.Substring(0, SIZE);

            return saltString;
        }

        private byte[] GenerateSalt(int size)
        {
            byte[] salt = new byte[size];

            RandomNumberGenerator.Fill(salt);

            return salt;
        }
    }
}
