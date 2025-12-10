using casusprogrammeren.Services.Calculation;

namespace casusprogrammeren.Services.Handlers;

public class ActionPricingHandler
{
    public static float HandleCosts(int capacity, int lokaalType)
    {
        int openingHours = 0; // If you need specific time of day for costs you should change it into a interaction
        switch (lokaalType)
        {
            case 0: // Spectrum Room
                return CostsCalculator.CalculateSpectrumRoomCosts(capacity, openingHours);
            case 1: // Prisma Room
                return CostsCalculator.CalculatePrismaRoomCosts(capacity, openingHours);
            case 2: // Spectrum Workspace
                return CostsCalculator.CalculateSpectrumWorkspaceCosts(openingHours);
            case 3: // Prisma Workspace
                return CostsCalculator.CalculatePrismaWorkspaceCosts(openingHours);
            case 4: // Public Space
                return CostsCalculator.CalculatePublicSpaceCosts(openingHours);
        }
        return 0;
    }
    
    public static float HandlePrices(int capacity, int lokaalType)
    {
        switch (lokaalType)
        {
            case 0: // Spectrum Room
                return PricingCalculator.CalculateSpectrumRoomPrice(capacity);
            case 1: // Prisma Room
                return PricingCalculator.CalculatePrismaRoomPrice(capacity);
            case 2: // Spectrum Workspace
                return PricingCalculator.CalculateSpectrumWorkspacePrice();
            case 3: // Prisma Workspace
                return PricingCalculator.CalculatePrismaWorkspacePrice();
            case 4: // Public Space
                return PricingCalculator.CalculatePublicSpacePrice();
        }
        return 0;
    }
}