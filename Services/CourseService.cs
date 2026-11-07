using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.Models;

namespace WestCoastEducation_App.Services;

public class CourseService : ICourseService
{
    public async Task Add(Course course)
    {
        var httpService = new HttpService<Course>();
        await httpService.Post("courses", course);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Course>();
        await httpService.Delete("courses", id);
    }
    public async Task<CourseRestDb> Find(string itemNumber)
    {
        var httpService = new HttpService<CourseRestDb>();
        var searchCriteria = "{\"itemNumber\":" + "\"" + itemNumber + "\"}";
        return await httpService.Get("courses", searchCriteria);
    }
    public async Task<List<Course>> List()
    {
        var httpService = new HttpService<Course>();
        var courses = await httpService.Get("courses");
        return courses;
    }

    public async Task Update(Course course, string _objectId)
    {
        var httpService = new HttpService<Course>();
        await httpService.Put("courses", course, _objectId);
    }
}
