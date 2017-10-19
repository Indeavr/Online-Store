﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;

namespace Online_Store.Commands.FeedbackCommands
{
    public class EditCommentCommand : Command, ICommand
    {
        public EditCommentCommand(IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();

            var product = parameters[0];
            var feedbackId = int.Parse(parameters[1]);

            Feedback feedback = base.context.Feedbacks.Single(f => f.Id == feedbackId);

            writer.Write("Edit comment: ");
            feedback.Comment = reader.ReadLine();

            return $"Comment edited succesfully";
        }

        private IList<string> TakeInput()
        {
            var product = base.ReadOneLine("Product: ");
            var feedback = base.ReadOneLine("Feedback ID: ");

            return new List<string>() { product, feedback };
           
        }
    }
}
