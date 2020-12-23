using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.ServiceLayer.Interface
{
    public interface IBytService
    {
        void Insert(Byt byt);
        Byt GetById(int id);
        void Update(Byt byt);
        void Delete(Byt byt);

    }
}
