using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducation_App.Models;

namespace WestCoastEducation_App.Interfaces;

public interface ICourseService
{
    Task Add(Course course);
    Task Delete(string id);
    Task<CourseRestDb> Find(string itemNumber);
    Task<List<Course>> List();
    Task Update(Course course, string _objectId);
}
