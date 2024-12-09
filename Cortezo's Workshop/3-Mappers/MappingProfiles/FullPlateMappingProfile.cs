
using _1___Entities.ProductEntities;
using _3___Data.Models.ProductModels;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class FullPlateMappingProfile : Profile
    {
        public FullPlateMappingProfile() 
        {
            CreateMap<FullPlate, FullPlateModel>();
            CreateMap<FullPlateModel, FullPlate>();
        }
    }
}
