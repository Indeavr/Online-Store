﻿using Bytes2you.Validation;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Linq;

namespace Online_Store.Commands.ProductCommands
{
    public class ListFeedbacksForProductCommand : Command
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ILoggedUserProvider loggedUserProvider;

        public ListFeedbacksForProductCommand(IStoreContext context, IWriter writer, IReader reader,
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

            string productName = TakeInput();

            return this.productService.ListFeedbacksFromProduct(productName);
        }

        private string TakeInput()
        {
            string productName = base.ReadOneLine("For which product do you want ot list the feedbacks: ").ToLower();
            if (!base.context.Products.Any(x => x.ProductName == productName))
            {
                throw new ArgumentException("Product does not exist.");
            }

            return productName;
        }
    }
}
