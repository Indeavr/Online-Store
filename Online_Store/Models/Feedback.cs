using System;

namespace Online_Store.Models
{
    public class Feedback
    {
        private int rating;
        private string comment;

        public Feedback()
        {

        }

        public Feedback(int rating, string comment)
        {
            this.rating = rating;
            this.comment = comment;
        }

        public int Id { get; set; }

        public int Rating { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        // public int SellerId { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
