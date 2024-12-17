using _1___Entities;
using _1___Entities.ResourcesBuyEntities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _2___Servicios.Services.OreMapServices;
using _2___Servicios.Services.ProductServices;
using _2___Servicios.Services.ResourcesBuyServices;
using _2___Servicios.Services.ShopStatServices;
using _2___Servicios.Services.StatisticsServices;
using _3___Data;
using _3___Data.Models;
using _3___Repository;
using _3___Repository.QueryObjects;
using _3_Loggers;
using _3_Mappers.MappingProfiles;
using _3_Presenters.Presenters;
using _3_Presenters.ViewModels;
using CortezosWorkshop.Configuracion;
using CortezosWorkshop.Estadisticas;
using CortezosWorkshop.Maps;
using CortezosWorkshop.Precios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CortezosWorkshop
{
    internal static class Program
    {
        public const string DATABASE_JSON_FILE = "appsettings.dev.json";

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
                .AddJsonFile(DATABASE_JSON_FILE, optional: false, reloadOnChange: true)
                .Build();

            // INYECCION DE DEPENDENCIAS.          
            //ENTITY FRAMEWORK
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB")));

            // REPOSITORIOS
            services.AddTransient<IRepository<ShopStat>, ShopStatsRepository>();
            services.AddTransient<IRepository<GenericProduct>, GenericProductsRepository>();
            services.AddTransient<IRepository<IngotResource>, IngotResourcesRepository>();

            // QUERY OBJECTS
            services.AddTransient<LogQuery>();

            // PRESENTERS
            services.AddTransient<IPresenter<ShopStat, FundsViewModel>, FundsPresenter>();
            services.AddTransient<IPresenter<Statistics, StatisticsViewModel>, StatisticsPresenter>();
            services.AddTransient<IPresenter<BuyResourceEntity, BuyResourceViewModel>, BuyResourcePresenter>();

            // MAPPERS
            services.AddAutoMapper(typeof(ShopStatMappingProfile));

            // LOGGERS
            services.AddTransient<ILogger, Logger>();

            // INYECCION DE ARCHIVO DE CONSTANTES
            services.AddSingleton<ConfigurationService>();

            // INYECCIÓN DE SERVICIOS
            services.AddTransient<SumToCajaFuerteService>();
            services.AddTransient<SumToBeneficioService>();
            services.AddTransient<AddCompletedMapData>();
            services.AddTransient<UpdateRecommendedPrice>();
            services.AddTransient<CreateStatisticsService<StatisticsViewModel>>();
            services.AddTransient<GetFundsByNameService<FundsViewModel>>();
            services.AddTransient<UpdateConfiguredResourcesService>();
            services.AddTransient<UpdateFullPlatePriceService>();
            services.AddTransient<UpdateToolPriceService>();
            services.AddTransient<UpdateLockpicksPriceService>();
            services.AddTransient<MapBuyService<BuyResourceViewModel>>();
            services.AddTransient<CommodityBuyService<BuyResourceViewModel>>();
            services.AddTransient<IngotBuyService<BuyResourceViewModel>>();

            // INYECCIÓN DE FORMULARIOS
            services.AddTransient<FormMain>();
            services.AddTransient<FormMapsMain>();
            services.AddTransient<FormPreciosMain>();
            services.AddTransient<FormConfigMain>();
            services.AddTransient<FormMainEditFunds>();
            services.AddTransient<FormMainBeneficio>();
            services.AddTransient<FormEstadisticasMain>();
            services.AddTransient<FormLog>();
        }

    }
}