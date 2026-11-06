using System;
using WestCoastEducation_App.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestCoastEducation_App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory? _pageViewFactory;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    [ObservableProperty]
    public partial bool IsBusy { get; set; }

    public MainWindowViewModel() { }

    public MainWindowViewModel(PageViewFactory pageViewFactory)
    {
        _pageViewFactory = pageViewFactory;
        GoToHome();
    }

    [RelayCommand]
    private void GoToHome() => CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewEnum.Home);
    [RelayCommand]
    private void GoToCourses() => CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewEnum.Courses);
}
