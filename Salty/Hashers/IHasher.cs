using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salty.Hasher
{
    public interface IHasher
    {
        string HashString(string stringToHash);
    }
}
