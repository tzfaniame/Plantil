using Plantil.API.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API
{
    public class ExperimentRepository : IExperimentRepository, IDisposable
    {
        private readonly ExperimentContext context;
        public ExperimentRepository(ExperimentContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddExperiment(Guid plantId, Experiment experiment)
        {
            if (plantId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(plantId));
            }

            if (experiment == null)
            {
                throw new ArgumentNullException(nameof(experiment));
            }
            // always set the PlantId to the passed-in plantId
            experiment.PlantId = plantId;
            context.Experiments.Add(experiment);
        }

        public void DeleteExperiment(Experiment experiment)
        {
            context.Experiments.Remove(experiment);
        }

        public Experiment GetExperiment(Guid plantId, Guid experimentId)
        {
            if (plantId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(plantId));
            }

            if (experimentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(experimentId));
            }

            return context.Experiments
              .Where(e => e.PlantId == plantId && e.Id == experimentId).FirstOrDefault();
        }

        public IEnumerable<Experiment> GetExperiments(Guid plantId)
        {
            if (plantId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(plantId));
            }

            return context.Experiments
                        .Where(c => c.PlantId == plantId)
                        .OrderBy(c => c.Plant.Name).ToList();
        }

        public void UpdateExperiment(Experiment experiment)
        {
            // no code in this implementation
        }

        public void AddPlant(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            // the repository fills the id (instead of using identity columns)
            plant.Id = Guid.NewGuid();

            foreach (var experiment in plant.Experiments)
            {
                experiment.Id = Guid.NewGuid();
            }

            context.Plants.Add(plant);
        }

        public bool PlantExists(Guid plantId)
        {
            if (plantId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(plantId));
            }

            return context.Plants.Any(p => p.Id == plantId);
        }

        public void DeletePlant(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            context.Plants.Remove(plant);
        }

        public Plant GetPlant(Guid plantId)
        {
            if (plantId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(plantId));
            }

            return context.Plants.FirstOrDefault(p => p.Id == plantId);
        }

        public IEnumerable<Plant> GetPlants()
        {
            return context.Plants.ToList<Plant>();
        }

        public IEnumerable<Plant> GetPlants(IEnumerable<Guid> plantIds)
        {
            if (plantIds == null)
            {
                throw new ArgumentNullException(nameof(plantIds));
            }

            return context.Plants.Where(p => plantIds.Contains(p.Id))
                .OrderBy(p => p.Name)
                .OrderBy(p => p.Genus)
                .ToList();
        }

        public void UpdatePlant(Plant plant)
        {
            // no code in this implementation
        }

        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
