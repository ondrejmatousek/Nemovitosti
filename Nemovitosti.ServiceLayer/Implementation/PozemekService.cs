using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;

namespace Nemovitosti.ServiceLayer.Implementation
{
    public class PozemekService : IPozemekService
    {
        private readonly IPozemekDao _pozemekDao;
        public PozemekService(IPozemekDao pozemekDao)
        {
            _pozemekDao = pozemekDao;
        }

        public void Insert(Pozemek pozemek)
        {
            _pozemekDao.Insert(pozemek);
        }
        public Pozemek GetById(int id)
        {
            return _pozemekDao.GetById(id);
        }
        public void Update(Pozemek pozemek)
        {
            _pozemekDao.Update(pozemek);
        }
        public void Delete(Pozemek pozemek)
        {
            _pozemekDao.Delete(pozemek);
        }
    }
}
