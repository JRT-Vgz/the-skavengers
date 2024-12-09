
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateConfiguredResources
    {
        private readonly IRepository<Product> _productsRepository;
        public UpdateConfiguredResources(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task ExecuteAsync(Product product, int newConfiguredResources)
        {
            product.Resources = newConfiguredResources;
            await _productsRepository.UpdateAsync(product);

            await _productsRepository.SaveChanges();
        }
    }
}
