using AutoMapper;

namespace TariffComparison.Business.Service.Mapping
{
    public class ModelMapper
    {
        private readonly IMapper mapper;
        public ModelMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Product, Data.Model.Product>();
                cfg.CreateMap<Data.Model.Product, Model.Product>();
            });

        }
    }
}
