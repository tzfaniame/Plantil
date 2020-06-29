using System;

namespace Plantil.Domain.Entities
{

    public class Experiment
    {
        public int Id { get; set; }
        public Plant Plant { get; set; }
        public int PlantId { get; set; }
        public DateTime ExperimentDate { get; set; }
        public LocationType Location { get; set; }
        public string Description { get; set; }
    }
}
