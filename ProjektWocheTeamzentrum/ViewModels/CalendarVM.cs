using ProjektWocheTeamzentrum.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<DayVM> MonthDays { get; } = new ObservableCollection<DayVM>();
        public void BuildCalendar(int year, int month)
        {
            MonthDays.Clear();
            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Wochentag von Montag (1) bis Sonntag (7)
            int startDayOffset = (int)firstDay.DayOfWeek == 0 ? 6 : (int)firstDay.DayOfWeek - 1;

            for (int i = 0; i < startDayOffset; i++) MonthDays.Add(new DayVM()); // Leere Tage

            for (int i = 1; i <= daysInMonth; i++)
            {
                var date = new DateTime(year, month, i);
                var dayVM = new DayVM(date);
                var evDM = new EventVM();
                foreach (var ev in evDM.Events.Where(e => e.StartingTime.Date == date.Date))
                {
                    dayVM.Events.Add(ev);
                }
                MonthDays.Add(dayVM);
            }
        }
        public int GetCalendarYear()
        {
            DateTime now = DateTime.Now;
            return (int)now.Year;
        }
        public int GetCalendarMonth()
        {
            DateTime now = DateTime.Now;
            return (int)now.Month;
        }
    }
}

