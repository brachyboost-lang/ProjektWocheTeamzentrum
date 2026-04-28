using ProjektWocheTeamzentrum.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class DayVM
    {
        public string DayName { get; set; }
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        internal DateTime Date { get ; set; }
        public DateTime date { get => Date; }
        public ObservableCollection<EventVM> EventVMs { get; set; }

        public DayVM(DateTime date)
        {
            Date = date;
            EventVMs = new ObservableCollection<EventVM>();
        }

        public void GenerateTestEvents()
        {
            Events.Add(new Event("Race 1", Date.AddHours(10), Date.AddHours(12)));
            Events.Add(new Event("Training", Date.AddHours(14), Date.AddHours(15)));
        }
    }
}
