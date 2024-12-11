
namespace _1___Entities.ResourcesBuyEntities
{
    public class BuyResourceEntity
    {
        public int BuyPrice { get; set; }
        public int ResourceQuantity { get; set; }
        public int PricePerResource { get; set; }
        public int FullPlateResourceCost { get; set; }
        public int FullPlateGoldCost { get; set; }
        public int FullPlateSellPrice { get; set; }
        public int ToolResourceCost { get; set; }
        public int ToolGoldCost { get; set; }
        public int ToolSellPrice { get; set; }

        public BuyResourceEntity(int buyPrice, int resourceQuantity, 
            int fullPlateResourceCost, int fullPlateSellPrice, 
            int toolResourceCost, int toolSellPrice) 
        {
            BuyPrice = buyPrice;
            ResourceQuantity = resourceQuantity;
            PricePerResource = Calculate_PricePerResource();
            FullPlateResourceCost = fullPlateResourceCost;
            FullPlateGoldCost = Calculate_FullPlateGoldCost();
            FullPlateSellPrice = fullPlateSellPrice;
            ToolResourceCost = toolResourceCost;
            ToolGoldCost = Calculate_ToolGoldCost();
            ToolSellPrice = toolSellPrice;
        }
        private int Calculate_PricePerResource()
        {
            if (ResourceQuantity == 0) { return BuyPrice; }
            else { return (int)Math.Ceiling((double)BuyPrice / ResourceQuantity); }
        }

        private int Calculate_FullPlateGoldCost()
            => PricePerResource * FullPlateResourceCost;

        private int Calculate_ToolGoldCost()
            => PricePerResource * ToolResourceCost;
    }
}
