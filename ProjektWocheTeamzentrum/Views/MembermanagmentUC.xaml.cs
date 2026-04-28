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
    /// Interaction logic for MembermanagmentUC.xaml
    /// </summary>
    public partial class MembermanagmentUC : UserControl
    {
        
        public MembermanagmentUC()
        {
            InitializeComponent();
            DataContext = new MembermanagmentVM();
        }

        public void ViewMembers_Click(object sender, RoutedEventArgs e)
        {
            MembersListBox.Visibility = MembersListBox.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            if (MembersListBox.Visibility == Visibility.Collapsed)
            {
                btnViewMembers.Content = "Show Members";
                StatsPanel.Visibility = Visibility.Visible;
            }
            else
            {
                btnViewMembers.Content = "Hide Members";
                StatsPanel.Visibility = Visibility.Collapsed;
            }
        }

        public void AddMember_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement add member logic
            // May be obsolete when syncing over DB or discord login
        }

        public void DeleteMember_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement delete member logic
            // May be obsolete when syncing over DB or discord login
        }

        public void EditMember_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement edit member logic
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {

            //Placeholder for Add to Squad Logic
        }
    }
}
