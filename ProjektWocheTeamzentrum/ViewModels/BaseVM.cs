using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class BaseVM : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
