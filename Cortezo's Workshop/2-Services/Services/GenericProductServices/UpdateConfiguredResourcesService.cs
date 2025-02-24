
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
            decimal actualCostPerItem = CalculateCostPerItem(product.QuantityCrafted, product.MaterialUsed);
            decimal costPerItemAdded = CalculateCostPerItem(quantityCrafted, materialUsed);

            product.QuantityCrafted += quantityCrafted;
            product.MaterialUsed += materialUsed;
            await _genericProductsRepository.UpdateAsync(product);
            await _genericProductsRepository.SaveChangesAsync();

            _soundSystem.PlaySound(craftSoundFile);
                      
            _logEntry = $"Fabricación de {quantityCrafted} {product.Name} usando {materialUsed} {product.MaterialName}.";
            _logEntry = _logger.GenerateLogWarning(_logEntry, actualCostPerItem, costPerItemAdded);

            await _logger.WriteLogEntryAsync(_logEntry);
        }

        private decimal CalculateCostPerItem(decimal quantityCrafted, decimal materialUsed)
            => Math.Round(materialUsed / quantityCrafted, 2);
    }
}
