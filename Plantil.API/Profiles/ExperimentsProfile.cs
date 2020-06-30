using AutoMapper;
using Plantil.Core;
using Plantil.Domain.Entities;

namespace Plantil.API.Profiles
{
    public class ExperimentsProfile : Profile
    {
        public ExperimentsProfile()
        {
            CreateMap<Experiment, ExperimentDto>();
            CreateMap<ExperimentForCreateDto, Experiment>();
            CreateMap<ExperimentForUpdateDto, Experiment>().ReverseMap();
        }
    }
}
