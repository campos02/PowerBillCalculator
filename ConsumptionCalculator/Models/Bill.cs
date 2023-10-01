namespace ConsumptionCalculator.Models;

public class Bill
{
    public static double Cost(double consumption)
    {
        return (consumption * 0.805) + 7.27;
    }
}
