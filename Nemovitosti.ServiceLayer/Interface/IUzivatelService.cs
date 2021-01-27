using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.ServiceLayer.Interface
{
    public interface IUzivatelService
    {
        void Insert(Uzivatel uzivatel);
        Uzivatel GetById(int Id);
        void Update(Uzivatel uzivatel);
    }
}
