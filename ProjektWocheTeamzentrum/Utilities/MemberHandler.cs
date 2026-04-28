using ProjektWocheTeamzentrum.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
                var fallbackList = new List<User>();
                foreach (var member in fallback)
                { fallbackList.Add(member); }
                return fallbackList;
            }

            // file did not exist - create and return default members
            var defaults = CreateDefaultMembers();
            try { await SaveMembersAsync(defaults); } catch { }
            var defaultsList = new List<User>();
            foreach (var member in defaults)
            { defaultsList.Add(member); }
            return defaultsList;
        }
        public static async Task AddMemberAsync(User user)
        {
            try
            {

                string path = GetMembersFilePath();
                ObservableCollection<User> members = new ObservableCollection<User>();
                if (File.Exists(path))
                {
                    string jsonText = await File.ReadAllTextAsync(path);
                    var memberList = JsonSerializer.Deserialize<List<User>>(jsonText) ?? new List<User>();
                    foreach (var member in memberList)
                    {
                        members.Add(member);
                    }
                }

                members.Add(user);
                await SaveMembersAsync(members);
            }
            catch (Exception ex)
            {
                try
                {

                    ObservableCollection<User> members = new ObservableCollection<User>();
                    members.Add(user);
                    await SaveMembersAsync(members);
                }
                catch
                {
                    MessageBox.Show($"Error on Saving Members: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
        public static async Task SaveMembersAsync(ObservableCollection<User> members)
        {
            try
            {
                List<User> memberList = new List<User>();
                foreach (var member in members)
                { memberList.Add(member); }
                string jsonText = JsonSerializer.Serialize(memberList);
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
        private static async Task SaveSquadsAsync(List<User> members)
        {
            try
            {
                string jsonText = JsonSerializer.Serialize(members);
                string path = GetSquadsFilePath();
                string? dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
                await File.WriteAllTextAsync(path, jsonText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving members file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private static async Task AddToSquadAsync(User user)
        {
            try
            {
                string path = GetSquadsFilePath();
                List<User> squads = new List<User>();
                if (File.Exists(path))
                {
                    string jsonText = await File.ReadAllTextAsync(path);
                    var squadList = JsonSerializer.Deserialize<List<User>>(jsonText) ?? new List<User>();
                    foreach (var member in squadList)
                    {
                        squads.Add(member);
                    }
                }
                squads.Add(user);
                await SaveSquadsAsync(squads);
            }
            catch (Exception ex)
            {
                try
                {
                    List<User> squads = new List<User>();
                    squads.Add(user);
                    await SaveSquadsAsync(squads);
                }
                catch
                {
                    MessageBox.Show($"Error on Saving Squads: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private static async Task RemoveFromSquadAsync(User user)
        {
            try
            {
                string path = GetSquadsFilePath();
                List<User> squads = new List<User>();
                if (File.Exists(path))
                {
                    string jsonText = await File.ReadAllTextAsync(path);
                    var squadList = JsonSerializer.Deserialize<List<User>>(jsonText) ?? new List<User>();
                    foreach (var member in squadList)
                    {
                        squads.Add(member);
                    }
                }
                squads.RemoveAll(u => u.Name == user.Name && u.Team == user.Team);
                await SaveSquadsAsync(squads);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on Removing from Squads: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static ObservableCollection<User> CreateDefaultMembers()
        {
            var members = new ObservableCollection<User>();
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
        private static string GetSquadsFilePath()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProjektWocheTeamzentrum");
            return Path.Combine(dir, "squads.json");
        }
    }
}
