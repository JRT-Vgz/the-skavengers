
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateToolPriceService
    {
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        public UpdateToolPriceService(IRepository<IngotResource> ingotResourceRepository)
        {
            _ingotResourceRepository = ingotResourceRepository;
        }

        public async Task ExecuteAsync(IngotResource ingotResource, int newToolPrice)
        {
            ingotResource.ToolPrice = newToolPrice;
            await _ingotResourceRepository.UpdateAsync(ingotResource);

            await _ingotResourceRepository.SaveChanges();
        }
    }
}
