using AutoMapper;
using Plantil.API.Models;
using Plantil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Plantil.API.Profiles
{
    public class PlantsProfile : Profile
    {
        public PlantsProfile()
        {
            CreateMap<Plant, PlantDto>()
                .ForMember(
                    dest => dest.Classification,
                    opt => opt.MapFrom(src => $"{src.Genus},{src.Family}")
                )
                .ForMember(
                    dest => dest.DaysFromPlanting,
                    opt => opt.MapFrom(src => src.PlantingDate.GetGapDays())
                );
        }
    }
}
