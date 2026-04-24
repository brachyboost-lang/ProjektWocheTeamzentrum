using System;
using System.Collections.Generic;
using System.Text;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Models.Cars;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class Race : Event
    {
        public List<User> Participants { get; set; } = new List<User>();
        public List<CarClass> CarClasses { get; set; } = new List<CarClass>();
        public string Track { get; set; } = string.Empty;
        public int SimulationType { get; set; }
        public int MaximumParticipants { get; set; }
        public int DriversPerCar { get; set; } = 1;
        public bool IsEndurance { get; set; } = false;
        public bool isEsports { get; set; } = false;
        public bool isLeague { get; set; } = false;
        public bool isBroadcasted { get; set; } = false;
        public string BroadcastLink { get; set; } = string.Empty;
    }
}
