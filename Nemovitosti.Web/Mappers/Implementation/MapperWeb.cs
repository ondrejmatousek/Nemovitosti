using AutoMapper;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Web.Models;

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

            });
            this.autoMapper = config.CreateMapper();
        }

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


    }
}
