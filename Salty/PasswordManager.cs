using Salty.Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salty
{
    public static class PasswordManager
    {

        public static string GeneratePasswordHash(IHasher hasher, string password)
        {
            string salt;
            string hashedPassword;

            var saltGenerator = SaltGenerator.GetInstance();
            salt = saltGenerator.GenerateSaltString();
            password += salt;

            var hashContext = new HashContext(hasher);
            hashedPassword = hashContext.GenerateHash(password);

            return hashedPassword;
        }
    }
}
