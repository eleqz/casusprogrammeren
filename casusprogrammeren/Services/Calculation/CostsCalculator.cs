namespace casusprogrammeren.Services.Calculation;

public class CostsCalculator
{
    private static readonly float[] OpeningHoursExtraCharge = [ 5, 4, 3, 2 ];
    
    private static float CalculateExtraCharge(int openingHours )
    {
        if (openingHours < 1 || openingHours > 4)
        {
            return 0;
        }

        float total = 0;
        for (int i = 0; i < openingHours; i++)
        {
            total += OpeningHoursExtraCharge[i];
            Console.WriteLine(total);
        }

        return total;
    }
    
    public static float CalculateSpectrumRoomCosts(int capacity, int openingHours)
    {
        float baseCosts = capacity == 60 ? 500 : 300;
        float extraCharge = CalculateExtraCharge(openingHours);
    
        if (extraCharge == 0)
        {
            return baseCosts;
        }
    
        return baseCosts + extraCharge;
    }

    public static float CalculatePrismaRoomCosts(int capacity, int openingHours)
    {
        float baseCosts = capacity == 60 ? 475 : 275;
        float extraCharge = CalculateExtraCharge(openingHours);
    
        if (extraCharge == 0)
        {
            return baseCosts;
        }
    
        return baseCosts + extraCharge;
    }

    public static float CalculateSpectrumWorkspaceCosts(int openingHours)
    {
        float baseCosts = 100;
        float extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? baseCosts : baseCosts + extraCharge;
    }

    public static float CalculatePrismaWorkspaceCosts(int openingHours)
    {
        float baseCosts = 90;
        float extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? baseCosts : baseCosts + extraCharge;
    }

    public static float CalculatePublicSpaceCosts(int openingHours)
    {
        float baseCosts = 200;
        float extraCharge = CalculateExtraCharge(openingHours);
    
        return extraCharge == 0 ? baseCosts : baseCosts + extraCharge;
    }
}