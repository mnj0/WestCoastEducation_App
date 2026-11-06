using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducation_App.Models;

namespace WestCoastEducation_App.Interfaces;

public interface ICourseService
{
    Task<List<Course>> List();
}
