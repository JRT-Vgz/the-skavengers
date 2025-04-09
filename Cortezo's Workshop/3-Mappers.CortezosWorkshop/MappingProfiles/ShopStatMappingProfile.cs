using _1_Domain.CortezosWorkshop.Entities;
using _3_Data.CortezosWorkshop.Models;
using AutoMapper;

namespace _3_Mappers.CortezosWorkshop.MappingProfiles
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
