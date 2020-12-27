using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.ServiceLayer.Interface
{
    public interface IPozemekService
    {
        void Insert(Pozemek pozemek);
        Pozemek GetById(int id);
        void Update(Pozemek pozemek);
        void Delete(Pozemek pozemek);
    }
}
