﻿using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Data
{
    public interface IStoreContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Seller> Sellers { get; set; }
        IDbSet<Cart> Carts { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<ShippingDetails> ShippingDetails { get; set; }
        IDbSet<Feedback> Feedbacks { get; set; }
        IDbSet<Sale> Sales { get; set; }
        int SaveChanges();
        
    }
}
