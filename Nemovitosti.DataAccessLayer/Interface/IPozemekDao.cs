using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.DataAccessLayer.Interface
{
    public interface IPozemekDao
    {
        void Insert(Pozemek pozemek);
        Pozemek GetById(int id);
        void Update(Pozemek pozemek);
        void Delete(Pozemek pozemek);
    }
}
