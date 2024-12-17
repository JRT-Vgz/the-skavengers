
using _1___Entities;
using _2___Servicios.Exceptions;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ShopStatServices
{
    public class SumToBeneficioService
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly ConfigurationService _configurationService;
        private readonly ILogger _logger;

        private string _logEntry;

        public SumToBeneficioService(IRepository<ShopStat> shopStatsRepository,
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

            if (quantity > shopStatCajaFuerte.Quantity) { throw new NotEnoughFundsException(); }

            var shopStatBeneficio = await _shopStatsRepository.GetByNameAsync(
                _configurationService.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);

            shopStatBeneficio.Quantity += quantity;
            await _shopStatsRepository.UpdateAsync(shopStatBeneficio);

            shopStatCajaFuerte.Quantity -= quantity;
            await _shopStatsRepository.UpdateAsync(shopStatCajaFuerte);

            await _shopStatsRepository.SaveChanges();

            _logEntry = $"Retirado {FormatQuantity(quantity)} de oro de la caja fuerte como beneficio.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
