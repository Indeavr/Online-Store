using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
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
    public class BecomeSellerCommand : Command, ICommand
    {
        private IUserService userService;
        private IModelFactory factory;

        public BecomeSellerCommand(IModelFactory factory, IUserService userService, IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(factory, "model factory").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.factory = factory;
            this.userService = userService;
        }

        public override string Execute(IList<string> parameters)
        {
            if (this.userService.LoggedUserId == -1)
            {
                return "You must Login First!";
            }

            if (this.context.Sellers.Any(i => i.UserId == this.userService.LoggedUserId))
            {
                return "You are already a Seller!";
            }

            var seller =  this.factory.CreateSeller();

            this.context.Users.SingleOrDefault(i => i.Id == this.userService.LoggedUserId).Seller = seller;
            this.context.SaveChanges();

            return $"Congrats, you can now Sell Products!";
        }

    }
}
