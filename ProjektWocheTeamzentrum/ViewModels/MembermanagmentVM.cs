using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ProjektWocheTeamzentrum.Models.User;
using ProjektWocheTeamzentrum.Utilities;

namespace ProjektWocheTeamzentrum.ViewModels
{
    class MembermanagmentVM
    {
        public ObservableCollection<User> Members { get; set; } = new ObservableCollection<User>();
        public string Name { get; set; } = string.Empty;
        public User SelectedMember { get; set; } = null!;
    public void InitializeMembers()
        {
            List<User> members = new List<User>();
            members = MemberHandler.GetAllMembers();
            foreach (var member in members)
            {
                Members.Add(member);
            }
        }
    }
}
