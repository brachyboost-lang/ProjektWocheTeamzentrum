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
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var item in doc.RootElement.EnumerateArray())
                        {
                            // new wrapper format: { "EventType": "Race", "Event": { ... } }
                            if (item.ValueKind == JsonValueKind.Object && item.TryGetProperty("EventType", out var tprop) && item.TryGetProperty("Event", out var eprop))
                            {
                                var typeName = tprop.GetString();
                                var raw = eprop.GetRawText();
                                if (string.Equals(typeName, "Race", StringComparison.OrdinalIgnoreCase))
                                {
                                    var race = JsonSerializer.Deserialize<Race>(raw);
                                    if (race != null) events.Add(race);
                                }
                                else
                                {
                                    var ev = JsonSerializer.Deserialize<Event>(raw);
                                    if (ev != null) events.Add(ev);
                                }
                            }
                            else
                            {
                                // old simple array of Event/Race objects - try to detect Race by available properties
                                var raw = item.GetRawText();
                                // attempt Race first
                                try
                                {
                                    var race = JsonSerializer.Deserialize<Race>(raw);
                                    if (race != null && (race.CarClasses?.Count > 0 || race.SimulationType != 0))
                                    {
                                        events.Add(race);
                                        continue;
                                    }
                                }
                                catch { }

                                try
                                {
                                    var ev = JsonSerializer.Deserialize<Event>(raw);
                                    if (ev != null) events.Add(ev);
                                }
                                catch { }
                            }
                        }
                    }
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
                // wrap each event with its concrete type name so we can deserialize polymorphically later
                var wrappers = new List<object>();
                foreach (var e in events)
                {
                    wrappers.Add(new { EventType = e.GetType().Name, Event = e });
                }
                string json = JsonSerializer.Serialize(wrappers, new JsonSerializerOptions { WriteIndented = true });
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
