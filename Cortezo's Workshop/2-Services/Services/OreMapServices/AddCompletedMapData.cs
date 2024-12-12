
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.OreMapServices
{
    public class AddCompletedMapData
    {
        private readonly IRepository<IngotResource> _ingotResourcesRepository;

        public AddCompletedMapData(IRepository<IngotResource> ingotResourcesRepository)
        {
            _ingotResourcesRepository = ingotResourcesRepository;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int mapQuantity, int resourcesQuantity)
        {
            ingotResource.MapQuantity += mapQuantity;
            ingotResource.MapTotalOre += resourcesQuantity;

            await _ingotResourcesRepository.UpdateAsync(ingotResource);
            await _ingotResourcesRepository.SaveChanges();
        }
    }
}
