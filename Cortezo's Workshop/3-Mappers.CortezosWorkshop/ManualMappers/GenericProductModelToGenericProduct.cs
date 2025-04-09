using _1_Domain.TheSkavengers.Interfaces;
using _1_Domain.CortezosWorkshop.Entities;
using _3_Data.CortezosWorkshop.Models;

namespace _3_Mappers.CortezosWorkshop.ManualMappers
{
    public class GenericProductModelToGenericProduct : IManualMapper<GenericProductModel, GenericProduct>
    {
        public GenericProduct Map(GenericProductModel model)
            => new GenericProduct(model.Id, model.Name, model.IdMaterial, model.QuantityCrafted, model.MaterialUsed, model.Material.Name);
    }
}
