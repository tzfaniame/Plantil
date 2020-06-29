using AutoMapper;
using Plantil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API.Profiles
{
    public class ExperimentsProfile : Profile
    {
        public ExperimentsProfile()
        {
            CreateMap<Entities.Experiment, ExperimentDto>();
            CreateMap<ExperimentForCreateDto, Entities.Experiment>();
        }
    }
}
