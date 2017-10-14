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
    public class CreateUserCommand : Command, ICommand
    {
        private IUserService userService;
        private IModelFactory factory;

        public CreateUserCommand(IModelFactory factory, IUserService userService, IStoreContext context, IWriter writer, IReader reader)
            :base(context, writer, reader)
        {
            Guard.WhenArgument(factory, "model factory").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.factory = factory;
            this.userService = userService;
        }

        public override string Execute(IList<string> parameters)
        {
            parameters = TakeInput();
            string username = parameters[0];
            string password = parameters[1];

            if (userService.CheckUsername(username)) //if it returns true there is already a user with the username
            {
                return "Username is taken!";
            }

            string hashedPassword = userService.GeneratePasswordHash(password);
            User user = factory.CreateUser(username, hashedPassword);

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return $"Created User \"{username}\" successfully";
        }

        private IList<string> TakeInput()
        {
            var username = base.ReadOneLine("Username: ");
            var password = base.ReadOneLine("Password: ");

            return new List<string>() { username, password };
        }
    }
}
