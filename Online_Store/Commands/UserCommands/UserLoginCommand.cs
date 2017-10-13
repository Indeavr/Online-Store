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
    public class UserLoginCommand : ICommand
    {
        private IUserService userService;
        private IModelFactory factory;
        private IStoreContext context;

        public UserLoginCommand(IModelFactory factory, IStoreContext context, IUserService userService)
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
            string username = parameters[0];
            string password = parameters[1];

            userService.ValidateCredentials(username, password);

            //this.context.loggedUserId = this.context.Users.Single(u => u.Username == username).Id;
            //Console.WriteLine(this.context.loggedUserId);

            return $"Successfully Logged in!";
        }
    }
}
