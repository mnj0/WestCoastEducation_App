using System;
using WestCoastEducation_App.Factories;
using WestCoastEducation_App.Interfaces;
//using WestCoastEducation_App.Services;
using WestCoastEducation_App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace WestCoastEducation_App.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
    }
}
