using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;

namespace Online_Store.Commands.FeedbackCommands
{
    public class AddFeedbackCommand : Command, ICommand
    {
        public AddFeedbackCommand(IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();

            var rating = parameters[0];
            var comment = parameters[1];

            Feedback feedback = base.context.Feedbacks.Single(f => f.Comment == comment);

            return $"Feedback added successfully";
        }

        private IList<string> TakeInput()
        {
            var rating = base.ReadOneLine("Rate this product: ");
            var comment = base.ReadOneLine("Add comment: ");

            return new List<string>() { rating, comment };

        }
    }
}
