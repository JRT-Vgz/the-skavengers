namespace _1_Domain.CortezosWorkshop.Entities
{
    public class GenericProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdMaterial { get; set; }
        public int QuantityCrafted { get; set; }
        public int MaterialUsed { get; set; }
        public int Resources { get; set; }
        public string MaterialName { get; set; }

        public GenericProduct(int id, string name, int idMaterial, int quantityCrafted, int materialUsed, string materialName)
        {
            Id = id;
            Name = name;
            IdMaterial = idMaterial;
            QuantityCrafted = quantityCrafted;
            MaterialUsed = materialUsed;
            Resources = CalculateCostPerItem();
            MaterialName = materialName;
        }

        private int CalculateCostPerItem()
        {
            if (QuantityCrafted > 0 && MaterialUsed > 0) { return (MaterialUsed + QuantityCrafted - 1) / QuantityCrafted; }
            return 0;
        }
    }
}
