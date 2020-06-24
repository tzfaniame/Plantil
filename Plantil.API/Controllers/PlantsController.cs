using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API.Controllers
{
    [ApiController]
    [Route("api/plants")]
    public class PlantsController : ControllerBase
    {
        private readonly IExperimentRepository _experimentRepository;
        
        public PlantsController(IExperimentRepository experimentRepository)
        {
            _experimentRepository = experimentRepository ??
                throw new ArgumentNullException(nameof(experimentRepository));
        }

        [HttpGet()]
        public IActionResult GetPlants() {
            var plants = _experimentRepository.GetPlants();
            return new JsonResult(plants);
        }

        [HttpGet("{plantId:Guid}")]
        public IActionResult GetPlant(Guid plantId)
        {
            var plant = _experimentRepository.GetPlant(plantId);
            return new JsonResult(plant);
        }
    }
}
