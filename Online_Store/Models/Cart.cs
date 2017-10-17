using System.Collections.Generic;

namespace Online_Store.Models
{
    public class Cart
    {
        //private ICollection<Product> products;

        public Cart()
        {

        }

        public int Id { get; set; }

        //public int ProductId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
