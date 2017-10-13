using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("StoreDB")
        {

        }
    }
}
