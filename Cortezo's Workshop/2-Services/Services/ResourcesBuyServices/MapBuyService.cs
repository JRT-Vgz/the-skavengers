
using _1___Entities;
using _1___Entities.ResourcesBuyEntities;
using _2___Servicios.Interfaces;

namespace _2___Servicios.Services.ResourcesBuyServices
{
    public class MapBuyService<TViewModel>
    {
        private readonly ConfigurationService _configuration;
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IPresenter<BuyResourceEntity, TViewModel> _presenter;
        public MapBuyService(ConfigurationService configuration,
            IRepository<GenericProduct> genericProductsRepository,
            IPresenter<BuyResourceEntity, TViewModel> presenter)
        {
            _configuration = configuration;
            _genericProductsRepository = genericProductsRepository;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(IngotResource ingotResource, int buyPrice)
        {
            var resourceQuantity = (int)Math.Floor((double)ingotResource.MapTotalOre / ingotResource.MapQuantity);

            var fullPlateGenericProduct = await _genericProductsRepository.
                GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_FULL_PLATE"]);
            var fullPlateResourceCost = fullPlateGenericProduct.Resources;

            var fullPlateSellPrice = ingotResource.FullPlatePrice;

            var toolGenericProduct = await _genericProductsRepository
                .GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_TOOLS"]);
            var toolResourceCost = toolGenericProduct.Resources;

            var toolSellPrice = ingotResource.ToolPrice;

            var buyResourceEntity = new BuyResourceEntity(buyPrice, resourceQuantity, fullPlateResourceCost, fullPlateSellPrice,
                toolResourceCost, toolSellPrice);

            return _presenter.Present(buyResourceEntity);
        }
    }
}
