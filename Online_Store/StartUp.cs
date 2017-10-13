using Ninject;
using Online_Store.Core;
using Online_Store.Data;
using Online_Store.Migrations;
using Online_Store.Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store
{
    public class StartUp
    {
        public static void Main()
        {
            Database
                .SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());

            IKernel kernel = new StandardKernel(new StoreModule());

            IEngine engine = kernel.Get<IEngine>("Engine"); 
            engine.Start();
        }
    }
}
