using Ninject.Modules;
using Online_Store.Commands;
using Online_Store.Commands.UserCommands;
using Online_Store.Core;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services;
using Online_Store.Core.Services.User;
using Online_Store.Data;

namespace Online_Store.Ninject
{
    public class StoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope(); //no need from named bindings here // can be singleton, as long as dont accept database in constructor or method arguments
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope(); //no need from named bindings here // can be singleton, as long as dont accept database in constructor or method arguments
            this.Bind<IParser>().To<CommandParser>().InSingletonScope(); //no need from named bindings here // can be singleton, as long as dont accept database in constructor or method arguments

            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope(); //no need from named bindings here // can be singleton, as long as dont accept database in constructor or method arguments
            this.Bind<IModelFactory>().To<ModelFactory>().InSingletonScope(); //no need from named bindings here // can be singleton, as long as dont accept database in constructor or method arguments

            this.Bind<IEngine>().To<Engine>().InSingletonScope(); //no need from named bindings here, because there is only one IEngine class // can be singleton, as long as dont accept database in constructor or method arguments
            this.Bind<IStoreContext>().To<StoreContext>().Named("context");

            this.Bind<IUserService>().To<UserService>().InSingletonScope().Named("userService");
            this.Bind<IPasswordSecurityHasher>().To<PasswordSecurityHasher>().Named("passwordHasher");
            
            this.Bind<ICommand>().To<CreateUserCommand>().Named("createuser");
            this.Bind<ICommand>().To<UserLoginCommand>().Named("login");
            this.Bind<ICommand>().To<BecomeSellerCommand>().Named("becomeseller");
        }
    }
}
