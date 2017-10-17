using Bytes2you.Validation;
using Online_Store.Core.Providers;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands
{
    public abstract class Command : ICommand
    {
        protected IStoreContext context;
        protected IWriter writer;
        protected IReader reader;

        public Command(IStoreContext context, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();

            this.context = context;
            this.writer = writer;
            this.reader = reader;
        }

        public abstract string Execute(IList<string> parameters);

        protected string ReadOneLine(string textToShow)
        {
            this.writer.Write(textToShow);

            return this.reader.ReadLine();
        }
    }
}
