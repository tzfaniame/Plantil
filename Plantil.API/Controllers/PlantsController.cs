using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plantil.API.Models;
using Plantil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<PlantDto>> GetPlants() { //IActionResult
            var plantsFromRep = _experimentRepository.GetPlants();

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

        [HttpGet("{plantId:Guid}")]
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
    }
}
