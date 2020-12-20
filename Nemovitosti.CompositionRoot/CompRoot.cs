using DryIoc;
using Nemovitosti.DataAccessLayer.Implementation;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.ServiceLayer.Implementation;
using Nemovitosti.ServiceLayer.Interface;

namespace Nemovitosti.CompositionRoot
{

    public class CompRoot : CompositionRootBase
    {
        //Nedaří se mi vytvořit nakonfigurovaný kontejner. Pořád to píše, že je to Container without Scope
        public override void Compose()
        {
            IocContainer = new Container();  //vytvořím do interface nový object Container a přes interface naplním Container

            IocContainer.Register<IBytDao, BytDao>();
            IocContainer.Register<IBytService, BytService>();
        }
    }

}
