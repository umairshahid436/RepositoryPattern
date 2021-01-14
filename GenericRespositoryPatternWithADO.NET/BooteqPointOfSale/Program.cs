using BooteqPointOfSale.Business.Interfaces;
using BooteqPointOfSale.Business.Services;
using BooteqPointOfSale.Data;
using BooteqPointOfSale.Data.Interfaces;
using BooteqPointOfSale.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace BooteqPointOfSale
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<Form1>();
                 services.AddScoped<IWorkerService, WorkerService>();
                 services.AddScoped<IWorkerTypeService, WorkerTypeService>();
                 services.AddScoped<IWorkerRespository, WorkerRespository>();
                 services.AddScoped<IWorkerTypeRespository, WorkerTypeRepository>();

             });
            var host = builder.Build();
            using (var service = host.Services.CreateScope())
            {
                var services = service.ServiceProvider;
                try
                {

                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var form = services.GetRequiredService<Form1>();
                    Application.Run(form);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}
