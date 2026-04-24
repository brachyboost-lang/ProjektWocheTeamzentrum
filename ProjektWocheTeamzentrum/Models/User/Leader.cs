using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.User
{
    public class Leader : User
    {
        public Leader()
            : base(string.Empty, string.Empty, string.Empty, DateOnly.FromDateTime(DateTime.Now), 90, Array.Empty<int>())
        {
        }

        public Leader(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 90, simulationType)
        {
        }
    }
}
