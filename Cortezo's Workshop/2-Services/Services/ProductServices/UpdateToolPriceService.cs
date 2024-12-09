
using _1___Entities.ProductEntities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateToolPriceService
    {
        private readonly IRepository<Tool> _toolRepository;
        public UpdateToolPriceService(IRepository<Tool> toolRepository)
        {
            _toolRepository = toolRepository;
        }

        public async Task ExecuteAsync(Tool tool, int newToolPrice)
        {
            tool.Price = newToolPrice;
            await _toolRepository.UpdateAsync(tool);

            await _toolRepository.SaveChanges();
        }
    }
}
