using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TariffComparison.Business.Interface;
using TariffComparison.Business.Service;
using TariffComparison.Infrastructure.Common;

namespace TariffComparison.Infrastructure.DI
{
    public static class ServiceModule
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<BasicConsumptionCalculationService>();
            services.AddScoped<PackagedConsumptionCalculationService>();
            services.AddScoped<Func<CustomEnum.CalculationModel, IConsumptionCalculator>>(serviceProvider => key =>
            {
                return key switch
                {
                    CustomEnum.CalculationModel.Basic => serviceProvider.GetService<BasicConsumptionCalculationService>(),
                    CustomEnum.CalculationModel.Packaged => serviceProvider.GetService<PackagedConsumptionCalculationService>(),
                    _ => throw new KeyNotFoundException(),
                };
            });

        }
    }
}
