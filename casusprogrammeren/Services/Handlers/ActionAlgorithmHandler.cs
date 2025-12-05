using System.Text;

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
}
