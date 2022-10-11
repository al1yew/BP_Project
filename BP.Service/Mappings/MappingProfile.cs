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
            #region Weight

            CreateMap<WeightPostDTO, Weight>()
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<Weight, WeightListDTO>();

            CreateMap<Weight, WeightGetDTO>();

            #endregion
        }
    }
}
