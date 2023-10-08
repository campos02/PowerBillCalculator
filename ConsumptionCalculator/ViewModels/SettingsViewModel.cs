using ConsumptionCalculator.Models;
using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace ConsumptionCalculator.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }

    public SettingsManager SettingsManager { get; set; } = new SettingsManager();

    public string EnergyCost { get; set; } = string.Empty;
    public string Taxes { get; set; } = string.Empty;

    private string successText = string.Empty;

    public string SuccessText
    {
        get => successText;
        set => this.RaiseAndSetIfChanged(ref successText, value);
    }

    public SettingsViewModel()
    {
        SaveCommand = ReactiveCommand.CreateFromTask(Save);

        EnergyCost = SettingsManager.Settings.EnergyCost.ToString();
        Taxes = SettingsManager.Settings.Taxes.ToString("F2");
    }

    private async Task Save()
    {
        try
        {
            if (EnergyCost != string.Empty)
                SettingsManager.Settings.EnergyCost = Convert.ToDouble(EnergyCost);

            if (Taxes != string.Empty)
                SettingsManager.Settings.Taxes = Convert.ToDouble(Taxes);

            SettingsManager.SaveToFile();
        }
        catch (Exception) { return; }

        SuccessText = "Saved Successfully!";
        await Task.Delay(1500);
        SuccessText = "";
    }
}
