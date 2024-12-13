
using _1___Entities.ResourcesBuyEntities;
using _2___Servicios.Interfaces;
using _3_Presenters.ViewModels;

namespace _3_Presenters.Presenters
{
    public class BuyResourcePresenter : IPresenter<BuyResourceEntity, BuyResourceViewModel>
    {
        public BuyResourceViewModel Present(BuyResourceEntity mapBuyEntity)
            => new BuyResourceViewModel
            {
                ResourceQuantity = $"- Cantidad media de lingotes:     {FormatResourceQuantity(mapBuyEntity.ResourceQuantity)}",
                PricePerResource = $"- Precio por lingote:     {FormatQuantity(mapBuyEntity.PricePerResource)} gp",
                FullPlateGoldCost = $"- Coste por armadura:     {FormatQuantity(mapBuyEntity.FullPlateGoldCost)} gp",
                FullPlateSellPrice = $"- Precio venta armadura:     {FormatQuantity(mapBuyEntity.FullPlateSellPrice)} gp",
                ToolGoldCost = $"- Coste por herramienta:     {FormatQuantity(mapBuyEntity.ToolGoldCost)}",
                ToolSellPrice = $"- Precio venta herramienta:     {FormatQuantity(mapBuyEntity.ToolSellPrice)}",
                LockpicksGoldCost = $"- Coste por lockpicks:     {FormatQuantity(mapBuyEntity.LockpicksGoldCost)}",
                LockpicksSellPrice = $"- Precio venta lockpicks:     {FormatQuantity(mapBuyEntity.LockpicksSellPrice)}"
            };

        private string FormatQuantity(int quantity)
        {
            return quantity.ToString("#,0").Replace(",", ".");
        }

        private string FormatResourceQuantity(int resourceQuantity)
        {
            if (resourceQuantity == 0) { return "N/A"; }
            return resourceQuantity.ToString("#,0").Replace(",", ".");
        }
    }
}
