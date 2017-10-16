using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }

        string CategoryName { get; set; }
    }
}
