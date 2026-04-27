using ProjektWocheTeamzentrum.Models.Events;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;


namespace ProjektWocheTeamzentrum.ViewModels
{
    public class EventVM : BaseVM
    {
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public List<User> RegisteredParticipants { get; set; } = new List<User>();
        public int EventId { get; set; }
        public DateTime StartingTime { get; set; }
        public string Name { get; set; } = "Name";
        public int DurationInMinutes { get; set; }
        public string MeetingLocation { get; set; } = "Meeting Location";
        public int RequiredClearanceLevel { get; set; } = 0;
        public int IdHandler { get; set; } = 0;
        public int MaxParticipants { get; set; } = 0;
        public int MaxDriversPerCar { get; set; } = 0;
        public string Description { get; set; } = "Description";
        public string LeagueURL { get; set; } = "League URL";
        public string BroadcastURL { get; set; } = "Broadcast URL";
        public bool IsEsports { get; set; } = false;
        public bool isBroadcasted { get; set; } = false;
        public bool isEsports { get; set; } = false;



        public async Task InitializeEvents()
        {
            try
            {
                List<Event> events = new List<Event>();
                events = await EventUtil.GetAllEventsAsync();
                foreach (Event e in events)
                {
                    Events.Add(e);
                }
            }
            catch (Exception)
            {

            }
        }
        public EventVM()
        {
            _ = InitializeEvents();
        }
        public void AddEvent(Event e)
        {
            Events.Add(e);
        }
    }
}
