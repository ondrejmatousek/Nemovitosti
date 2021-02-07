using Nemovitosti.DomainModel.Model;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.Web.Models;
using Nemovitosti.Web.Models.Account;
using Nemovitosti.Web.Models.CiselnikyViewModel;
using System.Collections.Generic;

namespace Nemovitosti.Web.Mappers
{
    public interface IMapperWeb
    {
        BytVM Map(Byt byt);
        Byt Map(BytVM bytVM);

        PozemekVM Map(Pozemek pozemek);
        Pozemek Map(PozemekVM pozemekVM);

        UzivatelVM Map(Uzivatel uzivatel);
        Uzivatel Map(UzivatelVM uzivatelVM);

        CiselnikTypPozemkuVM Map(CiselnikTypPozemku ciselnikTypPozemku);
        CiselnikTypPozemku Map(CiselnikTypPozemkuVM ciselnikTypPozemkuVM);

        CiselnikProdejNeboPronajemVM Map(CiselnikProdejNeboPronajem ciselnikProdejNeboPronajem);
        CiselnikProdejNeboPronajem Map(CiselnikProdejNeboPronajemVM ciselnikProdejNeboPronajemVM);

        List<CiselnikTypPozemkuVM> Map(List<CiselnikTypPozemku> ciselnikTypPozemku);
        List<CiselnikTypPozemku> Map(List<CiselnikTypPozemkuVM> ciselnikTypPozemkuVM);

        List<CiselnikProdejNeboPronajemVM> Map(List<CiselnikProdejNeboPronajem> ciselnikProdejNeboPronajem);
        List<CiselnikProdejNeboPronajem> Map(List<CiselnikProdejNeboPronajemVM> ciselnikProdejNeboPronajemVM);
    }
}
