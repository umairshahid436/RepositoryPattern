using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TariffComparison.Infrastructure.DI
{
    public static class Extensions
    {
        public static void ConfigureDatabaseDefaults(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            RepositoryModule.ConfigureDatabaseDefaults(app, serviceProvider);
        }
        public static void RegisterDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            ComponentModule.Configure(services);
            RepositoryModule.Configure(services, configuration);
            ServiceModule.Configure(services);
        }
    }
}
