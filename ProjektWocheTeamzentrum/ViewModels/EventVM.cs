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
using ProjektWocheTeamzentrum.Models.Cars;


namespace ProjektWocheTeamzentrum.ViewModels
{
    public class EventVM : BaseVM
    {
        public RelayCommand AddEventCommand => new RelayCommand(execute => { }, canExecute => { return canEditEvent(); });
        public RelayCommand DeleteEventCommand => new RelayCommand(execute => { }, canExecute => { return canEditEvent(); });
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public ObservableCollection<User> RegisteredParticipants { get; set; } = new ObservableCollection<User>();
        public int EventId { get; set; }
        public DateTime StartingTime { get; set; }
        public string Name { get; set; } = "Name";
        public int DurationInMinutes { get; set; }
        public string EventLocation { get; set; } = "Event Location";
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
        public int SimulationType { get; set; } = 0;
        public User? LoggedInUser { get; set; }
        public ObservableCollection<CarClass> AvailableCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> ACCCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> LMUCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> IRCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> TeamEvents { get; set; } = new ObservableCollection<CarClass>();

        public bool canEditEvent()
        {
            if (LoggedInUser != null) { return true; }
            if (LoggedInUser != null && LoggedInUser.ClearanceLevel >= 60)
            {
                return true;
            }
            return false;
        }

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
            CarClass TeamEvents = new CarClass
            {
                Name = "Team Events",
                SimulationType = 0,
                Cars = new List<Car>()
                    {
                new Car("Team Meeting VOIP"),
                new Car("Team Meeting in Person"),
                new Car("Other Event"),
                new Car("German Time Attack Masters"),
                new Car("Rennen (Zuschauen)"),
                new Car("Gruppen Coaching")
                    }
            };
        }
        
    }
}
