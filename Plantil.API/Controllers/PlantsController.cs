using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plantil.API.Helpers;
using Plantil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Plantil.API.Controllers
{
    [ApiController]
    [Route("api/plants")]
    public class PlantsController : ControllerBase //Controller
    {
        private readonly IExperimentRepository _experimentRepository;
        private readonly IMapper _mapper;

        public PlantsController(IExperimentRepository experimentRepository,
            IMapper mapper)
        {
            _experimentRepository = experimentRepository ??
                throw new ArgumentNullException(nameof(experimentRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()] //[HttpGet("api/plants")]
        [HttpHead]
        public ActionResult<IEnumerable<PlantDto>> GetPlants(
            //[FromQuery] string genus, [FromQuery] string searchQuery
            [FromQuery] PlantResourceParameters plantResourceParameters) { //IActionResult

            var plantsFromRep = _experimentRepository.GetPlants(plantResourceParameters);

            var plantsDto = _mapper.Map<IEnumerable<PlantDto>>(plantsFromRep);

            //foreach (var plant in plantsFromRep)
            //{
            //    plantsDto.Add(new PlantDto
            //    {
            //        Id = plant.Id,
            //        Name = plant.Name,
            //        Classification = $"{plant.Genus},{plant.Family}",
            //        DaysFromPlanting = plant.PlantingDate.GetGapDays(),
            //        Multiplication = (int)plant.Multiplication
            //    }) ;
            //}

            return Ok(plantsDto);//new JsonResult(plants);
        }

        [HttpGet("{plantId:Guid}",Name = "GetPlant")]
        public ActionResult<PlantDto> GetPlant(Guid plantId)
        {
            //if (!_experimentRepository.PlantExists(plantId)) {
            //    return NotFound();
            //}
            var plant = _experimentRepository.GetPlant(plantId);

            if (plant == null) {
                return NotFound();
            }

            var plantDto = _mapper.Map<PlantDto>(plant);
            return Ok(plant);
        }

        [HttpPost]
        public ActionResult<PlantForCreateDto> CreatePlant([FromBody]PlantForCreateDto plant)
        {
            var plantEntity = _mapper.Map<Entities.Plant>(plant);
            _experimentRepository.AddPlant(plantEntity);
            _experimentRepository.Save();

            var plantToReturn = _mapper.Map<PlantDto>(plantEntity);
            return CreatedAtRoute("GetPlant",
                new { plantId = plantToReturn.Id },
                plantToReturn);

        }

        [HttpGet("({ids})",Name = "GetPlantCollection")]
        public IActionResult GetPlantCollection(
            [FromRoute] 
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids) {
            if (ids == null) {
                return BadRequest();
            }

            var plantEntities = _experimentRepository.GetPlants(ids);

            if (ids.Count() != plantEntities.Count()) {
                return NotFound();
            }

            return Ok(plantEntities);
        
        }

        [HttpPost("PlantCollection")]
        public ActionResult<IEnumerable<PlantForCreateDto>> PlantCollection(
            [FromBody] IEnumerable<PlantForCreateDto> PlantsForCreateDto) {
            var plantsEntity = _mapper.Map<IEnumerable<Entities.Plant>>(PlantsForCreateDto);

            foreach (var p in plantsEntity)
            {
                _experimentRepository.AddPlant(p);
            }
            _experimentRepository.Save();

            var plantsDto = _mapper.Map<IEnumerable<PlantDto>>(plantsEntity);

            string idsAsString = string.Join(',', plantsDto.Select(p => p.Id));
            return CreatedAtRoute("GetPlantCollection",
                new { ids = idsAsString } , 
                plantsDto);

        }

        [HttpOptions]
        public IActionResult GetPlantsOptions() {
            Response.Headers.Add("Allow", "GET,OPTION,POST");
            return Ok();
        }

        [HttpDelete("{plantId}")]
        public ActionResult DeletePlant([FromRoute]Guid plantId) {
            var plantFromRepo = _experimentRepository.GetPlant(plantId);
            if (plantFromRepo == null) {
                return NotFound();
            }

            _experimentRepository.DeletePlant(plantFromRepo);
            _experimentRepository.Save();

            return NoContent();
        }
    }
}
