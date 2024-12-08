
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ShopStatServices
{
    public class SumToBeneficioService
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly ConfigurationService _configurationService;

        public SumToBeneficioService(IRepository<ShopStat> shopStatsRepository,
            ConfigurationService configurationService)
        {
            _shopStatsRepository = shopStatsRepository;
            _configurationService = configurationService;
        }

        public async Task ExecuteAsync(int quantity)
        {
            var shopStatBeneficio = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);

            shopStatBeneficio.Quantity += quantity;
            await _shopStatsRepository.UpdateAsync(shopStatBeneficio);

            var shopStatOroTotal = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_ORO_TOTAL"]);

            shopStatOroTotal.Quantity += quantity;
            await _shopStatsRepository.UpdateAsync(shopStatOroTotal);

            await _shopStatsRepository.SaveChanges();
        }
    }
}
