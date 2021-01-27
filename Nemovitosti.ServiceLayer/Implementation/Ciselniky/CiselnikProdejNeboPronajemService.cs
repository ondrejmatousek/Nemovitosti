using Nemovitosti.DataAccessLayer.Interface.Ciselniky;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.ServiceLayer.Interface.Ciselniky;
using System.Collections.Generic;

namespace Nemovitosti.ServiceLayer.Implementation.Ciselniky
{
    public class CiselnikProdejNeboPronajemService : ICiselnikProdejNeboPronajemService
    {
        private readonly ICiselnikProdejNeboPronajemDao _ciselnikProdejNeboPronajemDao;
        public CiselnikProdejNeboPronajemService(ICiselnikProdejNeboPronajemDao ciselnikProdejNeboPronajemDao)
        {
            _ciselnikProdejNeboPronajemDao = ciselnikProdejNeboPronajemDao;
        }

        public List<CiselnikProdejNeboPronajem> GetAll()
        {
            return _ciselnikProdejNeboPronajemDao.GetAll();
        }
    }
}
