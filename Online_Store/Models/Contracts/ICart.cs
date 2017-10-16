using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public interface ICart
    {
        int Id { get; set; }

        int ProductId { get; set; }

        int Quantity { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
