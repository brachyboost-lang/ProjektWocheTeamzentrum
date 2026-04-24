using ProjektWocheTeamzentrum.Models.Users;
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
        public static async Task<List<User>> GetAllMembersAsync()
        {
            List<User> members = new List<User>();
            string jsonText = File.ReadAllText("members.json");
            JsonSerializer.Deserialize<List<User>>(jsonText)?.ForEach(m => members.Add(m));
            return members;
        }
        public static void AddMember(User user)
        {
            string jsonText = File.ReadAllText("members.json");
            List<User> members = JsonSerializer.Deserialize<List<User>>(jsonText) ?? new List<User>();
            members.Add(user);
            SaveMembers(members);
        }
        public static void SaveMembers(List<User> members)
        {
            string jsonText = JsonSerializer.Serialize(members);
            File.WriteAllText("members.json", jsonText);
        }
    }
}
