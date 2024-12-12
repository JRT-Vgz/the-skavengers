
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateFullPlatePriceService
    {
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        public UpdateFullPlatePriceService(IRepository<IngotResource> ingotResourceRepository)
        {
            _ingotResourceRepository = ingotResourceRepository;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int newFullPlatePrice)
        {
            ingotResource.FullPlatePrice = newFullPlatePrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChanges();
        }
    }
}
