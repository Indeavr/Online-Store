using Online_Store.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class ShippingDetails : IShippingDetails
    {
        public ShippingDetails()
        {
        }

        public int Id { get; set; }

        public decimal Cost { get; set; }

        public int DeliveryTIme { get; set; }
    }
}
