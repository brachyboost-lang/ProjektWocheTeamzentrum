using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Guest : User
    {
        public Guest()
            : base(string.Empty, string.Empty, string.Empty, DateOnly.FromDateTime(DateTime.Now), 5, Array.Empty<int>())
        {
        }

        public Guest(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 5, simulationType)
        {
        }
    }
}
