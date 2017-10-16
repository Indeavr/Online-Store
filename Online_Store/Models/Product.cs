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

        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public virtual ICollection<Category> Categories { get; set; } 
        /*
         * не може един продукт да има колекция от категории
         * */
        public ICollection<Category> Categories { get; set; }

        [NotMapped]
        public DateTime Date { get; set; }

        //[Key, ForeignKey("PaymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public bool Instock { get; set; }
        
        //[Key, ForeignKey("Seller")]
        public Seller Seller { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

        public Feedback Feedback { get; set; }

        public Sale Sale { get; set; }
    }
}
