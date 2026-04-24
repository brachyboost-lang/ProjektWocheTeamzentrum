using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Cars
{
    public class CarClass
    {
        public string Name { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new List<Car>();
        public int SimulationType { get; set; }

    }
}
