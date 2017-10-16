using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands.ProductCommands
{
    public class EditProductCommand : Command
    {
        public EditProductCommand(IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            //implement something here
            parameters = TakeInput();
            string productName = parameters[0];

            try
            {
                //implement something here
                return "Product successfuly edited.";
            }
            catch
            {
                //implement something here
                //several cases to handle
                return "Product doesn`t exist.";
            }
        }

        private IList<string> TakeInput()
        {
            //implement something here
            var productName = base.ReadOneLine("ProductName (case insensitive): ");
            return new List<string>() { productName.ToLower() };
        }
    }
}
