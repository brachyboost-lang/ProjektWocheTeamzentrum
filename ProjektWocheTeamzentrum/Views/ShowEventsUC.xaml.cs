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
        public ShowEventsUC()
        {
            InitializeComponent();
            if (DataContext == null)
                DataContext = new CalendarVM();
        }

        public void NewEvent_Click(object sender, RoutedEventArgs e)
        {
            // Request the main window to switch the content to CreateEventUC
            var window = Window.GetWindow(this);
            if (window != null && window.DataContext is ViewModels.MainWindowVM vm)
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
