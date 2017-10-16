using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class Cart : ICart
    {
        private ICollection<IProduct> products;

        public Cart()
        {

        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<IProduct> Products { get; set; }
    }
}
