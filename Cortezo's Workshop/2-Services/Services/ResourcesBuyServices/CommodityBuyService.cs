
using _1___Entities.ProductEntities;
using _1___Entities.ResourcesBuyEntities;
using _1___Entities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ResourcesBuyServices
{
    public class CommodityBuyService<TViewModel>
    {
        private readonly ConfigurationService _configuration;
        private readonly IRepository<OreMap> _oreMapsRepository;
        private readonly IRepository<FullPlate> _fullPlatesRepository;
        private readonly IRepository<Tool> _toolsRepository;
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IPresenter<BuyResourceEntity, TViewModel> _presenter;
        public CommodityBuyService(ConfigurationService configuration,
            IRepository<OreMap> oreMapsRepository,
            IRepository<FullPlate> fullPlatesRepository,
            IRepository<Tool> toolsRepository,
            IRepository<GenericProduct> genericProductsRepository,
            IPresenter<BuyResourceEntity, TViewModel> presenter)
        {
            _configuration = configuration;
            _oreMapsRepository = oreMapsRepository;
            _fullPlatesRepository = fullPlatesRepository;
            _toolsRepository = toolsRepository;
            _genericProductsRepository = genericProductsRepository;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(string commodityName, int buyPrice)
        {
            var resourceQuantity = 2500;

            var fullPlateGenericProduct = await _genericProductsRepository.
                GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_FULL_PLATE"]);
            var fullPlateResourceCost = fullPlateGenericProduct.Resources;

            var commodityNameStrip = commodityName.Replace(" Commodity", "");
            var fullPlate = await _fullPlatesRepository.GetByNameAsync(commodityNameStrip);
            var fullPlateSellPrice = fullPlate.Price;

            var toolGenericProduct = await _genericProductsRepository
                .GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_TOOLS"]);
            var toolResourceCost = toolGenericProduct.Resources;

            var tool = await _toolsRepository.GetByNameAsync(commodityNameStrip);
            var toolSellPrice = tool.Price;

            var buyResourceEntity = new BuyResourceEntity(buyPrice, resourceQuantity, fullPlateResourceCost, fullPlateSellPrice,
                toolResourceCost, toolSellPrice);

            return _presenter.Present(buyResourceEntity);
        }
    }
}
