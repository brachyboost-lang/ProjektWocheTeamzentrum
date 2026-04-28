using ProjektWocheTeamzentrum.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class DayVM : BaseVM
    {
        public DateTime Date { get; set; }
        public string DayText => Date == DateTime.MinValue ? "" : Date.Day.ToString();
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();

        // Dieser Konstruktor wird für die leeren Tage (startDayOffset) gebraucht
        public DayVM(DateTime date)
        {
            Date = date;
        }
        public string DayName { get => Date.ToString("dddd"); set; }
        // Standard-Konstruktor für leere Felder
        public DayVM() { Date = DateTime.Now; }


        public void GenerateTestEvents()
        {
            Events.Add(new Event("Race 1", Date.AddHours(10), Date.AddHours(12)));
            Events.Add(new Event("Training", Date.AddHours(14), Date.AddHours(15)));
        }
    }
}
