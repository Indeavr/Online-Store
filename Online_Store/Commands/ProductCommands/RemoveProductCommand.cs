using Bytes2you.Validation;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.ProductCommands
{
    public class RemoveProductCommand : Command
    {
        private readonly IProductService productService;

        public RemoveProductCommand(IStoreContext context, IWriter writer, IReader reader,
            IProductService productService)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(productService, "productService").IsNull().Throw();
            this.productService = productService;
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();
            string productName = parameters[0];

            return this.productService.RemoveProductWithName(productName);
        }

        private IList<string> TakeInput()
        {
            var productName = base.ReadOneLine("Specify a product name to remove (case insensitive): ");

            return new List<string>() { productName.ToLower() };
        }
    }
}
