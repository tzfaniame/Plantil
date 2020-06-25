using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plantil.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API.Controllers
{
    [ApiController]
    [Route("api/plants/{plantId}/experiments")]
    public class ExperimentsController : ControllerBase
    {
        private readonly IExperimentRepository _experimentRepository;
        private readonly IMapper _mapper;

        public ExperimentsController(IExperimentRepository experimentRepository,
            IMapper mapper)
        {
            _experimentRepository = experimentRepository ??
                throw new ArgumentNullException(nameof(experimentRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<ExperimentDto>> GetExperiments(Guid plantId) {
            var experimnts = _experimentRepository.GetExperiments(plantId);
            if (experimnts == null || experimnts.ToList().Count == 0) {
                return NotFound();
            }

            var experimntsDto = _mapper.Map<IEnumerable<ExperimentDto>>(experimnts);
            return Ok(experimntsDto);
        }

        [HttpGet("{experimentId:guid}")]
        public ActionResult<ExperimentDto> GetExperiment(Guid plantId , Guid experimentId) {
            var experimnt = _experimentRepository.GetExperiment(plantId , experimentId);
            if (experimnt == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ExperimentDto>(experimnt));
        }



    }
}
