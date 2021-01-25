using Nemovitosti.DomainModel.Model.Ciselniky;
using System.Collections.Generic;

namespace Nemovitosti.ServiceLayer.Interface.Ciselniky
{
    public interface ICiselnikTypPozemkuService
    {
        List<CiselnikTypPozemku> GetAll();
    }
}
