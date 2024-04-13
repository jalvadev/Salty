using Salty.Hasher;

namespace Salty
{
    public class HashContext
    {
        private IHasher _hasher;

        public HashContext(IHasher hasher)
        {
            _hasher = hasher;
        }

        public void SetHasher(IHasher hasher)
        {
            _hasher = hasher;
        }

        public string GenerateHash(string stringToHash)
        {
            return _hasher.HashString(stringToHash);
        }
    }
}
