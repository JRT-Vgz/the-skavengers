
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.StatisticsServices
{
    public class CreateStatisticsService<TViewModel>
    {
        private readonly ConfigurationService _configurationService;
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IRepository<IngotResource> _ingotResourcesRepository;
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IPresenter<Statistics, TViewModel> _presenter;

        public CreateStatisticsService(ConfigurationService configurationService,
            IRepository<ShopStat> shopStatsRepository,
            IRepository<IngotResource> ingotResourcesRepository,
            IRepository<GenericProduct> genericProductsRepository,
            IPresenter<Statistics, TViewModel> presenter)
        {
            _configurationService = configurationService;
            _shopStatsRepository = shopStatsRepository;
            _ingotResourcesRepository = ingotResourcesRepository;
            _genericProductsRepository = genericProductsRepository;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync()
        {
            var shopStats = await _shopStatsRepository.GetAllAsync();
            var ingotResources = await _ingotResourcesRepository.GetAllAsync();
            var genericProducts = await _genericProductsRepository.GetAllAsync();

            var oroTotal = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_ORO_TOTAL"]);
            var cajaFuerte = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);
            var beneficio = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);
            var oroGastado = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_ORO_GASTADO"]);
            var armaduraCompleta = genericProducts.FirstOrDefault(g => g.Name == _configurationService.Configuration["Constants:_GENERICPROD_FULL_PLATE"]);
            var herramientas = genericProducts.FirstOrDefault(g => g.Name == _configurationService.Configuration["Constants:_GENERICPROD_TOOLS"]);
            var lockpicks = genericProducts.FirstOrDefault(g => g.Name == _configurationService.Configuration["Constants:_GENERICPROD_LOCKPICKS"]);


            var statistics = new Statistics
            {
                OroTotal = oroTotal.Quantity,
                CajaFuerte = cajaFuerte.Quantity,
                Beneficio = beneficio.Quantity,
                OroGastado = oroGastado.Quantity,
                MapasCompletados = ingotResources.Sum(o => o.MapQuantity),
                RecursosExtraidos = ingotResources.Sum(o => o.MapTotalOre),
                ArmadurasCrafteadas = armaduraCompleta.QuantityCrafted,
                HerramientasCrafteadas = herramientas.QuantityCrafted,
                LockpicksCrafteados = lockpicks.QuantityCrafted
            };

            return _presenter.Present(statistics);
        }
    }
}
