using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace casusprogrammeren.Services.Calculation;

public class AlgorithmCalculator
{
    public static IEnumerable<uint> CalculateShortestPath(int startNodeId, int endNodeId)
    {
        var graph = new Graph<int, string>();
        var nodeMapping = new Dictionary<int, uint>();
        int[] nodeIds = {
            1,   // Entrance
            2,   // Stairs
            3,   // Elevator Spectrum
            4,   // Bridge
            5,   // Elevator Prisma
            6,   // First floor Prisma
            7,   // Second floor Prisma
            8,   // Third floor Prisma
            9,   // Hart van ICT rechts
            10,  // Hart van ICT links
            11   // Room IT
        };

        foreach (var nodeId in nodeIds)
        {
            nodeMapping[nodeId] = graph.AddNode(nodeId);
        }

        // Entrance to Stairs and Elevator Spectrum
        graph.Connect(nodeMapping[1], nodeMapping[2], 5, "Entrance-Stairs");
        graph.Connect(nodeMapping[2], nodeMapping[1], 5, "Stairs-Entrance");
        graph.Connect(nodeMapping[1], nodeMapping[3], 7, "Entrance-ElevatorSpectrum");
        graph.Connect(nodeMapping[3], nodeMapping[1], 7, "ElevatorSpectrum-Entrance");

        // Stairs and Elevator Spectrum to Bridge
        graph.Connect(nodeMapping[2], nodeMapping[4], 5, "Stairs-Bridge");
        graph.Connect(nodeMapping[4], nodeMapping[2], 5, "Bridge-Stairs");
        graph.Connect(nodeMapping[3], nodeMapping[4], 4, "ElevatorSpectrum-Bridge");
        graph.Connect(nodeMapping[4], nodeMapping[3], 4, "Bridge-ElevatorSpectrum");

        // Bridge to First floor Prisma
        graph.Connect(nodeMapping[4], nodeMapping[6], 4, "Bridge-FirstFloorPrisma");
        graph.Connect(nodeMapping[6], nodeMapping[4], 4, "FirstFloorPrisma-Bridge");
        
        // Bridge to Elevator Prisma
        graph.Connect(nodeMapping[4], nodeMapping[5], 4, "Bridge-ElevatorPrisma");
        graph.Connect(nodeMapping[5], nodeMapping[4], 4, "ElevatorPrisma-Bridge");

        // First floor Prisma to Second floor Prisma
        graph.Connect(nodeMapping[6], nodeMapping[7], 2, "FirstFloorPrisma-SecondFloorPrisma");
        graph.Connect(nodeMapping[7], nodeMapping[6], 2, "SecondFloorPrisma-FirstFloorPrisma");
        
        // Second floor Prisma to Third floor Prisma
        graph.Connect(nodeMapping[7], nodeMapping[8], 2, "SecondFloorPrisma-ThirdFloorPrisma");
        graph.Connect(nodeMapping[8], nodeMapping[7], 2, "ThirdFloorPrisma-SecondFloorPrisma");
        
        // Elevator Prisma to Third floor Prisma
        graph.Connect(nodeMapping[5], nodeMapping[8], 5, "ElevatorPrisma-ThirdFloorPrisma");
        graph.Connect(nodeMapping[8], nodeMapping[5], 5, "ThirdFloorPrisma-ElevatorPrisma");
        
        // Hart van ICT to Third floor Prisma
        graph.Connect(nodeMapping[9], nodeMapping[8], 2, "HartICTRechts-ThirdFloorPrisma");
        graph.Connect(nodeMapping[8], nodeMapping[9], 2, "ThirdFloorPrisma-HartICTRechts");
        graph.Connect(nodeMapping[10], nodeMapping[8], 2, "HartICTLinks-ThirdFloorPrisma");
        graph.Connect(nodeMapping[8], nodeMapping[10], 2, "ThirdFloorPrisma-HartICTLinks");
        
        // Hart van ICT to Room IT
        graph.Connect(nodeMapping[9], nodeMapping[11], 3, "HartICTRechts-RoomIT");
        graph.Connect(nodeMapping[11], nodeMapping[9], 3, "RoomIT-HartICTRechts");
        graph.Connect(nodeMapping[10], nodeMapping[11], 2, "HartICTLinks-RoomIT");
        graph.Connect(nodeMapping[11], nodeMapping[10], 2, "RoomIT-HartICTLinks");
        ShortestPathResult result = graph.Dijkstra(nodeMapping[startNodeId], nodeMapping[endNodeId]);
        return result.GetPath();
    }
}
