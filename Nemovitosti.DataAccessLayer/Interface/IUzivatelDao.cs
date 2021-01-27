using Nemovitosti.DomainModel.Model;

namespace Nemovitosti.DataAccessLayer.Interface
{
    public interface IUzivatelDao
    {
        void Insert(Uzivatel uzivatel);
        Uzivatel GetById(int Id);
        void Update(Uzivatel uzivatel);
    }
}
