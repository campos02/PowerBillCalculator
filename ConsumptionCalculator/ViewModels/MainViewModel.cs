using ReactiveUI;
using System;
using System.Reactive;
using ConsumptionCalculator.Models;

namespace ConsumptionCalculator.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CostCommand { get; }

    public string Consumption { get; set; } = string.Empty;
    public double Cost
    {
        get => cost;
        set => this.RaiseAndSetIfChanged(ref cost, value);
    }

    private double consumption;
    private double cost;

    public MainViewModel() 
    {
        CostCommand = ReactiveCommand.Create(DisplayCost);
    }

    private void DisplayCost()
    {
        if (Consumption == string.Empty)
            consumption = 0;
        else
        {
            try
            {
                consumption = Convert.ToDouble(Consumption);
            }
            catch { return; }
        }

        Cost = Bill.Cost(consumption);
    }
}
