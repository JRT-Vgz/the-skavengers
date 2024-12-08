
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class ShopStatMappingProfile : Profile
    {
        public ShopStatMappingProfile() 
        {
            CreateMap<ShopStatsModel, ShopStat>();
            CreateMap<ShopStat, ShopStatsModel>();
        }
    }
}
