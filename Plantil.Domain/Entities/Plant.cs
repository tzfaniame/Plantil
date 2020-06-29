﻿using System;
using System.Collections.Generic;

namespace Plantil.Domain.Entities
{

    public class Plant
    {
        public Plant()
        {
            Experiments = new List<Experiment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PlantingDate { get; set; }
        public MultiplicationType Multiplication { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public ICollection<Experiment> Experiments { get; set; }
    }
}
