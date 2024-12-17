
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.OreMapServices
{
    public class UpdateRecommendedPrice
    {
        private readonly IRepository<IngotResource> _ingotResourcesRepository;
        private readonly ILogger _logger;

        private string _logEntry;

        public UpdateRecommendedPrice(IRepository<IngotResource> ingotResourcesRepository, 
            ILogger logger)
        {
            _ingotResourcesRepository = ingotResourcesRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, string newRecommendedPrice)
        {
            ingotResource.MapRecommendedPrice = newRecommendedPrice;

            await _ingotResourcesRepository.UpdateAsync(ingotResource);
            await _ingotResourcesRepository.SaveChanges();

            _logEntry = $"{ingotResource.MapName} ahora cuesta {newRecommendedPrice}.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }
    }
}
