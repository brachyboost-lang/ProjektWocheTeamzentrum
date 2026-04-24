using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Guest : User
    {
        public Guest(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 5, simulationType)
        {
        }
    }
}
