using System;
using WestCoastEducation_App.Factories;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation_App.Enums;
using WestCoastEducation_App.Services;

namespace WestCoastEducation_App.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddSingleton<ICourseService, CourseService>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CoursesViewModel>();
        collection.AddTransient<AddCourseViewModel>();
        collection.AddTransient<EditCourseViewModel>();
        
        collection.AddSingleton<Func<PageViewEnum, ViewModelBase>>(c => name => name switch
        {
            PageViewEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewEnum.Courses => c.GetRequiredService<CoursesViewModel>(),
            PageViewEnum.AddCourse => c.GetRequiredService<AddCourseViewModel>(),
            PageViewEnum.EditCourse => c.GetRequiredService<EditCourseViewModel>(),
            _ => throw new InvalidOperationException()
        });
    }
}
