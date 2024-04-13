using Salty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class SaltTest
    {
        private SaltGenerator _saltGenerator;

        [SetUp]
        public void SetUp()
        {
            _saltGenerator = SaltGenerator.GetInstance();
        }

        [Test]
        public void IsGeneratingRandom_ReturnTrue()
        {
            int saltNumberToTest = 100000;
            string salt1;
            string salt2;

            salt1 = _saltGenerator.GenerateSaltString();

            for (int i = 0; i < saltNumberToTest; i++)
            {
                salt2 = _saltGenerator.GenerateSaltString();

                Assert.That(salt1.Equals(salt2), Is.False);
            }
        }

        [Test]
        public void IsCorrectSize_ReturnTrue()
        {
            const int CONFIGURED_SIZE = 11; // Set same as configured in library.
            int saltNumberToTest = 100;
            string salt;

            for(int i = 0; i < saltNumberToTest; i++)
            {
                salt = _saltGenerator.GenerateSaltString();

                Assert.That(salt.Length == CONFIGURED_SIZE, Is.True);
            }
        }
    }
}
