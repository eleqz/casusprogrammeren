namespace casusprogrammeren.Services.Calculation;

public class PricingCalculator
{
    
    public static int CalculateSpectrumRoomPrice(int capacity)
    {
        int basePrice = capacity * 20;
        return basePrice;
    }

    public static float CalculatePrismaRoomPrice(int capacity)
    {
        float basePrice = capacity * 17.50;
        return basePrice;
    }

    public static int CalculateSpectrumWorkspacePrice()
    {
        int basePrice = 120;
        return basePrice;
    }

    public static int CalculatePrismaWorkspacePrice()
    {
        int basePrice = 150;
        return basePrice;
    }

    public static int CalculatePublicSpacePrice()
    {
        int basePrice = 250;
        return basePrice;
    }
}