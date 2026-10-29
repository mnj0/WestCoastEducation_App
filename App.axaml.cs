using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using WestCoastEducation_App.Helpers;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.ViewModels;
using WestCoastEducation_App.Views;
using Microsoft.Extensions.DependencyInjection;

namespace WestCoastEducation_App;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Skapa en instans ServiceCollection...
        // En lista av beroende som applikation har eller kommer att ha...
        var collection = new ServiceCollection();
        collection.AddServices();

        // Bygga ihop services
        var serviceProvider = collection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                // Kopplar på vår ViewModel till vår View
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}