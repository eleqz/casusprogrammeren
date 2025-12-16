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


    public class DeserializeFromFile
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
    }
}
