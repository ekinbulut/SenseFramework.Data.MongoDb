using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MongoDB.Driver;
using SenseFramework.Core.Configuration;
using SenseFramework.Core.Intercepters;
using SenseFramework.Data.MongoDb.Configuration;
using SenseFramework.Data.MongoDb.Repositories;

namespace SenseFramework.Data.MongoDb
{
    internal class MongoDbModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = MongoConfigurationManager.ConnectionString;

            // !IMPORTANT!
            // Register as a factory. It will provide new MongoClient(""); instance in a IMongoClient Request
            container.Register(Component.For<IMongoClient>().ImplementedBy<MongoClient>().LifestyleSingleton()
                .UsingFactoryMethod(() => new MongoClient(connectionString)));

            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyInstaller.AssemblyDirectory))
                    .BasedOn(typeof(IRepository<>))
                    .WithServiceDefaultInterfaces().Configure(t=>t.Interceptors<DisplayIntercepter>()));
        }
    }
}