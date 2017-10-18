using Bytes2you.Validation;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.ProductCommands
{
    public class RemoveProductCommand : Command
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ILoggedUserProvider loggedUserProvider;

        public RemoveProductCommand(IStoreContext context, IWriter writer, IReader reader,
            IProductService productService, IUserService userService, ILoggedUserProvider loggedUserProvider)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(productService, "productService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            this.productService = productService;
            this.userService = userService;
            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {
            if (!this.userService.IsUserLogged())
            {
                return "You must Login First!";
            }
            
            IList<string> parameters = TakeInput();
            string productName = parameters[0];
            if (!this.context.Products.Any(x => x.ProductName == productName))
            {
                throw new ArgumentException("Product does not exist.");
            }
            return this.productService.RemoveProductWithName(productName);
        }

        private IList<string> TakeInput()
        {
            var productName = base.ReadOneLine("Specify a product name to remove (case insensitive): ");

            return new List<string>() { productName.ToLower() };
        }
    }
}
