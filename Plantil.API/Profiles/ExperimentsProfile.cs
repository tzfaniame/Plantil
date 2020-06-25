using AutoMapper;
using Plantil.API.Models;
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
            CreateMap<Experiment, ExperimentDto>();
        }
    }
}
