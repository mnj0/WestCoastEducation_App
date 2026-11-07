using System;

namespace WestCoastEducation_App.Models;

public record CourseRestDb : Course
{
    public string _id { get; set; } = string.Empty;
}
