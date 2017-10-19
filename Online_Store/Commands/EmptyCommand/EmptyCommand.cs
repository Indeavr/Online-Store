using Bytes2you.Validation;
using Newtonsoft.Json;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Online_Store.Commands.EmptyCommand
{
    public class EmptyCommand : Command
    {
        //private readonly ILoggedUserProvider loggedUserProvider;
        //private readonly IModelFactory modelFactory;

        public EmptyCommand(IStoreContext context, IWriter writer, IReader reader) //,
            //ILoggedUserProvider loggedUserProvider, IModelFactory modelFactory)
            : base(context, writer, reader)
        {
            //Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            //Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();

            //this.loggedUserProvider = loggedUserProvider;
            //this.modelFactory = modelFactory;
        }

        public override string Execute()
        {
            //using (StreamReader usersStream = new StreamReader(@"../../../json/Users.json"))
            //{
            //    IList<User> users = JsonConvert.DeserializeObject<IList<User>>(usersStream.ReadToEnd());
            //    if (this.context.Users.Count()==0)
            //    {
            //        for (int i = 0; i <= users.Count - 1; i++)
            //        {
            //            if (i % 2 == 0)
            //            {
            //                User user = users[i];
            //                user.Seller = new Seller();
            //                base.context.Users.Add(user);
            //            }
            //            else
            //            {
            //                base.context.Users.Add(users[i]);
            //            }
            //        }
            //        base.context.SaveChanges();
            //    }
            //}
            
            //using (StreamReader productsStream = new StreamReader(@"../../../json/Products.json"))
            //{
            //    if (this.context.Products.Count()==0)
            //    {
            //        IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productsStream.ReadToEnd());

            //        IList<Seller> sellerCollection = this.context.Sellers.Take(3).ToList();

            //        for (int i = 0; i <= 2; i++)
            //        {
            //            products[i].Seller = sellerCollection[i];
            //            this.context.Products.Add(products[i]);
            //        }
            //    }
            //    base.context.SaveChanges();
            //}
            
            return "Command doesn`t exist.";
        }
    }
}
/*

    
--delete from Categories
--delete from Sales
--delete from ShippingDetails
--delete from Feedbacks
--delete from Products
--delete from Sellers
--delete from Users

select * from Users
select * from Sellers
select * from Products
select * from Categories
select * from Sales
select * from ShippingDetails
select * from Feedbacks


 * */
