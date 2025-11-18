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
        public static void Deserialize(string file)
        {
            
            string fileName = $"C:\\Users\\racia\\RiderProjects\\casusprogrammeren\\casusprogrammeren\\{file}.json";
            string jsonString = File.ReadAllText(fileName);
            
            if (file == "Rooms") {
                List<Rooms> rooms = JsonSerializer.Deserialize<List<Rooms>>(jsonString)!;

                if (rooms == null) return;

                foreach (var room in rooms)
                {
                    Console.WriteLine($"Type: {room.Type}");
                    Console.WriteLine($"Code: {room.Code}");
                    Console.WriteLine($"Activity: {room.Activity}");
                }
            }
        }

    }
}
