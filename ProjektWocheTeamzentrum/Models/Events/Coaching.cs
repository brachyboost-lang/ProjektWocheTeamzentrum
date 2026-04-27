using System;
using System.Collections.Generic;
using System.Text;
using ProjektWocheTeamzentrum.Models.Users;

namespace ProjektWocheTeamzentrum.Models.Events
{
    public class Coaching : Event
    {
        User RequestingUser { get; set; }
        List<User> Coaches { get; set; } = new List<User>();
        public Coaching(User requestingUser, DateTime startingTime, string name, int durationInMinutes, string meetingLocation) 
            : base(startingTime, name, durationInMinutes, meetingLocation, 30)
        {
            RequestingUser = requestingUser;
        }
    }
}
