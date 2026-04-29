using ProjektWocheTeamzentrum.Utilities;
using ProjektWocheTeamzentrum.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        public RelayCommand ShowEventsCommand => new RelayCommand(execute => ShowEvents());
        public RelayCommand ShowUsermanagementCommand => new RelayCommand(execute => ShowUsermanagement());
        public RelayCommand ShowCoachingCommand => new RelayCommand(execute => ShowCoaching());
        public RelayCommand ShowSettingsCommand => new RelayCommand(execute => ShowSettings());

        public Action<UserControl?>? RequestViewChange;

        private void ShowEvents()
        {
            RequestViewChange?.Invoke(new ShowEventsUC { DataContext = new EventVM() });
        }
        private void ShowUsermanagement()
        {
            RequestViewChange?.Invoke(new MembermanagmentUC { DataContext = new MembermanagmentVM() });
        }
        private void ShowCoaching()
        {
            RequestViewChange?.Invoke(new RequestCoachingUC());
        }
        private void ShowSettings()
        {
            RequestViewChange?.Invoke(new SettingsUC());
        }
    }
}
