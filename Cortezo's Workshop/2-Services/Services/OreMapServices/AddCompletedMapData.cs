
using _1___Entities;
using _2___Servicios.Interfaces;
using System.ComponentModel.Design;

namespace _2___Servicios.Services.OreMapServices
{
    public class AddCompletedMapData
    {
        private readonly IRepository<IngotResource> _ingotResourcesRepository;
        private readonly ILogger _logger;
        private readonly ISoundSystem _soundSystem;

        private string _logEntry;

        public AddCompletedMapData(IRepository<IngotResource> ingotResourcesRepository, 
            ILogger logger,
            ISoundSystem soundSystem)
        {
            _ingotResourcesRepository = ingotResourcesRepository;
            _logger = logger;
            _soundSystem = soundSystem;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int mapQuantity, int resourcesQuantity, string addMapSoundFile)
        {
            decimal actualResourcesPerMap = CalculateResourcesPerMap(ingotResource.MapQuantity, ingotResource.MapTotalOre);
            decimal resourcesPerAddedMap = CalculateResourcesPerMap(mapQuantity, resourcesQuantity);

            ingotResource.MapQuantity += mapQuantity;
            ingotResource.MapTotalOre += resourcesQuantity;
            await _ingotResourcesRepository.UpdateAsync(ingotResource);
            await _ingotResourcesRepository.SaveChangesAsync();

            _soundSystem.PlaySound(addMapSoundFile);

            if (mapQuantity == 1) { _logEntry += "Añadido "; } else { _logEntry += "Añadidos "; }
            _logEntry += $"{mapQuantity}x {ingotResource.MapName} con {resourcesQuantity} recursos.";
            _logEntry = _logger.GenerateLogWarning(_logEntry, actualResourcesPerMap, resourcesPerAddedMap);

            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private decimal CalculateResourcesPerMap(decimal mapQuantity, decimal mapTotalOre)
            => Math.Round(mapTotalOre / mapQuantity, 2);
    }
}
