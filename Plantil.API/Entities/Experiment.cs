using Plantil.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plantil.API.Entities
{

    public class Experiment
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("PlantId")]
        public Plant Plant { get; set; }

        public Guid PlantId { get; set; }

        [Required]
        public DateTime ExperimentDate { get; set; }
        
        public LocationType Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

    }
}
