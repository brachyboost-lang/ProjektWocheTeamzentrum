using ProjektWocheTeamzentrum.Models.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class RaceLMU : Race
    {
        public int AvailableTyres { get; set; }
        public string FuelMultiplier { get; set; } = "1x";
        public string TyreMultiplier { get; set; } = "1x";
        public RaceLMU(List<CarClass> carClasses, string track, int simulationType, int maximumParticipants, 
            int driversPerCar, bool isEndurance, bool isEsports, bool isLeague, bool isBroadcasted, 
            string broadcastLink, DateTime startingTime, string name, int durationInMinutes, string meetingLocation, 
            int requiredClearanceLevel, int availableTyres, string fuelMultiplier, string tyreMultiplier) 
            : base(carClasses, track, 1, maximumParticipants, driversPerCar, 
                  isEndurance, isEsports, isLeague, isBroadcasted, broadcastLink, startingTime, name, 
                  durationInMinutes, meetingLocation, requiredClearanceLevel)
        {
            AvailableTyres = availableTyres;
            FuelMultiplier = fuelMultiplier;
            TyreMultiplier = tyreMultiplier;
        }
    }
}
