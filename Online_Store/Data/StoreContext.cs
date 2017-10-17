﻿using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Data
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext()
            : base("StoreDB")
        {

        }   

        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public IDbSet<Cart> Carts { get; set; }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                        .HasOptional(c => c.Seller)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasRequired(s => s.Seller)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

}
