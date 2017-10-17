using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands
{
    public interface ICommand
    {
        string Execute();
    }
}
