using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Models
{
    public class Product
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

        public virtual ICollection<Feedback> Feedback { get; set; }

        public virtual Sale Sale { get; set; }

        // think about it
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
