
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.OreMapServices
{
    public class UpdateRecommendedPrice
    {
        private readonly IRepository<OreMap> _oreMapRepository;

        public UpdateRecommendedPrice(IRepository<OreMap> oreMapRepository)
        {
            _oreMapRepository = oreMapRepository;
        }

        public async Task ExecuteAsync(OreMap oreMap, string newRecommendedPrice)
        {
            oreMap.RecommendedPrice = newRecommendedPrice;
            await _oreMapRepository.UpdateAsync(oreMap);

            await _oreMapRepository.SaveChanges();
        }
    }
}
