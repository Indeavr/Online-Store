using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Core.Factories
{
    public interface IModelFactory
    {
        User CreateUser(string username, string hashedPassword);

        Seller CreateSeller();
    }
}
