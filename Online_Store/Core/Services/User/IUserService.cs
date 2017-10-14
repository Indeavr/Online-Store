using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Core.Services.User
{
    public interface IUserService
    {
        int LoggedUserId { get; set; }

        string GeneratePasswordHash(string password);

        bool ValidateCredentials(string username, string password);

        bool CheckUsername(string username);
    }
}
