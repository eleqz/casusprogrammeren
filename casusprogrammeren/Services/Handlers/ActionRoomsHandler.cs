using System.Text;
using casusprogrammeren.utils;

namespace casusprogrammeren.Services.Handlers;

public class ActionRoomsHandler
{
    // Vraag 1
    public static string HandleAction()
    {
        var sb = new StringBuilder();
        
        var deserializer = new DeserializeFromFile();
        var rooms = deserializer.Deserialize<Rooms>();
        if (rooms != null)
        {
            foreach (var room in rooms)
            {
                sb.AppendLine($"Naam: {room.Name}, " +
                              $"Code: {room.Code}, " +
                              $"Type: {room.Type}, " +
                              $"Inhoud in m3: {room.VolumeM3}, " +
                              $"Capaciteit: {room.CapacityPeople} ");
                
            }
        }

        return sb.ToString();
    }
}
