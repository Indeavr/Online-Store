using Online_Store.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class Product : IProduct
    {
        public Product()
        {
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public virtual Category Categories { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; }

        [Required]
        public bool Instock { get; set; }
        
        public virtual Seller Seller { get; set; }

        public virtual ShippingDetails ShippingDetails { get; set; }

        public virtual Feedback Feedback { get; set; }

        public virtual Sale Sale { get; set; }
        
    }
}
