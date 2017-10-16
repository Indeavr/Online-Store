using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using Bytes2you.Validation;
using Online_Store.Core.Factories;

namespace Online_Store.Commands.CartCommands
{
    public class AddToCartCommand : Command, ICommand
    {
        private IModelFactory factory;


        public AddToCartCommand(IModelFactory factory, IStoreContext context, IWriter writer, IReader reader, ICart cart, IProduct product) : base(context, writer, reader)
        {
            this.factory = factory;
        }

        public override string Execute(IList<string> parameters)
        {
            parameters = TakeInput();

            int cartId = int.Parse(parameters[0]);
            string productName = parameters[1];

            Cart cart = factory.CreateCart();
            Product product = factory.CreateProduct();

            product.ProductName = productName;

            //cart.Product = product;
            
            cart.Products.Add(product);

            return $"Product successfully added to cart";
        }

        private IList<string> TakeInput()
        {
            var cart = base.ReadOneLine("Cart ID: ");
            var product = base.ReadOneLine("Product: ");

            return new List<string>() { cart, product };
        }
    }
}
