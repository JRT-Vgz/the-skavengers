
using _1___Entities;
using _3___Data.Models;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class IngotMappingProfile : Profile
    {
        public IngotMappingProfile() 
        {
            CreateMap<IngotModel, Ingot>();
        }
    }
}
