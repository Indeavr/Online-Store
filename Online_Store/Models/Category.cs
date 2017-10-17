using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}
