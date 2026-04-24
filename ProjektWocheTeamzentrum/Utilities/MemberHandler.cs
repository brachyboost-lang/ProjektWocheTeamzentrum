using ProjektWocheTeamzentrum.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace ProjektWocheTeamzentrum.Utilities
{
    public static class MemberHandler
    {
      // später über datenbank mit rest api agenten - erstmal nur JSON
        public static List<User> GetAllMembers()
        {
            List<User> members = new List<User>();
            string jsonText = File.ReadAllText("members.json");

            return members;
        }
        public static void AddMember(User user)
        {
            string jsonText = File.ReadAllText("members.json");
            List<User> members = JsonSerializer.Deserialize<List<User>>(jsonText) ?? new List<User>();
            members.Add(user);
            jsonText = JsonSerializer.Serialize(members);
            File.WriteAllText("members.json", jsonText);
        }

    }
}
