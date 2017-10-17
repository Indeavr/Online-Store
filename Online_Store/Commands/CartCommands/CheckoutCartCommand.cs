using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;

namespace Online_Store.Commands.CartCommands
{
    public class CheckoutCardCommand : Command, ICommand
    {
        public CheckoutCardCommand(IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();

            int cartId = int.Parse(parameters[0]);
            string productName = parameters[1];

            Cart cart = base.context.Carts.Single(c => c.Id == cartId);
            Product product = base.context.Products.Single(p => p.ProductName == productName);
            cart.Products.Remove(product);

            return $"Thank you for purchasing this product";
        }

        private IList<string> TakeInput()
        {
            var cart = base.ReadOneLine("Cart ID: ");
            var product = base.ReadOneLine("Product: ");

            return new List<string>() { cart, product };
        }
    }
}
