using Ninject.Modules;
using Online_Store.Commands;
using Online_Store.Commands.UserCommands;
using Online_Store.Core;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Ninject
{
    public class StoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWriter>().To<ConsoleWriter>().Named("console writer");
            this.Bind<IReader>().To<ConsoleReader>().Named("console reader");
            this.Bind<IParser>().To<CommandParser>().Named("command parser");


            this.Bind<ICommandFactory>().To<CommandFactory>().Named("CommandFactory");
            this.Bind<IModelFactory>().To<ModelFactory>().Named("ModelFactory");

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named("Engine");
            this.Bind<IStoreContext>().To<StoreContext>().Named("context");

            this.Bind<IUserService>().To<UserService>().InSingletonScope().Named("userService");
            this.Bind<IPasswordSecurityHasher>().To<PasswordSecurityHasher>().Named("passwordHasher");


            this.Bind<ICommand>().To<CreateUserCommand>().Named("createuser");
            this.Bind<ICommand>().To<UserLoginCommand>().Named("login");
            this.Bind<ICommand>().To<Logout>().Named("logout");
            this.Bind<ICommand>().To<BecomeSellerCommand>().Named("becomeseller");
        }
    }
}
