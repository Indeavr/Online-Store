using Bytes2you.Validation;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands.UserCommands
{
    public class Logout : ICommand
    {
        private IStoreContext context;
        private IUserService userService;

        public Logout(IStoreContext context, IUserService userService)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            this.userService.LoggedUserId = -1;


            return "Successfully loged out !";
        }
    }
}
