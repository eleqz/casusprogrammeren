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
    
    public static int CalculateSpectrumRoomCosts(int capacity, int openingHours)
    {
        int baseCosts = capacity == 60 ? 500 : 300;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        if (extraCharge == 0)
        {
            return baseCosts;
        }
    
        return baseCosts + extraCharge;
    }

    public static int CalculatePrismaRoomCosts(int capacity, int openingHours)
    {
        int baseCosts = capacity == 60 ? 475 : 275;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        if (extraCharge == 0)
        {
            return baseCosts;
        }
    
        return baseCosts + extraCharge;
    }

    public static int CalculateSpectrumWorkspaceCosts(int openingHours)
    {
        int baseCosts = 100;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? baseCosts : baseCosts + extraCharge;
    }

    public static int CalculatePrismaWorkspaceCosts(int openingHours)
    {
        int baseCosts = 90;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? baseCosts : baseCosts + extraCharge;
    }

    public static int CalculatePublicSpaceCosts(int openingHours)
    {
        int baseCosts = 200;
        int extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? baseCosts : baseCosts + extraCharge;
    }
}