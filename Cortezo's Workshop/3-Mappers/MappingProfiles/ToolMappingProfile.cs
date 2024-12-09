
using _1___Entities.ProductEntities;
using _3___Data.Models.ProductModels;
using AutoMapper;

namespace _3_Mappers.MappingProfiles
{
    public class ToolMappingProfile : Profile
    {
        public ToolMappingProfile() 
        {
            CreateMap<Tool, ToolModel>();
            CreateMap<ToolModel, Tool>();
        }
    }
}
