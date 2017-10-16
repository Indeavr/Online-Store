using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models.Contracts
{
    public interface IShippingDetails
    {
        int Id { get; set; }

        decimal Cost { get; set; }

        int DeliveryTIme { get; set; }
    }
}
