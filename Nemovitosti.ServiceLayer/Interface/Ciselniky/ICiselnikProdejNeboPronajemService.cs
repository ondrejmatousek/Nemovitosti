using Nemovitosti.DomainModel.Model.Ciselniky;
using System.Collections.Generic;

namespace Nemovitosti.ServiceLayer.Interface.Ciselniky
{
    public interface ICiselnikProdejNeboPronajemService
    {
        List<CiselnikProdejNeboPronajem> GetAll();
    }
}
