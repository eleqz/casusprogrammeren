namespace casusprogrammeren.Services.Calculation;

public class CostsCalculator
{
    private static readonly int[] OpeningHoursExtraCharge = [ 5, 4, 3, 2 ];
    
    private static int CalculateExtraCharge(int openingHours )
    {
        if (openingHours < 1 || openingHours > 4)
        {
            return 0;
        }

        int total = 0;
        for (int i = 0; i < openingHours; i++)
        {
            total += OpeningHoursExtraCharge[i];
            Console.WriteLine(total);
        }

        return total;
    }
    
    public static int CalculateSpectrumRoomPrice(int capacity, int openingHours)
    {
        int basePrice = capacity == 60 ? 500 : 300;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        if (extraCharge == 0)
        {
            return basePrice;
        }
    
        return basePrice + extraCharge;
    }

    public static int CalculatePrismaRoomPrice(int capacity, int openingHours)
    {
        int basePrice = capacity == 60 ? 475 : 275;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        if (extraCharge == 0)
        {
            return basePrice;
        }
    
        return basePrice + extraCharge;
    }

    public static int CalculateSpectrumWorkspacePrice(int openingHours)
    {
        int basePrice = 100;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? basePrice : basePrice + extraCharge;
    }

    public static int CalculatePrismaWorkspacePrice(int openingHours)
    {
        int basePrice = 90;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? basePrice : basePrice + extraCharge;
    }

    public static int CalculatePublicSpacePrice(int openingHours)
    {
        int basePrice = 200;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? basePrice : basePrice + extraCharge;
    }
}