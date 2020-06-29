using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plantil.Core;
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

        [HttpGet("{experimentId:guid}",Name = "GetExperiment")]
        public ActionResult<ExperimentDto> GetExperiment(Guid plantId , Guid experimentId) {
            var experimnt = _experimentRepository.GetExperiment(plantId , experimentId);
            if (experimnt == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ExperimentDto>(experimnt));
        }

        [HttpPost]
        public ActionResult<ExperimentForCreateDto> Create(
           Guid plantId , [FromBody]ExperimentForCreateDto experiment) {

            if (!_experimentRepository.PlantExists(plantId)) {
                return NotFound();
            }

            var experimentEntity = _mapper.Map<Entities.Experiment>(experiment);
            _experimentRepository.AddExperiment(plantId , experimentEntity);
            _experimentRepository.Save();

            var experimentDto = _mapper.Map<ExperimentDto>(experimentEntity);
            return CreatedAtRoute(
                "GetExperiment" , 
                new { plantId = plantId, experimentId = experimentDto.Id } , 
                experimentDto);
        }

        [HttpDelete("{experimentId}")]
        public ActionResult DeleteExperimentForPlant([FromRoute] Guid plantId , [FromRoute] Guid experimentId) {

            if (!_experimentRepository.PlantExists(plantId)) {
                return NotFound();
            }

            var experimentForPlantFromRepo = _experimentRepository.GetExperiment(plantId , experimentId);
            if (experimentForPlantFromRepo == null) {
                return NotFound();
            }

            _experimentRepository.DeleteExperiment(experimentForPlantFromRepo);
            _experimentRepository.Save();

            return NoContent();
        }


    }
}
