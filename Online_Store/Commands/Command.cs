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
<<<<<<< HEAD
        protected readonly IStoreContext context;
        private readonly IWriter writer;
        private readonly IReader reader;
=======
        protected IStoreContext context;
        protected IWriter writer;
        protected IReader reader;
>>>>>>> 96e58c3ec079339cb2d2aa6d10f5d87410324c77

        public Command(IStoreContext context, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();

            this.context = context;
            this.writer = writer;
            this.reader = reader;
        }

        public abstract string Execute();

        protected string ReadOneLine(string textToShow)
        {
            this.writer.Write(textToShow);

            return this.reader.ReadLine();
        }
    }
}
