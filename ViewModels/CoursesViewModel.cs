using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.Models;

namespace WestCoastEducation_App.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly ICourseService? _courseService;
    private readonly MainWindowViewModel? _mainWindowViewModel;
    private string _courseId = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    public CoursesViewModel()
    {
        PageTitle = "Våra kurser";
    }
    public CoursesViewModel(ICourseService courseService, MainWindowViewModel mainWindowViewModel)
    {
        _courseService = courseService;
        _mainWindowViewModel = mainWindowViewModel;
        PageTitle = "Våra kurser";

        Init();
    }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            _courseId = id;
            _mainWindowViewModel!.IsBusy = true;
            ShowDialog = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    [RelayCommand]
    private async Task Confirm()
    {
        ShowDialog = false;
        try
        {
            CourseRestDb course = await _courseService!.Find(_courseId);
            await _courseService.Delete(course._id);
            await LoadCourses();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            _mainWindowViewModel!.IsBusy = false;
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        Console.WriteLine("Jasååå, du ångrar dig, fegis!");
        ShowDialog = false;
        _mainWindowViewModel!.IsBusy = false;
    }

    private async void Init()
    {
        await LoadCourses();
    }

    private async Task LoadCourses()
    {
        try
        {
            Courses = new ObservableCollection<Course>(await _courseService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
}
