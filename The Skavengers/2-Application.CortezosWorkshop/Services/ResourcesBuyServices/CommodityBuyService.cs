using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _2_Application.TheSkavengers.Services;

namespace _2_Application.CortezosWorkshop.Services.ResourcesBuyServices
{
    public class CommodityBuyService<TViewModel>
    {
        private readonly ConstantsConfigurationService _configuration;
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IPresenter<BuyResourceEntity, TViewModel> _presenter;
        public CommodityBuyService(ConstantsConfigurationService configuration,
            IRepository<GenericProduct> genericProductsRepository,
            IPresenter<BuyResourceEntity, TViewModel> presenter)
        {
            _configuration = configuration;
            _genericProductsRepository = genericProductsRepository;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(IngotResource ingotResource, int buyPrice)
        {
            var resourceQuantity = 2500;

            var fullPlateGenericProduct = await _genericProductsRepository.
                GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_FULL_PLATE"]);
            var fullPlateResourceCost = fullPlateGenericProduct.Resources;

            var fullPlateSellPrice = ingotResource.FullPlatePrice;

            var toolGenericProduct = await _genericProductsRepository
                .GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_TOOLS"]);
            var toolResourceCost = toolGenericProduct.Resources;

            var toolSellPrice = ingotResource.ToolPrice;

            var lockpicksGenericProduct = await _genericProductsRepository
                .GetByNameAsync(_configuration.Configuration["Constants:_GENERICPROD_LOCKPICKS"]);
            var lockpicksResourceCost = lockpicksGenericProduct.Resources;

            var lockpicksSellPrice = ingotResource.LockpicksPrice;

            var buyResourceEntity = new BuyResourceEntity(buyPrice, resourceQuantity, fullPlateResourceCost, fullPlateSellPrice,
                toolResourceCost, toolSellPrice, lockpicksResourceCost, lockpicksSellPrice);

            return _presenter.Present(buyResourceEntity);
        }
    }
}
