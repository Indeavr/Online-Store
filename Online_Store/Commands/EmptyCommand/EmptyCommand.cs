using Online_Store.Core.Providers;
using Online_Store.Data;

namespace Online_Store.Commands.EmptyCommand
{
    public class EmptyCommand : Command
    {
        public EmptyCommand(IStoreContext context, IWriter writer, IReader reader) 
            : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            return "Command doesn`t exist.";
        }
    }
}
