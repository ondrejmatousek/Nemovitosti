using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.DataAccessLayer.Interface
{
    public interface IDumDao
    {
        void Insert(Dum dum);
        void Update(Dum dum);
        Dum GetById(int Id);
        void Delete(Dum dum);
    }
}
