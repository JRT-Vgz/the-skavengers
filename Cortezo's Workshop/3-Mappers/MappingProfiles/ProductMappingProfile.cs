
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Name));

            CreateMap<Product, ProductModel>();
        }
    }
}
