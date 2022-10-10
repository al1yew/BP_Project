using AutoMapper;
using BP.Core.Entities;
using BP.Service.DTOs.WeightDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeightPostDTO, Weight>();
        }
    }
}
