using System;
using WestCoastEducation_App.Factories;
using WestCoastEducation_App.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestCoastEducation_App.ViewModels;

public partial class MainViewsModels : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}
