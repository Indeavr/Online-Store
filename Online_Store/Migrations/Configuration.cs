using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

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
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }

            using (StreamReader reader = new StreamReader(@"../../../UserInfo.json"))
            {
                if (!context.Products.Any())
                {
                    var json = reader.ReadToEnd();
                    var product = JsonConvert.DeserializeObject<Product>(json);
                    context.Sellers.Single(s => s.UserId == product.SellerId).Products.Add(product);
                    //Console.WriteLine(context.Sellers.Single(s => s.UserId == product.SellerId).Products.First().Price);
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }

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
