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
    }
}
