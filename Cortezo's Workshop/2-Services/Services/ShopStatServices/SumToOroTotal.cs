
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ShopStatServices
{
    public class SumToOroTotal
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly ConfigurationService _configurationService;

        public SumToOroTotal(IRepository<ShopStat> shopStatsRepository,
            ConfigurationService configurationService)
        {
            _shopStatsRepository = shopStatsRepository;
            _configurationService = configurationService;
        }

        public async Task ExecuteAsync(int quantity)
        {
            var shopStatOroTotal = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_ORO_TOTAL"]);

            shopStatOroTotal.Quantity += quantity;

            await _shopStatsRepository.UpdateAsync(shopStatOroTotal);
        }
    }
}
