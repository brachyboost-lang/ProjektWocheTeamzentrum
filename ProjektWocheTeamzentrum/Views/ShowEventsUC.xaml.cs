using ProjektWocheTeamzentrum.Models.Events;
using ProjektWocheTeamzentrum.ViewModels;
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
using ProjektWocheTeamzentrum.Utilities;

namespace ProjektWocheTeamzentrum.Views
{
    /// <summary>
    /// Interaction logic for ShowEventsUC.xaml
    /// </summary>
    public partial class ShowEventsUC : UserControl
    {
        private CalendarVM? _calendarVm;
        private EventVM _eventVm;

        public ShowEventsUC()
        {
            InitializeComponent();


            _eventVm = new EventVM();
            _calendarVm = new CalendarVM();


            CalendarGrid.DataContext = _calendarVm;

            SortedEventsList.ItemsSource = _eventVm.Events;

            _ = _eventVm.InitializeEvents();
            _ = _calendarVm.BuildCalendar(DateTime.Now.Year, DateTime.Now.Month);
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
        private async void Event_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var border = sender as FrameworkElement;
            if (border?.DataContext is Event clickedEvent)
            {

                string details = await EventUtil.GetEventDetails(clickedEvent);

 
                MessageBox.Show(details, $"Details für: {clickedEvent.Name}");
            }
        }

        private async void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            var selectedEvent = SortedEventsList.SelectedItem as Event;

            if (selectedEvent != null)
            {
                bool success = await EventUtil.DeleteEventAsync(selectedEvent.EventId);

                if (success)
                {
                    _eventVm.Events.Remove(selectedEvent);
                    MessageBox.Show("Event erfolgreich gelöscht!");
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle zuerst ein Event in der Liste aus.");
            }
        }
    }
}
