using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Core.Services.User
{
    public interface IPasswordSecurityHasher
    {
        string Hash(string password, int iterations);
        string Hash(string password);
        bool Verify(string hashedPassword, string realPassword);
    }
}
