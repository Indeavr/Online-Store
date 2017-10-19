using Newtonsoft.Json;
using Online_Store.Models;
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

            using (StreamReader r = new StreamReader(@"../../../User.json"))
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

            using (StreamReader bananiReader = new StreamReader(@"../../../jsonproducts/banani.json"))
            {
                if (!context.Products.Any(x => x.ProductName == "banani"))
                {
                    var bananiProduct = JsonConvert.DeserializeObject<Product>(bananiReader.ReadToEnd());
                    context.Products.Add(bananiProduct);
                    context.SaveChanges();
                }
            }

            using (StreamReader qbulkiReader = new StreamReader(@"../../../jsonproducts/qbulki.json"))
            {
                if (!context.Products.Any(x => x.ProductName == "qbulki"))
                {
                    var qbulkiProduct = JsonConvert.DeserializeObject<Product>(qbulkiReader.ReadToEnd());
                    context.Products.Add(qbulkiProduct);
                    context.SaveChanges();
                }
            }

            using (StreamReader semkiReader = new StreamReader(@"../../../jsonproducts/semki.json"))
            {
                if (!context.Products.Any(x => x.ProductName == "semki"))
                {
                    var semkiProduct = JsonConvert.DeserializeObject<Product>(semkiReader.ReadToEnd());
                    context.Products.Add(semkiProduct);
                    context.SaveChanges();
                }
            }

           

            using (StreamReader reader = new StreamReader(@"../../../Feedback.json"))
            {
                if (!context.Feedbacks.Any())
                {
                    string json = reader.ReadToEnd();
                    var feedback = JsonConvert.DeserializeObject<Feedback>(json);
                    context.Feedbacks.Add(feedback);
                    context.SaveChanges();
                }
            }

            //using (StreamReader cartReader = new StreamReader(@"../../../Cart.json"))
            //{
            //    if (!context.Carts.Any(x => x.UserId == 2))
            //    {
            //        string json = cartReader.ReadToEnd();
            //        var cart = JsonConvert.DeserializeObject<Cart>(json);
            //        context.Carts.Add(cart);
            //        context.SaveChanges();
            //    }
            //}

            //using (StreamReader reader = new StreamReader(@"../../../ShippingDetails.json"))
            //{
            //    if (!context.ShippingDetails.Any())
            //    {
            //        string json = reader.ReadToEnd();
            //        var shippingDetails = JsonConvert.DeserializeObject<ShippingDetails>(json);
            //        context.ShippingDetails.Add(shippingDetails);
            //        context.SaveChanges();
            //    }
            //}


            //using (StreamReader reader = new StreamReader(@"../../../UserInfo.json"))
            //{
            //    if (!context.Products.Any())
            //    {
            //        var json = reader.ReadToEnd();
            //        var product = JsonConvert.DeserializeObject<Product>(json);
            //        context.Sellers.Single(s => s.UserId == product.SellerId).Products.Add(product);
            //        //Console.WriteLine(context.Sellers.Single(s => s.UserId == product.SellerId).Products.First().Price);
            //        context.Products.Add(product);
            //        context.SaveChanges();
            //    }
            //}

            //using (StreamReader r = new StreamReader(@"../../../Product.xml"))
            //{
            //    XmlSerializer xmlS = new XmlSerializer(typeof(Product));
            //    XmlTextReader xmlReader = new XmlTextReader(r);
            //    Product product = (Product)xmlS.Deserialize(xmlReader);

            //    context.Products.Add(product);
            //    context.SaveChanges();
            //}
        }
    }
}