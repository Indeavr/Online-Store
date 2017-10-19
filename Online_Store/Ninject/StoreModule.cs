using Ninject.Modules;
using Online_Store.Commands;
using Online_Store.Commands.CartCommands;
using Online_Store.Commands.EmptyCommand;
using Online_Store.Commands.FeedbackCommands;
using Online_Store.Commands.ProductCommands;
using Online_Store.Commands.SellerCommands;
using Online_Store.Commands.UserCommands;
using Online_Store.Core;
using Online_Store.Core.Factories;
using Online_Store.Core.ProductServices;
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
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();

            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IModelFactory>().To<ModelFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IStoreContext>().To<StoreContext>().Named("context");

            this.Bind<IUserService>().To<UserService>().InSingletonScope().Named("userService");
            this.Bind<IProductService>().To<ProductService>().InSingletonScope().Named("productservice");
            this.Bind<IPasswordSecurityHasher>().To<PasswordSecurityHasher>().Named("passwordHasher");

            this.Bind<ILoggedUserProvider>().To<LoggedUserProvider>().InSingletonScope();

            this.Bind<ICommand>().To<CreateUserCommand>().Named("createuser");
            this.Bind<ICommand>().To<UserLoginCommand>().Named("login");
            this.Bind<ICommand>().To<Logout>().Named("logout");
            this.Bind<ICommand>().To<BecomeSellerCommand>().Named("becomeseller");
            this.Bind<ICommand>().To<UpdateProduct>().Named("updateproduct");

            this.Bind<ICommand>().To<ListAllProductsBySellerCommand>().Named("sellerProducts");

            this.Bind<ICommand>().To<AddToCartCommand>().Named("addtocart");
            this.Bind<ICommand>().To<CheckoutCardCommand>().Named("checkoutcart");
            this.Bind<ICommand>().To<AddFeedbackCommand>().Named("addfeedback");

            this.Bind<ICommand>().To<AddProductCommand>().Named("addproduct");
            this.Bind<ICommand>().To<RemoveProductCommand>().Named("removeproduct");

            this.Bind<ICommand>().To<EmptyCommand>().Named("emptycommand");
        }
    }
}
