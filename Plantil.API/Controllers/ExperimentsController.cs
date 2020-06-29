using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("{experimentId}")]
        public ActionResult UpdateExperimentForPlant([FromRoute]Guid plantId,
            [FromRoute] Guid experimentId , [FromBody] ExperimentForUpdateDto experiment) {

            if (!_experimentRepository.PlantExists(plantId)) {
                NotFound();
            }

            var experimentFromRepo = _experimentRepository.GetExperiment(plantId , experimentId);

            if (experimentFromRepo == null) {
                var experimentToAdd = _mapper.Map<Entities.Experiment>(experiment);
                experimentToAdd.Id = experimentId;

                _experimentRepository.AddExperiment(plantId , experimentToAdd);
                _experimentRepository.Save();

                return CreatedAtRoute("GetExperiment",
                    new { plantId, experimentId },
                    experimentToAdd);
            }

            //entity -> ExperimetForUpdateDto
            //ExperimetForUpdateDto -> experiment
            //experiment -> entity
            _mapper.Map(experiment, experimentFromRepo);

            _experimentRepository.UpdateExperiment(experimentFromRepo);
            _experimentRepository.Save();

            return NoContent();
        }

        [HttpPatch("{experimentId}")]
        public ActionResult PartiallyUpdateExperimentForPlant(
            Guid plantId,
            Guid experimentId,
            JsonPatchDocument<ExperimentForUpdateDto> patchDocument) {

            if (!_experimentRepository.PlantExists(plantId)) {
                return NotFound();
            }

            var experimentForPlantFromRepo = _experimentRepository.GetExperiment(plantId , experimentId);

            if (experimentForPlantFromRepo == null) {
                var experimentDto = new ExperimentForUpdateDto();
                patchDocument.ApplyTo(experimentDto);
                var experimentToAdd  = _mapper.Map<Entities.Experiment>(experimentDto);
                experimentToAdd.Id = experimentId;
                _experimentRepository.AddExperiment(plantId, experimentToAdd);
                _experimentRepository.Save();

                return CreatedAtRoute("GetExperiment",
                    new { plantId, experimentId },
                    experimentToAdd);
            }

            var experimentToPatch = _mapper.Map<ExperimentForUpdateDto>(experimentForPlantFromRepo);
            patchDocument.ApplyTo(experimentToPatch,ModelState);

            if (!TryValidateModel(experimentToPatch)) {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(experimentToPatch , experimentForPlantFromRepo);

            _experimentRepository.UpdateExperiment(experimentForPlantFromRepo);
            _experimentRepository.Save();

            return NoContent();
        }
    }
}
