using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace ProjektWocheTeamzentrum.Models.Cars
{
    public class Car
    {
        public string Constructor { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; // alternativ falls damit einfacher umzugehen ist

        public Car() { }

        public Car(string name)
        {
            Name = name;
        }
        public Car(string constructor, string model) 
        {
            Constructor = constructor;
            Model = model;
        }
    }
}
