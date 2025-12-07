using System.Text;
using casusprogrammeren.Services.Calculation;

namespace casusprogrammeren.Services.Handlers;

public class ActionAlgorithmHandler
{
    public static string HandlePseudoCode()
    {
        {
            // TODO: Algoritme afmaken
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
                              determine next_step towards destination
                              show next_step
                              update location











                          \u001b[1mEND\u001b[0m
                          """);
            return sb.ToString();
        }
    }

    public static string HandleAlgorithm()
    {
        var sb = new StringBuilder();
        var path = AlgorithmCalculator.CalculateShortestPath();
    
        sb.AppendLine("Kortste pad is: ");
        sb.AppendLine(string.Join(" -> ", path));
    
        return sb.ToString();
    }

}
