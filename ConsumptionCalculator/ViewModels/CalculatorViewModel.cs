using ConsumptionCalculator.Models;
using ReactiveUI;
using System;
using System.Globalization;
using System.Reactive;

namespace ConsumptionCalculator.ViewModels;

public class CalculatorViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CostCommand { get; }

    public string LastReading { get; set; } = string.Empty;
    public string CurrentReading { get; set; } = string.Empty;

    public Bill Bill { get; set; } = new Bill();

    private string cost = string.Empty;

    public string Cost
    {
        get => cost;
        set => this.RaiseAndSetIfChanged(ref cost, value);
    }

    public CalculatorViewModel()
    {
        CostCommand = ReactiveCommand.Create(DisplayCost);
    }

    /// <summary>
    /// Convert input to double, call bill cost function and display its result in a currency format
    /// </summary>
    private void DisplayCost()
    {
        double lastMonth = 0, currentMonth = 0;

        try
        {
            if (LastReading != string.Empty)
                lastMonth = Convert.ToDouble(LastReading);

            if (CurrentReading != string.Empty)
                currentMonth = Convert.ToDouble(CurrentReading);

            Cost = Bill.Cost(lastMonth, currentMonth).ToString("C2", CultureInfo.CurrentCulture);
        }
        catch { return; }
    }
}
