using Ninject.Modules;
using Online_Store.Core;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Ninject
{
    public class StoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWriter>().To<ConsoleWriter>().Named("console writer");
            this.Bind<IReader>().To<ConsoleReader>().Named("console reader");
            this.Bind<IParser>().To<CommandParser>().Named("command parser");


            this.Bind<ICommandFactory>().To<CommandFactory>().Named("CommandFactory");
            this.Bind<IModelFactory>().To<ModelFactory>().Named("ModelFactory");

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named("Engine");
        }
    }
}
