using System.Collections.Generic;

namespace Online_Store.Models
{
    public class Cart
    {
        private ICollection<Product> products;

        public Cart()
        {
            this.products = new HashSet<Product>();
        }

//<<<<<<< HEAD
       // public int Id { get; set; }
        
//=======
        //[Key, ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

//>>>>>>> origin/master
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
