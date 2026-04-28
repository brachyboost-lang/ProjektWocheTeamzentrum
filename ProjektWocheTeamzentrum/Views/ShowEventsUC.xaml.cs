using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektWocheTeamzentrum.ViewModels;

namespace ProjektWocheTeamzentrum.Views
{
    /// <summary>
    /// Interaction logic for ShowEventsUC.xaml
    /// </summary>
    public partial class ShowEventsUC : UserControl
    {
        private CalendarVM? _calendarVm;

        public ShowEventsUC()
        {
            InitializeComponent();
            if (DataContext == null)
                DataContext = new CalendarVM();

            // create a dedicated CalendarVM for the left-side calendar and assign it
            // to the named grid so its bindings (Hours, Days) work regardless of
            // the control's overall DataContext (which may be an EventVM).
            _calendarVm = new CalendarVM();
            try
            {
                CalendarGrid.DataContext = _calendarVm;
                int year = _calendarVm.GetCalendarYear();
                int month = _calendarVm.GetCalendarMonth();
                _calendarVm.BuildCalendar(year, month);
            }
            catch
            {
                // ignore if the named element isn't present at construction time
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // if DataContext is EventVM, ensure the calendar grid is bound or refreshed
            if (DataContext is EventVM evm)
            {
                // no-op: events collection is observable and UI will update automatically
            }
        }

        public void NewEvent_Click(object sender, RoutedEventArgs e)
        {
            // Request the main window to switch the content to CreateEventUC
            var window = Window.GetWindow(this);
            if (window != null && window.DataContext is MainWindowVM vm)
            {
                vm.RequestViewChange?.Invoke(new CreateEventUC());
            }
            else
            {
                // fallback: directly set parent content if main VM not available
                if (window is MainWindow mw)
                {
                    mw.MainContentControl.Content = new CreateEventUC();
                }
            }
        }
    }
}
