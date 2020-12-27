using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;

namespace Nemovitosti.ServiceLayer.Implementation
{
    public class PozemekService : IPozemekService
    {
        private readonly IPozemekDao pozemekDao;
        public PozemekService(IPozemekDao pozemekDao)
        {
            this.pozemekDao = pozemekDao;
        }

        public void Insert(Pozemek pozemek)
        {
            pozemekDao.Insert(pozemek);
        }
        public Pozemek GetById(int id)
        {
            return pozemekDao.GetById(id);
        }
        public void Update(Pozemek pozemek)
        {
            pozemekDao.Update(pozemek);
        }
        public void Delete(Pozemek pozemek)
        {
            pozemekDao.Delete(pozemek);
        }
    }
}
