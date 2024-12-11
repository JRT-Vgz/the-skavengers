
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class CommodityMapperProfile : Profile
    {
        public CommodityMapperProfile() 
        {
            CreateMap<CommodityModel, Commodity>();
        }
    }
}
