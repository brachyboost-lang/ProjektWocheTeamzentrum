using ProjektWocheTeamzentrum.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Threading.Tasks;

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

                string path = GetMembersFilePath();
                if (File.Exists(path))
                {
                    string jsonText = await File.ReadAllTextAsync(path);
                    JsonSerializer.Deserialize<List<User>>(jsonText)?.ForEach(m => members.Add(m));
                    return members;
                }
                // if file doesn't exist, fall through to create default members
            }
            catch (Exception)
            {
                // If reading fails, fall back to default members
                var fallback = CreateDefaultMembers();
                try { await SaveMembersAsync(fallback); } catch { }
                return fallback;
            }

            // file did not exist - create and return default members
            var defaults = CreateDefaultMembers();
            try { await SaveMembersAsync(defaults); } catch { }
            return defaults;
        }
        public static async Task AddMemberAsync(User user)
        {
            try
            {

                string path = GetMembersFilePath();
                List<User> members = new List<User>();
                if (File.Exists(path))
                {
                    string jsonText = await File.ReadAllTextAsync(path);
                    members = JsonSerializer.Deserialize<List<User>>(jsonText) ?? new List<User>();
                }

                members.Add(user);
                await SaveMembersAsync(members);
            }
            catch (Exception ex) 
            {
                List<User> members = new List<User>();
                members.Add(user);
                await SaveMembersAsync(members);
                MessageBox.Show($"Error on Loading Members: {ex.Message} \n\n Loading Fallback Data...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static async Task SaveMembersAsync(List<User> members)
        {
            try
            {
                string jsonText = JsonSerializer.Serialize(members);
                string path = GetMembersFilePath();
                string? dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
                await File.WriteAllTextAsync(path, jsonText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving members file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static List<User> CreateDefaultMembers()
        {
            var members = new List<User>();
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

        private static string GetMembersFilePath()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProjektWocheTeamzentrum");
            return Path.Combine(dir, "members.json");
        }
    }
}
