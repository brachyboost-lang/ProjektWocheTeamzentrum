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
using System.Windows;


namespace ProjektWocheTeamzentrum.ViewModels
{
    public class EventVM : BaseVM
    {
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public ObservableCollection<User> RegisteredParticipants { get; set; } = new ObservableCollection<User>();
        public int EventId { get; set; }
        private DateTime _startingTime = DateTime.Now;
        public DateTime StartingTime
        {
            get => _startingTime;
            set
            {
                if (_startingTime != value)
                {
                    _startingTime = value;
                    OnPropertyChanged(nameof(StartingTime));
                }
            }
        }
        public string Name { get; set; } = "Name";
        public string Track { get; set; } = "Track";
        public int DurationInMinutes { get; set; }
        public string EventLocation { get; set; } = "Meeting Location";
        public int RequiredClearanceLevel { get; set; }
        public int IdHandler { get; set; } = 0;
        public int MaxParticipants { get; set; } = 0;
        public int MaxDriversPerCar { get; set; } = 0;
        public string SelectedParticipants { get; set; }
        public string Description { get; set; } = "Description";
        public string LeagueURL { get; set; } = "League URL";
        public string BroadcastURL { get; set; } = "Broadcast URL";
        public bool IsEsports { get; set; } = false;
        public bool IsBroadcasted { get; set; } = false;
        public bool IsLeague { get; set; } = false;
        public int SimulationType { get; set; } = 0;
        public bool IsEndurance { get; set; } = false;
        public User? LoggedInUser { get; set; }
        public ObservableCollection<CarClass> AvailableCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> ACCCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> LMUCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> IRCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> TeamEvents { get; set; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> SelectedCarClasses { get; set; } = new ObservableCollection<CarClass>();
        public string Location
        {
            get => EventLocation;
            set
            {
                if (EventLocation != value)
                {
                    EventLocation = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }
        public RelayCommand AddEventCommand => new RelayCommand(execute => { }, canExecute => { return canEditEvent(); });
        public RelayCommand DeleteEventCommand => new RelayCommand(execute => { }, canExecute => { return canEditEvent(); });

        public bool canEditEvent()
        {
            if (LoggedInUser != null) { return true; }
            if (LoggedInUser != null && LoggedInUser.ClearanceLevel >= 60)
            {
                return true;
            }
            return false;
        }

        // Date and time selection helpers for bindings
        private DateTime? _selectedDate = DateTime.Today;
        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                    UpdateStartingTime();
                }
            }
        }

        private int _selectedHour = DateTime.Now.Hour;
        // bind to Hours ComboBox.SelectedIndex
        public int SelectedHour
        {
            get => _selectedHour;
            set
            {
                if (_selectedHour != value)
                {
                    _selectedHour = value;
                    OnPropertyChanged(nameof(SelectedHour));
                    UpdateStartingTime();
                }
            }
        }

        private int _selectedMinuteIndex = 0; // 0->0,1->15,2->30,3->45
        // bind to Minutes ComboBox.SelectedIndex
        public int SelectedMinuteIndex
        {
            get => _selectedMinuteIndex;
            set
            {
                if (_selectedMinuteIndex != value)
                {
                    _selectedMinuteIndex = value;
                    OnPropertyChanged(nameof(SelectedMinuteIndex));
                    UpdateStartingTime();
                }
            }
        }

        private void UpdateStartingTime()
        {
            if (SelectedDate.HasValue)
            {
                int minutes = SelectedMinuteIndex switch
                {
                    1 => 15,
                    2 => 30,
                    3 => 45,
                    _ => 0,
                };
                var date = SelectedDate.Value.Date;
                StartingTime = date.AddHours(SelectedHour).AddMinutes(minutes);
            }
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
        public async Task InitializeCarClasses()
        {
            await CarHandler.InitializeCarsAsync();
        }
        public EventVM()
        {
            _ = InitializeEvents();
            _ = InitializeCarClasses();
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
        public async Task CreateEvent()
        {
            if (SimulationType > 0)
            {

                try
                {
                    var carClasses = new List<CarClass>(SelectedCarClasses);
                    int minutes = SelectedMinuteIndex switch
                    {
                        1 => 15,
                        2 => 30,
                        3 => 45,
                        _ => 0,
                    };
                    DateTime starting = SelectedDate.HasValue ? SelectedDate.Value.Date.AddHours(SelectedHour).AddMinutes(minutes) : DateTime.Now;

                    var newEvent = new Race(carClasses, Track ?? string.Empty, SimulationType, MaxParticipants, MaxDriversPerCar,
                        IsEndurance, IsEsports, IsLeague, IsBroadcasted, BroadcastURL ?? string.Empty,
                        starting, Name, DurationInMinutes, EventLocation ?? string.Empty, RequiredClearanceLevel, Description ?? string.Empty);

                    await EventUtil.AddEventAsync(newEvent);
                }
                catch (Exception ex)
                {
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show($"Error creating event: {ex.Message}", "Error", button, icon);
                }
            }
            if (SimulationType == 0)
                try
                {
                    int minutes = SelectedMinuteIndex switch
                    {
                        1 => 15,
                        2 => 30,
                        3 => 45,
                        _ => 0,
                    };
                    DateTime starting = SelectedDate.HasValue ? SelectedDate.Value.Date.AddHours(SelectedHour).AddMinutes(minutes) : DateTime.Now;
                    var newEvent = new Event(StartingTime, Name, DurationInMinutes, EventLocation ?? string.Empty, RequiredClearanceLevel, Description ?? string.Empty);
                    await EventUtil.AddEventAsync(newEvent);
                }
                catch (Exception ex)
                {
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show($"Error creating event: {ex.Message}", "Error", button, icon);
                }
        }
    }
}
