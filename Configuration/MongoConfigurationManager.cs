using System.Configuration;

namespace SenseFramework.Data.MongoDb.Configuration
{
    internal  static class MongoConfigurationManager
    {
        public static string ConnectionString => ConfigurationManager.AppSettings["MongoConnection"];

        public static string Database => ConfigurationManager.AppSettings["MongoDatabase"];
    }
}
