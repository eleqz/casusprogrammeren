using Xunit;
using casusprogrammeren.Services.Calculation;
using casusprogrammeren.Services.Handlers;
using casusprogrammeren.utils;

namespace UnitTest;

public class OxygenCalculatorTests
{
    [Fact]
    public void CalculateOxygenUsedTwoHours_Returns810Liters()
    {
        // 30 liters/person/hour * 27 people = 810 liters
        var result = OxygenCalculator.CalculateOxygenUsedTwoHours();
        Assert.Equal(810, result);
    }

    [Fact]
    public void CalculateOxygenNotUsedTwoHours_ReturnsCorrectValue()
    {
        int volumeM3 = 100;
        // 100 m3 * 210 = 21000 liters total
        // 21000 - 810 = 20190 liters remaining
        var result = OxygenCalculator.CalculateOxygenNotUsedTwoHours(volumeM3);
        Assert.Equal(20190, result);
    }

    [Fact]
    public void CalculateMaximumOxygenConsumption_ReturnsCorrectValue()
    {
        int volumeM3 = 100;
        // (100 * 210) / (30 * 27) = 25.92 hours ~ 25 hours
        var result = OxygenCalculator.CalculateMaximumOxygenConsumption(volumeM3);
        Assert.Equal(25, result);
    }
}

public class PricingCalculatorTests
{
    [Fact]
    public void CalculateSpectrumRoomPrice_Capacity27_Returns540()
    {
        // 27 * 20 = 540
        var result = PricingCalculator.CalculateSpectrumRoomPrice(27);
        Assert.Equal(540, result);
    }

    [Fact]
    public void CalculateSpectrumRoomPrice_Capacity60_Returns1200()
    {
        // 60 * 20 = 1200
        var result = PricingCalculator.CalculateSpectrumRoomPrice(60);
        Assert.Equal(1200, result);
    }

    [Fact]
    public void CalculatePrismaRoomPrice_Capacity27_Returns472Point5()
    {
        // 27 * 17.5 = 472.5
        var result = PricingCalculator.CalculatePrismaRoomPrice(27);
        Assert.Equal(472.5F, result);
    }

    [Fact]
    public void CalculateSpectrumWorkspacePrice_Returns120()
    {
        // 120
        var result = PricingCalculator.CalculateSpectrumWorkspacePrice();
        Assert.Equal(120, result);
    }

    [Fact]
    public void CalculatePrismaWorkspacePrice_Returns150()
    {
        // 150
        var result = PricingCalculator.CalculatePrismaWorkspacePrice();
        Assert.Equal(150, result);
    }

    [Fact]
    public void CalculatePublicSpacePrice_Returns250()
    {
        // 250
        var result = PricingCalculator.CalculatePublicSpacePrice();
        Assert.Equal(250, result);
    }
}

public class CostsCalculatorTests
{
    [Fact]
    public void CalculateSpectrumRoomCosts_Capacity27_NoExtraHours_Returns300()
    {
        // 300
        var result = CostsCalculator.CalculateSpectrumRoomCosts(27, 0);
        Assert.Equal(300, result);
    }
    
    [Fact]
    public void CalculateSpectrumRoomCosts_WithExtraHours_AlsoReturnsExtraCharge()
    {
        // 300 + extra charge for 2 hours (5 + 4 = 9)
        var result = CostsCalculator.CalculateSpectrumRoomCosts(27, 2);
        Assert.Equal(309, result);
    }

    [Fact]
    public void CalculatePrismaRoomCosts_Capacity27_NoExtraHours_Returns275()
    {
        // 275
        var result = CostsCalculator.CalculatePrismaRoomCosts(27, 0);
        Assert.Equal(275, result);
    }

    [Fact]
    public void CalculateSpectrumWorkspaceCosts_NoExtraHours_Returns100()
    {
        // 100
        var result = CostsCalculator.CalculateSpectrumWorkspaceCosts(0);
        Assert.Equal(100, result);
    }

    [Fact]
    public void CalculatePrismaWorkspaceCosts_NoExtraHours_Returns90()
    {
        // 90
        var result = CostsCalculator.CalculatePrismaWorkspaceCosts(0);
        Assert.Equal(90, result);
    }

    [Fact]
    public void CalculatePublicSpaceCosts_NoExtraHours_Returns200()
    {
        // 200
        var result = CostsCalculator.CalculatePublicSpaceCosts(0);
        Assert.Equal(200, result);
    }
}

public class ActionPricingHandlerTests
{
    [Theory]
    [InlineData(27, 0, 300)] // Spectrum Room capacity 27
    [InlineData(60, 0, 500)] // Spectrum Room capacity 60
    [InlineData(27, 1, 275)] // Prisma Room capacity 27
    public void HandleCosts_ReturnsCorrectCosts(int capacity, int roomType, float expected)
    {
        var result = ActionPricingHandler.HandleCosts(capacity, roomType);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(27, 0, 540)]  // Spectrum Room
    [InlineData(27, 1, 472.5F)] // Prisma Room
    [InlineData(0, 2, 120)]   // Spectrum Workspace
    [InlineData(0, 3, 150)]   // Prisma Workspace
    [InlineData(0, 4, 250)]   // Public Space
    public void HandlePrices_ReturnsCorrectPrices(int capacity, int roomType, float expected)
    {
        var result = ActionPricingHandler.HandlePrices(capacity, roomType);
        Assert.Equal(expected, result);
    }
}

public class JsonUtilTest
{
    private readonly string _basePath;

    public JsonUtilTest()
    {
        // Navigate to casusprogrammeren project directory, otherwise it takes the UnitTest root dir
        _basePath = Path.Combine(
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName,
            "casusprogrammeren"
        );
    }

    [Fact]
    public void HandleJsonDeserialize_ReturnsOccupanceObject()
    {
        var occupancePath = Path.Combine(_basePath, "Occupance.json");
        Assert.True(File.Exists(occupancePath), $"File not found: {occupancePath}");

        var jsonString = File.ReadAllText(occupancePath);
        var occupance = System.Text.Json.JsonSerializer.Deserialize<List<Occupance>>(jsonString);

        Assert.NotNull(occupance);
        Assert.NotEmpty(occupance);
        Assert.All(occupance, o => Assert.NotNull(o.Month));
    }

    [Fact]
    public void HandleJsonDeserialize_ReturnsRoomsObject()
    {
        var roomsPath = Path.Combine(_basePath, "Rooms.json");
        Assert.True(File.Exists(roomsPath), $"File not found: {roomsPath}");

        var jsonString = File.ReadAllText(roomsPath);
        var rooms = System.Text.Json.JsonSerializer.Deserialize<List<Rooms>>(jsonString);

        Assert.NotNull(rooms);
        Assert.NotEmpty(rooms);
        Assert.All(rooms, r => Assert.NotNull(r.Code));
    }
}

