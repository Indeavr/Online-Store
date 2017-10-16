using System.Collections.Generic;

namespace Online_Store.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }

        string CategoryName { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
