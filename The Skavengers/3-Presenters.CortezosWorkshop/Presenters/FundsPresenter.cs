using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _3_Presenters.CortezosWorkshop.ViewModels;

namespace _3_Presenters.CortezosWorkshop.Presenters
{
    public class FundsPresenter : IPresenter<ShopStat, FundsViewModel>
    {
        public FundsViewModel Present(ShopStat shopStat)
            => new FundsViewModel
            {
                Funds = FormatFunds(shopStat.Quantity)
            };

        private static string FormatFunds(int funds)
        {
            return funds.ToString("#,0").Replace(",", ".") + " gp";
        }
    }

}
