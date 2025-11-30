namespace casusprogrammeren.Services.Calculation;

public class OxygenCalculator
{
    public static int CalculateOxygenUsedTwoHours()
    {
        int oxygenConsumptionPerPersonPerHour = 30;
        int hoursOfOxygenForTwentysevenPeople = oxygenConsumptionPerPersonPerHour * 27;
        
        return hoursOfOxygenForTwentysevenPeople;
    }
    
    public static int CalculateOxygenNotUsedTwoHours(int volumeM3)
    {
        int oxygenAmountInARoom = volumeM3 * 210;
        
        int oxygenUsedTwoHours = CalculateOxygenUsedTwoHours();
        
        int oxygenNotUsedTwoHours = oxygenAmountInARoom - oxygenUsedTwoHours;
        
        return oxygenNotUsedTwoHours;
    }
    
    public static int CalculateMaximumOxygenConsumption(int volumeM3)
    {
        int oxygenAmountInARoom = volumeM3 * 210;
        int oxygenConsumptionPerPersonPerHour = 30;
        int hoursOfOxygenForTwentysevenPeople = oxygenAmountInARoom / (oxygenConsumptionPerPersonPerHour * 27); 
        
        return hoursOfOxygenForTwentysevenPeople;
    }
}