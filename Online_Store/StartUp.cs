using Ninject;
using Online_Store.Core;
using Online_Store.Data;
using Online_Store.Migrations;
using Online_Store.Ninject;
using System.Data.Entity;
using System.Linq;

namespace Online_Store
{
    public class StartUp
    {
        public static void Main()
        {
            Database
                .SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());

            using (var context = new StoreContext())
            {
                var sdaasdasda = context.Users.ToList();
            }

            //IKernel kernel = new StandardKernel(new StoreModule());

            //IEngine engine = kernel.Get<IEngine>();
            //engine.Start();
        }
    }
}
