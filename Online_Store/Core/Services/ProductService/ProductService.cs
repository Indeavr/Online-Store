using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Core.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IStoreContext context;
        private readonly ILoggedUserProvider loggedUserProvider;
        private readonly IWriter writer;
        private readonly IModelFactory modelFactory;

        public ProductService(IStoreContext context, ILoggedUserProvider loggedUserProvider, IWriter writer,
            IModelFactory modelFactory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();
            this.context = context;
            this.loggedUserProvider = loggedUserProvider;
            this.writer = writer;
            this.modelFactory = modelFactory;
        }

        public string AddProduct(IList<string> parameters)
        {
            string productName;
            decimal price;
            string category;
            PaymentMethodEnum paymentMethod;
            decimal shippingDetailsCost;
            int shippingDetailsDeliveryTIme;
            decimal priceReduction;

            try
            {
                //validation
                productName = parameters[0].ToLower();
                if (this.context.Products.Any(x => x.ProductName == productName))
                {
                    return "Product already exists.";
                }
                price = decimal.Parse(parameters[1]);
                if (price < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                category = parameters[2].ToLower();
                paymentMethod = (PaymentMethodEnum)Enum.Parse(typeof(PaymentMethodEnum), parameters[3], true);
                if ((int)paymentMethod <= -1 || (int)paymentMethod >= 6)
                {
                    throw new ArgumentOutOfRangeException("Invalid payment method.");
                }
                shippingDetailsCost = decimal.Parse(parameters[4]);
                if (price < 0)
                {
                    throw new ArgumentException("Shipping cost cannot be negative.");
                }
                shippingDetailsDeliveryTIme = int.Parse(parameters[5]);
                if (price < 0)
                {
                    throw new ArgumentException("Delivery time cannot be negative.");
                }
                priceReduction = decimal.Parse(parameters[6]);
                if (price < 0)
                {
                    throw new ArgumentException("Price reduction cannot be negative.");
                }
            }
            catch
            {
                return "One or more parameters for the AddProduct command are invalid.";
            }

            Product product = new Product();
            product.ProductName = productName;
            product.Price = price;
            product.Date = DateTime.Now;
            product.PaymentMethod = paymentMethod;
            product.Instock = true;
            product.SellerId = this.loggedUserProvider.CurrentUserId;

            if (this.context.Categories.Any(x => x.CategoryName == category))
            {
                product.Categories.Add(this.context.Categories.First(x => x.CategoryName == category));
            }
            else
            {
                Category newCategory = this.modelFactory.CreateCategory();
                newCategory.CategoryName = category;
                product.Categories.Add(newCategory);
            }

            ShippingDetails newShippingDetails = modelFactory.CreateShippingDetails();
            newShippingDetails.DeliveryTime = shippingDetailsDeliveryTIme;
            newShippingDetails.Cost = shippingDetailsCost;
            product.ShippingDetails = newShippingDetails;

            //fix this to decimal
            Sale newSale = this.modelFactory.CreateSale();
            newSale.PriceReduction = (int)priceReduction;
            product.Sale = newSale;

            //useless
            //product.Seller = this.context.Sellers.Single(x => x.UserId == this.loggedUserProvider.CurrentUserId);

            context.Products.Add(product);
            context.SaveChanges();

            this.writer.CleanScrean();
            return "Product added succesfully.";
        }

        public string EditProduct(IList<string> parameters)
        {
            return "penka";
        }

        public string ListAllProducts()
        {
            throw new NotImplementedException();
        }

        public string ListFeedbacksFromProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public string ListProductsByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public string RemoveProductWithName(string productName)
        {
            
            try
            {
                Product product = this.context.Products.Single(x => x.ProductName.ToLower() == productName.ToLower());
                this.context.Products.Remove(product);
                this.context.SaveChanges();
                return "Product successfuly removed.";
            }
            catch
            {
                //several cases to handle
                return "TOFIX: Product doesn`t exist or several other reasons.";
            }
        }
    }
}
