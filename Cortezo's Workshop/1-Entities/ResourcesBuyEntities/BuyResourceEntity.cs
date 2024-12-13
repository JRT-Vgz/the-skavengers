
namespace _1___Entities.ResourcesBuyEntities
{
    public class BuyResourceEntity
    {
        public int ResourceQuantity { get; set; }
        public int PricePerResource { get; set; }
        public int FullPlateGoldCost { get; set; }
        public int FullPlateSellPrice { get; set; }
        public int ToolGoldCost { get; set; }
        public int ToolSellPrice { get; set; }
        public int LockpicksGoldCost { get; set; }
        public int LockpicksSellPrice { get; set; }
        public double FullPlateBenefit { get; set; }
        public double ToolBenefit { get; set; }
        public double LockpicksBenefit { get; set; }

        public BuyResourceEntity(int buyPrice, int resourceQuantity, 
            int fullPlateResourceCost, int fullPlateSellPrice, 
            int toolResourceCost, int toolSellPrice,
            int lockpicksResourceCost, int lockpicksSellPrice) 
        {
            ResourceQuantity = resourceQuantity;
            PricePerResource = Calculate_PricePerResource(buyPrice);
            FullPlateGoldCost = Calculate_ProductGoldCost(fullPlateResourceCost);
            FullPlateSellPrice = fullPlateSellPrice;
            ToolGoldCost = Calculate_ProductGoldCost(toolResourceCost);
            ToolSellPrice = toolSellPrice;
            LockpicksGoldCost = Calculate_ProductGoldCost(lockpicksResourceCost);
            LockpicksSellPrice = lockpicksSellPrice;
            FullPlateBenefit = Calculate_ProductBenefit(FullPlateGoldCost, FullPlateSellPrice);
            ToolBenefit = Calculate_ProductBenefit(ToolGoldCost, ToolSellPrice);
            LockpicksBenefit = Calculate_ProductBenefit(LockpicksGoldCost, LockpicksSellPrice);
        }
        private int Calculate_PricePerResource(int buyPrice)
        {
            if (ResourceQuantity == 0) { return buyPrice; }
            else { return (int)Math.Ceiling((double)buyPrice / ResourceQuantity); }
        }

        private int Calculate_ProductGoldCost(int resourceCost)
            => PricePerResource * resourceCost;

        private double Calculate_ProductBenefit(double cost, double sellPrice)
        {
            double benefit = ((sellPrice - cost) / cost) * 100;
            return Math.Round(benefit, 2);
        }
    }
}
