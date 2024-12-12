
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.StatisticsServices
{
    public class CreateStatisticsService<TViewModel>
    {
        private readonly ConfigurationService _configurationService;
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IRepository<IngotResource> _ingotResourcesRepository;
        private readonly IPresenter<Statistics, TViewModel> _presenter;

        public CreateStatisticsService(ConfigurationService configurationService,
            IRepository<ShopStat> shopStatsRepository,
            IRepository<IngotResource> ingotResourcesRepository,
            IPresenter<Statistics, TViewModel> presenter)
        {
            _configurationService = configurationService;
            _shopStatsRepository = shopStatsRepository;
            _ingotResourcesRepository = ingotResourcesRepository;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync()
        {
            var oroTotal = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_ORO_TOTAL"]);
            var cajaFuerte = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);
            var beneficio = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);
            var oroGastado = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_ORO_GASTADO"]);
            var ingotResources = await _ingotResourcesRepository.GetAllAsync();

            var statistics = new Statistics
            {
                OroTotal = oroTotal.Quantity,
                CajaFuerte = cajaFuerte.Quantity,
                Beneficio = beneficio.Quantity,
                OroGastado = oroGastado.Quantity,
                MapasCompletados = ingotResources.Sum(o => o.MapQuantity),
                RecursosExtraidos = ingotResources.Sum(o => o.MapTotalOre)
            };

            return _presenter.Present(statistics);
        }
    }
}
