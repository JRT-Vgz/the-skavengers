
using _1___Entities;
using _2___Servicios.Interfaces;
using _3_Presenters.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _3_Presenters.Presenters
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
