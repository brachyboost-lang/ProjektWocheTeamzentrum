using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.User
{
    public class Coach : User
    {
        public Coach()
            : base(string.Empty, string.Empty, string.Empty, DateOnly.FromDateTime(DateTime.Now), 50, Array.Empty<int>())
        {
        }

        public Coach(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 50, simulationType)
        {
        }
    }
}
