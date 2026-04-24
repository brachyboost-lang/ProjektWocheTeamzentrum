using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWocheTeamzentrum.Models.Users
{
    public class Member : User
    {
        public Member()
            : base(string.Empty, string.Empty, string.Empty, DateOnly.FromDateTime(DateTime.Now), 30, Array.Empty<int>())
        {
        }

        public Member(string firstName, string lastName, string email, DateOnly dateJoined, DateOnly birthday, int[] simulationType)
            : base(firstName, lastName, email, dateJoined, 30, simulationType)
        {
        }
    }
}
