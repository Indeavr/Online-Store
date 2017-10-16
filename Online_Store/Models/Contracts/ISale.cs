using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public interface ISale
    {
        int Id { get; set; }

        int ProductId { get; set; }

        int PriceReduction { get; set; }
    }
}
