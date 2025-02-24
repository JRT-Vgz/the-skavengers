
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateToolPriceService
    {
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        private readonly ILogger _logger;

        private string _logEntry;
        public UpdateToolPriceService(IRepository<IngotResource> ingotResourceRepository, 
            ILogger logger)
        {
            _ingotResourceRepository = ingotResourceRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int newToolPrice)
        {
            var oldPrice = ingotResource.ToolPrice;

            ingotResource.ToolPrice = newToolPrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChangesAsync();

            _logEntry = $"Configuradas Herramientas de {ingotResource.ResourceName}. Antes: {FormatQuantity(oldPrice)} gp.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private string FormatQuantity(int quantity)
            => quantity.ToString("#,0").Replace(",", ".");
    }
}
