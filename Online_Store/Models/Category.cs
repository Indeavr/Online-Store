using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Models
{
    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
        }

        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

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
