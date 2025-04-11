using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _2_Application.TheSkavengers.Services;

namespace _2_Application.CortezosWorkshop.Services.ShopStatServices
{
    public class SumToCajaFuerteService
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly ConstantsConfigurationService _configurationService;
        private readonly ILogger _logger;
        private readonly ISoundSystem _soundSystem;

        private string _logEntry;

        public SumToCajaFuerteService(IRepository<ShopStat> shopStatsRepository, 
            ConstantsConfigurationService configurationService,
            ILogger logger,
            ISoundSystem soundSystem)
        {
            _shopStatsRepository = shopStatsRepository;
            _configurationService = configurationService;
            _logger = logger;
            _soundSystem = soundSystem;
        }

        public async Task ExecuteAsync(int quantity, string goldSoundFile)
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

            await _shopStatsRepository.SaveChangesAsync();

            _soundSystem.PlaySound(goldSoundFile);

            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
