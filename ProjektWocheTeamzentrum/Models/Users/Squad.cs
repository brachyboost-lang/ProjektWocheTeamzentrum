using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Squad
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<User>? Users { get; set; }
        public User? TeamLeader { get; set; }
        public int[] Simulation { get; set; } = Array.Empty<int>();

        public Squad(string name, string description, List<User> users, User teamLeader, int[] simulation)
        {
            Name = name;
            Description = description;
            Users = users;
            TeamLeader = teamLeader;
            Simulation = simulation;
        }
        public Squad(string name, string description, User teamLeader, int[] simulation)
        {
            Name = name;
            Description = description;
            Users = new List<User>();
            TeamLeader = teamLeader;
            Simulation = simulation;
        }
        public Squad(string name, User teamLeader, int[] simulation)
        {
            Name = name;
            Description = string.Empty;
            Users = new List<User>();
            TeamLeader = teamLeader;
            Simulation = simulation;
        }
        public Squad(string name, int[] simulation)
        {
            Name = name;
            Description = string.Empty;
            Users = new List<User>();
            Simulation = simulation;

        }
        public Squad(string name)
        {
            Name = name;
            Description = string.Empty;
            Users = new List<User>();
            Simulation = Array.Empty<int>();
        }
        public Squad() { }
    }
}
