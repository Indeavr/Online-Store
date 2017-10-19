using System.Collections.Generic;
using System.Xml.Serialization;

namespace Online_Store.Models
{
    public class Cart
    {
        private ICollection<Product> products;

        public Cart()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }
        
        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
    }
}
