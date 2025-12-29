using System.Text;
using casusprogrammeren.Services.Calculation;

namespace casusprogrammeren.Services.Handlers;

public class ActionAlgorithmHandler
{
    public static string HandlePseudoCode()
    {
        {
            var sb = new StringBuilder();
            sb.AppendLine("""
                          PseudoCode
                          
                          START
                          int location initial_position
                          string destination = roomcode
                          convert roomcode to integer destination_position

                          if location == destination_position then
                              print "You have arrived at your destination"
                          else 
                              location != destination do
                              determine next_step towards destination with dijkstra
                              show next_step
                              update location
                          END
                          """);
            return sb.ToString();
        }
    }

    public static string HandleAlgorithm()
    {
        var sb = new StringBuilder();
        var path = Algorithm.CalculateShortestPath(1, 11);
        var nodeNames = new Dictionary<uint, string>
        {
            { 1, "Ingang" },
            { 2, "Trap naar brug" },
            { 3, "Lift naar brug" },
            { 4, "Brug" },
            { 5, "Lift Prisma" },
            { 6, "Eerste verdieping Prisma" },
            { 7, "Tweede Verdieping Prisma" },
            { 8, "Derde Verdieping Prisma" },
            { 9, "Hart van ICT rechts" },
            { 10, "Hart van ICT links" },
            { 11, "ICT-Lokaal" }
        };

        sb.AppendLine("Kortste pad is: ");
        sb.AppendLine(string.Join(" -> ", path.Select(id => nodeNames[id])));

        return sb.ToString();
    }
}
