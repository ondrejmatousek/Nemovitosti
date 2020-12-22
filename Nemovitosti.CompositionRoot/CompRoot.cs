using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using Nemovitosti.DataAccessLayer.Implementation;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.ServiceLayer.Implementation;
using Nemovitosti.ServiceLayer.Interface;
using System.Configuration;

namespace Nemovitosti.CompositionRoot
{

    public class CompRoot : CompositionRootBase
    {
        //Nedaří se mi vytvořit nakonfigurovaný kontejner. Pořád to píše, že je to Container without Scope
        public override void Compose()
        {
            IocContainer = new Container();  //vytvořím do interface nový object Container a přes interface naplním Container

            IocContainer.Register<IBytDao, BytDao>(Reuse.Singleton);
            IocContainer.Register<IBytService, BytService>(Reuse.Singleton);
        }
    }

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSharedData(this IServiceCollection services, ConnectionStringSettings stringSettings)
        {

            services.AddSingleton<IBytDao>(s => new BytDao(stringSettings));
            services.AddSingleton<IBytService>(s => new BytService(new BytDao(stringSettings)));

            return services;
        }

    }

}
