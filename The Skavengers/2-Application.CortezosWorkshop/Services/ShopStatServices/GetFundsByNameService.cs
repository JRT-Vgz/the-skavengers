using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;

namespace _2_Application.CortezosWorkshop.Services.ShopStatServices
{
    public class GetFundsByNameService<TViewModel>
    {
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IPresenter<ShopStat, TViewModel> _presenter;

        public GetFundsByNameService(IRepository<ShopStat> shopStatsRepository, 
            IPresenter<ShopStat, TViewModel> presenter)
        {
            _shopStatsRepository = shopStatsRepository;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(string name)
        {
            var shopStat = await _shopStatsRepository.GetByNameAsync(name);

            return _presenter.Present(shopStat);
        }
    }
}
