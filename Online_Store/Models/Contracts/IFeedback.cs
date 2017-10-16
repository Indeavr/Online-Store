using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models.Contracts
{
    public interface IFeedback
    {
        int Id { get; set; }

        int Rating { get; set; }

        int UserId { get; set; }

        int ProductId { get; set; }

        string Comment { get; set; }

        DateTime Date { get; set; }
    }
}
