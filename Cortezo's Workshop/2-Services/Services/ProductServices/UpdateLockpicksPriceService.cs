
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
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
            ingotResource.LockpicksPrice = newLockpicksPrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChanges();

            _logEntry = $"Configurados Lockpicks de {ingotResource.ResourceName} a {FormatQuantity(newLockpicksPrice)} gp.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
