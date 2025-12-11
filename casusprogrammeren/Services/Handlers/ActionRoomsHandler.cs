using System.Text;
using casusprogrammeren.utils;

namespace casusprogrammeren.Services.Handlers;

public class ActionRoomsHandler
{
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

    public static string HandleReservationRoom(int capacity)
    {
        var sb = new StringBuilder();
        
        var deserializer = new DeserializeFromFile();
        var rooms = deserializer.Deserialize<Rooms>();
        if (rooms != null)
        {
            foreach (var room in rooms)
            {
                if (capacity <= room.CapacityPeople)
                {
                    sb.AppendLine($"\n{room.Code} ");
                }
            }
        }

        return sb.ToString();
    }
}
