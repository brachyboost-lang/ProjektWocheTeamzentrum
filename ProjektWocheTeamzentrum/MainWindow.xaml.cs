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
using ProjektWocheTeamzentrum.Views;
using ProjektWocheTeamzentrum.ViewModels;

namespace ProjektWocheTeamzentrum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModels.MainWindowVM();
            DataContext = vm;
            vm.RequestViewChange += Vm_RequestViewChange;
            // show default view
            vm.RequestViewChange?.Invoke(new ShowEventsUC { DataContext = new EventVM() });
        }

        private void Vm_RequestViewChange(UserControl? view)
        {
            MainContentControl.Content = view;
        }

        public void EventUC_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new ShowEventsUC { DataContext = new EventVM() };
        }

        public void UsermanagmentUC_Click(object sender, RoutedEventArgs e)
        {
            MembermanagmentVM membermanagmentVM = new MembermanagmentVM();
            MainContentControl.Content = new MembermanagmentUC { DataContext = membermanagmentVM };
        }

        public void CoachingUC_Click(object sender, RoutedEventArgs e)
        {
            // TODO: switch to Coaching view
        }

        public void SettingsUC_Click(object sender, RoutedEventArgs e)
        {
            // TODO: switch to Settings view
        }
    }
}