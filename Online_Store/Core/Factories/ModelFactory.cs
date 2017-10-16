using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public User CreateUser(string username, string hashedPassword)
        {
            return new User(username, hashedPassword);
        }

        public Seller CreateSeller()
        {
            return new Seller();
        }

        public Cart CreateCart()
        {
            return new Cart();
        }

        public Product CreateProduct()
        {
            return new Product();
        }
    }
}
