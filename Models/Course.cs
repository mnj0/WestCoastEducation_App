using System;
using WestCoastEducation_App.Services;
using WestCoastEducation_App.Interfaces;
using System.Text.Json;
using Tmds.DBus.Protocol;
using System.IO;

namespace WestCoastEducation_App.Models;

public record class Course
{
    public string Id {get; set; } = Guid.NewGuid().ToString();
    public required string Titel {get; set;}

    //Antal veckor i längd
    public required string HowManyWeeks {get; set;}
    public required string StartDate {get; set;}
    public required string EndDate {get; set;}

    //om det är distans, hybrid eller på plats. Komm ej på ett bra namn
    public required string TypeOfCourse {get; set;}
    
    public virtual void CourseAdd(Course course, string jsonfile)
{
    var path = Path.Combine(Environment.CurrentDirectory, "Data", jsonfile);
    IStorage<Course> storage = new Storage<Course>();

    var courses = storage.Read(path);
    courses.Add(course);
    storage.Write(path, courses);
}
}
