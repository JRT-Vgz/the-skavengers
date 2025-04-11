using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _2_Application.CortezosWorkshop.Exceptions;
using _2_Application.TheSkavengers.Services;

namespace _2_Application.CortezosWorkshop.Services.ShopStatServices
{
    public class SumToBeneficioService
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly ConstantsConfigurationService _configurationService;
        private readonly ILogger _logger;
        private readonly ISoundSystem _soundSystem;

        private string _logEntry;

        public SumToBeneficioService(IRepository<ShopStat> shopStatsRepository,
            ConstantsConfigurationService configurationService,
            ILogger logger,
            ISoundSystem soundSystem)
        {
            _shopStatsRepository = shopStatsRepository;
            _configurationService = configurationService;
            _logger = logger;
            _soundSystem = soundSystem;
        }

        public async Task ExecuteAsync(int quantity, string retrieveBenefitsSoundFile)
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

            await _shopStatsRepository.SaveChangesAsync();

            _soundSystem.PlaySound(retrieveBenefitsSoundFile);

            _logEntry = $"Retirado {FormatQuantity(quantity)} de oro como beneficio.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
