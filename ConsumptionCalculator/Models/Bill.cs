using System;

namespace ConsumptionCalculator.Models;

public class Bill
{
    public SettingsManager SettingsManager { get; private set; } = new SettingsManager();

    /// <summary>
    /// Calculate power bill cost using settings values and return it
    /// </summary>
    /// <param name="consumption">kWh value</param>
    /// <returns>Bill cost</returns>
    public double Cost(double consumption)
    {
        return (consumption * SettingsManager.Settings.EnergyCost) + SettingsManager.Settings.Taxes;
    }

    /// <summary>
    /// Overload that takes two power readings and subtracts them when calling Cost function
    /// </summary>
    /// <param name="lastReading">Last kWh reading</param>
    /// <param name="currentReading">Current kWh reading</param>
    /// <returns>Bill cost from first overload</returns>
    /// <exception cref="ArgumentException">Throw if paramaters would result in a negative cost</exception>
    public double Cost(double lastReading, double currentReading)
    {
        if (lastReading > currentReading)
            throw new ArgumentException("Current reading is greater than last reading");

        return Cost(currentReading - lastReading);
    }
}
