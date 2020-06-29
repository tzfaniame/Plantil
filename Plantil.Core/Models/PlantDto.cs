using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.Core
{
    public class PlantDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Classification { get; set; }

        public int DaysFromPlanting { get; set; }

        public int Multiplication { get; set; }
    }
}
