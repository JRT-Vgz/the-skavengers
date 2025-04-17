
using _1_Domain.Armory.Entities;
using _3_Data.Armory.Models;
using _3_Mappers.Armory.Dtos;
using AutoMapper;

namespace _3_Mappers.Armory.MappingProfiles
{
    public class ScriptMappingProfile : Profile
    {
        public ScriptMappingProfile()
        {
            CreateMap<ScriptModel, Script>();
            CreateMap<Script, ScriptModel>();

            CreateMap<ScriptDto, Script>();
        }
    }
}
