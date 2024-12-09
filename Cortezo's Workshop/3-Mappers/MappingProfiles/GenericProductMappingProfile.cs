
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class GenericProductMappingProfile : Profile
    {
        public GenericProductMappingProfile() 
        {
            CreateMap<GenericProductModel, GenericProduct>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Name));

            CreateMap<GenericProduct, GenericProductModel>();
        }
    }
}
