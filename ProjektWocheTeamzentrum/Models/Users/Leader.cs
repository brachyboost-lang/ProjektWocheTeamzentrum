using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Leader : User
    {
        public Leader(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 90, simulationType)
        {
        }
    }
}
