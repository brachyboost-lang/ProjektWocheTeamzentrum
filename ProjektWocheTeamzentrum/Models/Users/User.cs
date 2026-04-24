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
        // Do not call async methods synchronously in property initializers or constructors.
        // Id will be assigned when the user is persisted.

        public User(string firstName, string lastName, string email, DateOnly birthday, int clearanceLevel, int[] simulationType)
        {
            Id = 0; // placeholder until persisted
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateJoined = DateOnly.FromDateTime(DateTime.Now);
            Birthday = birthday;
            ClearanceLevel = clearanceLevel;
            SimulationType = simulationType;
            // Do not add the user to storage in the constructor to avoid IO side effects during object creation.
        }
        public User(string firstName, string lastName, int clearanceLevel, int[] simulationType)
        {
            Id = 0; // placeholder until persisted
            FirstName = firstName;
            LastName = lastName;
            DateJoined = DateOnly.FromDateTime(DateTime.Now);
            ClearanceLevel = clearanceLevel;
            SimulationType = simulationType;
            // Do not add the user to storage in the constructor to avoid IO side effects during object creation.
        }

    }
}
