using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.Models;

namespace WestCoastEducation_App.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
{
    private readonly ICourseService? _courseService;
    private readonly MainWindowViewModel? _mainWindowViewModel;
    private string _courseId = string.Empty;
    private string _objectId = string.Empty;

    [ObservableProperty]
    public partial string ListNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Titel { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string HowManyWeeks { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string StartDate { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string EndDate { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string TypeOfCourse { get; set; } = string.Empty;

    // Endast för design och preview hantering
    public EditCourseViewModel()
    {
        PageTitle = "Uppdatera Kurs";
    }

    public EditCourseViewModel(ICourseService courseService, MainWindowViewModel mainWindowViewModel)
    {
        _courseService = courseService;
        _mainWindowViewModel = mainWindowViewModel;
        PageTitle = "Uppdatera Kurs";
    }

    public async void Init(string courseId)
    {
        try
        {
            _courseId = courseId;
            var course = await _courseService!.Find(courseId);

            _objectId = course._id;
            ListNumber = course.ListNumber;
            Titel = course.Titel;
            HowManyWeeks = course.HowManyWeeks;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
            TypeOfCourse = course.TypeOfCourse;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        Course course = new()
        {
            Id = _courseId,
            ListNumber = ListNumber,
            Titel = Titel,
            HowManyWeeks = HowManyWeeks,
            StartDate = StartDate,
            EndDate = EndDate,
            TypeOfCourse = TypeOfCourse
        };

        await _courseService!.Update(course, _objectId);

        // Tillbaka till listan så man ser ändringen
        _mainWindowViewModel!.GoToCoursesCommand.Execute(null);
    }
}