using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.ViewModels
{
    class CalendarVM
    {
        public List<string> Hours { get; set; }
        public List<DayVM> Days { get; set; }

        public CalendarVM()
        {
            Hours = Enumerable.Range(0, 24)
                .Select(h => $"{h:00}:00")
                .ToList();

            Days = new List<DayVM>();

            for (int i = 0; i < 7; i++)
            {
                var day = new DayVM(DateTime.Today.AddDays(i));
                day.GenerateTestEvents();
                Days.Add(day);
            }
        }
        public class DayVM
        {
            public DateTime Date { get; set; }
            public List<EventVM> Events { get; set; }

            public DayVM(DateTime date)
            {
                Date = date;
                Events = new List<EventVM>();
            }

            public void GenerateTestEvents()
            {
                Events.Add(new EventVM("Race 1", Date.AddHours(10), Date.AddHours(12)));
                Events.Add(new EventVM("Training", Date.AddHours(14), Date.AddHours(15)));
            }
        }
    }
}
