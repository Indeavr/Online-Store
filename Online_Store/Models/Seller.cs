using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class Seller
    {
        //private ICollection<Product> products;

        //private ICollection<Feedback> feedbacks;

        public Seller()
        {
            //this.products = new HashSet<Product>();
            //this.feedbacks = new HashSet<Feedback>();
        }

        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        // public virtual ICollection<Product> Products { get; set; }

        // public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
