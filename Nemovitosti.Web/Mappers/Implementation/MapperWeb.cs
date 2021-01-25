using AutoMapper;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.Web.Models;
using Nemovitosti.Web.Models.CiselnikyViewModel;
using System.Collections.Generic;

namespace Nemovitosti.Web.Mappers.Implementation
{
    public class MapperWeb : IMapperWeb
    {
        private readonly IMapper autoMapper;
        public MapperWeb()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BytVM, Byt>();
                cfg.CreateMap<Byt, BytVM>();
                cfg.CreateMap<PozemekVM, Pozemek>();
                cfg.CreateMap<Pozemek, PozemekVM>();
                cfg.CreateMap<CiselnikTypPozemkuVM, CiselnikTypPozemku>();
                cfg.CreateMap<CiselnikTypPozemku, CiselnikTypPozemkuVM>();
                cfg.CreateMap<CiselnikProdejNeboPronajemVM, CiselnikProdejNeboPronajem>();
                cfg.CreateMap<CiselnikProdejNeboPronajem, CiselnikProdejNeboPronajemVM>();

            });
            this.autoMapper = config.CreateMapper();
        }

        //Byt
        public BytVM Map(Byt byt)
        {
            BytVM bytVM = autoMapper.Map<Byt, BytVM>(byt);
            return bytVM;
        }
        public Byt Map(BytVM bytVM)
        {
            Byt byt = autoMapper.Map<BytVM, Byt>(bytVM);
            return byt;
        }

        // Pozemek
        public Pozemek Map(PozemekVM pozemekVM)
        {
            Pozemek pozemek = autoMapper.Map<PozemekVM, Pozemek>(pozemekVM);
            return pozemek;
        }
        public PozemekVM Map(Pozemek pozemek)
        {
            PozemekVM pozemekVM = autoMapper.Map<Pozemek, PozemekVM>(pozemek);
            return pozemekVM;
        }

        //CiselnikTypPozemku
        public CiselnikTypPozemku Map(CiselnikTypPozemkuVM ciselnikTypPozemkuVM)
        {
            CiselnikTypPozemku ciselnikTypPozemku = autoMapper.Map<CiselnikTypPozemkuVM, CiselnikTypPozemku>(ciselnikTypPozemkuVM);
            return ciselnikTypPozemku;
        }
        public CiselnikTypPozemkuVM Map(CiselnikTypPozemku ciselnikTypPozemku)
        {
            CiselnikTypPozemkuVM ciselnikTypPozemkuVM = autoMapper.Map<CiselnikTypPozemku, CiselnikTypPozemkuVM>(ciselnikTypPozemku);
            return ciselnikTypPozemkuVM;
        }

        //CiselnikProdejNeboPronajem
        public CiselnikProdejNeboPronajem Map(CiselnikProdejNeboPronajemVM ciselnikProdejNeboPronajemVM)
        {
            CiselnikProdejNeboPronajem ciselnikProdejNeboPronajem = autoMapper.Map<CiselnikProdejNeboPronajemVM, CiselnikProdejNeboPronajem>(ciselnikProdejNeboPronajemVM);
            return ciselnikProdejNeboPronajem;
        }
        public CiselnikProdejNeboPronajemVM Map(CiselnikProdejNeboPronajem ciselnikProdejNeboPronajem)
        {
            CiselnikProdejNeboPronajemVM ciselnikProdejNeboPronajemVM = autoMapper.Map<CiselnikProdejNeboPronajem, CiselnikProdejNeboPronajemVM>(ciselnikProdejNeboPronajem);
            return ciselnikProdejNeboPronajemVM;
        }

        //ListCiselnikTypPozemku
        public List<CiselnikTypPozemkuVM> Map(List<CiselnikTypPozemku> ciselnikTypPozemkuList)
        {
            List<CiselnikTypPozemkuVM> ciselnikTypPozemkuVMList = autoMapper.Map<List<CiselnikTypPozemku>, List<CiselnikTypPozemkuVM>>(ciselnikTypPozemkuList);
            return ciselnikTypPozemkuVMList;
        }
        public List<CiselnikTypPozemku> Map(List<CiselnikTypPozemkuVM> ciselnikTypPozemkuListVM)
        {
            List<CiselnikTypPozemku> ciselnikTypPozemkuVMList = autoMapper.Map<List<CiselnikTypPozemkuVM>, List<CiselnikTypPozemku>>(ciselnikTypPozemkuListVM);
            return ciselnikTypPozemkuVMList;
        }
    }
}
