//using Bytes2you.Validation;
//using Online_Store.Core.ProductServices;
//using Online_Store.Core.Providers;
//using Online_Store.Core.Services.User;
//using Online_Store.Data;
//using Online_Store.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Online_Store.Commands.ProductCommands
//{
//    public class EditProductCommand : Command
//    {
//        private readonly IProductService productService;
//        private readonly IUserService userService;
//        private readonly ILoggedUserProvider loggedUserProvider;

//        public EditProductCommand(IStoreContext context, IWriter writer, IReader reader,
//            IProductService productService, IUserService userService, ILoggedUserProvider loggedUserProvider)
//            : base(context, writer, reader)
//        {
//            Guard.WhenArgument(productService, "productService").IsNull().Throw();
//            Guard.WhenArgument(userService, "userService").IsNull().Throw();
//            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
//            this.productService = productService;
//            this.userService = userService;
//            this.loggedUserProvider = loggedUserProvider;
//        }

//        public override string Execute()
//        {
//            if (!this.userService.IsUserLogged())
//            {
//                return "You must Login First!";
//            }

//            //implement something here
//            IList<string> parameters = TakeInput();
//            string productName = parameters[0];

//            try
//            {
//                //implement something here
//                return "Product successfuly edited.";
//            }
//            catch
//            {
//                //implement something here
//                //several cases to handle
//                return "Product doesn`t exist.";
//            }
//        }

//        private IList<string> TakeInput()
//        {
//            //implement something here
//            var productName = base.ReadOneLine("ProductName (case insensitive): ");
//            return new List<string>() { productName.ToLower() };
//        }
//    }
//}
