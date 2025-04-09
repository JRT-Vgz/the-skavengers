using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;

namespace _2_Application.CortezosWorkshop.Services.ProductServices
{
    public class UpdateLockpicksPriceService
    {
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        private readonly ILogger _logger;

        private string _logEntry;
        public UpdateLockpicksPriceService(IRepository<IngotResource> ingotResourceRepository,
            ILogger logger)
        {
            _ingotResourceRepository = ingotResourceRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int newLockpicksPrice)
        {
            var oldPrice = ingotResource.LockpicksPrice;

            ingotResource.LockpicksPrice = newLockpicksPrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChangesAsync();

            _logEntry = $"Configurados Lockpicks de {ingotResource.ResourceName}. Antes: {FormatQuantity(oldPrice)} gp.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
