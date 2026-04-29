using ProjektWocheTeamzentrum.Models.Events;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Utilities;
using ProjektWocheTeamzentrum.Models.Cars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class EventVM : BaseVM
    {
        public ObservableCollection<Event> Events { get; } = new ObservableCollection<Event>();
        public ObservableCollection<User> RegisteredParticipants { get; } = new ObservableCollection<User>();

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

        private int _requiredClearanceLevel;
        public int RequiredClearanceLevel
        {
            get => _requiredClearanceLevel;
            set
            {
                if (_requiredClearanceLevel != value)
                {
                    _requiredClearanceLevel = value;
                    OnPropertyChanged(nameof(RequiredClearanceLevel));
                }
            }
        }

        public int MaxParticipants { get; set; } = 0;
        public int MaxDriversPerCar { get; set; } = 0;

        private string _selectedParticipants = string.Empty;
        public string SelectedParticipants
        {
            get => _selectedParticipants;
            set
            {
                if (_selectedParticipants != value)
                {
                    _selectedParticipants = value;
                    OnPropertyChanged(nameof(SelectedParticipants));
                    RequiredClearanceLevel = value?.ToLowerInvariant() switch
                    {
                        "leaders" => 80,
                        "coach" => 60,
                        "members" => 30,
                        "everyone" => 5,
                        _ => 5,
                    };
                }
            }
        }

        public string Description { get; set; } = string.Empty;
        public string LeagueURL { get; set; } = string.Empty;
        public string BroadcastURL { get; set; } = string.Empty;
        public bool IsEsports { get; set; } = false;
        public bool IsBroadcasted { get; set; } = false;
        public bool IsLeague { get; set; } = false;
        public int SimulationType { get; set; } = 0;
        public bool IsEndurance { get; set; } = false;

        public User? LoggedInUser { get; set; }
        public IEnumerable<Event> SortedFutureEvents =>
    Events.Where(e => e.StartingTime >= DateTime.Now)
          .OrderBy(e => e.StartingTime);

        // Car class collections
        public ObservableCollection<CarClass> AvailableCarClasses { get; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> ACCCarClasses { get; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> LMUCarClasses { get; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> IRCarClasses { get; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> TeamEvents { get; } = new ObservableCollection<CarClass>();
        public ObservableCollection<CarClass> SelectedCarClasses { get; } = new ObservableCollection<CarClass>();

        public Event SelectedEvent { get; set; }
        public ObservableCollection<string> Hours { get; } = new ObservableCollection<string>(
    Enumerable.Range(0, 24).Select(h => h.ToString("00") + ":00")
);

        public ObservableCollection<DayVM> Days { get; } = new ObservableCollection<DayVM>();

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

        public RelayCommand AddEventCommand => new RelayCommand(async _ => await CreateEvent(), _ => canEditEvent());
        public RelayCommand DeleteEventCommand => new RelayCommand(_ => { }, _ => canEditEvent() && SelectedEvent != null);

        public bool canEditEvent()
        {
            if (LoggedInUser != null) { return true; }
            if (LoggedInUser != null && LoggedInUser.ClearanceLevel >= 60)
            {
                return true;
            }
            return false;
        }


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

        public void UpdateStartingTime()
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
            if (_isInitialized) return;
            _isInitialized = true;
            try
            {

                Events.Clear();
                Days.Clear();

                List<Event> events = await EventUtil.GetAllEventsAsync();

                foreach (var e in events.OrderBy(ev => ev.StartingTime))
                {
                    Events.Add(e);
                }

               
                var date = DateTime.Today;
                for (int i = 0; i < 7; i++)
                {
                    var dayDate = date.AddDays(i);
                    var dayVM = new DayVM { DayName = dayDate.ToString("dddd") };

                    
                    foreach (var e in events.Where(ev => ev.StartingTime.Date == dayDate.Date))
                    {
                        dayVM.Events.Add(e);
                    }
                    Days.Add(dayVM);
                }

               
                var cvm = new CalendarVM();
                await cvm.BuildCalendar(DateTime.Now.Year, DateTime.Now.Month);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fehler in InitializeEvents: {ex.Message}");
            }
        }

        public async Task InitializeCarClasses()
        {
            try
            {
                var carClasses = await CarHandler.InitializeCarsAsync();
                // distribute to simulation-specific collections
                AvailableCarClasses.Clear();
                ACCCarClasses.Clear();
                LMUCarClasses.Clear();
                IRCarClasses.Clear();
                foreach (var cc in carClasses)
                {
                    AvailableCarClasses.Add(cc);
                    switch (cc.SimulationType)
                    {
                        case 1:
                            LMUCarClasses.Add(cc);
                            break;
                        case 2:
                            ACCCarClasses.Add(cc);
                            break;
                        case 3:
                            IRCarClasses.Add(cc);
                            break;
                        default:
                            break;
                    }
                }
                // wire up change notifications so UI selections (IsSelected) update SelectedCarClasses
                WireCarClassCollection(AvailableCarClasses);
                WireCarClassCollection(ACCCarClasses);
                WireCarClassCollection(LMUCarClasses);
                WireCarClassCollection(IRCarClasses);
                WireCarClassCollection(TeamEvents);
            }
            catch
            {

            }
        }
        private bool _isInitialized = false;
        public EventVM()
        {
            Events.CollectionChanged += (s, e) => OnPropertyChanged(nameof(SortedFutureEvents));
            _ = InitializeEvents();
            _ = InitializeCarClasses();
            var teamEventClass = new CarClass
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
            teamEventClass.IsSelected = false;
            this.TeamEvents.Add(teamEventClass);
            // ensure handlers are wired for team events
            WireCarClassCollection(this.TeamEvents);
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

                    bool success = await EventUtil.AddEventAsync(newEvent);
                    if (success)
                    {
                        Events.Add(newEvent);
                    }
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
                    var newEvent = new Event(starting, Name, DurationInMinutes, EventLocation ?? string.Empty, RequiredClearanceLevel, Description ?? string.Empty);
                    await EventUtil.AddEventAsync(newEvent);
                    Events.Add(newEvent);
                }
                catch (Exception ex)
                {
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show($"Error creating event: {ex.Message}", "Error", button, icon);
                }
        }

        private const double HourHeight = 60; // 1 Stunde = 60px

        private void WireCarClassCollection(ObservableCollection<CarClass> collection)
        {
            if (collection == null) return;
            // subscribe to future changes
            collection.CollectionChanged -= CarClassCollection_CollectionChanged;
            collection.CollectionChanged += CarClassCollection_CollectionChanged;

            foreach (var cc in collection)
            {
                cc.PropertyChanged -= CarClass_PropertyChanged;
                cc.PropertyChanged += CarClass_PropertyChanged;
                // ensure already-selected items are present in SelectedCarClasses
                if (cc.IsSelected)
                {
                    if (!SelectedCarClasses.Contains(cc)) SelectedCarClasses.Add(cc);
                }
            }
        }

        private void CarClassCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e == null) return;
            if (e.NewItems != null)
            {
                foreach (var ni in e.NewItems)
                {
                    if (ni is CarClass cc)
                    {
                        cc.PropertyChanged -= CarClass_PropertyChanged;
                        cc.PropertyChanged += CarClass_PropertyChanged;
                        if (cc.IsSelected && !SelectedCarClasses.Contains(cc)) SelectedCarClasses.Add(cc);
                    }
                }
            }
            if (e.OldItems != null)
            {
                foreach (var oi in e.OldItems)
                {
                    if (oi is CarClass cc)
                    {
                        cc.PropertyChanged -= CarClass_PropertyChanged;
                        if (SelectedCarClasses.Contains(cc)) SelectedCarClasses.Remove(cc);
                    }
                }
            }
        }

        private void CarClass_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CarClass.IsSelected) && sender is CarClass cc)
            {
                if (cc.IsSelected)
                {
                    if (!SelectedCarClasses.Contains(cc)) SelectedCarClasses.Add(cc);
                }
                else
                {
                    if (SelectedCarClasses.Contains(cc)) SelectedCarClasses.Remove(cc);
                }
            }
        }

        public string Title { get => Name; set => Name = value; }
        public DateTime Start { get => StartingTime; set => StartingTime = value; }
        public DateTime End { get => StartingTime.AddMinutes(DurationInMinutes); set => DurationInMinutes = (int)(value - StartingTime).TotalMinutes; }

        public double Top => (Start.Hour + Start.Minute / 60.0) * HourHeight;

        public double Height => (End - Start).TotalHours * HourHeight;

        public double Left => 5;   // später für Overlap
        public double Width => 120;
        // Convenience constructor used by CalendarVM for demo events
        public EventVM(string title, DateTime start, DateTime end)
        {
            Events.CollectionChanged += (s, e) => OnPropertyChanged(nameof(SortedFutureEvents));
            Name = title;
            StartingTime = start;
            DurationInMinutes = (int)(end - start).TotalMinutes;
        }



    }
}

