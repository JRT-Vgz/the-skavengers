
using _1___Entities;
using _2___Servicios.Exceptions;
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
            var shopStatCajaFuerte = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);

            if (quantity > shopStatCajaFuerte.Quantity) { throw new NotEnoughFundsException(); }

            var shopStatBeneficio = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);

            shopStatBeneficio.Quantity += quantity;
            await _shopStatsRepository.UpdateAsync(shopStatBeneficio);

            shopStatCajaFuerte.Quantity -= quantity;
            await _shopStatsRepository.UpdateAsync(shopStatCajaFuerte);

            await _shopStatsRepository.SaveChanges();
        }
    }
}
