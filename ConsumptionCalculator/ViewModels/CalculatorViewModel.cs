using ConsumptionCalculator.Models;
using ReactiveUI;
using System;
using System.Reactive;

namespace ConsumptionCalculator.ViewModels;

public class CalculatorViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CostCommand { get; }

    public string LastReading { get; set; } = string.Empty;
    public string CurrentReading { get; set; } = string.Empty;

    public Bill Bill { get; set; } = new Bill();

    private double cost;

    public double Cost
    {
        get => cost;
        set => this.RaiseAndSetIfChanged(ref cost, value);
    }

    public CalculatorViewModel()
    {
        CostCommand = ReactiveCommand.Create(DisplayCost);
    }

    private void DisplayCost()
    {
        double lastMonth = 0, currentMonth = 0;

        try
        {
            if (LastReading != string.Empty)
                lastMonth = Convert.ToDouble(LastReading);

            if (CurrentReading != string.Empty)
                currentMonth = Convert.ToDouble(CurrentReading);

            Cost = Bill.Cost(lastMonth, currentMonth);
        }
        catch { return; }
    }
}
