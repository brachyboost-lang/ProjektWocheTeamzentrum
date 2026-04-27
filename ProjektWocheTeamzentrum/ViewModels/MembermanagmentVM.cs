using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Utilities;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class MembermanagmentVM : BaseVM
    {
        public ObservableCollection<User> Members { get; set; } = new ObservableCollection<User>();
        public string Name { get; set; } = string.Empty;
        public User SelectedMember { get; set; } = null!;

        public async Task InitializeMembersAsync()
        {
            try
            {
                List<User> members = new List<User>();
                members = await MemberHandler.GetAllMembersAsync();
                foreach (var member in members)
                {
                    Members.Add(member);
                }
            }
            catch (Exception ex)
            {
                MessageBoxButton messageBoxButton = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(ex.Message, "Error", messageBoxButton);
            }
        }
        public MembermanagmentVM()
        {
            // Start initialization without blocking the UI thread. Waiting synchronously causes a deadlock in WPF.
            _ = InitializeMembersAsync();
        }
    }
}
