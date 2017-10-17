using Online_Store.Core.Providers;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands.SellerCommands
{
    public class ListAllProductsBySellerCommand : Command, ICommand
    {

        public ListAllProductsBySellerCommand(IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
        }

     
        public override string Execute(IList<string> parameters)
        {
            var products = this.context.Sellers.Single(i => i.UserId == 1).Products;

            return "";
        }
    }
}
