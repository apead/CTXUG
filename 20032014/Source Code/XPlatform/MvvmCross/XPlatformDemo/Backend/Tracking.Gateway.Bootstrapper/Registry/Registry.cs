using Raven.Client;
using Raven.Client.Document;
using StructureMap;

namespace AdSoftSystems.Bootstrapper.Registry
{
    using System.Configuration;

    public class Registry
    {
        public static IContainer Initialize()
        {
            IContainer container = new Container();

            var url = ConfigurationManager.AppSettings["RavenDbUrl"];
            var database = ConfigurationManager.AppSettings["RavenDbDatabase"];

            container.Configure(
                x =>
                    {
                        x.For<IDocumentStore>()
                            .Singleton()
                            .Use(() => new DocumentStore { Url = url, DefaultDatabase = database })
                            .OnCreation<IDocumentStore>(c => c.Initialize());

                    });
 
            return container;
        }
    }
}
