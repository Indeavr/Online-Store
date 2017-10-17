﻿using Bytes2you.Validation;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Commands.UserCommands
{
    public class Logout : Command, ICommand
    {
        private IUserService userService;
        private ILoggedUserProvider loggedUserProvider;

        public Logout(IUserService userService, ILoggedUserProvider loggedUserProvider, IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.userService = userService;
            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute(IList<string> parameters)
        {
            //add logout in user service
            this.loggedUserProvider.CurrentUserId = -1;

            return "Successfully loged out !";
        }
    }
}
