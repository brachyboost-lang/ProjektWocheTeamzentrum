using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjektWocheTeamzentrum.Models.Events;
using System.IO;
using System.Text.Json;

namespace ProjektWocheTeamzentrum.Utilities
{
    public static class EventUtil
    {
        public static async Task<List<Event>> GetAllEventsAsync()
        {
            List<Event> events = new List<Event>();
            string json = await File.ReadAllTextAsync("events.json");
            JsonSerializer.Deserialize<List<Event>>(json)?.ForEach(e => events.Add(e));
            return events;
        }
    }
}
