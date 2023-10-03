using System;

namespace ConsumptionCalculator.Models;

public class Bill
{
    public static double Cost(double consumption)
    {
        return (consumption * 0.805) + 7.27;
    }

    public static double Cost(double lastReading, double currentReading)
    {
        if (lastReading > currentReading)
            throw new ArgumentException("Current reading is greater than last reading");

        return Cost(currentReading - lastReading);
    }
}
