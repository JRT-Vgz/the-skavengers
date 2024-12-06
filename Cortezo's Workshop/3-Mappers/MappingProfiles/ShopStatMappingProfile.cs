
using _1___Entities;
using _3_Mappers.Dtos.ShopStatDtos;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class ShopStatMappingProfile : Profile
    {
        public ShopStatMappingProfile() 
        {
            CreateMap<ShopStatUpdateDto, ShopStat>();
        }
    }
}
