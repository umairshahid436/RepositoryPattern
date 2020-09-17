using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Data.Interface;
using TariffComparison.Data.Repository;

namespace TariffComparison.Infrastructure.DI
{
    public static class RepositoryModule
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("MySqlConnection"),
                    sqlServerOptionsAction => sqlServerOptionsAction.MigrationsAssembly("TariffComparison.Data")
                    ));

            services.AddScoped<IRepositoryContext, RepositoryContext>();
            services.AddScoped<IUnitOfWork>(unitOfWork => new UnitOfWork(unitOfWork.GetService<IRepositoryContext>()));
            services.AddTransient<IProductRepository, ProductRespository>();


        }
        public static void ConfigureDatabaseDefaults(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

        }
    }
}
