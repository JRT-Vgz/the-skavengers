
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class OreMapMappingProfile : Profile
    {
        public OreMapMappingProfile()
        {
            CreateMap<OreMapModel, OreMap>();
        }
    }
}
