using System.Text;
using casusprogrammeren.Services.Calculation;
using casusprogrammeren.utils;

namespace casusprogrammeren.Services.Handlers;

public class ActionOxygenHandler
{
    public static string HandleOxygenUsedCalculator()
    {
        var sb = new StringBuilder();
        
        var jsonUtil = new JsonUtil();
        var rooms = jsonUtil.Deserialize<Rooms>();
        if (rooms != null)
        {
            sb.AppendLine("Bij 27 personen en 2 uur in het lokaal is er: ");
            foreach (var room in rooms)
            {
                if (OxygenCalculator.CalculateOxygenNotUsedTwoHours(room.VolumeM3 ?? 0) < 0)
                {
                    sb.AppendLine("Error!, slechte gegevens voor dit lokaal.");
                }
                else
                {
                    sb.AppendLine(OxygenCalculator.CalculateOxygenUsedTwoHours() +
                                  $" liter gebruikte zuurstof in {room.Code} ");
                    sb.AppendLine(OxygenCalculator.CalculateOxygenNotUsedTwoHours(room.VolumeM3 ?? 0) +
                                  $" liter zuurstof over in {room.Code} ");
                }
            }

        }
        return sb.ToString();
    }
    
    public static string HandleMaximumOxygenConsumptionCalculator()
    {
        var sb = new StringBuilder();
        
        var jsonUtil = new JsonUtil();
        var rooms = jsonUtil.Deserialize<Rooms>();
        if (rooms != null)
        {
            foreach (var room in rooms)
            {
                if (OxygenCalculator.CalculateMaximumOxygenConsumption(room.VolumeM3 ?? 0) < 0)
                {
                    sb.AppendLine("Error!, slechte gegevens voor dit lokaal.");
                }
                else
                {
                    sb.AppendLine($"Maximale consumptie aan zuurstof in {room.Code} is " +
                                  OxygenCalculator.CalculateMaximumOxygenConsumption(room.VolumeM3 ?? 0) + " liter");
                }
            }
                        
        }
        
        return sb.ToString();
    }
}
