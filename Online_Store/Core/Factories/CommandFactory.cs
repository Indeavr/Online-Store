using Bytes2you.Validation;
using Ninject;
using Online_Store.Commands;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;
        private readonly IUserService userService;
        private readonly IWriter writer;

        public CommandFactory(IKernel kernel, IUserService userService, IWriter writer)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.kernel = kernel;
            this.userService = userService;
            this.writer = writer;
        }

        public ICommand CreateCommand(string commandName)
        {
            ////edited here
            //if (this.userService.IsUserLogged())
            //{
            return this.kernel.Get<ICommand>(commandName);
            //}
            //else
            //{
            //    this.writer.WriteLine("Login first...");
            //    return this.kernel.Get<ICommand>("login");
            //}
        }
    }
}