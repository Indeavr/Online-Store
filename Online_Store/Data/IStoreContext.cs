using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Data
{
    public interface IStoreContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Seller> Sellers { get; set; }

        int SaveChanges();
    }
}
