using System;

namespace ConsumptionCalculator.Models
{
    public class Bill
    {
        public static double Cost(double consumption)
        {
            return consumption * 0.463 + consumption * 0.342 + 7.27;
        }
    }
}
