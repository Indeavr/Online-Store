using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Online_Store.Models
{
    public class Product
    {
        private ICollection<Category> categories;
        private ICollection<Feedback> feedbacks;
        private ICollection<Cart> carts;

        public Product()
        {
            this.categories = new HashSet<Category>();
            this.feedbacks = new HashSet<Feedback>();
            this.carts = new HashSet<Cart>();
        }

        public Product(string productName, decimal price, PaymentMethodEnum paymentMethod)
        {
            this.ProductName = productName;
            this.Price = price;
            this.PaymentMethod = paymentMethod;
        }

        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Nullable<DateTime> Date { get; set; }

        [Required]
        public PaymentMethodEnum PaymentMethod { get; set; }

        [Required]
        [ForeignKey("Seller")]
        public int? SellerId { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual ShippingDetails ShippingDetails { get; set; }

        public bool Instock { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }

        public virtual ICollection<Feedback> Feedbacks
        {
            get
            {
                return this.feedbacks;
            }
            set
            {
                this.feedbacks = value;
            }
        }

        public virtual ICollection<Cart> Carts
        {
            get
            {
                return this.carts;
            }
            set
            {
                this.carts = value;
            }
        }

        //public object this[string propertyName]
        //{
        //    get
        //    {
        //        // probably faster without reflection:
        //        // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
        //        // instead of the following
        //        Type myType = typeof(Product);
        //        PropertyInfo myPropInfo = myType.GetProperty(propertyName);
        //        return myPropInfo.GetValue(this, null);
        //    }
        //    set
        //    {
        //        Type myType = typeof(Product);
        //        PropertyInfo myPropInfo = myType.GetProperty(propertyName);
        //        myPropInfo.SetValue(this, value, null);

        //    }

        //}
    }
}
