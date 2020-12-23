using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.ServiceLayer.Interface
{
    public interface IDumService
    {
        void Insert(Dum dum);
        Dum GetById(int id);
        void Update(Dum dum);
        void Delete(Dum dum);
    }
}
