using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class Product : IProduct
    {
        public Product()
        {
        }

        
        public int Id { get; set; }

        
        public decimal Price { get; set; }

        
        public string Category { get; set; }

        
        public DateTime Date { get; set; }

        
        public string PaymentMethod { get; set; }

        
        public bool Instock { get; set; }

        [NotMapped]
        public Seller Seller { get; set; }
        //public ShippingDetails ShippingDetails { get; set; }
        //public Feedback Feedback { get; set; }
        //public Sale Sale { get; set; }
    }
}
