
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.OreMapServices
{
    public class UpdateRecommendedPrice
    {
        private readonly IRepository<IngotResource> _ingotResourcesRepository;

        public UpdateRecommendedPrice(IRepository<IngotResource> ingotResourcesRepository)
        {
            _ingotResourcesRepository = ingotResourcesRepository;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, string newRecommendedPrice)
        {
            ingotResource.MapRecommendedPrice = newRecommendedPrice;

            await _ingotResourcesRepository.UpdateAsync(ingotResource);
            await _ingotResourcesRepository.SaveChanges();
        }
    }
}
