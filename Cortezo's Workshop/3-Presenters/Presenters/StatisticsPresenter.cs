
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
                MapasCompletados = $"- Mapas completados:     {FormatQuantity(statistics.MapasCompletados)}",
                RecursosExtraidos = $"- Total de recursos extraídos:     {FormatQuantity(statistics.RecursosExtraidos)}",
                ArmadurasCrafteadas = $"- Datos de Armaduras completas:     {FormatQuantity(statistics.ArmadurasCrafteadas)}",
                HerramientasCrafteadas = $"- Datos de Herramientas:     {FormatQuantity(statistics.HerramientasCrafteadas)}",
                LockpicksCrafteados = $"- Datos de Lockpicks:     {FormatQuantity(statistics.LockpicksCrafteados)}"
            };

        private static string FormatQuantity(int quantity)
        {
            return quantity.ToString("#,0").Replace(",", ".");
        }
    }
}
