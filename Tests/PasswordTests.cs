using Salty;
using Salty.Hashers;

namespace Tests
{
    [TestFixture]
    internal class PasswordTests
    {
        [Test]
        public void TestPasswordsSHA256DoesntRepeat_ReturnTrue()
        {
            // Prepare data.
            int timesToChek = 1000;
            string password = "f1nd1ngN3m0_567#";
            
            // Get first password hashed.
            string hashedPassword = PasswordManager.GeneratePasswordHash(new SHA256Hasher(), password);

            // Assert.
            for(int i = 0; i < timesToChek; i++)
            {
                string hashedPasswordToCompareWith = PasswordManager.GeneratePasswordHash(new SHA256Hasher(), password);
                
                Assert.That(hashedPassword != hashedPasswordToCompareWith, Is.True);
            }
        }

        [Test]
        public void TestPasswordsSHA512DoesntRepeat_ReturnTrue()
        {
            // Prepare data.
            int timesToChek = 1000;
            string password = "f1nd1ngN3m0_567#";

            // Get first password hashed.
            string hashedPassword = PasswordManager.GeneratePasswordHash(new SHA512Hasher(), password);

            // Assert.
            for (int i = 0; i < timesToChek; i++)
            {
                string hashedPasswordToCompareWith = PasswordManager.GeneratePasswordHash(new SHA512Hasher(), password);

                Assert.That(hashedPassword != hashedPasswordToCompareWith, Is.True);
            }
        }

        [Test]
        public void TestPassword256Matching_ReturnTrue()
        {
            string insertedPassword = "f1nd1ngN3m0_567#";
            string userSalt = "wBPi/6GoGI3";
            string userHash = "005219A14AD7B476693C7ECC0AEDCD50DB066328E2FB65E460730A910036B52A";

            bool result = PasswordManager.ChekPasswordHash(new SHA256Hasher(), insertedPassword, userSalt, userHash);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestPassword512Matching_ReturnTrue()
        {
            string insertedPassword = "f1nd1ngN3m0_567#";
            string userSalt = "wBPi/6GoGI3";
            string userHash = "A46A1F626393D9B5144A6EE94489DDDB3197A3DB483F9D2F45DA5AC2BED363B5B8C72138FD5E28DF87FE1EE3D17CF1FC4F89F9863BD74B8116D4E5A694134CC6";

            bool result = PasswordManager.ChekPasswordHash(new SHA512Hasher(), insertedPassword, userSalt, userHash);

            Assert.That(result, Is.True);
        }
    }
}
