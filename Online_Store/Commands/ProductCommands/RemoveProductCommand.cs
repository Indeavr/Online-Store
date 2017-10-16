using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.ProductCommands
{
    public class RemoveProductCommand : Command
    {
        public RemoveProductCommand(IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            parameters = TakeInput();
            string productName = parameters[0];

            try
            {
                Product product = base.context.Products.Single(x=>x.ProductName.ToLower() == productName.ToLower());
                base.context.Products.Remove(product);
                return "Product successfuly removed.";
            }
            catch
            {
                //several cases to handle
                return "Product doesn`t exist.";
            }
        }
        
        private IList<string> TakeInput()
        {
            var productName = base.ReadOneLine("ProductName (case insensitive): ");
            
            return new List<string>() { productName.ToLower() };
        }
    }
}
