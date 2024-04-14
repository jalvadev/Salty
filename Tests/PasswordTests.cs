using Salty;
using Salty.Hashers;
using Salty.Responses;

namespace Tests
{
    [TestFixture]
    internal class PasswordTests
    {
        [Test]
        public void TestPasswordsSHA256DoesntRepeat_ReturnTrue()
        {
            // Prepare data.
            PasswordResponse passwordResult;
            int timesToChek = 1000;
            string password = "f1nd1ngN3m0_567#";
            
            // Get first password hashed.
            passwordResult = PasswordManager.GeneratePasswordHash(new SHA256Hasher(), password);
            string hashedPassword = passwordResult.HashedPassword;

            // Assert.
            for (int i = 0; i < timesToChek; i++)
            {
                passwordResult = PasswordManager.GeneratePasswordHash(new SHA256Hasher(), password);
                string hashedPasswordToCompareWith = passwordResult.HashedPassword;

                Assert.That(hashedPassword != hashedPasswordToCompareWith, Is.True);
            }
        }

        [Test]
        public void TestPasswordsSHA512DoesntRepeat_ReturnTrue()
        {
            // Prepare data.
            PasswordResponse passwordResult;
            int timesToChek = 1000;
            string password = "f1nd1ngN3m0_567#";

            // Get first password hashed.
            passwordResult = PasswordManager.GeneratePasswordHash(new SHA512Hasher(), password);
            string hashedPassword = passwordResult.HashedPassword;

            // Assert.
            for (int i = 0; i < timesToChek; i++)
            {
                passwordResult = PasswordManager.GeneratePasswordHash(new SHA512Hasher(), password);
                string hashedPasswordToCompareWith = passwordResult.HashedPassword;

                Assert.That(hashedPassword != hashedPasswordToCompareWith, Is.True);
            }
        }

        [Test]
        public void TestPassword256Matching_ReturnTrue()
        {
            string insertedPassword = "f1nd1ngN3m0_567#";
            string userSalt;
            string userHash;

            PasswordResponse passwordResult = PasswordManager.GeneratePasswordHash(new SHA256Hasher(), insertedPassword);
            userHash = passwordResult.HashedPassword;
            userSalt = passwordResult.Salt;

            bool result = PasswordManager.ChekPasswordHash(new SHA256Hasher(), insertedPassword, userSalt, userHash);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestPassword512Matching_ReturnTrue()
        {
            string insertedPassword = "f1nd1ngN3m0_567#";
            string userSalt;
            string userHash;

            PasswordResponse passwordResult = PasswordManager.GeneratePasswordHash(new SHA512Hasher(), insertedPassword);
            userHash = passwordResult.HashedPassword;
            userSalt = passwordResult.Salt;

            bool result = PasswordManager.ChekPasswordHash(new SHA512Hasher(), insertedPassword, userSalt, userHash);

            Assert.That(result, Is.True);
        }
    }
}
