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
        public int? PresentPeople { get; set; }
        public float? DurationHours { get; set; }
        public string? Activity { get; set; }
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
