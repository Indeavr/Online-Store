using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public interface IUser
    {
        int Id { get; set; }

        string username { get; set; }

        string password { get; set; }

        // ICart cart { get; set; }
    }
}
