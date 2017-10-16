using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public interface IProduct
    {
        int Id {get; set;}
        string ProductName { get; set; }
        decimal Price { get; set; }
        string Category { get; set; }
        DateTime Date { get; set; }
        string PaymentMethod { get; set; }
        bool Instock { get; set; }
        Seller Seller { get; set; }
        //ShippingDetails ShippingDetails { get; set; }
        //Feedback Feedback { get; set; }
        //Sale Sale { get; set; }
    }
}
