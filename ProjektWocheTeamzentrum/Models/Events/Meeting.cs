using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class Meeting : Event
    {
        public Meeting(DateTime startingTime, string name, int durationInMinutes, string meetingLocation, int requiredClearanceLevel) 
            : base(startingTime, name, durationInMinutes, meetingLocation, requiredClearanceLevel)
        {
        }
        public Meeting() : base(DateTime.Now, string.Empty, 0, string.Empty, 0, string.Empty) { }

        public Meeting(DateTime startingTime, string name, int durationInMinutes, string meetingLocation, int requiredClearanceLevel, string description)
            : base(startingTime, name, durationInMinutes, meetingLocation, requiredClearanceLevel, description)
        {
        }
    }
}
