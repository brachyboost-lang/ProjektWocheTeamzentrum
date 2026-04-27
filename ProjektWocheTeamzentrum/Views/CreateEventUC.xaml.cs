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
    /// Interaction logic for CreateEventUC.xaml
    /// </summary>
    public partial class CreateEventUC : UserControl
    {
        public string SelectedSimulation { get; set; } = string.Empty;
        public CreateEventUC()
        {
            InitializeComponent();
            EventVM DC = new EventVM();
            DataContext = DC;
        }
        private void SimulationRadio_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            SelectedSimulation = rb.Tag?.ToString() ?? string.Empty;

            switch (SelectedSimulation)
            {
                case "All":
                    CarClassContentControl.ContentTemplate = (DataTemplate)Resources["AllTemplate"];
                    break;
                case "LMU":
                    CarClassContentControl.ContentTemplate = (DataTemplate)Resources["LMUTemplate"];
                    break;
                case "ACC":
                    CarClassContentControl.ContentTemplate = (DataTemplate)Resources["ACCTemplate"];
                    break;
                case "IR":
                    CarClassContentControl.ContentTemplate = (DataTemplate)Resources["iRacingTemplate"];
                    break;
            }
        }
        private void Broadcast_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var cc = FindSiblingContentControl(rb, "LivestreamContentControl");
            if (cc != null)
                cc.ContentTemplate = (DataTemplate)Resources["LivestreamTemplate"];
        }

        private void League_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var cc = FindSiblingContentControl(rb, "LeagueContentControl");
            if (cc != null)
                cc.ContentTemplate = (DataTemplate)Resources["LeagueTemplate"];
        }

        private void MaxParticipants_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var cc = FindSiblingContentControl(rb, "MaxParticipantsContentControl");
            if (cc != null)
                cc.ContentTemplate = (DataTemplate)Resources["MaxParticipantsTemplate"];
        }

        private void MaxDriversPerCar_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var cc = FindSiblingContentControl(rb, "MaxDriversPerCarContentControl");
            if (cc != null)
                cc.ContentTemplate = (DataTemplate)Resources["MaxDriversPerCarTemplate"];

        }

        private void CreateEvent_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // placeholder - clear fields or close
            MessageBox.Show("Cancel clicked");
        }

        // Helper: search up the visual tree and find a ContentControl with the given name
        private ContentControl FindSiblingContentControl(DependencyObject start, string controlName)
        {
            if (start == null || string.IsNullOrEmpty(controlName)) return null;

            DependencyObject current = start;
            while (current != null)
            {
                var found = FindContentControlIn(current, controlName);
                if (found != null) return found;
                current = VisualTreeHelper.GetParent(current);
            }

            return null;
        }

        private ContentControl FindContentControlIn(DependencyObject parent, string controlName)
        {
            if (parent == null) return null;
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (child is ContentControl cc && cc.Name == controlName) return cc;
                var deeper = FindContentControlIn(child, controlName);
                if (deeper != null) return deeper;
            }
            return null;
        }
    }
}
