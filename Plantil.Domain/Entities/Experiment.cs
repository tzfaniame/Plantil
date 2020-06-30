using System;
using System.Collections.Generic;

namespace Plantil.Domain.Entities
{

    public class Experiment
    {
        public Experiment()
        {
            PlantExperiments = new List<PlantExperiment>();
        }

        public int Id { get; set; }
        public DateTime ExperimentDate { get; set; }
        public LocationType Location { get; set; }
        public string Description { get; set; }
        public ICollection<PlantExperiment> PlantExperiments { get; set; }
    }
}
