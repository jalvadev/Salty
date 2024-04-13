using Salty;
using Salty.Hasher;
using Salty.Hashers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class SHA256Tests
    {
        [Test]
        public void IsSHA256GenerationOk_ReturnTrue()
        {
            // Passwords to test.
            string[] passwords = GetPasswordsToTest();

            // Hash for these passwords.
            string[] hashes = GetHashedPasswordsToTest();

            string[] hashedPasswords = new string[ passwords.Length ];

            // Execute hasher.
            HashContext hashContext = new HashContext(new SHA256Hasher());

            for(int i = 0; i < passwords.Length; i++)
            {
                hashedPasswords[i] = hashContext.GenerateHash(passwords[i]);
            }

            // Assert results.
            for(int i = 0;i < hashes.Length; i++)
            {
                Assert.That(hashedPasswords[i] == hashes[i], Is.True);
            }
        }

        [Test]
        public void IsSHA256PassCheckingOk_ReturnTrue()
        {
            // Passwords to test.
            string[] passwords = GetPasswordsToTest();
            string[] hashedPasswords = new string[passwords.Length];

            // Execute hasher.
            HashContext hashContext = new HashContext(new SHA256Hasher());

            for (int i = 0; i < passwords.Length; i++)
            {
                hashedPasswords[i] = hashContext.GenerateHash(passwords[i]);
            }

            // Assert results.
            for (int i = 0; i < hashedPasswords.Length; i++)
            {
                Assert.That(hashContext.CheckHash(passwords[i], hashedPasswords[i]), Is.True);
            }
        }

        [Test]
        public void BadSHA256IsDetected_ReturnFalse()
        {
            // Password to test.
            string password = "8d18NZ1YgYaHCierT5";
            string passwordBad = "8d18NZ1YgYaHCierT6";

            // Execute hasher.
            HashContext hashContext = new HashContext(new SHA256Hasher());
            string hashedPassword = hashContext.GenerateHash(password);

            // Assert.
            Assert.That(hashContext.CheckHash(passwordBad, hashedPassword), Is.False);
        }

        private string[] GetPasswordsToTest()
        {
            return [
                "8d18NZ1YgYaHCierT5",
                "Q41CnxwvRYwDm75dqcwc",
                "MnqXXPX2s590epHjhmKr",
                "QqDPyy5p1UDMKuwXdoYN",
                "Fu4ZxpC8BotBAE537joQ",
                "hDTbGrgCsZ2NoVRhUu54",
                "Jm2arjtwMwFinMhg4Pui",
                "qbo9tMCfmR7JyHc5JMWW"
            ];
        }

        private string[] GetHashedPasswordsToTest()
        {
            return [
                "6CB5D385B3DA22015229DE6647D12CA75D1D65E2CDCC146CB749A398643701AA",
                "EF55BED82C8EA7BF56F84CAFAED2ACB4853DEAB319EFCA67359552A027CA87C6",
                "FAA555950A47A840F42F1D35835F08FDB9C63D9B3E34158CA956EE460CA40680",
                "D0A0647726C0AB9911547953A34E175370B6515B91956CA2299F9AF983C12A85",
                "D7C5AA0F6B626B8D336E9887F5C5BAFCDE58E890906573FAB86BC9C4883C7E0C",
                "214501B2AD2CBE71D4A8FDDAEBE83B7721CE0D2B82A91A25F0479A255B1975C9",
                "B33B9DDAE991F51668E08C9E0EE78D095DD80E85355BAC73E16D0B4599CC7D42",
                "698A7BB68AD859683E7F336F6A0AF1454448FBEFAAC5DC66B1D84258E7EFB3BE"
            ];
        }
    }
}
