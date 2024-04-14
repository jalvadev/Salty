using Salty.Hasher;
using Salty.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salty
{
    public static class PasswordManager
    {

        public static PasswordResponse GeneratePasswordHash(IHasher hasher, string password)
        {
            string salt;
            string hashedPassword;

            var saltGenerator = SaltGenerator.GetInstance();
            salt = saltGenerator.GenerateSaltString();
            password += salt;

            var hashContext = new HashContext(hasher);
            hashedPassword = hashContext.GenerateHash(password);

            return new PasswordResponse { HashedPassword = hashedPassword, Salt = salt };
        }

        public static bool ChekPasswordHash(IHasher hasher, string password, string salt, string hash)
        {
            var hashContext = new HashContext(hasher);

            password += salt;

            return hashContext.CheckHash(password, hash);
        }
    }
}
