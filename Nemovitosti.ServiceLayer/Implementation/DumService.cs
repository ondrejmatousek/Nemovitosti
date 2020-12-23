using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;

namespace Nemovitosti.ServiceLayer.Implementation
{
    public class DumService : IDumService
    {
        private readonly IDumDao dumDao;
        public DumService(IDumDao dumDao)
        {
            this.dumDao = dumDao;
        }
        public void Insert(Dum dum)
        {
            dumDao.Insert(dum);
        }

        public Dum GetById(int id)
        {
            return dumDao.GetById(id);
        }

        public void Update(Dum dum)
        {
            dumDao.Update(dum);
        }

        public void Delete(Dum dum)
        {
            dumDao.Delete(dum);
        }
    }
}
