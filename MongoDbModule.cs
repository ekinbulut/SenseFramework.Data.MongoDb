using SenseFramework.Core.Integrations;
using SenseFramework.Core.IoC;
using SenseFramework.Core.Messaging;

namespace SenseFramework.Data.MongoDb
{
    public class MongoDbModule : ITierApplicationModule
    {
        public void RegisterModule()
        {
            Messanger.Logger.Info("MongoDb Core Data Module Installing...");

            IoCManager.Container.Install(new MongoDbModuleInstaller());

            Messanger.Logger.Info("MongoDb Core Data Module Installed...");

        }
    }
}
