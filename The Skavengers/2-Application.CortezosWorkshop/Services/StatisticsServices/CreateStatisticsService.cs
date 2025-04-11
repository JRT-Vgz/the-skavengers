using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _2_Application.TheSkavengers.Services;

namespace _2_Application.CortezosWorkshop.Services.StatisticsServices
{
    public class CreateStatisticsService<TViewModel>
    {
        private readonly ConstantsConfigurationService _configurationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPresenter<Statistics, TViewModel> _presenter;

        public CreateStatisticsService(ConstantsConfigurationService configurationService,
            IUnitOfWork unitOfWork,
            IPresenter<Statistics, TViewModel> presenter)
        {
            _configurationService = configurationService;
            _unitOfWork = unitOfWork;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync()
        {
            var shopStats = await _unitOfWork.ShopStats.GetAllAsync();
            var ingotResources = await _unitOfWork.IngotResources.GetAllAsync();
            var genericProducts = await _unitOfWork.GenericProducts.GetAllAsync();

            var oroTotal = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_ORO_TOTAL"]);
            var cajaFuerte = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);
            var beneficio = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);
            var oroGastado = shopStats.FirstOrDefault(s => s.Name == _configurationService.Configuration["Constants:_SHOPSTAT_ORO_GASTADO"]);
            var armaduraCompleta = genericProducts.FirstOrDefault(g => g.Name == _configurationService.Configuration["Constants:_GENERICPROD_FULL_PLATE"]);
            var herramientas = genericProducts.FirstOrDefault(g => g.Name == _configurationService.Configuration["Constants:_GENERICPROD_TOOLS"]);
            var lockpicks = genericProducts.FirstOrDefault(g => g.Name == _configurationService.Configuration["Constants:_GENERICPROD_LOCKPICKS"]);


            var statistics = new Statistics
            {
                OroTotal = oroTotal.Quantity,
                CajaFuerte = cajaFuerte.Quantity,
                Beneficio = beneficio.Quantity,
                OroGastado = oroGastado.Quantity,
                MapasCompletados = ingotResources.Sum(o => o.MapQuantity),
                RecursosExtraidos = ingotResources.Sum(o => o.MapTotalOre),
                ArmadurasCrafteadas = armaduraCompleta.QuantityCrafted,
                HerramientasCrafteadas = herramientas.QuantityCrafted,
                LockpicksCrafteados = lockpicks.QuantityCrafted
            };

            return _presenter.Present(statistics);
        }
    }
}
