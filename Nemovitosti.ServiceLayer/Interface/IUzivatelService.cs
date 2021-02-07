using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.ServiceLayer.Interface
{
    public interface IUzivatelService
    {
        void Insert(Uzivatel uzivatel);
        Uzivatel GetById(int Id);
        Uzivatel GetByEmailAndPassword(Uzivatel uzivatel);
        void Update(Uzivatel uzivatel);
    }
}
