using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands.UserCommands
{
    public class BecomeSellerCommand : ICommand
    {
        private IUserService userService;
        private IModelFactory factory;
        private IStoreContext context;

        public BecomeSellerCommand(IModelFactory factory, IStoreContext context, IUserService userService)
        {
            Guard.WhenArgument(factory, "model factory").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
            this.factory = factory;
            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            var seller =  this.factory.CreateSeller();


            //var sql = string.Format("SELECT * FROM [MyDb].[dbo].[MyEntities] WHERE [ID] IN ({0})", this.context.loggedUserId);

            //var result = this.context.Users.SqlQuery(sql)

            this.context.Users.SingleOrDefault(i => i.Id == this.userService.LoggedUserId).Seller = seller;
            this.context.SaveChanges();

            return $"Congrats, you can now Sell Products!";
        }
    }
}
