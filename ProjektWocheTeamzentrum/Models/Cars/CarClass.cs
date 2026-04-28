using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ProjektWocheTeamzentrum.Models.Cars
{
    public class CarClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

        public string Name { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new List<Car>();
        public int SimulationType { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
    }
}
