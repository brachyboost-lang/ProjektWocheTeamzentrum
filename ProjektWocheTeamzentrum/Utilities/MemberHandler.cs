using ProjektWocheTeamzentrum.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace ProjektWocheTeamzentrum.Utilities
{
    public static class MemberHandler
    {
        // später über datenbank mit rest api agenten - erstmal nur JSON
        public static async Task<List<User>> GetAllMembersAsync()
        {
                List<User> members = new List<User>();
            try
            {

                string jsonText = await File.ReadAllTextAsync("members.json");
                JsonSerializer.Deserialize<List<User>>(jsonText)?.ForEach(m => members.Add(m));
                return members;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Mitglieder: {ex.Message} \n\n Lade Standardmitglieder...", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                members.Add(new Admin("Team", "Admin", new int[] { 0, 1, 2, 3 }));
                members.Add(new Member("LMU", "Member1", new int[] { 1 }));
                members.Add(new Member("LMU", "Member2", new int[] { 1 }));
                members.Add(new Member("LMU", "Member3", new int[] { 1 }));
                members.Add(new Member("LMU", "Member4", new int[] { 1 }));
                members.Add(new Member("LMU", "Member5", new int[] { 1 }));
                members.Add(new Member("LMU", "Member6", new int[] { 1 }));
                members.Add(new Member("LMU", "Member7", new int[] { 1 }));
                members.Add(new Member("LMU", "Member8", new int[] { 1 }));
                members.Add(new Member("ACC", "Member1", new int[] { 2 }));
                members.Add(new Member("ACC", "Member2", new int[] { 2 }));
                members.Add(new Member("ACC", "Member3", new int[] { 2 }));
                members.Add(new Member("ACC", "Member4", new int[] { 2 }));
                members.Add(new Member("ACC", "Member5", new int[] { 2 }));
                members.Add(new Member("ACC", "Member6", new int[] { 2 }));
                members.Add(new Member("ACC", "Member7", new int[] { 2 }));
                members.Add(new Member("ACC", "Member8", new int[] { 2 }));
                members.Add(new Member("iRacing", "Member1", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member2", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member3", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member4", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member5", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member6", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member7", new int[] { 3 }));
                members.Add(new Member("iRacing", "Member8", new int[] { 3 }));
                members.Add(new Guest("Team", "Guest", new int[] { 0 }));
                members.Add(new Coach("Team", "Coach", new int[] { 0, 1, 2, 3 }));
                members.Add(new Leader("Team", "Leader", new int[] { 0, 1, 2, 3 }));
                members.Add(new Leader("LMU", "Leader", new int[] { 1 }));
                members.Add(new Leader("ACC", "Leader", new int[] { 2 }));
                members.Add(new Leader("iRacing", "Leader", new int[] { 3 }));

                return members;
            }
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
