using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace casusprogrammeren.Services.Calculation;

public class AlgorithmCalculator
{
    public static IEnumerable<uint> CalculateShortestPath() 
    {
        var graph = new Graph<int, string>();

        graph.AddNode(1);
        graph.AddNode(2);

        graph.Connect(1, 2, 5, "some custom information in edge"); //First node has key equal 1

        ShortestPathResult result = graph.Dijkstra(1, 2); //result contains the shortest path

        var path = result.GetPath();

        return path;
    }
}