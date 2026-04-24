using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime StartingTime { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public string MeetingLocation { get; set; } = string.Empty;
    }
}
