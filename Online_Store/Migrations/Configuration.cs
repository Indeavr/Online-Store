using Newtonsoft.Json;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            using (StreamReader r = new StreamReader(@"../../../UserInfo.json"))
            {
                if (!context.Users.Any())
                {
                    string json = r.ReadToEnd();
                    var user = JsonConvert.DeserializeObject<User>(json);
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
