using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class ShippingDetails
    {
        public ShippingDetails()
        {
        }

        [Key, ForeignKey("Product")]
        public int ProductId { get; set; }

        public decimal Cost { get; set; }

        public int DeliveryTIme { get; set; }

        public Product Product { get; set; }
    }
}
