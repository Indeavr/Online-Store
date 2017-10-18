using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Core.ProductServices
{
    public interface IProductService
    {
        string AddProduct(IList<string> parameters);
        string EditProduct(IList<string> parameters);
        string RemoveProductWithName(string productName);
        string ListAllProducts();
        string ListFeedbacksFromProduct(string productName);
        string ListProductsByCategory(string categoryName);
    }
}
