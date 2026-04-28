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
    /// Interaction logic for CoachingUC.xaml
    /// </summary>
    public partial class CoachingUC : UserControl
    {
        public CoachingUC()
        {
            InitializeComponent();
            DataContext = new CoachingVM();
        }
    }
}
