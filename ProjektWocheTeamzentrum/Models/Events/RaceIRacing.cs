using ProjektWocheTeamzentrum.Models.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class RaceIRacing : Race
    {
        public RaceIRacing(List<CarClass> carClasses, string track, int simulationType, int maximumParticipants,
            int driversPerCar, bool isEndurance, bool isEsports, bool isLeague, bool isBroadcasted,
            string broadcastLink, DateTime startingTime, string name, int durationInMinutes, string meetingLocation,
            int requiredClearanceLevel)
            : base(carClasses, track, 3, maximumParticipants, driversPerCar,
                  isEndurance, isEsports, isLeague, isBroadcasted, broadcastLink, startingTime, name,
                  durationInMinutes, meetingLocation, requiredClearanceLevel)
        {
        }
        public RaceIRacing(List<CarClass> carClasses, string track, int simulationType, int maximumParticipants,
    int driversPerCar, bool isEndurance, bool isEsports, bool isLeague, bool isBroadcasted,
    string broadcastLink, DateTime startingTime, string name, int durationInMinutes, string meetingLocation,
    int requiredClearanceLevel, string description)
    : base(carClasses, track, 3, maximumParticipants, driversPerCar,
          isEndurance, isEsports, isLeague, isBroadcasted, broadcastLink, startingTime, name,
          durationInMinutes, meetingLocation, requiredClearanceLevel, description)
        {
        }
    }
}
