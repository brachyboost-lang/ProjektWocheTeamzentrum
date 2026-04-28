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
        public string EventLocation { get; set; } = string.Empty;
        public int RequiredClearanceLevel { get; set; } = 0;
        public int IdHandler { get; set; } = 0;
        public List<User> VisibleToUsers { get; set; } = new List<User>();
        public string Description { get; set; } = string.Empty;
        public DateTime EndingTime { get; set; }

        // parameterless ctor required for JSON deserialization
        public Event()
        {
        }
        public Event(string name, DateTime startingTime, DateTime endingTime)
        {
            Name = name;
            StartingTime = startingTime;
            EndingTime = endingTime;
        }

        public Event(DateTime startingTime, string name, int durationInMinutes, string eventLocation, int requiredClearanceLevel, string description)
        {
            IdHandler++;
            EventId = IdHandler;
            StartingTime = startingTime;
            Name = name;
            DurationInMinutes = durationInMinutes;
            EventLocation = eventLocation;
            RequiredClearanceLevel = requiredClearanceLevel;
            Description = description ?? string.Empty;
        }

        //backwards compatibility constructor without description parameter, faster than finding all usages right now, close to deadline
        public Event(DateTime startingTime, string name, int durationInMinutes, string eventLocation, int requiredClearanceLevel)
            : this(startingTime, name, durationInMinutes, eventLocation, requiredClearanceLevel, string.Empty)
        {
        }
    }
}
