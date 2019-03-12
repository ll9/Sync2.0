using AutoMapper;
using Sync2._0.DTOs;
using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.AutoMapper.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DynamicEntity, DynamicEntityDTO>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectTable.ProjectId))
                .ReverseMap();

            CreateMap<SchemaDefinition, SchemaDefinitionDTO>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectTable.ProjectId))
                .ReverseMap();
        }
    }
}
