using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjektWocheTeamzentrum.Models.Users;
using ProjektWocheTeamzentrum.Utilities;
using System.Linq;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class MembermanagmentVM : BaseVM
    {
        public ObservableCollection<User> Members { get; set; } = new ObservableCollection<User>();
        public RelayCommand AddMemberCommand { get; }
        public RelayCommand DeleteMemberCommand { get; }
        public RelayCommand AddToSquadCommand { get; }
        public RelayCommand RemoveFromSquadCommand { get; }
        public ObservableCollection<User> Squads { get; set; } = new ObservableCollection<User>();
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int TotalMembers { get => Members.Count; }

        private User? _selectedMember;
        public User? SelectedMember
        {
            get => _selectedMember;
            set
            {
                if (_selectedMember != value)
                {
                    _selectedMember = value;
                    OnPropertyChanged(nameof(SelectedMember));
                }
            }
        }

        public User LoggedInUser { get; set; }
        public bool canAdd { get => LoggedInUser != null && LoggedInUser.ClearanceLevel >= 90; }

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
                // ensure TotalMembers updates are propagated
                OnPropertyChanged(nameof(TotalMembers));
            }
            catch (Exception ex)
            {
                MessageBoxButton messageBoxButton = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(ex.Message, "Error", messageBoxButton);
            }
        }
        public MembermanagmentVM()
        {
            // default logged in user for design/runtime - can be replaced by actual auth
            LoggedInUser = new Admin("Team", "Admin", new int[] { 0, 1, 2, 3 });

            AddMemberCommand = new RelayCommand(async _ => await AddMemberAsync(), _ => canAdd);
            DeleteMemberCommand = new RelayCommand(async _ => await DeleteSelectedMemberAsync(), _ => canAdd && SelectedMember != null);

            // update TotalMembers when collection changes
            Members.CollectionChanged += Members_CollectionChanged;

            // Start initialization without blocking the UI thread. Waiting synchronously causes a deadlock in WPF.
            _ = InitializeMembersAsync();

        }

        private void Members_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalMembers));
            OnPropertyChanged(nameof(Squads));
        }

        public int SquadsCount => Squads.Count();

        public async Task AddMemberAsync()
        {
            try
            {
                // Basic validation
                if (string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName))
                    return;

                var newMember = new Member(FirstName, LastName, new int[] { 0 });
                await MemberHandler.AddMemberAsync(newMember);
                Members.Add(newMember);
                // clear input
                FirstName = string.Empty;
                LastName = string.Empty;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(TotalMembers));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding member: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task DeleteSelectedMemberAsync()
        {
            if (SelectedMember == null) return;
            try
            {
                Members.Remove(SelectedMember);
                await MemberHandler.SaveMembersAsync(Members);
                SelectedMember = null;
                OnPropertyChanged(nameof(TotalMembers));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting member: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public async Task AddToSquadAsync()
        {
            if (SelectedMember == null) return;
            try
            {
                if (!Squads.Contains(SelectedMember))
                {
                    Squads.Add(SelectedMember);
                    OnPropertyChanged(nameof(SquadsCount));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to squad: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public async Task RemoveFromSquadAsync()
        {
            if (SelectedMember == null) return;
            try
            {
                if (Squads.Contains(SelectedMember))
                {
                    Squads.Remove(SelectedMember);
                    OnPropertyChanged(nameof(SquadsCount));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing from squad: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
