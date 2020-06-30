using AutoMapper;
using Plantil.Core;
using Plantil.Domain.Entities;

namespace Plantil.API.Profiles
{
    public class PlantsProfile : Profile
    {
        public PlantsProfile()
        {
            CreateMap<Plant, PlantDto>()
                .ForMember(
                    dest => dest.Classification,
                    opt => opt.MapFrom(src => $"{src.Taxonomy.Genus},{src.Taxonomy.Family}")
                )
                .ForMember(
                    dest => dest.DaysFromPlanting,
                    opt => opt.MapFrom(src => src.PlantingDate.GetGapDays())
                );

            CreateMap<PlantForCreateDto, Plant>();
        }
    }
}
