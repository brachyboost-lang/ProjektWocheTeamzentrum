using ProjektWocheTeamzentrum.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class User
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DateJoined { get; set; }
        public DateOnly Birthday { get; set; }
        public int ClearanceLevel { get; set; } = 0;
        public int[] SimulationType { get; set; }
        public int idHandler { get; set; } = MemberHandler.GetAllMembersAsync().Result.Count + 1; // wird später durch datenbank mit auto increment ersetzt

        public User(string firstName, string lastName, string email, DateOnly birthday, int clearanceLevel, int[] simulationType)
        {
            Id = idHandler; // wird später durch datenbank mit auto increment ersetzt
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateJoined = DateOnly.FromDateTime(DateTime.Now);
            Birthday = birthday;
            ClearanceLevel = clearanceLevel;
            SimulationType = simulationType;
            MemberHandler.AddMember(this);
        }
        public User(string firstName, string lastName, int clearanceLevel, int[] simulationType)
        {
            Id = idHandler; // wird später durch datenbank mit auto increment ersetzt
            FirstName = firstName;
            LastName = lastName;
            DateJoined = DateOnly.FromDateTime(DateTime.Now);
            ClearanceLevel = clearanceLevel;
            SimulationType = simulationType;
            MemberHandler.AddMember(this);
        }

    }
}
