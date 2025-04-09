using _1_Domain.CortezosWorkshop.Entities;
using _3_Data.CortezosWorkshop.Models;
using AutoMapper;

namespace _3_Mappers.CortezosWorkshop.MappingProfiles
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
