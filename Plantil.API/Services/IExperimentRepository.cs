using Plantil.Core;
using Plantil.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API
{
    public interface IExperimentRepository
    {
        IEnumerable<Experiment> GetExperiments(Guid plantId);
        Experiment GetExperiment(Guid plantId, Guid experimentId);
        void AddExperiment(Guid plantId, Experiment experiment);
        void UpdateExperiment(Experiment experiment);
        void DeleteExperiment(Experiment experiment);
        IEnumerable<Plant> GetPlants();
        IEnumerable<Plant> GetPlants(PlantResourceParameters plantResourceParameters);
        Plant GetPlant(Guid plantId);
        IEnumerable<Plant> GetPlants(IEnumerable<Guid> plantIds);
        void AddPlant(Plant plant);
        void DeletePlant(Plant plant);
        void UpdatePlant(Plant plant);
        bool PlantExists(Guid plantId);
        bool Save();
    }
}
