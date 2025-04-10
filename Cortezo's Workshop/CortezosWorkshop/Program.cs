using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.Armory.Services.AutoEquipServices;
using _2_Application.CortezosWorkshop.Services.GenericProductServices;
using _2_Application.CortezosWorkshop.Services.OreMapServices;
using _2_Application.CortezosWorkshop.Services.ProductServices;
using _2_Application.CortezosWorkshop.Services.ResourcesBuyServices;
using _2_Application.CortezosWorkshop.Services.ShopStatServices;
using _2_Application.CortezosWorkshop.Services.StatisticsServices;
using _2_Application.TheSkavengers.Services;
using _3___Repository;
using _3_Data.CortezosWorkshop;
using _3_Data.CortezosWorkshop.Models;
using _3_Encrypters.TheSkavengers;
using _3_Loggers;
using _3_Mappers.Armory.Dtos;
using _3_Mappers.CortezosWorkshop.ManualMappers;
using _3_Mappers.CortezosWorkshop.MappingProfiles;
using _3_Presenters.Armory.Presenters;
using _3_Presenters.CortezosWorkshop.Presenters;
using _3_Presenters.CortezosWorkshop.ViewModels;
using _3_Repository.CortezosWorkshop.QueryObjects;
using _3_SoundSystem;
using TheSkavengers.Configuracion;
using TheSkavengers.Estadisticas;
using TheSkavengers.Maps;
using TheSkavengers.Precios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Forms.Armory.Forms;

namespace TheSkavengers
{
    internal static class Program
    {
        public const string DATABASE_SETTINGS_DIR = @"Resources\AppSettings\";
        public const string DATABASE_JSON_FILE = "appsettings.dev.json";

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<FormTheSkavengersMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var DbSettingsFullPath = DATABASE_SETTINGS_DIR + DATABASE_JSON_FILE;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(DbSettingsFullPath, optional: false, reloadOnChange: true)
                .Build();

            // INYECCION DE DEPENDENCIAS.          
            //ENTITY FRAMEWORK
            string connectionString = DBEncrypter.Decrypt(configuration.GetConnectionString("DB"));
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // REPOSITORIOS
            services.AddTransient<IRepository<ShopStat>, ShopStatsRepository>();
            services.AddTransient<IRepository<GenericProduct>, GenericProductsRepository>();
            services.AddTransient<IRepository<IngotResource>, IngotResourcesRepository>();

            // UNIT OF WORK
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // QUERY OBJECTS
            services.AddTransient<LogQuery>();

            // PRESENTERS
            services.AddTransient<IPresenter<ShopStat, FundsViewModel>, FundsPresenter>();
            services.AddTransient<IPresenter<Statistics, StatisticsViewModel>, StatisticsPresenter>();
            services.AddTransient<IPresenter<BuyResourceEntity, BuyResourceViewModel>, BuyResourcePresenter>();
            services.AddTransient<IPresenter<PlayerArmoryDataDto, string>, PlayerArmoryDataPresenter>();

            // MANUAL MAPPERS
            services.AddTransient<IManualMapper<GenericProductModel, GenericProduct>, GenericProductModelToGenericProduct>();

            // MAPPERS
            services.AddAutoMapper(typeof(ShopStatMappingProfile));

            // LOGGERS
            services.AddTransient<ILogger, Logger>();

            // SOUND SYSTEM
            services.AddTransient<ISoundSystem, SoundSystem>();

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
            services.AddTransient<CreateAutoEquipScriptTemplateService<PlayerArmoryDataDto>>();

            // INYECCIÓN DE FORMULARIOS
            services.AddTransient<FormTheSkavengersMain>();
            services.AddTransient<FormMain>();
            services.AddTransient<FormMapsMain>();
            services.AddTransient<FormPreciosMain>();
            services.AddTransient<FormConfigMain>();
            services.AddTransient<FormMainEditFunds>();
            services.AddTransient<FormMainBeneficio>();
            services.AddTransient<FormEstadisticasMain>();
            services.AddTransient<FormLog>();
            services.AddTransient<FormAutoEquipTemplate>();
        }

    }
}