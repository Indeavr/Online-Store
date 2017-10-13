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
        int loggedUserId { get; set; }

        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
