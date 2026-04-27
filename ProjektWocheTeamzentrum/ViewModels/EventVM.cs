using ProjektWocheTeamzentrum.Models.Events;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string Name { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public string MeetingLocation { get; set; } = string.Empty;
        public int RequiredClearanceLevel { get; set; } = 0;
        public int IdHandler { get; set; } = 0;

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
    }
}
