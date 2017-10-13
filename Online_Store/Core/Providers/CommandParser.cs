using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Commands;

namespace Online_Store.Core.Providers
{
    public class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            throw new NotImplementedException();
        }
    }
}
