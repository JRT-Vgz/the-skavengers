
using _1___Entities.ProductEntities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ProductServices
{
    public class UpdateFullPlatePriceService
    {
        private readonly IRepository<FullPlate> _fullPlateRepository;
        public UpdateFullPlatePriceService(IRepository<FullPlate> fullPlateRepository)
        {
            _fullPlateRepository = fullPlateRepository;
        }

        public async Task ExecuteAsync(FullPlate fullPlate, int newFullPlatePrice)
        {
            fullPlate.Price = newFullPlatePrice;
            await _fullPlateRepository.UpdateAsync(fullPlate);

            await _fullPlateRepository.SaveChanges();
        }
    }
}
