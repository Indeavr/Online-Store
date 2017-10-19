using Newtonsoft.Json;
using Online_Store.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace Online_Store.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Online_Store.Data.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Online_Store.Data.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //<<<<<<< HEAD
            using (StreamReader usersStream = new StreamReader(@"../../../json/Users.json"))
            {
                IList<User> users = JsonConvert.DeserializeObject<IList<User>>(usersStream.ReadToEnd());
                if (context.Users.Count() == 0)
                {
                    for (int i = 0; i <= users.Count - 1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            User user = users[i];
                            user.Seller = new Seller();
                            context.Users.Add(user);
                        }
                        else
                        {
                            context.Users.Add(users[i]);
                        }
                    }
                    context.SaveChanges();
                }
            }

            using (StreamReader r = new StreamReader(@"../../../json/User.json"))
            {
                if (!context.Users.Any())
                {
                    string json = r.ReadToEnd();
                    var user = JsonConvert.DeserializeObject<User>(json);
                    user.Seller = new Seller();
                    user.Cart = new Cart();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            //using (StreamReader cartReader = new StreamReader(@"../../../json/Cart.json"))
            //{
            //    if (!context.Carts.Any(x => x.UserId == 2)) //throws exeption when there is no user with ID=2 => should be if (context.Carts.ToList().Count != 0)
            //    {
            //        string json = cartReader.ReadToEnd();
            //        var cart = JsonConvert.DeserializeObject<Cart>(json);
            //        context.Carts.Add(cart);
            //        context.SaveChanges(); //exception when there is no user with ID=1
            //    }
            //}

            if (context.Carts.ToList().Count==0)
            {
                context.Carts.Add(new Cart() { UserId = context.Users.First().Id }); //only exceptionless way for now to add a cart
                context.SaveChanges();
            }
            
            using (StreamReader productsStream = new StreamReader(@"../../../json/Products.json"))
            {
                if (context.Products.Count() == 0)
                {
                    IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productsStream.ReadToEnd());

                    IList<Seller> sellerCollection = context.Sellers.Take(3).ToList();

                    for (int i = 0; i <= 2; i++)
                    {
                        products[i].Seller = sellerCollection[i];
                        context.Products.Add(products[i]);
                    }
                }
                context.SaveChanges();
            }

            using (StreamReader reader = new StreamReader(@"../../../json/Feedback.json"))
            {
                if (!context.Feedbacks.Any())
                {
                    string json = reader.ReadToEnd();
                    var feedback = JsonConvert.DeserializeObject<Feedback>(json);
                    context.Feedbacks.Add(feedback);
                    context.SaveChanges();
                }
            }
            
            using (StreamReader reader = new StreamReader(@"../../../json/ShippingDetails.json"))
            {
                if (!context.ShippingDetails.Any())
                {
                    string json = reader.ReadToEnd();
                    var shippingDetails = JsonConvert.DeserializeObject<ShippingDetails>(json);
                    context.ShippingDetails.Add(shippingDetails);
                    context.SaveChanges();
                }
            }

        }
    }
}