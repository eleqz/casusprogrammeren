namespace casusprogrammeren.Services.Calculation;

public class PricesCalculator
{
    
    public static float CalculateSpectrumRoomPrice(int capacity)
    {
        return capacity * 20;
    }

    public static float CalculatePrismaRoomPrice(int capacity)
    {
        return capacity * 17.5F;
    }

    public static float CalculateSpectrumWorkspacePrice()
    {
        return 120;
    }

    public static float CalculatePrismaWorkspacePrice()
    {
        return 150;
    }

    public static float CalculatePublicSpacePrice()
    {
        return 250;
    }
}