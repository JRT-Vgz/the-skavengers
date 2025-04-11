using _1_Domain.CortezosWorkshop.Entities;
using _3_Data.CortezosWorkshop.Models;
using AutoMapper;

namespace _3_Mappers.CortezosWorkshop.MappingProfiles
{
    public class GenericProductMappingProfile : Profile
    {
        public GenericProductMappingProfile() 
        {
            //CreateMap<GenericProductModel, GenericProduct>()
            //    .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Name));

            CreateMap<GenericProduct, GenericProductModel>();
        }
    }
}
