
using _1___Entities;
using _2___Servicios.Interfaces;
using _3___Data.Models;

namespace _3_Mappers.ManualMappers
{
    public class GenericProductModelToGenericProduct : IManualMapper<GenericProductModel, GenericProduct>
    {
        public GenericProduct Map(GenericProductModel model)
            => new GenericProduct(model.Id, model.Name, model.IdMaterial, model.QuantityCrafted, model.MaterialUsed, model.Material.Name);
    }
}
