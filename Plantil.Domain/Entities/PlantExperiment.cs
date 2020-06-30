using System;
using System.Collections.Generic;
using System.Text;

namespace Plantil.Domain.Entities
{
    public class PlantExperiment
    {
        public int PlantId { get; set; }
        public int ExperimentId { get; set; }
        public Plant Plant { get; set; }
        public Experiment Experiment { get; set; }
    }
}
