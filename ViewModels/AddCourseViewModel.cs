using System;
using System.Threading.Tasks;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.Models;
using WestCoastEducation_App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducation_App.ViewModels;

namespace WestCoastEducation_App.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;
    [ObservableProperty]
    public partial string ListNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Titel { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string HowManyWeeks { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string StartDate { get; set; }
    [ObservableProperty]
    public partial string EndDate { get; set; }
    [ObservableProperty]
    public partial string TypeOfCourse { get; set; }


    // Endast för design och preview hantering
    /* Ta bort när allt fungerar!!! */
    // TODO: Ta bort när allt fungerar...
    public AddCourseViewModel()
    {
        _courseService = new CourseService();
        PageTitle = "Ny Kurs";
    }
    /*********************************************/

    public AddCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Ny Kurs";
    }

    [RelayCommand]
    private async Task Save()
    {
        // Behöver eventuellt göra validering här...
        Course course = new()
        {
            ListNumber = ListNumber,
            Titel = Titel,
            HowManyWeeks = HowManyWeeks,
            StartDate = StartDate,
            EndDate = EndDate,
            TypeOfCourse = TypeOfCourse
        };

        await _courseService.Add(course);

        ClearData();
    }

    private void ClearData()
    {

        ListNumber = string.Empty;
        Titel = string.Empty;
        HowManyWeeks = string.Empty;
        StartDate = string.Empty;
        EndDate = string.Empty;
        TypeOfCourse = string.Empty;

        /*ItemNumber = string.Empty;
        ProductName = string.Empty;
        Supplier = string.Empty;
        Price = 0;*/
    }
}
