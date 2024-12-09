
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateConfiguredResources
    {
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        public UpdateConfiguredResources(IRepository<GenericProduct> genericProductsRepository)
        {
            _genericProductsRepository = genericProductsRepository;
        }

        public async Task ExecuteAsync(GenericProduct product, int newConfiguredResources)
        {
            product.Resources = newConfiguredResources;
            await _genericProductsRepository.UpdateAsync(product);

            await _genericProductsRepository.SaveChanges();
        }
    }
}
