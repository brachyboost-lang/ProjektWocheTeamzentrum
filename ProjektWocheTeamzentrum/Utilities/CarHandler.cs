using ProjektWocheTeamzentrum.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using ProjektWocheTeamzentrum.Models.Cars;

namespace ProjektWocheTeamzentrum.Utilities
{
    public static class CarHandler
    {
        public static async Task<List<CarClass>> GetAllCarClassesAsync()
        {
            List<CarClass> carClasses = new List<CarClass>();
            string json = await File.ReadAllTextAsync("carClasses.json");
            JsonSerializer.Deserialize<List<CarClass>>(json)?.ForEach(c => carClasses.Add(c));
            return carClasses;
        }
    }
}
