using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API.Models
{
    public class ExperimentDto
    {
        public Guid Id { get; set; }

        public Guid PlantId { get; set; }

        public DateTime ExperimentDate { get; set; }

        public int Location { get; set; }

        public string Description { get; set; }
    }
}
