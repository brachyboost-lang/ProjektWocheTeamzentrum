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
    }
}

