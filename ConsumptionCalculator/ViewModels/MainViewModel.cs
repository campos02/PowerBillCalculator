using DynamicData;
using ReactiveUI;
using System.Reactive;

namespace ConsumptionCalculator.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> BackCommand { get; }
    public ReactiveCommand<Unit, Unit> SettingsCommand { get; }

    private ViewModelBase currentPage;
    private bool canGoBack;

    public ViewModelBase CurrentPage
    {
        get => currentPage;
        private set => this.RaiseAndSetIfChanged(ref currentPage, value);
    }

    public bool CanGoBack
    {
        get => canGoBack;
        private set => this.RaiseAndSetIfChanged(ref canGoBack, value);
    }

    private readonly ViewModelBase[] Pages =
    {
        new CalculatorViewModel(),
        new SettingsViewModel()
    };

    public MainViewModel()
    {
        currentPage = Pages[0];

        BackCommand = ReactiveCommand.Create(GoBack);
        SettingsCommand = ReactiveCommand.Create(GoToSettings);
    }

    private void GoToSettings()
    {
        CurrentPage = Pages[1];
        CanGoBack = true;
    }

    private void GoBack()
    {
        int index = Pages.IndexOf(CurrentPage);

        if (index <= 0)
            return;

        index -= 1;
        CurrentPage = Pages[index];
        
        if (index == 0)
            CanGoBack = false;
    }
}
