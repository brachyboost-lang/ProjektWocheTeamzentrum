using ProjektWocheTeamzentrum.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class DayVM
    {
        public DateTime Date { get; set; } // Das Datum des Tages
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public string DayName => Date.ToString("dddd");
        // Standard-Konstruktor für leere Felder
        public DayVM() { Date = DateTime.Now; }

        public DayVM(DateTime date) { Date = date; }

        public void GenerateTestEvents()
        {
            Events.Add(new Event("Race 1", Date.AddHours(10), Date.AddHours(12)));
            Events.Add(new Event("Training", Date.AddHours(14), Date.AddHours(15)));
        }
    }
}
