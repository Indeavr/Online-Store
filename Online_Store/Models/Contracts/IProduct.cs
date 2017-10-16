using Online_Store.Models.Enums;
using System;

namespace Online_Store.Models
{
    public interface IProduct
    {
        int Id { get; set; }

        string ProductName { get; set; }

        decimal Price { get; set; }
        
        Category Categories { get; set; }

        DateTime Date { get; set; }

        PaymentMethodEnum PaymentMethod { get; set; }

        bool Instock { get; set; }

        Seller Seller { get; set; }

        ShippingDetails ShippingDetails { get; set; }

        Feedback Feedback { get; set; }

        Sale Sale { get; set; }
    }
}
