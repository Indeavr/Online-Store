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
    public class AddProductCommand : Command
    {
        public AddProductCommand(IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            parameters = TakeInput();
            string productName = parameters[0];

            try
            {
                Product product = base.context.Products.Single(x => x.ProductName.ToLower() == productName.ToLower());
                base.context.Products.Remove(product);
                return "Product successfuly removed.";
            }
            catch
            {
                //several cases to handle
                return "Product doesn`t exist.";
            }
        }

        private string CommandDescription()
        {
            string description = "";
            string example = "";
            return string.Format("{0}\n{1}",description, example);
        }

        //AUTO   int Id { get; set; }
        //public string ProductName { get; set; }
        //public decimal Price { get; set; }
        //public virtual Category Categories { get; set; }
        //AUTO   DateTime Date { get; set; }
        //public PaymentMethodEnum PaymentMethod { get; set; }
        //AUTO   bool Instock { get; set; }
        //AUTO   virtual Seller Seller { get; set; }
        //public virtual ShippingDetails ShippingDetails { get; set; }
        //public virtual Feedback Feedback { get; set; }
        //public virtual Sale Sale { get; set; }

        private IList<string> TakeInput()
        {
            string forWellcome = string.Format("{0}\n{1}", CommandDescription(), "ProductName (case insensitive):");
            var productName = base.ReadOneLine(forWellcome);

            return new List<string>() { productName.ToLower() };
        }
    }
}
