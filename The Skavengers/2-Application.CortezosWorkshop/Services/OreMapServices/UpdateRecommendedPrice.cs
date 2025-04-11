using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;

namespace _2_Application.CortezosWorkshop.Services.OreMapServices
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
