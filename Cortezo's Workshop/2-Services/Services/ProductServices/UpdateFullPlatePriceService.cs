
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateFullPlatePriceService
    {
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        private readonly ILogger _logger;

        private string _logEntry;

        public UpdateFullPlatePriceService(IRepository<IngotResource> ingotResourceRepository, 
            ILogger logger)
        {
            _ingotResourceRepository = ingotResourceRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int newFullPlatePrice)
        {
            ingotResource.FullPlatePrice = newFullPlatePrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChanges();

            _logEntry = $"Configurada Armadura Completa de {ingotResource.ResourceName} a {FormatQuantity(newFullPlatePrice)} gp.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
