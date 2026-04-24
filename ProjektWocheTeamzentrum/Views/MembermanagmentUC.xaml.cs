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

namespace ProjektWocheTeamzentrum.Views
{
    /// <summary>
    /// Interaction logic for MembermanagmentUC.xaml
    /// </summary>
    public partial class MembermanagmentUC : UserControl
    {
        
        public MembermanagmentUC()
        {
            InitializeComponent();
        }
        public void ViewMembers(object sender, RoutedEventArgs e)
        {
            MembersListBox.Visibility = Visibility.Visible;
            if (MembersListBox.Visibility == Visibility.Collapsed)
            {
                btnViewMembers.Content = "Show All Members";
            }
            else
            {
                btnViewMembers.Content = "Back";
            }
        }
    }
}
