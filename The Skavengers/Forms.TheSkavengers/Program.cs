using _1_Domain.Armory.Entities;
using _1_Domain.Armory.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.Armory.Services.Armory_AuthN_Services;
using _2_Application.Armory.Services.AutoEquip_Services;
using _2_Application.Armory.Services.Script_Services;
using _2_Application.CortezosWorkshop.Services.GenericProductServices;
using _2_Application.CortezosWorkshop.Services.OreMapServices;
using _2_Application.CortezosWorkshop.Services.ProductServices;
using _2_Application.CortezosWorkshop.Services.ResourcesBuyServices;
using _2_Application.CortezosWorkshop.Services.ShopStatServices;
using _2_Application.CortezosWorkshop.Services.StatisticsServices;
using _2_Application.TheSkavengers.Services;
using _3___Repository;
using _3_AuthNSystem.Armory;
using _3_Data.Armory;
using _3_Data.CortezosWorkshop;
using _3_Data.CortezosWorkshop.Models;
using _3_Encrypters.TheSkavengers;
using _3_Loggers;
using _3_Mappers.Armory.Dtos;
using _3_Mappers.Armory.MappingProfiles;
using _3_Mappers.CortezosWorkshop.ManualMappers;
using _3_Mappers.CortezosWorkshop.MappingProfiles;
using _3_Presenters.Armory.Presenters;
using _3_Presenters.CortezosWorkshop.Presenters;
using _3_Presenters.CortezosWorkshop.ViewModels;
using _3_Repository.Armory;
using _3_Repository.CortezosWorkshop.QueryObjects;
using _3_SoundSystem;
using _3_Validators.Armory.Entity_Validators;
using _3_Validators.Armory.Form_Validators;
using Forms.Armory.Forms;
using Forms.CortezosWorkshop;
using Forms.CortezosWorkshop.Forms.Configuration;
using Forms.CortezosWorkshop.Forms.Maps;
using Forms.CortezosWorkshop.Forms.Prices;
using Forms.CortezosWorkshop.Forms.Statistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Forms.TheSkavengers
{
    internal static class Program
    {
        public const string DATABASE_NAMESPACE = "Forms.TheSkavengers.Resources.AppSettings";
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
            var configuration = BuildConfiguration();

            // INYECCION DE DEPENDENCIAS.          
            // ENTITY FRAMEWORK
            string connectionString = DBEncrypter.Decrypt(configuration.GetConnectionString("DB"));
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDbContext<ArmoryDbContext>(options =>
                options.UseSqlServer(connectionString));

            // REPOSITORIOS
            services.AddTransient<IRepository<ShopStat>, ShopStatsRepository>();
            services.AddTransient<IRepository<GenericProduct>, GenericProductsRepository>();
            services.AddTransient<IRepository<IngotResource>, IngotResourcesRepository>();
            services.AddTransient<IArmoryRepository<Script>, ScriptRepository>();

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
            services.AddAutoMapper(
                typeof(ShopStatMappingProfile),
                typeof(ScriptMappingProfile)
                );

            // LOGGERS
            services.AddTransient<ILogger, Logger>();

            // VALIDATORS:
            services.AddTransient<IFormValidator<ScriptDto>, ScriptDtoFormValidator>();
            services.AddTransient<IEntityValidator<Script>, ScriptValidator>();

            // AUTHZ:
            services.AddTransient<IAuthNSystem, ArmoryAuthNSystem>();

            // SOUND SYSTEM
            services.AddTransient<ISoundSystem, SoundSystem>();

            // INYECCION DE ARCHIVO DE CONSTANTES
            services.AddSingleton<ConstantsConfigurationService>();

            // INYECCIÓN DE SERVICIOS
            // Cortezo's Workshop
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
            // Armory
            services.AddTransient<ArmoryAuthNService>();
            services.AddTransient<GetAllScriptsService>();
            services.AddTransient<AddScriptService<ScriptDto>>();
            services.AddTransient<UpdateScriptService<ScriptDto>>();
            services.AddTransient<DeleteScriptService>();
            services.AddTransient<CreateAutoEquipScriptTemplateService<PlayerArmoryDataDto>>();

            // INYECCIÓN DE FORMULARIOS
            services.AddTransient<FormTheSkavengersMain>();
            services.AddTransient<FormTheSkavengersMain>();
            // Cortezo's Workshop
            services.AddTransient<FormCortezosWorkshopMain>();
            services.AddTransient<FormCortezosWorkshopEditFunds>();
            services.AddTransient<FormCortezosWorkshopBenefit>();
            services.AddTransient<FormCortezosWorkshopConfig>();
            services.AddTransient<FormCortezosWorkshopMaps>();
            services.AddTransient<FormCortezosWorkshopPrices>();
            services.AddTransient<FormCortezosWorkShopStatistics>();
            services.AddTransient<FormCortezosWorkshopLog>();
            // Armory
            services.AddTransient<FormArmoryMain>();
            services.AddTransient<FormArmoryNewUpdateScript>();
            services.AddTransient<FormAutoEquipTemplate>();
            services.AddTransient<FormArmoryPasswordInputBox>();
        }

        private static IConfiguration BuildConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Leer el archivo JSON como recurso incrustado
            using (var stream = assembly.GetManifestResourceStream($"{DATABASE_NAMESPACE}.{DATABASE_JSON_FILE}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("El archivo de configuración no se encuentra como recurso incrustado.");
                }

                var configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                return configuration;
            }
        }
    }
}