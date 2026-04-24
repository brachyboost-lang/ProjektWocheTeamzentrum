using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Admin : User
    {
        public Admin()
            : base(string.Empty, string.Empty, string.Empty, DateOnly.FromDateTime(DateTime.Now), 100, Array.Empty<int>())
        {
        }

        public Admin(string firstName, string lastName, string email, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, birthday, 100, simulationType)
        {
        }
    }
}
