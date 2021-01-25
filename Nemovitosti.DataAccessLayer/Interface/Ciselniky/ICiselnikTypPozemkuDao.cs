using Nemovitosti.DomainModel.Model.Ciselniky;
using System.Collections.Generic;

namespace Nemovitosti.DataAccessLayer.Interface.Ciselniky
{
    public interface ICiselnikTypPozemkuDao
    {
        List<CiselnikTypPozemku> GetAll();
    }
}
