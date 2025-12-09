using System.Text;
using casusprogrammeren.Services.Calculation;
using casusprogrammeren.utils;

namespace casusprogrammeren.Services.Handlers;

public class ActionOxygenHandler
{
    public static string HandleOxygenUsedCalculator()
    {
        var sb = new StringBuilder();
        
        var deserializer = new DeserializeFromFile();
        var rooms = deserializer.Deserialize<Rooms>();
        if (rooms != null)
        {
            sb.AppendLine("Bij 27 personen en 2 uur in het lokaal is er: ");
            foreach (var room in rooms)
            {
                sb.AppendLine(OxygenCalculator.CalculateOxygenUsedTwoHours() +
                              $" liter gebruikte zuurstof in {room.Code} ");
                sb.AppendLine(OxygenCalculator.CalculateOxygenNotUsedTwoHours(room.VolumeM3 ?? 0) +
                              $" liter zuurstof over in {room.Code} ");
            }

        }
        return sb.ToString();
    }
    
    public static string HandleMaximumOxygenConsumptionCalculator()
    {
        var sb = new StringBuilder();
        
        var deserializer = new DeserializeFromFile();
        var rooms = deserializer.Deserialize<Rooms>();
        if (rooms != null)
        {
            foreach (var room in rooms)
            {
                sb.AppendLine($"Maximale consumptie aan zuurstof in {room.Code} is " + 
                              OxygenCalculator.CalculateMaximumOxygenConsumption(room.VolumeM3 ?? 0) + " liter");
            }
                        
        }
        
        return sb.ToString();
    }
}
