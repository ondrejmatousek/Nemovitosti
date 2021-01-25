using Nemovitosti.DataAccessLayer.Interface.Ciselniky;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.ServiceLayer.Interface.Ciselniky;
using System.Collections.Generic;

namespace Nemovitosti.ServiceLayer.Implementation.Ciselniky
{
    public class CiselnikTypPozemkuService : ICiselnikTypPozemkuService
    {
        private readonly ICiselnikTypPozemkuDao _ciselnikTypPozemku;
        public CiselnikTypPozemkuService(ICiselnikTypPozemkuDao ciselnikTypPozemku)
        {
            _ciselnikTypPozemku = ciselnikTypPozemku;
        }

        public List<CiselnikTypPozemku> GetAll()
        {
            return _ciselnikTypPozemku.GetAll();
        }
    }
}
