using System;
using System.Collections.Generic;
using System.Text;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Models.Cars;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class Race : Event
    {
        public List<CarClass> CarClasses { get; set; } = new List<CarClass>();
        public string Track { get; set; } = string.Empty;
        public int SimulationType { get; set; }
        public int MaximumParticipants { get; set; }
        public int DriversPerCar { get; set; } = 1;
        public bool IsEndurance { get; set; } = false;
        public bool IsEsports { get; set; } = false;
        public bool IsLeague { get; set; } = false;
        public bool IsBroadcasted { get; set; } = false;
        public string BroadcastLink { get; set; } = string.Empty;
        public Race(List<CarClass> carClasses, string track, int simulationType, int maximumParticipants, int driversPerCar, 
            bool isEndurance, bool isEsports, bool isLeague, bool isBroadcasted, string broadcastLink, 
            DateTime startingTime, string name, int durationInMinutes, string meetingLocation, int requiredClearanceLevel, string description)
            : base(startingTime, name, durationInMinutes, meetingLocation, requiredClearanceLevel, description)
        {
            CarClasses = carClasses;
            Track = track;
            SimulationType = simulationType;
            MaximumParticipants = maximumParticipants;
            DriversPerCar = driversPerCar;
            IsEndurance = isEndurance;
            IsEsports = isEsports;
            IsLeague = isLeague;
            IsBroadcasted = isBroadcasted;
            BroadcastLink = broadcastLink;
        }

        // Backwards-compatible constructor without description
        public Race(List<CarClass> carClasses, string track, int simulationType, int maximumParticipants, int driversPerCar,
            bool isEndurance, bool isEsports, bool isLeague, bool isBroadcasted, string broadcastLink,
            DateTime startingTime, string name, int durationInMinutes, string meetingLocation, int requiredClearanceLevel)
            : this(carClasses, track, simulationType, maximumParticipants, driversPerCar, isEndurance, isEsports, isLeague, isBroadcasted, broadcastLink, startingTime, name, durationInMinutes, meetingLocation, requiredClearanceLevel, string.Empty)
        {
        }
    }
}
