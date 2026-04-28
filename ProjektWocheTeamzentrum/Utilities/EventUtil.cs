using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjektWocheTeamzentrum.Models.Events;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace ProjektWocheTeamzentrum.Utilities
{
    public static class EventUtil
    {
        public static async Task<List<Event>> GetAllEventsAsync()
        {
            List<Event> events = new List<Event>();
            try
            {
                string path = GetEventsFilePath();
                if (File.Exists(path))
                {
                    string json = await File.ReadAllTextAsync(path);
                    JsonSerializer.Deserialize<List<Event>>(json)?.ForEach(e => events.Add(e));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on Loading Events: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return events;
        }
        public static async Task<bool> AddEventAsync(Event newEvent)
        {
            try
            {
                List<Event> events = await GetAllEventsAsync();

                // assign EventId here so constructor doesn't need to call async code
                int nextId = 1;
                if (events.Count > 0) nextId = events[^1].EventId + 1;
                newEvent.EventId = nextId;
                events.Add(newEvent);
                await SaveEventsAsync(events);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding event: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static async Task SaveEventsAsync(List<Event> events)
        {
            try
            {
                string json = JsonSerializer.Serialize(events, new JsonSerializerOptions { WriteIndented = true });
                string path = GetEventsFilePath();
                string? dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
                await File.WriteAllTextAsync(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving events file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static string GetEventsFilePath()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProjektWocheTeamzentrum");
            return Path.Combine(dir, "events.json");
        }
    }
}
