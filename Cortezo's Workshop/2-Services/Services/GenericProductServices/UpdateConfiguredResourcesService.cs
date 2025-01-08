
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateConfiguredResourcesService
    {
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly ILogger _logger;
        private readonly ISoundSystem _soundSystem;

        private string _logEntry;
        public UpdateConfiguredResourcesService(IRepository<GenericProduct> genericProductsRepository, 
            ILogger logger,
            ISoundSystem soundSystem)
        {
            _genericProductsRepository = genericProductsRepository;
            _logger = logger;
            _soundSystem = soundSystem;
        }

        public async Task ExecuteAsync(GenericProduct product, int quantityCrafted, int materialUsed, string craftSoundFile)
        {
            product.QuantityCrafted += quantityCrafted;
            product.MaterialUsed += materialUsed;

            await _genericProductsRepository.UpdateAsync(product);

            await _genericProductsRepository.SaveChanges();

            _soundSystem.PlaySound(craftSoundFile);

            _logEntry = $"Fabricación de {quantityCrafted} {product.Name} usando {materialUsed} {product.MaterialName}.";
            await _logger.WriteLogEntryAsync(_logEntry);
        }
    }
}
