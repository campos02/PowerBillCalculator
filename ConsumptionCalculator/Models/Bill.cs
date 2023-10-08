using System;

namespace ConsumptionCalculator.Models;

public class Bill
{
    public SettingsManager SettingsManager { get; private set; } = new SettingsManager();

    public double Cost(double consumption)
    {
        return (consumption * SettingsManager.Settings.EnergyCost) + SettingsManager.Settings.Taxes;
    }

    public double Cost(double lastReading, double currentReading)
    {
        if (lastReading > currentReading)
            throw new ArgumentException("Current reading is greater than last reading");

        return Cost(currentReading - lastReading);
    }
}
