
using System.Text.Json;

namespace casusprogrammeren.utils
{
    public class Rooms
    {
        public string? Type { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? VolumeM3 { get; set; }
        public int? CapacityPeople { get; set; }
        public int? PresentStudents { get; set; }
        public int? PresentTeachers { get; set; }
        public float? DurationHours { get; set; }
        public string? Activity { get; set; }
    }

    public class Occupance
    {
        public string Month { get; set; }
        public List<Building> Buildings { get; set; }
    }

    public class Building
    {
        public string Name { get; set; }
        public int TotalRooms { get; set; }
        public double OccupiedDays { get; set; }
    }
    
    public class ScheduleRequests
    {
        public int Id { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedTime { get; set; }
        public TimePreference TimePreferences { get; set; }
        public List<string> Preferences { get; set; }
        public int DurationMinutes { get; set; }
    }

    public class TimePreference
    {
        public DateTime Earliest { get; set; }
        public DateTime Latest { get; set; }
    }

    public class ScheduledRequests
    {
        public string Id { get; set; }
        public string ScheduledRoom { get; set; }
        public DateTime ScheduledStartTime { get; set; }
        public DateTime ScheduledEndTime { get; set; }
    }


    public class JsonUtil
    {
        public string? filePath { get; private set; }

        public List<T>? Deserialize<T>() where T : class
        {
            filePath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\" +
                           $"{typeof(T).Name}.json";
            string jsonString = File.ReadAllText(filePath);
        
            List<T>? list = JsonSerializer.Deserialize<List<T>>(jsonString);
        
            return list;
        }
        
        public void Serialize<T>(List<T> list, string jsonFile)
        {
            filePath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\" +
                       $"{jsonFile}";
            string jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
