using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;

namespace Nemovitosti.ServiceLayer.Implementation
{
    public class BytService : IBytService
    {
        private readonly IBytDao bytDao;
        public BytService(IBytDao bytDao)
        {
            this.bytDao = bytDao;
        }
        public void Insert(Byt byt)
        {
            bytDao.Insert(byt);
        }
        public Byt GetById(int id)
        {
            return bytDao.GetById(id);
        }
        public void Update(Byt byt)
        {
            bytDao.Update(byt);
        }
        public void Delete(Byt byt)
        {
            bytDao.Delete(byt);
        }
    }
}
