
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class IronResourceMappingProfile : Profile
    {
        public IronResourceMappingProfile()
        {
            CreateMap<IngotResource, IngotResourceModel>();
            CreateMap<IngotResourceModel, IngotResource>()
                .ForMember(dest => dest.MaterialType, opt => opt.MapFrom(src => src.Material.Name));            
        }
    }
}
