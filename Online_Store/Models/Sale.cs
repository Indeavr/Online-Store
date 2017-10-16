using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class Sale : ISale
    {
        public Sale()
        {
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int PriceReduction { get; set; }
    }
}
