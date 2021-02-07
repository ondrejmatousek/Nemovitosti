using AutoMapper;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.Web.Models;
using Nemovitosti.Web.Models.Account;
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
                cfg.CreateMap<Uzivatel, UzivatelVM>();
                cfg.CreateMap<UzivatelVM, Uzivatel>();
                cfg.CreateMap<PozemekVM, Pozemek>()
                .ForMember(dest => dest.CiselnikTypPozemku, opt => opt.MapFrom(src => src.CiselnikTypPozemkuVM))
                .ForMember(dest => dest.CiselnikProdejNeboPronajem, opt => opt.MapFrom(src => src.CiselnikProdejNeboPronajemVM));
                cfg.CreateMap<Pozemek, PozemekVM>()
                .ForMember(dest => dest.CiselnikTypPozemkuVM, opt => opt.MapFrom(src => src.CiselnikTypPozemku))
                .ForMember(dest => dest.CiselnikProdejNeboPronajemVM, opt => opt.MapFrom(src => src.CiselnikProdejNeboPronajem));
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

        public Uzivatel Map(UzivatelVM uzivatelVM)
        {
            Uzivatel uzivatel = autoMapper.Map<UzivatelVM, Uzivatel>(uzivatelVM);
            return uzivatel;
        }
        public UzivatelVM Map(Uzivatel uzivatel)
        {
            UzivatelVM uzivatelVM = autoMapper.Map<Uzivatel, UzivatelVM>(uzivatel);
            return uzivatelVM;
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
            List<CiselnikTypPozemku> ciselnikTypPozemkuList = autoMapper.Map<List<CiselnikTypPozemkuVM>, List<CiselnikTypPozemku>>(ciselnikTypPozemkuListVM);
            return ciselnikTypPozemkuList;
        }

        //ListCiselnikProdejNeboPronajem
        public List<CiselnikProdejNeboPronajemVM> Map(List<CiselnikProdejNeboPronajem> ciselnikProdejNeboPronajemList)
        {
            List<CiselnikProdejNeboPronajemVM> ciselnikProdejNeboPronajemVMList = autoMapper.Map<List<CiselnikProdejNeboPronajem>, List<CiselnikProdejNeboPronajemVM>>(ciselnikProdejNeboPronajemList);
            return ciselnikProdejNeboPronajemVMList;
        }
        public List<CiselnikProdejNeboPronajem> Map(List<CiselnikProdejNeboPronajemVM> ciselnikProdejNeboPronajemVMList)
        {
            List<CiselnikProdejNeboPronajem> ciselnikProdejNeboPronajemList = autoMapper.Map<List<CiselnikProdejNeboPronajemVM>, List<CiselnikProdejNeboPronajem>>(ciselnikProdejNeboPronajemVMList);
            return ciselnikProdejNeboPronajemList;
        }
    }
}
