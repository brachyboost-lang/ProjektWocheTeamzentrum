using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Coach : User
    {
        public Coach(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 70, simulationType)
        {
        }
        public Coach(string firstName, string lastName, int[] simulationType) : base(firstName, lastName, 70, simulationType)
        {
        }
    }
}
