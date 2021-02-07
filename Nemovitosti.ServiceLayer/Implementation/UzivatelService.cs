using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;

namespace Nemovitosti.ServiceLayer.Implementation
{
    public class UzivatelService : IUzivatelService
    {
        private readonly IUzivatelDao _uzivatelDao;
        public UzivatelService(IUzivatelDao uzivatelDao)
        {
            _uzivatelDao = uzivatelDao;
        }
        public void Insert(Uzivatel uzivatel)
        {
            _uzivatelDao.Insert(uzivatel);
        }
        public Uzivatel GetById(int id)
        {
            return _uzivatelDao.GetById(id);
        }
        public Uzivatel GetByEmailAndPassword(Uzivatel uzivatel)
        {
            return _uzivatelDao.GetByEmailAndPassword(uzivatel);
        }
        public void Update(Uzivatel uzivatel)
        {
            _uzivatelDao.Update(uzivatel);
        }

    }
}
