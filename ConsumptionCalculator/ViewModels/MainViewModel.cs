using ReactiveUI;
using System;
using System.Reactive;

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

    private double consumption = 0;
    private double cost = 0;

    public MainViewModel() 
    {
        CostCommand = ReactiveCommand.Create(DisplayCost);
    }

    private void DisplayCost()
    {
        if (Consumption is "") { return; }
        consumption = Convert.ToDouble(Consumption);
        Cost = consumption * 0.463 + consumption * 0.342 + 7.27;
    }
}
