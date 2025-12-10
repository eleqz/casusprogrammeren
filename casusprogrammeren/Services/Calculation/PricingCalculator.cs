namespace casusprogrammeren.Services.Calculation;

public class PricingCalculator
{
    
    public static float CalculateSpectrumRoomPrice(int capacity)
    {
        float basePrice = capacity * 20;
        return basePrice;
    }

    public static float CalculatePrismaRoomPrice(int capacity)
    {
        float basePrice = capacity * 17.5F;
        return basePrice;
    }

    public static float CalculateSpectrumWorkspacePrice()
    {
        float basePrice = 120;
        return basePrice;
    }

    public static float CalculatePrismaWorkspacePrice()
    {
        float basePrice = 150;
        return basePrice;
    }

    public static float CalculatePublicSpacePrice()
    {
        float basePrice = 250;
        return basePrice;
    }
}