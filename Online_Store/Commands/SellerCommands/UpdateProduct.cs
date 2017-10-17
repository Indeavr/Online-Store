using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Bytes2you.Validation;

namespace Online_Store.Commands.SellerCommands
{
    public class UpdateProduct : Command, ICommand
    {
        private ILoggedUserProvider loggedUserProvider;

        public UpdateProduct(ILoggedUserProvider loggedUserProvider, IStoreContext context, 
            IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {
            //parameters = TakeInput();
            //int productId = int.Parse(parameters[0]);
            //string property = parameters[1];
            //string property = parameters[1];

            //if (property == "ShippingDetails")
            //{
            //    return "Please Type [updateshippingdetails {productId}] in order to update";
            //}

            // just list property by property
            return "";
        }

        //private IList<string> TakeInput()
        //{
        //    var result = new List<string>();

        //    var productId =int.Parse(base.ReadOneLine("Enter product ID: "));
        //    if (productId > this.context.Products.Last().Id)
        //    {
        //        throw new Exception("Wrong Product ID !");
        //    }
        //    result.Add(productId.ToString());

        //    while (true)
        //    {
        //        var property = base.ReadOneLine("What do you want to edit [press done if ready]?");
        //        if (property.ToLower().Equals("done"))
        //        {
        //            break;
        //        }

        //        if (property == "ProductName" || property == "Price"
        //            || property == "PaymentMethod" || property == "Instock"
        //            || property == "ShippingDetails")
        //        {
        //            result.Add(property);
        //            string newProperty = base.ReadOneLine($"{property}: ");
        //            UpdateProperty(productId, property, newProperty);
        //        }
        //        else
        //        {
        //            base.writer.WriteLine("Wrong Property ! [must be CamelCase]");
        //        }
        //    }

        //    return result;
        //}

        //private void UpdateProperty(int productId, string property, string newProperty)
        //{
        //    try
        //    {
        //        this.context.Products.Single(p => p.Id == productId)[property] = newProperty;
        //    }
        //    catch (Exception)
        //    {
        //        this.writer.WriteLine("Wrong value!");
        //    }
        
        //}
    }
}
