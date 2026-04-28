using ProjektWocheTeamzentrum.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ProjektWocheTeamzentrum.Utilities;

namespace ProjektWocheTeamzentrum.ViewModels
{
    class CalendarVM
    {
        public List<string> Hours { get; set; }
        public List<DayVM> Days { get; set; }

        public CalendarVM()
        {
            Hours = Enumerable.Range(0, 24).Select(h => $"{h:00}:00").ToList();

            // Initialisiere mit dem aktuellen Datum
            _ = BuildCalendar(DateTime.Now.Year, DateTime.Now.Month);
        }
        public ObservableCollection<DayVM> MonthDays { get; } = new ObservableCollection<DayVM>();
        public async Task BuildCalendar(int year, int month)
        {
            var allEvents = await EventUtil.GetAllEventsAsync();

            MonthDays.Clear();
            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDayOffset = (int)firstDay.DayOfWeek == 0 ? 6 : (int)firstDay.DayOfWeek - 1;

            for (int i = 0; i < startDayOffset; i++) MonthDays.Add(new DayVM(DateTime.MinValue));

            for (int i = 1; i <= daysInMonth; i++)
            {
                var date = new DateTime(year, month, i);
                var dayVM = new DayVM(date);

                // KORREKTUR: Filter hier die 'allEvents' Liste!
                foreach (var ev in allEvents.Where(e => e.StartingTime.Date == date.Date))
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

