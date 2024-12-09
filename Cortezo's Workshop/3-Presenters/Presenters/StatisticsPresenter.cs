
using _1___Entities;
using _2___Servicios.Interfaces;
using _3_Presenters.ViewModels;

namespace _3_Presenters.Presenters
{
    public class StatisticsPresenter : IPresenter<Statistics, StatisticsViewModel>
    {
        public StatisticsViewModel Present(Statistics statistics)
            => new StatisticsViewModel
            {
                OroTotal = $"- Oro total vendido en la tienda:     {FormatQuantity(statistics.OroTotal)} gp",
                CajaFuerte = $"- Fondos almacenados en la caja fuerte:     {FormatQuantity(statistics.CajaFuerte)} gp",
                Beneficio = $"- Beneficio retirado para nuestro disfrute:     {FormatQuantity(statistics.Beneficio)} gp",
                OroGastado = $"- Oro gastado en comprar mapas y materiales:     {FormatQuantity(statistics.OroGastado)} gp",
                MapasCompletados = $"- Mapas completdos: {FormatQuantity(statistics.MapasCompletados)}",
                RecursosExtraidos = $"- Total de recursos extra�dos: {FormatQuantity(statistics.RecursosExtraidos)}"
            };

        private static string FormatQuantity(int quantity)
        {
            return quantity.ToString("#,0").Replace(",", ".");
        }
    }
}
