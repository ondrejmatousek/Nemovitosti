using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.DataAccessLayer.Interface
{
    public interface IBytDao
    {
        void Insert(Byt byt);
        void Update(Byt byt);
        Byt GetById(int Id);
        void Delete(Byt byt);

    }
}
