using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class Event
    {
        public List<User> RegisteredParticipants { get; set; } = new List<User>();
        public int EventId { get; set; }
        public DateTime StartingTime { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public string MeetingLocation { get; set; } = string.Empty;
        public int RequiredClearanceLevel { get; set; } = 0;

        public Event(DateTime startingTime, string name, int durationInMinutes, string meetingLocation, int requiredClearanceLevel)
        {
            EventId = EventUtil.GetAllEventsAsync().Result.Count + 1; //temporär, wird später durch Datenbank mit auto increment ersetzt
            StartingTime = startingTime;
            Name = name;
            DurationInMinutes = durationInMinutes;
            MeetingLocation = meetingLocation;
            RequiredClearanceLevel = requiredClearanceLevel;
        }
    }
}
