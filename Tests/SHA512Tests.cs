using Salty.Hashers;
using Salty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class SHA512Tests
    {
        [Test]
        public void IsSHA512GenerationOk_ReturnTrue()
        {
            // Passwords to test.
            string[] passwords = GetPasswordsToTest();

            // Hash for these passwords.
            string[] hashes = GetHashedPasswordsToTest();

            string[] hashedPasswords = new string[passwords.Length];

            // Execute hasher.
            HashContext hashContext = new HashContext(new SHA512Hasher());

            for (int i = 0; i < passwords.Length; i++)
            {
                hashedPasswords[i] = hashContext.GenerateHash(passwords[i]);
            }

            // Assert results.
            for (int i = 0; i < hashes.Length; i++)
            {
                Assert.That(hashedPasswords[i] == hashes[i], Is.True);
            }
        }

        [Test]
        public void IsSHA512PassCheckingOk_ReturnTrue()
        {
            // Passwords to test.
            string[] passwords = GetPasswordsToTest();
            string[] hashedPasswords = new string[passwords.Length];

            // Execute hasher.
            HashContext hashContext = new HashContext(new SHA512Hasher());

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
        public void BadSHA512IsDetected_ReturnFalse()
        {
            // Password to test.
            string password = "8d18NZ1YgYaHCierT5";
            string passwordBad = "8d18NZ1YgYaHCierT6";

            // Execute hasher.
            HashContext hashContext = new HashContext(new SHA512Hasher());
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
                "F795DEA62ACC1F9C236C82EE8CF0D12E14365346B8F79F1127133A2208C75D67C37F08F21CCD9C4F5E86C27E3BED6F785F9413FF2723FB144D02B00E89B63094",
                "E09263AD7632DC8161FC7F895328D4BD24A2175E6AC19EFC2D83AC68BEAA798EAFE52E5A7CC8C1EF9C3CB4A23010101E194988871A7DF37547AC9CFF4C06040C",
                "972799A71C6D39028B3E4AD5E13CEE960DE0DAD3DA0A0401C6772C42BE24E69E959846DF73BDAD28E27B8CC0127099B18936288FBDB9DB9895225A1C2314FB8C",
                "45D733AE04C6E86C943FC7C37308E94C3E7862508B48AC7A93B3FD87D7E0554AF91977A9EA8EB00807B9D04BBBF2DB3BFB3C627C4FB5ABFB4340018D8E16C071",
                "589AD9D5EA1F5CCB5970CB610B41FA004372579ACB9F3711F6B844DA90E8FC103FE8411F9FD524A47305BC121BD0895FBDA2A4F419C93CCA062EE7771B39A580",
                "CB963EDE07712A1C6C54898D03624DDD0ACF56A6714666F48136C411917EA50A765F14BD2A2EB9CD9903A7180469FB77283048528C9A126F3275644CCD3E02A8",
                "C40784F175B0B475120C573D14B164F29A60F9426855EC4FA8B4EBE32FAB17E553A577201363F3361E41CA821EED1723B9159711BB29DAD94D7CCF6DCA0C9A33",
                "72DF02C4C365759608363C546BFAAE30E0E3F06A35E4E2CE70FDD0523B5F53960822A99D29508B8528467FEA05B39FCC975326E3A22C491D13F4872078B42B33"
            ];
        }
    }
}
