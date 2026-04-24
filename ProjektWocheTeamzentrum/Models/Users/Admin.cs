using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Admin : User
    {
        public Admin(string firstName, string lastName, string email, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, birthday, 100, simulationType)
        {
        }
        public Admin(string firstName, string lastName, int[]simulationType) : base(firstName, lastName, 100, simulationType)
        {
        }
    }
}
