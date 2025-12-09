using casusprogrammeren.Services.Calculation;

namespace casusprogrammeren.Services.Handlers;

public class ActionPricingHandler
{
    public static int HandleCosts(int capacity, int lokaalType)
    {
        int openingHours = 0; // If you need specific time of day for costs you should change it into a interaction
        switch (lokaalType)
        {
            case 0: // Spectrum Room
                return CostsCalculator.CalculateSpectrumRoomPrice(capacity, openingHours);
            case 1: // Prisma Room
                return CostsCalculator.CalculatePrismaRoomPrice(capacity, openingHours);
            case 2: // Spectrum Workspace
                return CostsCalculator.CalculateSpectrumWorkspacePrice(openingHours);
            case 3: // Prisma Workspace
                return CostsCalculator.CalculatePrismaWorkspacePrice(openingHours);
            case 4: // Public Space
                return CostsCalculator.CalculatePublicSpacePrice(openingHours);
        }
        return 0;
    }
    
    public static int HandlePrices(int capacity, int lokaalType)
    {
        int openingHours = 0; // If you need specific time of day for prices you should change it into a interaction
        switch (lokaalType)
        {
            case 0: // Spectrum Room
                return CostsCalculator.CalculateSpectrumRoomPrice(capacity, openingHours);
            case 1: // Prisma Room
                return CostsCalculator.CalculatePrismaRoomPrice(capacity, openingHours);
            case 2: // Spectrum Workspace
                return CostsCalculator.CalculateSpectrumWorkspacePrice(openingHours);
            case 3: // Prisma Workspace
                return CostsCalculator.CalculatePrismaWorkspacePrice(openingHours);
            case 4: // Public Space
                return CostsCalculator.CalculatePublicSpacePrice(openingHours);
        }
        return 0;
    }
}