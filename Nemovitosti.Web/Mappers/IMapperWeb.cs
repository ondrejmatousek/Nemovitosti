using Nemovitosti.DomainModel.Model;
using Nemovitosti.Web.Models;

namespace Nemovitosti.Web.Mappers
{
    public interface IMapperWeb
    {
        BytVM Map(Byt byt);
        Byt Map(BytVM bytVM);
    }
}
