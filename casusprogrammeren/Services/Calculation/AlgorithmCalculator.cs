using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace casusprogrammeren.Services.Calculation;

public class AlgorithmCalculator
{
    public static IEnumerable<uint> CalculateShortestPath()
    {
        var graph = new Graph<int, string>();

        // Add nodes
        graph.AddNode(1);
        graph.AddNode(2);
        graph.AddNode(3);
        graph.AddNode(4);
        graph.AddNode(5);

        // Connect nodes with weights
        graph.Connect(1, 2, 5, "connection 1-2");
        graph.Connect(1, 3, 3, "connection 1-3");
        graph.Connect(2, 4, 2, "connection 2-4");
        graph.Connect(3, 4, 6, "connection 3-4");
        graph.Connect(3, 5, 4, "connection 3-5");
        graph.Connect(4, 5, 1, "connection 4-5");

        ShortestPathResult result = graph.Dijkstra(1, 5); 

        var path = result.GetPath();

        return path;
    }
}