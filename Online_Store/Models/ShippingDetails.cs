using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class ShippingDetails
    {
        public ShippingDetails()
        {
        }

        public ShippingDetails(decimal cost, int? deliveryTime = null)
        {
            this.Cost = cost;
            this.DeliveryTime = deliveryTime;
        }

        [Required]
        public decimal Cost { get; set; }

        public int? DeliveryTime { get; set; } //nullable int

        [Key, ForeignKey("Product")] //validacii na database nivo, sys update database
        public int ProductId { get; set; }

        public Product Product { get; set; }
        //public virtual Product Product { get; set; }
    }
}
