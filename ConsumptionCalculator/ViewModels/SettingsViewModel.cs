using ConsumptionCalculator.Models;
using ReactiveUI;
using System;
using System.Globalization;
using System.Reactive;
using System.Threading.Tasks;

namespace ConsumptionCalculator.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }

    public SettingsManager SettingsManager { get; set; } = new SettingsManager();

    public string EnergyCost { get; set; } = string.Empty;
    public string Taxes { get; set; } = string.Empty;

    // Get current culture currency symbol
    public string Currency => NumberFormatInfo.CurrentInfo.CurrencySymbol;

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

        // Display with two decimal places
        Taxes = SettingsManager.Settings.Taxes.ToString("F2");
    }

    /// <summary>
    /// Convert the input values, assign them and call save to settings file function
    /// If successful, display success message for 1.5 seconds
    /// </summary>
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

        SuccessText = "Saved successfully!";
        await Task.Delay(1500);
        SuccessText = string.Empty;
    }
}
