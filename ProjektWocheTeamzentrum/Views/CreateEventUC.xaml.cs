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
            DataContext = new EventVM();
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
        private void AddCarClass_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
