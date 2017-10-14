using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Commands;
using Online_Store.Core.Factories;
using Bytes2you.Validation;

namespace Online_Store.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];

            return this.factory.CreateCommand(commandName);
        }

        public IList<string> ParseParameters()
        {
            return new List<string>();
        }
    }
}
