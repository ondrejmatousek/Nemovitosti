using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using Nemovitosti.DataAccessLayer;
using Nemovitosti.DataAccessLayer.Implementation;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.ServiceLayer.Implementation;
using Nemovitosti.ServiceLayer.Interface;
using System.Configuration;

namespace Nemovitosti.CompositionRoot
{

    public class CompRoot : CompositionRootBase
    {
        //Tato metoda je tu z důvodu testů. v projektu s testama se sestavuje kontejner s registracema metodou compose()
        public override void Compose()
        {
            IocContainer = new Container();  //vytvořím do interface nový object Container a přes interface naplním Container

            IocContainer.Register<IBytDao, BytDao>(Reuse.Singleton);
            IocContainer.Register<IDumDao, DumDao>(Reuse.Singleton);
            IocContainer.Register<IBytService, BytService>(Reuse.Singleton);

            DalInitializer.Init();
        }
    }

    //Registrace pro slutečné zapnutí aplikace (ne pro testy). Používá se ve tříde StartUp.ConfigureServices(IServiceCollection services) -  services.AddSharedData(stringSettings);
    //Registrace se tedy ve tříde CompRoot dělá 2x. Jednou pro testy a jednou pro skutečný produkční kód.
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSharedData(this IServiceCollection services, ConnectionStringSettings stringSettings)
        {

            services.AddSingleton<IBytDao>(s => new BytDao(stringSettings));
            services.AddSingleton<IDumDao>(s => new DumDao(stringSettings));
            services.AddSingleton<IBytService>(s => new BytService(new BytDao(stringSettings)));
            services.AddSingleton<IDumService>(s => new DumService(new DumDao(stringSettings)));

            return services;
        }

    }

}
