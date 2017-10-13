using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Services.User;
using Online_Store.Data;
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
            // var seller =  this.factory.CreateSeller(this.context.loggedUserId);

            return $"Congrats, you can now Sell Products!";
        }
    }
}
