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
            services.AddScoped<IComparisonService, ComparisonService>();
            services.AddScoped<BasicAnnualCostCalculationService>();
            services.AddScoped<PackagedAnnualCostCalculationService>();
            services.AddScoped<Func<CustomEnum.CalculationModel, IAnnualCostCalculator>>(serviceProvider => key =>
            {
                return key switch
                {
                    CustomEnum.CalculationModel.Basic => serviceProvider.GetService<BasicAnnualCostCalculationService>(),
                    CustomEnum.CalculationModel.Packaged => serviceProvider.GetService<PackagedAnnualCostCalculationService>(),
                    _ => throw new KeyNotFoundException(),
                };
            });

        }
    }
}
