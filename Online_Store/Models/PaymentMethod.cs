using Online_Store.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class PaymentMethod : IPaymentMethod
    {
        public int Id { get; set; }

        public string PaymentMethodName { get; set; }
    }
}
