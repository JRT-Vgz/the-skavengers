
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ShopStatServices
{
    public class SumToCajaFuerteService
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly ConfigurationService _configurationService;
        private readonly ILogger _logger;

        private string _logEntry;

        public SumToCajaFuerteService(IRepository<ShopStat> shopStatsRepository, 
            ConfigurationService configurationService,
            ILogger logger)
        {
            _shopStatsRepository = shopStatsRepository;
            _configurationService = configurationService;
            _logger = logger;
        }

        public async Task ExecuteAsync(int quantity)
        {
            var shopStatCajaFuerte = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);

            shopStatCajaFuerte.Quantity += quantity;

            await _shopStatsRepository.UpdateAsync(shopStatCajaFuerte);

            if (quantity > 0)
            {
                var shopStatOroTotal = await _shopStatsRepository.GetByNameAsync(
                    _configurationService.Configuration["Constants:_SHOPSTAT_ORO_TOTAL"]);

                shopStatOroTotal.Quantity += quantity;

                await _shopStatsRepository.UpdateAsync(shopStatOroTotal);

                _logEntry = $"Añadido {FormatQuantity(quantity)} de oro a la caja fuerte.";
            }
            else if (quantity < 0)
            {
                var shopStatOroGastado = await _shopStatsRepository.GetByNameAsync(
                    _configurationService.Configuration["Constants:_SHOPSTAT_ORO_GASTADO"]);

                shopStatOroGastado.Quantity -= quantity;

                await _shopStatsRepository.UpdateAsync(shopStatOroGastado);

                _logEntry = $"Gastados {FormatQuantity(Math.Abs(quantity))} de oro de la caja fuerte en recursos.";
            }

            await _shopStatsRepository.SaveChanges();

            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
