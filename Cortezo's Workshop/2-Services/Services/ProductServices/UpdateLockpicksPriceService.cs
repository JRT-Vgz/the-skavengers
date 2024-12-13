
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateLockpicksPriceService
    {
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        public UpdateLockpicksPriceService(IRepository<IngotResource> ingotResourceRepository)
        {
            _ingotResourceRepository = ingotResourceRepository;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int newLockpicksPrice)
        {
            ingotResource.LockpicksPrice = newLockpicksPrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChanges();
        }
    }
}
