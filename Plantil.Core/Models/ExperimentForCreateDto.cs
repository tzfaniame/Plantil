using System;
using System.Collections.Generic;
using System.Text;

namespace Plantil.Core
{
    public class ExperimentForCreateDto
    {
        public DateTime ExperimentDate { get; set; }
        public LocationType Location { get; set; }
        public string Description { get; set; }
    }
}
