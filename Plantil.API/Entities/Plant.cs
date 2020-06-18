using Plantil.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plantil.API
{

    public class Plant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genus { get; set; }
        
        public string Family { get; set; }

        [Required]
        public DateTime PlantingDate { get; set; }

        [Required]
        public MultiplicationType Multiplication { get; set; }

        public ICollection<Experiment> Experiments { get; set; }
            = new List<Experiment>();


    }
}
