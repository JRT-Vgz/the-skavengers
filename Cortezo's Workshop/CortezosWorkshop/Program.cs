using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data;
using _3___Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CortezosWorkshop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.dev.json", optional: false, reloadOnChange: true)
                .Build();

            // INYECCION DE DEPENDENCIAS.
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB")));

            services.AddTransient<IRepository<OreMap>, OreMapRepository>();


            // INYECCIÓN DE FORMULARIOS.
            services.AddTransient<FormMain>();
        }

    }
}