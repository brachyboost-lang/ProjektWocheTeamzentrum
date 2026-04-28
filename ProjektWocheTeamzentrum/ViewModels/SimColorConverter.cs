using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ProjektWocheTeamzentrum.ViewModels
{
    public class SimColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int simType = (int)value;
            return simType switch
            {
                1 => Brushes.Red, // LMU
                2 => Brushes.LightBlue,  // ACC
                3 => Brushes.Purple,     // iRacing
                _ => Brushes.LightGray   // Andere
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

