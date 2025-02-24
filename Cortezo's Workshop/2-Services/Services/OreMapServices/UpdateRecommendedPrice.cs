
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.OreMapServices
{
    public class UpdateRecommendedPrice
    {
        private readonly IRepository<IngotResource> _ingotResourcesRepository;
        private readonly ILogger _logger;
        private readonly ISoundSystem _soundSystem;

        private string _logEntry;

        public UpdateRecommendedPrice(IRepository<IngotResource> ingotResourcesRepository, 
            ILogger logger,
            ISoundSystem soundSystem)
        {
            _ingotResourcesRepository = ingotResourcesRepository;
            _logger = logger;
            _soundSystem = soundSystem;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, string newRecommendedPrice, string changePriceSoundFile)
        {
            ingotResource.MapRecommendedPrice = newRecommendedPrice;

            await _ingotResourcesRepository.UpdateAsync(ingotResource);
            await _ingotResourcesRepository.SaveChangesAsync();

            _soundSystem.PlaySound(changePriceSoundFile);

            _logEntry = $"{ingotResource.MapName} ahora cuesta {newRecommendedPrice}.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }
    }
}
