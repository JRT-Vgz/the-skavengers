
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.OreMapServices
{
    public class AddCompletedMapData
    {
        private readonly IRepository<OreMap> _oreMapsRepository;

        public AddCompletedMapData(IRepository<OreMap> oreMapsRepository)
        {
            _oreMapsRepository = oreMapsRepository;
        }

        public async Task ExecuteAsync(string oreMapName, int mapQuantity, int resourcesQuantity)
        {
            var oreMap = await _oreMapsRepository.GetByNameAsync(oreMapName);
            oreMap.Quantity += mapQuantity;
            oreMap.TotalOre += resourcesQuantity;

            await _oreMapsRepository.UpdateAsync(oreMap);

            await _oreMapsRepository.SaveChanges();
        }
    }
}
