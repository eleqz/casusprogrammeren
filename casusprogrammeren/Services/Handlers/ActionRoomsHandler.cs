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

    public static string HandleSearchRoom(int capacity)
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
                    sb.AppendLine($"{room.Code}\n");
                }
            }
        }

        return sb.ToString();
    }
    public static string HandleAmountPeoplePresent()
    {
        var sb = new StringBuilder();
        
        var deserializer = new DeserializeFromFile();
        var rooms = deserializer.Deserialize<Rooms>();
        if (rooms != null)
        {
            int? studentAmount = 0;
            int? teacherAmount = 0;
            foreach (var room in rooms)
            {
                if (room.PresentStudents > 0)
                {
                    studentAmount += room.PresentStudents;
                }
                if (room.PresentTeachers > 0)
                {
                    teacherAmount += room.PresentTeachers;
                }
            }
            sb.AppendLine("Aantal aanwezigen: ");
            sb.AppendLine($"Studenten: {Convert.ToString(studentAmount)}");
            sb.AppendLine($"Docenten: {Convert.ToString(teacherAmount)}");
        }

        return sb.ToString();
    }
}
