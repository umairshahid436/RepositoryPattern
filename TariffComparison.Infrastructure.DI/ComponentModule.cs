using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TariffComparison.Business.Service.Mapping;

namespace TariffComparison.Infrastructure.DI
{
    public static class ComponentModule
    {
        public static void Configure(IServiceCollection services)
        {
            string directoryName = Directory.GetCurrentDirectory();

            var config = ModelMapper.Configure();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
