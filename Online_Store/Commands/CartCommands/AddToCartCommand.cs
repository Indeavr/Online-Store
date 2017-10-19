using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.CartCommands
{
    public class AddToCartCommand : Command, ICommand
    {
        private readonly IModelFactory factory;
        private readonly ILoggedUserProvider loggedUserProvider;
        private readonly IUserService userService;


        public AddToCartCommand(ILoggedUserProvider loggedUserProvider, IUserService userService,
                    IModelFactory factory,IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.factory = factory;
            this.loggedUserProvider = loggedUserProvider;
            this.userService = userService;
        }

        public override string Execute()
        {
            if (!this.userService.IsUserLogged())
            {
                return "You must login first!";
            }

            IList<string> parameters = TakeInput();

            Product product = this.factory.CreateProduct();
            string productIdStr = parameters[0];
            if (productIdStr == null)
            {
                try
                {
                    string nameInput = parameters[1];
                    product = base.context.Products.Single(p => p.ProductName == nameInput);
                }
                catch (Exception)
                {
                    return "There is no product with this Name!";
                }
            }
            else if (parameters[1] == null)
            {
                int productIdInput;
                try
                {
                    productIdInput = int.Parse(productIdStr);
                }
                catch (Exception)
                {
                    return "ID must be a Number!";
                }

                try
                {
                    product = base.context.Products.Single(p => p.Id == productIdInput);
                }
                catch (Exception)
                {
                    return "There is no product with this ID!";
                }
            }

            this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                            .Cart.Products.Add(product);

            //Console.WriteLine(this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
            //    .Cart.Products.Count);

            this.context.SaveChanges();

            return $"Product successfully added to cart";
        }

        private IList<string> TakeInput()
        {
            var type = base.ReadOneLine("Choose by what to add Product: [id, name]: ");
            string id = null;
            string name = null;

            if (type.ToLower() == "id")
            {
                id = base.ReadOneLine("ProductId: ");
            }
            else if (type.ToLower() == "name")
            {
                name = base.ReadOneLine("Product Name: ");
            }
            else
            {
                this.writer.WriteLine("You didn't Enter 'id' or 'name'!");
            }

            return new List<string>() { id, name };
        }
    }
}
